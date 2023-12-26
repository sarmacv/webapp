using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webapp.Models;
using webapp.Services;

namespace webapp.Pages
{
    public class IndexModel : PageModel
    {

        public List<Product> Products;

        public void OnGet()
        {
            ProductService productService = new ProductService();   
            Products = productService.GetProducts();
        }
    }
}
