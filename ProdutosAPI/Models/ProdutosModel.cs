// Models/Produto.cs
namespace ProdutosAPI.Models
{
    public class ProdutosModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string DescricaoCurta { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
    }
}
