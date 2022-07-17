using Microsoft.AspNetCore.Mvc;
using System;

namespace eAutosalloni.net.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            Cart cart = new Cart();

            return View(cart);
        }

        public ActionResult Checkout(string cep, string type)
        {
            Cart cart = new Cart();

            return Redirect(cart.Checkout(
            "http://127.0.0.1:8080/Cart/Finalize",
            "http://127.0.0.1:8080/Cart/Cancel",
            cep,
            type
            ));
        }

        //public ActionResult Finale(string token, string PayerId)
        //{
        //    Cart cart = new Cart();

        //    //ResponseNVP nvp = cart.Finalize(token, PayerId);

        //}


        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Cart cart = new Cart();
        }
        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Shipping(string cep)
        {
            Cart cart = new Cart();

            return PartialView(cart.GetShipping(cep));
        }

        public ActionResult Fail()
        {
            return View();
        }
    }

    internal class Cart
    {
        internal string Checkout(string v1, string v2, string cep, string type)
        {
            throw new NotImplementedException();
        }

        internal string GetShipping(string cep)
        {
            throw new NotImplementedException();
        }
    }
}