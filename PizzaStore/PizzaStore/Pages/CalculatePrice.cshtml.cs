using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaStore.Models;
using PizzaStore.Controllers;
using PizzaStore.Utilidades;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Configuration;
using Microsoft.AspNetCore.Http;

namespace PizzaStore.Pages
{
    public class CalculatePriceModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int pizzaQuantity { set; get; }
        [BindProperty]
        public List<PizzaModel> pizzas { set; get; }






        public IngredientController ingredientController { set; get; }

        public MassController massController { set; get; }

        public ToastOptionController toastOptionController { set; get; }
        public PizzaController pizzaController { set; get; }
        public SizeController sizeController { set; get; }

        [BindProperty(SupportsGet = true)]
        public int orderComplete { set; get; }
        [BindProperty]
        public double totalPrice { set; get; }
        public CalculatePriceModel() {
            pizzaController = new PizzaController(); 
            
            

           
            
            ingredientController = new IngredientController();
            massController = new MassController();
            toastOptionController = new ToastOptionController();
            sizeController = new SizeController();
        }
        public void OnGet()
        {
            HttpContext.Session.SetComplexData("pizzaQuantity", pizzaQuantity);
            HttpContext.Session.SetComplexData("orderComplete", orderComplete);
            pizzas = HttpContext.Session.GetComplexData<List<PizzaModel>>("pizzas");
            totalPrice = pizzaController.GetPricePizza(pizzas, ingredientController, massController,sizeController);
            
        }
       
        


        public IActionResult OnPostReturn()
        {
            pizzaQuantity = HttpContext.Session.GetComplexData<int>("pizzaQuantity");

            orderComplete = HttpContext.Session.GetComplexData<int>("orderComplete");
            return Redirect("/CrearPizza/" + pizzaQuantity + "/" + orderComplete);
            

            
        }

        public IActionResult OnPostLocalization()
        {
            pizzaQuantity = HttpContext.Session.GetComplexData<int>("pizzaQuantity");

            orderComplete = HttpContext.Session.GetComplexData<int>("orderComplete");
            return Redirect("/Localization/" + pizzaQuantity + "/" + orderComplete);
        }
    }

}