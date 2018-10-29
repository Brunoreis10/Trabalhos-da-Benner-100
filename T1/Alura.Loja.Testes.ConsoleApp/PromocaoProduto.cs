namespace Alura.Loja.Testes.ConsoleApp
{
    public class PromocaoProduto
    {
        public int ProdutoId { get; internal set; }
        public Produto  Produto { get; internal set; }
        public int PromocaoId { get; internal set; }
        public Promocao Promocao { get; internal set; }

        public override string ToString()
        {
            return $"{Promocao.Descricao} - {Produto.Nome}";
        }
    }
}
