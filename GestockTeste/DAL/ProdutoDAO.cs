using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GestockTeste.Modelo;

namespace GestockTeste.DAL
{
    public class ProdutoDAO
    {
        public string mensagem;
        public void CadastrarProduto(Produto produto)
        {
            SqlConnection con = Conexao.Conectar();
            if (!Conexao.mensagem.Equals(""))
            {
                this.mensagem = Conexao.mensagem;
                return;
            }
            string sql = "INSERT INTO Produto (id, nome, categoria, lote, quantidade) VALUES (@id, @nome, @categoria, @lote, @quantidade)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", produto.id);
            cmd.Parameters.AddWithValue("@nome", produto.nome);
            cmd.Parameters.AddWithValue("@categoria", produto.categoria);
            cmd.Parameters.AddWithValue("@lote", produto.lote);
            cmd.Parameters.AddWithValue("@quantidade", produto.quantidade);
            try
            {
                cmd.ExecuteNonQuery();
                mensagem = "Produto cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao cadastrar produto: " + ex.Message;
            }
            finally
            {
                Conexao.Desconectar(con);

            }
        }
        public Produto PesquisarProdutoPorId(Produto produto)
        {
            SqlConnection con = Conexao.Conectar();
            if (!string.IsNullOrEmpty(Conexao.mensagem))
            {
                this.mensagem = Conexao.mensagem;
                return null;
            }

            string sql = "SELECT * FROM Produto WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", produto.id);

            SqlDataReader dr = null;

            try
            {
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    produto.id = Convert.ToInt32(dr["id"]);
                    produto.nome = dr["nome"].ToString();
                    produto.categoria = dr["categoria"].ToString();
                    produto.lote = dr["lote"].ToString(); // se for string, senão converta
                    produto.quantidade = Convert.ToInt32(dr["quantidade"]);
                }
                else
                {
                    produto = null;
                    this.mensagem = "ID do produto não encontrado!";
                }
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao pesquisar produto: " + ex.Message;
                produto = null;
            }
            finally
            {
                Conexao.Desconectar(con);
            }

            return produto;
        }

        }

        public List<Produto> PesquisarPorNome(Produto produto)
        {
            this.mensagem = "";
            List<Produto> listaProdutos = new List<Produto>();
            SqlConnection con = Conexao.Conectar();
            if (!Conexao.mensagem.Equals(""))
            {
                this.mensagem = Conexao.mensagem;
                return null;
            }
            string sql = "SELECT * FROM Produto WHERE nome LIKE @nome";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@nome", "%" + produto.nome + "%");

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Produto p = new Produto();
                    p.id = int.Parse(dr["id"].ToString());
                    p.nome = dr["nome"].ToString();
                    p.categoria = dr["categoria"].ToString();
                    p.lote = int.Parse(dr["lote"].ToString());
                    p.quantidade = int.Parse(dr["quantidade"].ToString());
                    listaProdutos.Add(p);
                }
            }
            catch (SqlException e)
            {
                this.mensagem = "Erro ao pesquisar produtos: " + e.Message;
            }
            finally
            {
                con.Close();
            }
            return listaProdutos;
        }
        public void EditarProduto(Produto produto)
        {
            SqlConnection con = Conexao.Conectar();
            if (!Conexao.mensagem.Equals(""))
            {
                this.mensagem = Conexao.mensagem;
                return;
            }
            string sql = "UPDATE Produto SET nome = @nome, categoria = @categoria, lote = @lote, quantidade = @quantidade WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", produto.id);
            cmd.Parameters.AddWithValue("@nome", produto.nome);
            cmd.Parameters.AddWithValue("@categoria", produto.categoria);
            cmd.Parameters.AddWithValue("@lote", produto.lote);
            cmd.Parameters.AddWithValue("@quantidade", produto.quantidade);

            try
            {
                cmd.ExecuteNonQuery();
                mensagem = "Produto editado com sucesso!";
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao editar produto: " + ex.Message;
            }
            finally
            {
                Conexao.Desconectar(con);
            }

        }
        public void ExcluirProduto(Produto produto)
        {
            produto = PesquisarProdutoPorId(produto);
            if (produto.id.Equals(0))
                return;
            SqlConnection con = Conexao.Conectar();
            if (!Conexao.mensagem.Equals(""))
            {
                this.mensagem = Conexao.mensagem;
                return;
            }
            string sql = "DELETE FROM Produto WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", produto.id);
            try
            {
                cmd.ExecuteNonQuery();
                mensagem = "Produto excluído com sucesso!";
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao excluir produto: " + ex.Message;
            }
            finally
            {
                Conexao.Desconectar(con);
            }
        }


    }
}
    

