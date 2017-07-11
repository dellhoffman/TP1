using Estacionamento.Negocio;
using System;
using System.Windows.Forms;

namespace Estacionamento.Apresentacao
{
    public partial class EstacionamentoForm : Form
    {
        private ICommand CheckIn = new CheckIn();
        private ICommand CheckOut = new CheckOut();

        public EstacionamentoForm()
        {
            InitializeComponent();
        }

        private void BtnCheckin_Click(object sender, EventArgs e)
        {
            string placa = (txtPlaca.Text.ToUpper().Trim());

            try
            {
                CheckIn.Run(placa);

                MessageBox.Show(String.Format("Placa '{0}' adicionada.", placa));
                txtPlaca.Text = string.Empty;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            string placa = txtPlaca.Text.ToUpper().Trim();

            try
            {
                var valor = CheckOut.Run(placa);

                MessageBox.Show(String.Format("Placa '{0}' valor de R${1}.", placa, valor));
                txtPlaca.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}