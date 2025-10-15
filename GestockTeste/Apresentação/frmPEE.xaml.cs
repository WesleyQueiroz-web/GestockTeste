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
using GestockTeste.Modelo;

namespace GestockTeste.Apresentação
{
    /// <summary>
    /// Lógica interna para frmPEE.xaml
    /// </summary>
    public partial class frmPEE : Window
    {
        public frmPEE()
        {
            InitializeComponent();
        }

        private void btnPesquisarPorId_Click(object sender, RoutedEventArgs e)
        {
            Controle controle = new Controle();
            Produto produto = controle.PesquisarProdutoPorId(txbId.Text);
            txbNome.Text = produto.nome;
            txbLote.Text = produto.lote.ToString();
            txbCategoria.Text = produto.categoria;
            txbQuantidade.Text = produto.quantidade.ToString();

            if (produto.id.Equals(0))
                MessageBox.Show("Id nao encontrado");



        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            List<string> listaDadosProduto = new List<string>();
            listaDadosProduto.Add(txbId.Text);
            listaDadosProduto.Add(txbNome.Text);
            listaDadosProduto.Add(txbCategoria.Text);
            listaDadosProduto.Add(txbLote.Text);
            listaDadosProduto.Add(txbQuantidade.Text);

            Controle controle = new Controle();
            controle.EditarProduto(listaDadosProduto);
            MessageBox.Show(controle.mensagem);


        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("Confirma a exclusao do produto?", "Excluir Produto", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                Controle controle = new Controle();
                controle.ExcluirProduto(txbId.Text);
                MessageBox.Show(controle.mensagem);
            }
            txbId.Text = "";
            txbNome.Text = string.Empty;
            txbCategoria.Text = string.Empty;
            txbLote.Text = string.Empty;
            txbQuantidade.Text = string.Empty;

        }

        private void btnPesquisarPorNome_Click(object sender, RoutedEventArgs e)
        {
            Controle controle = new Controle();
            List<Produto> listaProdutos = controle.PesquisarProdutoPorNome(txbNome.Text);

            if (!controle.mensagem);
            {
                MessageBox.Show(controle.mensagem);
                return;
            }

            if (listaProdutos.Count == 0)
            {
                MessageBox.Show("Nenhum produto encontrado com esse nome.");
                return;
            }

            if (listaProdutos.Count == 1)
            {
                txbCategoria.Text = listaProdutos[0].id.ToString();
                txbNome.Text = listaProdutos[0].nome;
                txbLote.Text = listaProdutos[0].lote.ToString();
                txbCategoria.Text = listaProdutos[0].categoria;
                txbQuantidade.Text = listaProdutos[0].quantidade.ToString();

            }
            if (listaProdutos.Count > 1)
            {
                Estaticos.listaProdutos = listaProdutos;
                frmSelecao frmS = new frmSelecao();
                frmS.ShowDialog();
                txbId.Text = Estaticos.produto.id.ToString();
                txbNome.Text = Estaticos.produto.nome;
                txbLote.Text = Estaticos.produto.lote.ToString();
                txbCategoria.Text = Estaticos.produto.categoria;
                txbQuantidade.Text = Estaticos.produto.quantidade.ToString();
            }

        }
    }
}
