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

       

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cerrar?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            if (!string.IsNullOrEmpty(lblResultado.Text))
            {
                this.lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
            }
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            if (!string.IsNullOrEmpty(lblResultado.Text))
            {
               this.lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
            }

        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            this.Limpiar();
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void Limpiar()
        {
            this.lblResultado.Text = "";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.SelectedIndex = -1;
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double retorno;
            char op;
            char.TryParse(operador, out op);
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            retorno=Calculadora.Operar(num1, num2, op);
            return retorno;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double total;
            total = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            lblResultado.Text = total.ToString();
        }
    }
}
