﻿namespace Produto.Web.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string DescricaoCurta { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
    }
}
