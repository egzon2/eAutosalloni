using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PTI2_eAutosalloni.Data.Cart;
using PTI2_eAutosalloni.Interfaces.Repositories;
using PTI2_eAutosalloni.Interfaces.Services;
using PTI2_eAutosalloni.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IVehicleService _productService;
        private readonly IVehicleRepository _productRepository;
        private readonly ShoppingCart _shoppingCart;
        //private readonly IOrdersService _ordersService;
        private readonly IUserService _customer;
        private readonly UserManager<IdentityUser> _userManager;

        public OrdersController(IVehicleService productService, IVehicleRepository productRepository, ShoppingCart shoppingCart, IUserService customer, UserManager<IdentityUser> userManager)
        {
            _productService = productService;
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
            _customer = customer;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }
        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {

            var item = await _productService.FindById(id);
            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemToShoppingCart(int id)
        {
            var item = await _productService.FindById(id);
            if (item != null)
            {
                _shoppingCart.RemoveItemFromCard(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
