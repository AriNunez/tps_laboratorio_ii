using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
            cmbOperador.Items.Add("");
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("/");
            cmbOperador.Items.Add("*");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            cmbOperador.SelectedIndex = -1;
            lblResultado.Text = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult opcion = MessageBox.Show("¿Seguro que queres salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcion == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">sender representa algo</param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = txtNumero1.Text.Trim();
            string numero2 = txtNumero2.Text.Trim();
            string operador = cmbOperador.Text;
            double resultado;
            
            if(!string.IsNullOrWhiteSpace(numero1) && !string.IsNullOrWhiteSpace(numero2))
            {
                resultado = Operar(numero1, numero2, operador);
                lblResultado.Text = resultado.ToString();
                if (operador == "")
                {
                    operador = "+";
                }
                lstOperaciones.Items.Add($"{numero1} {operador} {numero2} = {resultado}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando primerNumero = new Operando(numero1);
            Operando segundoNumero = new Operando(numero2);
            char operAux;
            if(operador == "")
            {
                operAux = ' ';
            }
            else
            {
                operAux = Convert.ToChar(operador);
            }

            return Calculadora.Operar(primerNumero,segundoNumero,operAux);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando numero = new Operando();
            string resultado = lblResultado.Text;
            string numeroConvertido;

            if(!String.IsNullOrWhiteSpace(resultado))
            {
                numeroConvertido = numero.DecimalBinario(resultado);
                lblResultado.Text = numeroConvertido;
                lstOperaciones.Items.Add($"{resultado} = {numeroConvertido}");
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando numero = new Operando();
            string resultado = lblResultado.Text;
            string numeroConvertido;

            if(!String.IsNullOrWhiteSpace(resultado))
            {
                numeroConvertido = numero.BinarioDecimal(resultado);
                lblResultado.Text = numeroConvertido;
                lstOperaciones.Items.Add($"{resultado} = {numeroConvertido}");
            }

        }
    }
}
