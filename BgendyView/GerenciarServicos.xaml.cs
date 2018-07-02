using BgendyController;
using BgendyModel;
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
    /// Lógica interna para GerenciarServicos.xaml
    /// </summary>
    public partial class GerenciarServicos : Window
    {
        public GerenciarServicos()
        {
            InitializeComponent();
        }

        private void ListViewServicos_Loaded(object sender, RoutedEventArgs e)
        {
            var gridView = new GridView();
            listViewServicos.View = gridView;

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Id",
                DisplayMemberBinding = new Binding("Id")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Nome",
                DisplayMemberBinding = new Binding("Descricao")
            });

            var binding = new Binding("Valor");
            binding.StringFormat = "C2";

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Preço",
                DisplayMemberBinding = binding
            });

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Tempo",
                DisplayMemberBinding = new Binding("Tempo")
            });

            PopulaListaServicos();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            bool validador = false;

            ServicoController servicoController = new ServicoController();

            if (string.IsNullOrEmpty(txtDescricao.Text))
                throw new NullReferenceException("O campo nome é obrigatório.");

            Servico servico = new Servico();

            servico.Descricao = txtDescricao.Text;
            servico.Valor = Convert.ToDouble(txtValor.Text);
            servico.Tempo = Convert.ToInt32(txtTempo.Text);


            servicoController.Adicionar(servico);
            MessageBox.Show("Serviço " + servico.Descricao + "  Cód.:  " + servico.Id + " registrado!");
            PopulaListaServicos();

            LimparCampos();
            HabilitaCampos(validador);
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            listViewServicos.Items.Clear();
            string nomeBusca = txtBusca.Text;
            ServicoController servicoController = new ServicoController();
            IList<Servico> servicos = servicoController.ListarPorNome(nomeBusca);

            foreach (Servico s in servicos)
            {
                listViewServicos.Items.Add(s);
            }
        }

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSelecionar_Click(object sender, RoutedEventArgs e)
        {
            bool validador = true;
            btnSalvar.IsEnabled = false;
            HabilitaCampos(validador);
            Servico servico = (Servico)listViewServicos.SelectedItem;

            txtDescricao.Text = servico.Descricao;
            txtTempo.Text = Convert.ToString(servico.Tempo);
            txtValor.Text = Convert.ToString(servico.Valor);


        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            bool validador = false;
            ServicoController servicoController = new ServicoController();
            Servico servico = (Servico)listViewServicos.SelectedItem;

            servico.Descricao = txtDescricao.Text;
            servico.Valor = Convert.ToDouble(txtValor.Text);
            servico.Tempo = Convert.ToInt16(txtTempo.Text);

            servicoController.Editar(servico);
            PopulaListaServicos();
            MessageBox.Show("Alterado");
            LimparCampos();
            HabilitaCampos(validador);
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            bool validador = false;
            LimparCampos();
            HabilitaCampos(validador);
            ServicoController servicoController = new ServicoController();
            Servico servico = (Servico)listViewServicos.SelectedItem;

            servicoController.Excluir(servico.Id);
            PopulaListaServicos();
            LimparCampos();
            MessageBox.Show("Excluido");
        }

        private void BtnNovo_Click(object sender, RoutedEventArgs e)
        {
            bool validador = true;
            
            BtnAlterar.IsEnabled = false;
            BtnExcluir.IsEnabled = false;

            LimparCampos();
            HabilitaCampos(validador);
        }

        private void PopulaListaServicos()
        {
            listViewServicos.Items.Clear();
            ServicoController servicoController = new ServicoController();
            IList<Servico> servicos = servicoController.ListarTodos();

            foreach (Servico s in servicos)
            {
                listViewServicos.Items.Add(s);
            }
        }

        private void HabilitaCampos(bool validador)
        {
            if (validador == true)
            {
                txtDescricao.IsEnabled = true;
                txtTempo.IsEnabled = true;
                txtValor.IsEnabled = true;
            }
            else
            {
                txtDescricao.IsEnabled = false;
                txtTempo.IsEnabled = false;
                txtValor.IsEnabled = false;
            }
        }
        private void LimparCampos()
        {
            txtDescricao.Clear();
            txtTempo.Clear();
            txtValor.Clear();
        }


    }

}

