using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestockTeste.Modelo
{
    public class ValidacaoFornecedores
    {
        public class ValidacaoFornecedor
        {
            public string mensagem = string.Empty;
            public int id;

            public ValidacaoFornecedor()
            {
            }

            public ValidacaoFornecedor(List<string> listaDadosFornecedor)
            {
                ValidarId(listaDadosFornecedor[0]);
                ValidarNome(listaDadosFornecedor[1]);
                ValidarCNPJ(listaDadosFornecedor[2]);
                ValidarTelefone(listaDadosFornecedor[3]);
                ValidarEmail(listaDadosFornecedor[4]);
            }

            public void ValidarId(string identificacao)
            {
                try
                {
                    this.id = Convert.ToInt32(identificacao);
                }
                catch
                {
                    this.mensagem += "Id inválido! \n";
                }
            }

            public void ValidarNome(string nome)
            {
                if (string.IsNullOrWhiteSpace(nome))
                    this.mensagem += "Nome é obrigatório \n";
                else if (nome.Length < 3)
                    this.mensagem += "Nome com menos que 3 caracteres \n";
                else if (nome.Length > 100)
                    this.mensagem += "Nome com mais que 100 caracteres \n";
            }

            public void ValidarCNPJ(string cnpj)
            {
                if (string.IsNullOrWhiteSpace(cnpj))
                {
                    this.mensagem += "CNPJ é obrigatório \n";
                    return;
                }

                if (cnpj.Length != 14)
                    this.mensagem += "CNPJ deve ter 14 dígitos \n";
                else if (!long.TryParse(cnpj, out _))
                    this.mensagem += "CNPJ deve conter apenas números \n";
            }

            public void ValidarTelefone(string telefone)
            {
                if (string.IsNullOrWhiteSpace(telefone))
                    this.mensagem += "Telefone é obrigatório \n";
                else if (telefone.Length < 8 || telefone.Length > 15)
                    this.mensagem += "Telefone com tamanho inválido \n";
            }

            public void ValidarEmail(string email)
            {
                if (string.IsNullOrWhiteSpace(email))
                    this.mensagem += "Email é obrigatório \n";
                else if (!email.Contains("@") || !email.Contains("."))
                    this.mensagem += "Email inválido \n";
            }
        }
    }
}
