using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestockTeste.Modelo
{
    public class Controle
    {
        public string mensagem = "";
        public void CadastrarProduto(List<String> listaDdadosProduto)
        {
            this.mensagem = "";
            Validacao validacao = new Validacao(listaDdadosProduto);
            if (validacao.mensagem.Equals(""))
            {
                Produto produto = new Produto();

                produto.id = listaDdadosProduto[0];
                produto.nome = listaDdadosProduto[1];
                produto.categoria = listaDdadosProduto[2];
                produto.lote = int.Parse(listaDdadosProduto[3]);
                produto.quantidade = int.Parse(listaDdadosProduto[4]);

                ProdutoDAO produtoDAO = new ProdutoDAO();

                this.mensagem = produtoDAO.mensagem;
            }
            else
            {
                this.mensagem = validacao.mensagem;
            }
        }

        public Produto PesquisarProdutoPorId(String identificacao)
        {
            this.mensagem = "";
            Produto produto = new Produto();
            Validacao validacao = new Validacao();
            validacao.ValidarId(identificacao);
            if (validacao.mensagem.Equals(""))
            {
                produto.id = validacao.id;
                ProdutoDAO produtoDAO = new ProdutoDAO();
                produto = produtoDAO.PesquisarProdutoPorId(produto.id);
            }
            else
            {
                this.mensagem = validacao.mensagem;
            }

            return produto;
        }

        public Lista<Produto> PesquisarProdutoPorNome(String nome)
        {
            this.mensagem = "";
            Lista<Produto> listaProdutos = new Lista<Produto>();

            Validacao validacao = new Validacao();
            Validacao.ValidarNome(nome);

            if (Validacao.mensagem.Equals(""))
            {
                Produto produto = new Produto();
                produto.nome = nome;
                ProdutoDAO produtoDAO = new ProdutoDAO();
                listaProdutos = produtoDAO.PesquisarProdutoPorNome(produto.nome);
            }
            else
            {
                this.mensagem = Validacao.mensagem;
            }
        }
    }
}
