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
        /// Al cargar la calculadora quita el boton minimizar y maximizar 
        /// aplica el metodo limpiar para setear todos los datos en ""
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            this.Limpiar();
        }
        /// <summary>
        /// pasa el numero del lblResultado a binario de decimal 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            if (!string.IsNullOrEmpty(lblResultado.Text))
            {
                this.lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
            }
        }
        /// <summary>
        /// pasa el numero del lblResultado a decimal de binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            if (!string.IsNullOrEmpty(lblResultado.Text))
            {
                this.lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
            }

        }
        /// <summary>
        /// llama el metodo operar y le pasa los parametros introducidos por pantalla
        /// agrega la operacion a la list box de operaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double total;
            StringBuilder sb = new StringBuilder();
            total = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            lblResultado.Text = total.ToString();
            sb.Append(txtNumero1.Text);
            sb.Append(cmbOperador.Text);
            sb.Append(txtNumero2.Text);
            sb.Append($" = {total.ToString()}");
            lstOperaciones.Items.Add(sb);
        }
        /// <summary>
        /// aplica el metodo limpiar para setear todos los datos en ""
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// muestra un mensaje para preguntar si se quiere cerrar el formulario
        /// con la opcion Yes se cierra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cerrar?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        /// <summary>
        /// resetea todos los datos en ""
        /// </summary>
        private void Limpiar()
        {
            this.lblResultado.Text = "";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.SelectedIndex = -1;
        }
        /// <summary>
        /// pasa los parametros numero1 y numero2 a tipo Numero y opera segun el operador pasado por parametro
        /// </summary>
        /// <param name="numero1">tipo string</param>
        /// <param name="numero2">tipo string</param>
        /// <param name="operador">tipo string</param>
        /// <returns>resultado de la operacion</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double retorno;
            char op;
            char.TryParse(operador, out op);
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            retorno = Calculadora.Operar(num1, num2, op);
            return retorno;
        }

       
    }
}
