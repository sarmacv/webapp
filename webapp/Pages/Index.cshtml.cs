using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webapp.Models;
using webapp.Services;

namespace webapp.Pages
{
    public class IndexModel : PageModel
    {

        public List<Product> Products;
        public bool IsBeta;

        private readonly IProductService _productService;

        public IndexModel (IProductService productService)
        {
            _productService = productService;
        }

        public void OnGet()
        {
            Products = _productService.GetProducts();
            IsBeta = _productService.IsBeta().Result;
        }
    }
}
