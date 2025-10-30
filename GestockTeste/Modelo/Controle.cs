using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestockTeste.DAL;

namespace GestockTeste.Modelo
{
    public class Controle
    {
        public string mensagem = "";

        // -------------------------------
        // CONTROLE DE PRODUTO
        // -------------------------------

        public void CadastrarProduto(List<string> dadosProduto)
        {
            this.mensagem = "";
            ValidacaoProduto validacao = new ValidacaoProduto(dadosProduto);

            if (validacao.mensagem.Equals(""))
            {
                Produto produto = new Produto
                {
                    id = int.Parse(dadosProduto[0]),
                    nome = dadosProduto[1],
                    categoria = dadosProduto[2],
                    lote = int.Parse(dadosProduto[3]),
                    quantidade = int.Parse(dadosProduto[4])
                };

                ProdutoDAO produtoDAO = new ProdutoDAO();
                produtoDAO.CadastrarProduto(produto);
                this.mensagem = produtoDAO.mensagem;
            }
            else
            {
                this.mensagem = validacao.mensagem;
            }
        }

        public Produto PesquisarProdutoPorId(string idStr)
        {
            this.mensagem = "";
            Produto produto = new Produto();
            ValidacaoProduto validacao = new ValidacaoProduto();
            validacao.ValidarId(idStr);

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

        public List<Produto> PesquisarProdutoPorNome(string nome)
        {
            this.mensagem = "";
            List<Produto> listaProdutos = new List<Produto>();
            ValidacaoProduto validacao = new ValidacaoProduto();
            validacao.ValidarNome(nome);

            if (validacao.mensagem.Equals(""))
            {
                Produto produto = new Produto { nome = nome };
                ProdutoDAO produtoDAO = new ProdutoDAO();
                listaProdutos = produtoDAO.PesquisarPorNome(produto.nome);
            }
            else
            {
                this.mensagem = validacao.mensagem;
            }

            return listaProdutos;
        }

        public void EditarProduto(Produto produto)
        {
            ProdutoDAO produtoDAO = new ProdutoDAO();
            produtoDAO.EditarProduto(produto);
            this.mensagem = produtoDAO.mensagem;
        }

        public void ExcluirProduto(int id)
        {
            Produto produto = PesquisarProdutoPorId(id.ToString());
            if (produto == null)
            {
                this.mensagem = "Produto não encontrado!";
                return;
            }

            ProdutoDAO produtoDAO = new ProdutoDAO();
            produtoDAO.ExcluirProduto(produto);
            this.mensagem = produtoDAO.mensagem;
        }

        // -------------------------------
        // CONTROLE DE PESSOA
        // -------------------------------

        public void CadastrarPessoa(List<string> dadosPessoa)
        {
            this.mensagem = "";
            ValidacaoPessoa validacao = new ValidacaoPessoa(dadosPessoa);

            if (validacao.mensagem.Equals(""))
            {
                Pessoa pessoa = new Pessoa
                {
                    Pessoaid = validacao.id,
                    Nome = dadosPessoa[1],
                    CPF = dadosPessoa[2],
                    Email = dadosPessoa[3],
                    TipoPessoa = dadosPessoa[4]
                };

                PessoaDAO pessoaDAO = new PessoaDAO();
                pessoaDAO.CadastrarPessoa(pessoa);
                this.mensagem = pessoaDAO.mensagem;
            }
            else
            {
                this.mensagem = validacao.mensagem;
            }
        }

        public Pessoa PesquisarPessoaPorId(string idStr)
        {
            this.mensagem = "";
            Pessoa pessoa = new Pessoa();
            ValidacaoPessoa validacao = new ValidacaoPessoa();
            validacao.ValidarId(idStr);

            if (validacao.mensagem.Equals(""))
            {
                pessoa.Pessoaid = validacao.id;
                PessoaDAO pessoaDAO = new PessoaDAO();
                pessoa = pessoaDAO.PesquisarPessoaPorId(pessoa);
            }
            else
            {
                this.mensagem = validacao.mensagem;
            }

            return pessoa;
        }

        public List<Pessoa> PesquisarPessoaPorNome(string nome)
        {
            this.mensagem = "";
            List<Pessoa> listaPessoas = new List<Pessoa>();
            ValidacaoPessoa validacao = new ValidacaoPessoa();
            validacao.ValidarNome(nome);

            if (validacao.mensagem.Equals(""))
            {
                Pessoa pessoa = new Pessoa { Nome = nome };
                PessoaDAO pessoaDAO = new PessoaDAO();
                listaPessoas = pessoaDAO.PesquisarPorNome(pessoa);
            }
            else
            {
                this.mensagem = validacao.mensagem;
            }

            return listaPessoas;
        }

        public void EditarPessoa(Pessoa pessoa)
        {
            PessoaDAO pessoaDAO = new PessoaDAO();
            pessoaDAO.EditarPessoa(pessoa);
            this.mensagem = pessoaDAO.mensagem;
        }

        public void ExcluirPessoa(int id)
        {
            Pessoa pessoa = PesquisarPessoaPorId(id.ToString());
            if (pessoa == null)
            {
                this.mensagem = "Pessoa não encontrada!";
                return;
            }

            PessoaDAO pessoaDAO = new PessoaDAO();
            pessoaDAO.ExcluirPessoa(pessoa);
            this.mensagem = pessoaDAO.mensagem;
        }
    }
}

