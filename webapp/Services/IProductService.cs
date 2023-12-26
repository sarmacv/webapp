using webapp.Models;

namespace webapp.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();

        Task<bool> IsBeta();
    }
}