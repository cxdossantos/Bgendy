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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BgendyView
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnBusca_Click(object sender, RoutedEventArgs e)
        {
            ClienteController clienteController = new ClienteController();

            int idBusca = Convert.ToInt32(txtId.Text);

            Cliente cliente = clienteController.BuscarPorID(idBusca);

            if(cliente != null) {
            MessageBox.Show("Nome cliente: " + cliente.Nome);
            }
            else{ MessageBox.Show("Cliente não encontrado"); }

        }

/*        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            ClienteController clienteController = new ClienteController();
            int idBusca = Convert.ToInt32(txtId.Text);

            clienteController.Excluir(idBusca);
            MessageBox.Show("Cliente Excluido com Sucesso!");

            PopulaListaClientes();
            // listViewClientes.Items.Clear();
        }*/

        private void GerenciarCadastros(object sender, RoutedEventArgs e)
        {
            GerenciarCadastros cadastros = new GerenciarCadastros();
            cadastros.txtNome.IsEnabled = false;
            cadastros.txtCpf.IsEnabled = false;
            cadastros.txtDtNasc.IsEnabled = false;
            cadastros.txtFone.IsEnabled = false;
            cadastros.ShowDialog();

        }

        private void GerenciarServicos(object sender, RoutedEventArgs e)
        {
            GerenciarServicos servicos = new GerenciarServicos();
            servicos.ShowDialog();
        }
    }
}
