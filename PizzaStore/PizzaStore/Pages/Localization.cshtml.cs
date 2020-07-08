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
    public class LocalizationModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int pizzaQuantity { set; get; }


        [BindProperty]
        public List<PizzaModel> pizzas { set; get; }







        [BindProperty(SupportsGet = true)]
        public int orderComplete { set; get; }

        [BindProperty]
        public string address { set; get; }
        public LocalizationModel()
        {
            address = null;

        }
        public void OnGet()
        {
            HttpContext.Session.SetComplexData("pizzaQuantity", pizzaQuantity);
            HttpContext.Session.SetComplexData("orderComplete", orderComplete);
            
        }




        public IActionResult OnPostFinish()
        {

            pizzaQuantity = HttpContext.Session.GetComplexData<int>("pizzaQuantity");

            orderComplete = HttpContext.Session.GetComplexData<int>("orderComplete");

            if (address != null)
            {
                orderComplete = 1;
                pizzas = HttpContext.Session.GetComplexData<List<PizzaModel>>("pizzas");
                pizzas = new List<PizzaModel>();
                pizzaQuantity = 0;
                HttpContext.Session.SetComplexData("pizzas", pizzas);

                return Redirect("/CrearPizza/" + pizzaQuantity + "/" + orderComplete);

            }
            else
            {
                AvisosInmediatos.Set(this, "Fail", "Please introduce an address ", AvisosInmediatos.TipoAviso.Error);
                return Redirect("/Localization/" + pizzaQuantity + "/" + orderComplete);
               
            }
        }

        public IActionResult OnPostReturn()
        {
            pizzaQuantity = HttpContext.Session.GetComplexData<int>("pizzaQuantity");

            orderComplete = HttpContext.Session.GetComplexData<int>("orderComplete");
            return Redirect("/CalculatePrice/" + pizzaQuantity + "/" + orderComplete);
        }
    }
}