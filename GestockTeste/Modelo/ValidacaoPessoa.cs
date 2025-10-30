using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestockTeste.Modelo
{
    public class ValidacaoPessoa
    {
            public string mensagem = string.Empty;
            public int id;

            public ValidacaoPessoa()
            {

            }

            public ValidacaoPessoa(List<string> listaDadosPessoa)
            {
                ValidarId(listaDadosPessoa[0]);
                ValidarNome(listaDadosPessoa[1]);
                ValidarCPF(listaDadosPessoa[2]);
                ValidarEmail(listaDadosPessoa[3]);
                ValidarTipoPessoa(listaDadosPessoa[4]);
            }

            public void ValidarId(string identificacao)
            {
                try
                {
                    this.id = Convert.ToInt32(identificacao);
                }
                catch (Exception)
                {
                    this.mensagem += "Id inválido!\n";
                }
            }

            public void ValidarNome(string nome)
            {
                if (string.IsNullOrWhiteSpace(nome))
                {
                    this.mensagem += "O nome não pode estar vazio.\n";
                }
                else if (nome.Length < 3)
                {
                    this.mensagem += "O nome deve ter pelo menos 3 caracteres.\n";
                }
                else if (nome.Length > 100)
                {
                    this.mensagem += "O nome não pode ter mais que 100 caracteres.\n";
                }
            }

            public void ValidarCPF(string cpf)
            {
                if (string.IsNullOrWhiteSpace(cpf))
                {
                    this.mensagem += "O CPF não pode estar vazio.\n";
                    return;
                }

                cpf = cpf.Replace(".", "").Replace("-", "").Trim();

                if (cpf.Length != 11 || !cpf.All(char.IsDigit))
                {
                    this.mensagem += "CPF inválido! Deve conter 11 dígitos numéricos.\n";
                }
            }

            public void ValidarEmail(string email)
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    this.mensagem += "O e-mail não pode estar vazio.\n";
                }
                else if (!email.Contains("@") || !email.Contains("."))
                {
                    this.mensagem += "E-mail inválido.\n";
                }
            }

            public void ValidarTipoPessoa(string tipoPessoa)
            {
                if (string.IsNullOrWhiteSpace(tipoPessoa))
                {
                    this.mensagem += "O tipo de pessoa deve ser informado.\n";
                }
                else if (tipoPessoa != "ADM" && tipoPessoa != "Operador")
                {
                    this.mensagem += "Tipo de pessoa inválido! Use 'ADM' ou 'Operador'.\n";
                }
            }
        }
    }

