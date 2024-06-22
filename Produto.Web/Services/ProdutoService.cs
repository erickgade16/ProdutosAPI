using Produto.Web.Models;
using Produto.Web.Services.Interfaces;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Produto.Web.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string apiEndpoint = "/api/produto/";
        private readonly JsonSerializerOptions _options;

        public ProdutoService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<ProdutoViewModel>> GetProdutos()
        {
            var client = _clientFactory.CreateClient("ProductAPI");
            using (var response = await client.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var ApiResponse = await response.Content.ReadAsStreamAsync();
                    var produtosVM = await JsonSerializer.DeserializeAsync<IEnumerable<ProdutoViewModel>>(ApiResponse, _options);
                    return produtosVM;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<IEnumerable<ProdutoViewModel>> GetProdutosFilter(string filtro)
        {
            var client = _clientFactory.CreateClient("ProductAPI");
            using (var response = await client.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var ApiResponse = await response.Content.ReadAsStreamAsync();
                    var produtosVM = await JsonSerializer.DeserializeAsync<IEnumerable<ProdutoViewModel>>(ApiResponse, _options);

                    if (!string.IsNullOrEmpty(filtro))
                    {
                        produtosVM = produtosVM.Where(p =>
                            p.Nome.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                            p.Descricao.Contains(filtro, StringComparison.OrdinalIgnoreCase)
                        ).ToList();
                    }

                    return produtosVM;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<ProdutoViewModel> GetProdutoId(int id)
        {
            var client = _clientFactory.CreateClient("ProductAPI");
            using (var response = await client.GetAsync($"{apiEndpoint}{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var ApiResponse = await response.Content.ReadAsStreamAsync();
                    var produto = await JsonSerializer.DeserializeAsync<ProdutoViewModel>(ApiResponse, _options);
                    return produto;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
