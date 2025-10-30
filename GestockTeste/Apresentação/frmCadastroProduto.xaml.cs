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
    /// Lógica interna para frmCadastro.xaml
    /// </summary>
    public partial class frmCadastro : Window
    {
        public frmCadastro()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCadastrar_Click_1(object sender, RoutedEventArgs e)
        {
            List<string> listaDadosPrdouto = new List<string>();
            listaDadosPrdouto.Add("0");
            listaDadosPrdouto.Add(txbId.Text);
            listaDadosPrdouto.Add(txbNome.Text);
            listaDadosPrdouto.Add(txbCategoria.Text);
            
            Controle controle = new Controle();
            controle.CadastrarProduto(listaDadosPrdouto);

            MessageBox.Show("Produto Cadastrado com Sucesso!");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
