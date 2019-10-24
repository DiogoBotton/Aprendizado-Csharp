using System.Collections.Generic;
namespace McBonalds.Models
{
    public abstract class Hamburguer : Produto
    {
        public abstract string MostrarProduto();
        public abstract double RetornarPreco();
        public abstract string RetornarNome();
        public abstract void AdcQtd(int qtd);
    }
}