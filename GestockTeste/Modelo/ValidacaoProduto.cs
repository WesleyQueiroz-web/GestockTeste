using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestockTeste.Modelo
{
    public class ValidacaoProduto
    {
        public string mensagem = String.Empty;
        public int id;
    

    public ValidacaoProduto()
        {

        }
        public ValidacaoProduto(List<String> listaDadosProduto)

        {
            ValidarId(listaDadosProduto[0]);
            ValidarNome(listaDadosProduto[1]);
            ValidarCategoria(listaDadosProduto[2]);
            ValidarLote(listaDadosProduto[3]);
            ValidarQuantidade(listaDadosProduto[4]);

        }

        public void ValidarId(string identificacao)
        {
            try
            {
                this.id = Convert.ToInt32(identificacao);
            }

            catch (Exception e)
            {
                this.mensagem += "Id Inválido! \n";
            }
        }
        public void ValidarNome(string nome)
        {
            if (nome.Length < 3)
            {
                this.mensagem += "Nome com menos que 3 caracteres \n";

                if (nome.Length > 45)
                    this.mensagem += "Nome com mais que 45 caracteres \n";
            }


        }
        public void ValidarCategoria(string categoria)
        {
            if (categoria.Length < 3)
            {
                this.mensagem += "Categoria com menos que 3 caracteres \n";
                if (categoria.Length > 45)
                    this.mensagem += "Categoria com mais que 45 caracteres \n";
            }
        }
        public void ValidarLote(string lote)
        {
            try
            {
                int loteConvertido = Convert.ToInt32(lote);
                if (loteConvertido < 0)
                {
                    this.mensagem += "Lote não pode ser negativo \n";
                }
            }
            catch (Exception e)
            {
                this.mensagem += "Lote inválido! \n";
            }
        }
        public void ValidarQuantidade(string quantidade)
        {
            try
            {
                int quantidadeConvertida = Convert.ToInt32(quantidade);
                if (quantidadeConvertida < 0)
                {
                    this.mensagem += "Quantidade não pode ser negativa \n";
                }
            }
            catch (Exception e)
            {
                this.mensagem += "Quantidade inválida! \n";
            }
        }
    }
}

