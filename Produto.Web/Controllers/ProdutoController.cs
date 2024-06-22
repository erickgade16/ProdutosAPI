using Microsoft.AspNetCore.Mvc;
using Produto.Web.Models;
using Produto.Web.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Produto.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> Index(string searchString)
        {
            try
            {
                var result = await _produtoService.GetProdutosFilter(searchString);
                if (result.Count() == 0)
                {
                    return View("ProdutoNaoEncontradoView");
                }

                if (result == null)
                {
                    return View("Error");
                }

                return View(result);
            }

            catch (Exception ex)
            {

                throw ex;
            }

        }
        [HttpGet]
        public async Task<ActionResult> Detalhes(int id)
        {
            try
            {
                var produto = await _produtoService.GetProdutoId(id);
                if (produto == null)
                {
                    return NotFound();
                }
                return PartialView("_DetalhesProduto", produto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
}
