using Produto.Web.Models;

namespace Produto.Web.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoViewModel>> GetProdutos();
        Task<IEnumerable<ProdutoViewModel>> GetProdutosFilter(string filtro);
        Task<ProdutoViewModel> GetProdutoId(int Id);
    }
}
