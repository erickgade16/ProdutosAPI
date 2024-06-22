using Microsoft.AspNetCore.Mvc;
using ProdutosAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProdutosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private static List<ProdutosModel> Produtos = new List<ProdutosModel>
        {
            new ProdutosModel { Id = 1, Nome = "Pizza", Descricao = "Uma deliciosa pizza com uma combinação perfeita de queijo derretido, molho de tomate fresco e ingredientes saborosos, assada até ficar crocante.", DescricaoCurta = "Pizza saborosa", Preco = 10.0M, ImagemUrl = "/img/Pizza.jpg" },
            new ProdutosModel { Id = 2, Nome = "Hambúrguer", Descricao = "Um suculento hambúrguer feito com carne grelhada, queijo derretido, alface fresca, tomate maduro e um molho especial, servido em um pão macio.", DescricaoCurta = "Hambúrguer suculento", Preco = 20.0M, ImagemUrl = "/img/hamburguer.jpg" },



            new ProdutosModel { Id = 3, Nome = "Lasanha", Descricao = "Deliciosa lasanha com massa fresca, molho de tomate caseiro, queijo derretido e carne moída temperada.", DescricaoCurta = "Lasanha caseira", Preco = 15.0M, ImagemUrl = "/img/lasanha.jpg" },
            new ProdutosModel { Id = 4, Nome = "Salada Caesar", Descricao = "Salada fresca com alface romana, croutons crocantes, queijo parmesão e molho Caesar cremoso.", DescricaoCurta = "Salada Caesar clássica", Preco = 25.0M, ImagemUrl = "/img/salada_caesar.jpg" },
            new ProdutosModel { Id = 5, Nome = "Sopa de Legumes", Descricao = "Sopa reconfortante com legumes frescos, caldo de legumes aromático e temperos naturais.", DescricaoCurta = "Sopa caseira de legumes", Preco = 30.0M, ImagemUrl = "/img/sopa_legumes.jpg" },
            new ProdutosModel { Id = 6, Nome = "Sushi de Salmão", Descricao = "Sushi fresco com fatias suculentas de salmão, arroz temperado e alga nori crocante.", DescricaoCurta = "Sushi de salmão fresco", Preco = 35.0M, ImagemUrl = "/img/sushi_salmao.jpg" },
            new ProdutosModel { Id = 7, Nome = "Bolo de Chocolate", Descricao = "Bolo irresistível de chocolate com massa de cacau, recheio de ganache e cobertura de chocolate ao leite.", DescricaoCurta = "Bolo de chocolate cremoso", Preco = 40.0M, ImagemUrl = "/img/bolo_chocolate.jpg" },

        };

        [HttpGet]
        public IEnumerable<ProdutosModel> Get()
        {
            try
            {
                return Produtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet("filtro")]
        public IEnumerable<ProdutosModel> GetFiltro([FromQuery] string filtro)
        {
            try
            {
                if (string.IsNullOrEmpty(filtro))
                    return Produtos;

                return Produtos.Where(p => p.Nome.Contains(filtro) || p.Descricao.Contains(filtro));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet("{id}")]
        public ActionResult<ProdutosModel> GetById(int id)
        {
            try
            {
                var produto = Produtos.FirstOrDefault(p => p.Id == id);
                if (produto == null)
                    return NotFound();
                return produto;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
