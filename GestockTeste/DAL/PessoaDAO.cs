using System;
using System.Data.SqlClient;
using GestockTeste.Modelo;
using GestockTeste.Modelo; // onde está sua classe Pessoa

namespace GestockTeste.DAL
{
    public class PessoaDAO
    {
        public string mensagem;

        // Cadastrar pessoa
        public void CadastrarPessoa(Pessoa pessoa)
        {
            try
            {
                using (SqlConnection con = Conexao.Conectar())
                {
                    if (!string.IsNullOrEmpty(Conexao.mensagem))
                    {
                        this.mensagem = Conexao.mensagem;
                        return;
                    }

                    string sql = "INSERT INTO Pessoa (Nome, CPF, Email, TipoPessoa) VALUES (@Nome, @CPF, @Email, @TipoPessoa)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Nome", pessoa.Nome);
                        cmd.Parameters.AddWithValue("@CPF", pessoa.CPF);
                        cmd.Parameters.AddWithValue("@Email", pessoa.Email);
                        cmd.Parameters.AddWithValue("@TipoPessoa", pessoa.TipoPessoa);

                        cmd.ExecuteNonQuery();
                        mensagem = "Pessoa cadastrada com sucesso!";
                    }
                }
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao cadastrar pessoa: " + ex.Message;
            }
        }

        // Pesquisar pessoa por ID
        public Pessoa PesquisarPessoaPorId(Pessoa pessoa)
        {
            SqlConnection con = Conexao.Conectar();

            if (!string.IsNullOrEmpty(Conexao.mensagem))
            {
                this.mensagem = Conexao.mensagem;
                return null;
            }

            string sql = "SELECT * FROM Pessoa WHERE PessoaId = @PessoaId";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@PessoaId", pessoa.Pessoaid);

            SqlDataReader dr = null;

            try
            {
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    pessoa.Pessoaid = Convert.ToInt32(dr["PessoaId"]);
                    pessoa.Nome = dr["Nome"].ToString();
                    pessoa.CPF = dr["CPF"].ToString();
                    pessoa.Email = dr["Email"].ToString();
                    pessoa.TipoPessoa = dr["TipoPessoa"].ToString();
                }
                else
                {
                    pessoa = null;
                    this.mensagem = "ID da pessoa não encontrado!";
                }
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao pesquisar pessoa: " + ex.Message;
                pessoa = null;
            }
            finally
            {
                Conexao.Desconectar(con);
            }

            return pessoa;
        }

        // Pesquisar pessoas por nome
        public List<Pessoa> PesquisarPorNome(Pessoa pessoa)
        {
            this.mensagem = "";
            List<Pessoa> listaPessoas = new List<Pessoa>();

            SqlConnection con = Conexao.Conectar();
            if (!string.IsNullOrEmpty(Conexao.mensagem))
            {
                this.mensagem = Conexao.mensagem;
                return null;
            }

            string sql = "SELECT * FROM Pessoa WHERE Nome LIKE @Nome";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Nome", "%" + pessoa.Nome + "%");

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Pessoa p = new Pessoa
                    {
                        Pessoaid = Convert.ToInt32(dr["PessoaId"]),
                        Nome = dr["Nome"].ToString(),
                        CPF = dr["CPF"].ToString(),
                        Email = dr["Email"].ToString(),
                        TipoPessoa = dr["TipoPessoa"].ToString()
                    };
                    listaPessoas.Add(p);
                }

                if (listaPessoas.Count == 0)
                {
                    this.mensagem = "Nenhuma pessoa encontrada com esse nome.";
                }
            }
            catch (SqlException e)
            {
                this.mensagem = "Erro ao pesquisar pessoas: " + e.Message;
            }
            finally
            {
                Conexao.Desconectar(con);
            }

            return listaPessoas;
        }

        // Editar pessoa
        public void EditarPessoa(Pessoa pessoa)
        {
            SqlConnection con = Conexao.Conectar();

            if (!string.IsNullOrEmpty(Conexao.mensagem))
            {
                this.mensagem = Conexao.mensagem;
                return;
            }

            string sql = "UPDATE Pessoa SET Nome = @Nome, CPF = @CPF, Email = @Email, TipoPessoa = @TipoPessoa WHERE PessoaId = @PessoaId";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@PessoaId", pessoa.Pessoaid);
            cmd.Parameters.AddWithValue("@Nome", pessoa.Nome);
            cmd.Parameters.AddWithValue("@CPF", pessoa.CPF);
            cmd.Parameters.AddWithValue("@Email", pessoa.Email);
            cmd.Parameters.AddWithValue("@TipoPessoa", pessoa.TipoPessoa);

            try
            {
                int linhasAfetadas = cmd.ExecuteNonQuery();

                if (linhasAfetadas > 0)
                {
                    mensagem = "Pessoa editada com sucesso!";
                }
                else
                {
                    mensagem = "Nenhuma pessoa encontrada com o ID informado.";
                }
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao editar pessoa: " + ex.Message;
            }
            finally
            {
                Conexao.Desconectar(con);
            }
        }

        // Excluir pessoa
        public void ExcluirPessoa(Pessoa pessoa)
        {
            // Verifica se a pessoa existe
            pessoa = PesquisarPessoaPorId(pessoa);
            if (pessoa == null)
            {
                this.mensagem = "Pessoa não encontrada para exclusão.";
                return;
            }

            SqlConnection con = Conexao.Conectar();

            if (!string.IsNullOrEmpty(Conexao.mensagem))
            {
                this.mensagem = Conexao.mensagem;
                return;
            }

            string sql = "DELETE FROM Pessoa WHERE PessoaId = @PessoaId";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@PessoaId", pessoa.Pessoaid);

            try
            {
                int linhasAfetadas = cmd.ExecuteNonQuery();

                if (linhasAfetadas > 0)
                {
                    mensagem = "Pessoa excluída com sucesso!";
                }
                else
                {
                    mensagem = "Nenhuma pessoa foi excluída.";
                }
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao excluir pessoa: " + ex.Message;
            }
            finally
            {
                Conexao.Desconectar(con);
            }
        }
    }
}
