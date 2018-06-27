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
    /// Lógica interna para GerenciarCadastros.xaml
    /// </summary>
    public partial class GerenciarCadastros : Window
    {
        public GerenciarCadastros()
        {
            InitializeComponent();
        }

        private void ListViewClientes_Loaded(object sender, RoutedEventArgs e)
        {
            var gridView = new GridView();
            listViewClientes.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Id",
                DisplayMemberBinding = new Binding("Id")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Nome",
                DisplayMemberBinding = new Binding("Nome")
            });

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Cpf",
                DisplayMemberBinding = new Binding("Cpf")
            });
            var binding = new Binding("DtNasc");
            binding.StringFormat = "dd/MM/yyyy";

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "DtNasc",
                DisplayMemberBinding = binding,
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Fone",
                DisplayMemberBinding = new Binding("Fone")
            });
            
            PopulaListaClientes();
            //listViewClientes.Items.Add(clientes);
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            ClienteController clientesController = new ClienteController();

            if (string.IsNullOrEmpty(txtNome.Text))
                throw new NullReferenceException("O campo nome é obrigatório.");

            Cliente cliente = new Cliente();

            cliente.Nome = txtNome.Text;
            cliente.Cpf = Convert.ToInt32(txtCpf.Text);
            cliente.DtNasc = Convert.ToDateTime(txtDtNasc.Text);
            cliente.Fone = Convert.ToInt32(txtFone.Text);

            clientesController.Adicionar(cliente);
            MessageBox.Show("Cliente " + cliente.Nome + "  Cód.:  " + cliente.Id + " registrado!");
            PopulaListaClientes();
        }

        private void PopulaListaClientes()
        {
            listViewClientes.Items.Clear();
            ClienteController clienteController = new ClienteController();
            IList<Cliente> clientes = clienteController.ListarTodos();

            foreach (Cliente c in clientes)
            {
                listViewClientes.Items.Add(c);
            }
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            listViewClientes.Items.Clear();
            string nomeBusca = txtBusca.Text;
            ClienteController clienteController = new ClienteController();
            IList<Cliente> clientes = clienteController.ListarPorNome(nomeBusca);

            foreach (Cliente c in clientes)
            {
                listViewClientes.Items.Add(c);
            }
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            txtNome.IsEnabled = true;
            txtCpf.IsEnabled = true;
            txtDtNasc.IsEnabled = true;
            txtFone.IsEnabled = true;

            Cliente cliente = (Cliente)listViewClientes.SelectedItem;

            txtNome.Text = cliente.Nome;
            txtCpf.Text = Convert.ToString(cliente.Cpf);
            txtDtNasc.Text = Convert.ToString(cliente.DtNasc);
            txtFone.Text = Convert.ToString(cliente.Fone);
        }

        private void btnAlterando_Click(object sender, RoutedEventArgs e)
        {
            ClienteController clienteController = new ClienteController();
            Cliente cliente = (Cliente)listViewClientes.SelectedItem;

            cliente.Nome = txtNome.Text;
            cliente.Cpf = Convert.ToInt32(txtCpf.Text);
            cliente.DtNasc = Convert.ToDateTime(txtDtNasc.Text);
            cliente.Fone = Convert.ToInt32(txtFone.Text);

            clienteController.Editar(cliente);
            PopulaListaClientes();
            MessageBox.Show("Alterado");
        }
    }
}
