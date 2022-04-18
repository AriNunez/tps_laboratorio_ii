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

        /// <summary>
        /// En la carga del formulario, se limpian los datos de los TextBox, ComboBox y Label. Tambien
        /// se realiza la carga de operadores posibles para operar.
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
        /// Al hacer click sobre el boton Limpiar, se limpian los datos de los TextBox, ComboBox y Label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Limpia los datos de los TextBox, ComboBox y Label.
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            cmbOperador.SelectedIndex = -1;
            lblResultado.Text = string.Empty;
        }

        /// <summary>
        /// Al hacer click sobre el boton Cerrar, intenta cerrar el formulario. Si contesta SI se cerrará, si contesta NO continua en ejecución.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Intenta cerrar el formulario. Si contesta SI se cerrará, si contesta NO continua en ejecución.
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
        /// Al hacer click sobre el boton Operar, realiza de ser posible una operacion entre dos numero.
        /// El resultado de la operacion se muestra por medio de un Label y se carga en una lista.
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
        /// Recibe dos valores y un operador en formato string para operar entre ellos.
        /// </summary>
        /// <param name="numero1">Primer valor de formato string para operar</param>
        /// <param name="numero2">Segundo valor de formato string para operar</param>
        /// <param name="operador">Operador en formato string para operar</param>
        /// <returns>Retorna el resultado de la operacion entre los valores recibidos en formato double</returns>
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
        /// Al hacer click sobre el boton Convertir a Binario, intenta convertir el resultado de una operacion
        /// previamente realizada de un formato decimal a binario.
        /// El resultado de la operacion se muestra por medio de un Label y se carga en una lista.
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
        /// Al hacer click sobre el boton Convertir a Decimal, intenta convertir el resultado de una operacion
        /// previamente realizada de un formato binario a decimal.
        /// El resultado de la operacion se muestra por medio de un Label y se carga en una lista.
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
