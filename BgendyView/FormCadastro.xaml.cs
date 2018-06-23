using BgendyController;
using BgendyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BgendyView
{
    /// <summary>
    /// Lógica interna para Window1.xaml
    /// </summary>
    public partial class Cadastro : Window
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            ClienteController clientesController = new ClienteController();

            if (string.IsNullOrEmpty(txtNome.Text))
                throw new NullReferenceException("O campo nome é obrigatório.");

            Cliente cliente = new Cliente();

            cliente.Nome = txtNome.Text;
            cliente.Cpf = txtCpf.Text;
            cliente.DtNasc = txtDtNasc.Text;
            cliente.Fone = txtFone.Text;


            clientesController.Adicionar(cliente);

            MessageBox.Show("Cliente " + cliente.Nome + "  Cód.:  " + cliente.Id + " registrado!");
        }
    }
}
