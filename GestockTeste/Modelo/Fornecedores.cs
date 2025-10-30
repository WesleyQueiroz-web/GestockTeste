using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestockTeste.Modelo
{
    public class Fornecedores
    {
        public int FornecedorId { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }


    public Fornecedores(int fornecedorId, string nome, string cnpj, string telefone, string email)
        {
            FornecedorId = fornecedorId;
            Nome = nome;
            CNPJ = cnpj;
            Telefone = telefone;
            Email = email;
        }
    }
}
