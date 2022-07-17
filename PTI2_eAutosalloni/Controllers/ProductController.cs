using Microsoft.AspNetCore.Mvc;
using PTI2_eAutosalloni.ViewModels;

namespace eAutosalloni.Controllers
{
    public class ProductController : Controller
    {
        private ProductViewModel productViewModel;


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {

            var response = new ProductViewModel();
            //var items = _shoppingCart.GetShoppingCartItems();
            //_shoppingCart.ShoppingCartItems = items;
            //var response = new ShoppingCartViewModel()
            //{
            //    ShoppingCart = _shoppingCart,
            //    ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            //};

            return View(response);
        }
    }
}
