using BgendyController;
using BgendyModel;
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
            bool validador = false;
            InitializeComponent();
            PopulaListaAtendimentos();
            HabilitaCampos(validador);

        }

        private void GerenciarCadastros(object sender, RoutedEventArgs e)
        {
            GerenciarCadastros cadastros = new GerenciarCadastros();
            this.Close();
            cadastros.ShowDialog();

        }

       private void GerenciarServicos(object sender, RoutedEventArgs e)
        {
            GerenciarServicos servicos = new GerenciarServicos();
            this.Close();
            servicos.ShowDialog();
        }

        private void GerenciarAtendimentos(object sender, RoutedEventArgs e)
        {
            //Implementar
        }

        private void ListViewAtendimentos_Loaded(object sender, RoutedEventArgs e)
        {
            //Atendimento atendimento = (Atendimento)e.Source;
            

            var gridView = new GridView();
            listViewAtendimentos.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Id",
                DisplayMemberBinding = new Binding("Id")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Nome do Cliente",
                DisplayMemberBinding = new Binding("_Cliente.Nome")
            });

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Serviço",
                DisplayMemberBinding = new Binding("_Servico.Descricao")
            });
            var bindingInicio = new Binding("Data e Hora Inicial");
            bindingInicio.StringFormat = "dd/MM/yyyy HH:mm";
            //binding.StringFormat = "dd/MM/yyyy HH:mm";

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Horario final",
                DisplayMemberBinding = bindingInicio,
            });
            var bindingFim = new Binding("Horario Final");
            bindingFim.StringFormat = "dd/MM/yyyy HH:mm";

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "DtAtendimentoFim",
                DisplayMemberBinding = bindingFim,
            });
            
            //PopulaListaAtendimentos();
        }

        private void ComboNome_Loaded(object sender, RoutedEventArgs e)
        {
            ClienteController clienteController = new ClienteController();
            IList<Cliente> clientes = clienteController.ListarTodos();

            foreach(Cliente c in clientes) {
                comboNome.Items.Add(c);
                comboNome.DisplayMemberPath = "Nome";
            }
        }

        private void ComboServico_Loaded(object sender, RoutedEventArgs e)
        {
            ServicoController servicoController = new ServicoController();
            IList<Servico> servicos = servicoController.ListarTodos();

            foreach (Servico s in servicos)
            {
                comboServico.Items.Add(s);
                comboServico.DisplayMemberPath = "Descricao";
            }
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            bool validador = false;
            AtendimentoController atendimentoController = new AtendimentoController();
            ServicoController sctrl = new ServicoController();
            ClienteController cctrl = new ClienteController();

            if (string.IsNullOrEmpty(comboNome.Text))
                throw new NullReferenceException("O campo nome é obrigatório.");


            Atendimento atendimento = new Atendimento();
            Cliente cliente = (Cliente)comboNome.SelectedItem;
            Servico servico = (Servico)comboServico.SelectedItem;

            atendimento._Cliente = cctrl.BuscarPorID(cliente.Id);
            atendimento._Servico = sctrl.BuscarPorID(servico.Id); ;
            atendimento.DtAtendimentoInicio = Convert.ToDateTime(txtDataAtendimento.Text);
            atendimento.DtAtendimentoFim = atendimento.DtAtendimentoInicio.AddMinutes(atendimento._Servico.Tempo);

            atendimentoController.Adicionar(atendimento);

            MessageBox.Show("Atendimento Marcado " + atendimento._Cliente.Nome);

            PopulaListaAtendimentos();
            HabilitaCampos(validador);
            LimparCampos();
        }

        private void PopulaListaAtendimentos()
        {
            listViewAtendimentos.Items.Clear();
            AtendimentoController atendimentoController = new AtendimentoController();
            IList<Atendimento> atendimentos = atendimentoController.ListarTodos();

            foreach (Atendimento a in atendimentos)
            {
                listViewAtendimentos.Items.Add(a);
            }
        }

        private void LimparCampos()
        {
            txtDataAtendimento.Clear();
            comboNome.SelectedIndex = -1;
            comboServico.SelectedIndex = -1;
        }

        private void HabilitaCampos(bool validador)
        {
            if (validador == true)
            {
                txtDataAtendimento.IsEnabled = true;
                comboNome.IsEnabled = true;
                comboServico.IsEnabled = true;
                btnSalvar.IsEnabled = true;
            }
            else
            {
                txtDataAtendimento.IsEnabled = false;
                comboNome.IsEnabled = false;
                comboServico.IsEnabled = false;
                btnSalvar.IsEnabled = false;
            }
        }

        private void BtnNewAtendimento_Click(object sender, RoutedEventArgs e)
        {
            bool validador = true;
            HabilitaCampos(validador);
        }
    }
}
