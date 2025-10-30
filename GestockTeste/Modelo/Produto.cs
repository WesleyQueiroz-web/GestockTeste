using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestockTeste.Modelo
{
    public class Produto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string categoria { get; set; }
        public int lote { get; set; }
        public int quantidade { get; set; }

        public int FornecedorId { get; set; }
        public Fornecedores Fornecedores { get; set; }

    }
}
