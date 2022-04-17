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
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
            cmbOperador.Items.Add("");
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("/");
            cmbOperador.Items.Add("*");
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.SelectedIndex = -1;
            lblResultado.Text = "0";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
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

            
            
            resultado = Operar(numero1, numero2, operador);
            lblResultado.Text = resultado.ToString();
            if(operador == "")
            {
                operador = "+";
            }
            lstOperaciones.Items.Add($"{numero1} {operador} {numero2} = {resultado}");
            



        }
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
    }
}
