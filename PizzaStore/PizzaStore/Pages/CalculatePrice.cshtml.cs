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
        [BindProperty]
        public int pizzaQuantity { set; get; }
        [BindProperty]
        public List<PizzaModel> pizzas { set; get; }

        [BindProperty]
        public List<string>  newIngredients{ set; get; }

        [BindProperty]
        public List<string> newMass { set; get; }

        [BindProperty]
        public List<string> newToastOption { set; get; }


        [BindProperty]
        public List<IngredientModel> ingredients { set; get; }

        [BindProperty]
        public List<MassModel> mass { set; get; }
        [BindProperty]
        public List<ToastOptionModel> toastOption { set; get; }



        public List<IngredientModel> oldIngredients { set; get; }

        public List<MassModel> oldMass { set; get; }

        public List<int> deletePizzas { set; get; }



        public List<ToastOptionModel> oldToastOption { set; get; }


        public IngredientController ingredientController { set; get; }

        public MassController massController { set; get; }

        public ToastOptionController toastOptionController { set; get; }
        public PizzaController pizzaController { set; get; }
        [BindProperty]
        public int orderComplete { set; get; }

        public CalculatePriceModel() {
            pizzaController = new PizzaController(); 
            
            

            if (orderComplete == 1) {
                AvisosInmediatos.Set(this, "Complete", "The order has been completed", AvisosInmediatos.TipoAviso.Exito);
            }
            if (pizzaQuantity == 0)
            {
                pizzas = new List<PizzaModel>();

            }
            else {
                
                pizzas = HttpContext.Session.GetComplexData<List<PizzaModel>>("pizzas");
                
                /* HttpContext.Session.SetComplexData("listaNotificaciones", listaNotificaciones);*/
                /*LoggedUserVM loggedUser = HttpContext.Session.GetComplexData<LoggedUserVM>("loggerUser");*/
            }
            ingredientController = new IngredientController();
            massController = new MassController();
            toastOptionController = new ToastOptionController();
            newIngredients = new List<string>();
            newMass = new List<string>();
            newToastOption = new List<string>();
            oldIngredients = ingredientController.InitIngredients();
            oldMass = massController.InitMass();
            oldToastOption = toastOptionController.InitToastOptions();
            deletePizzas = new List<int>();
        }
        public void OnGet()
        {
            
        }
       
        public int Valid()
        {
            int isValid = 0;
            if (ingredientController.VerifyIngredients(ingredients) == 1 && toastOptionController.VerifyToastOption(toastOption) == 1 && massController.VerifyMass(mass) == 1)
            {
                isValid = 1;
            }
            return isValid;
        }
        public IActionResult OnPostNew()
        {
            orderComplete = 0;
            if (Valid() == 1)
            {
                PizzaModel pizza = pizzaController.InitPizza(ingredients, mass, toastOption);
                pizzas = pizzaController.AddPizza(pizzas, pizza);
                pizzaQuantity = pizzaQuantity + 1;
                HttpContext.Session.SetComplexData("pizzas", pizzas);
                HttpContext.Session.SetComplexData("pizzaQuantity", pizzaQuantity);
                AvisosInmediatos.Set(this, "Done", "The pizza has been added ", AvisosInmediatos.TipoAviso.Exito);

            }
            else {
                AvisosInmediatos.Set(this, "Fail", "Please select only 1 mass and toast option and at least one ingredient", AvisosInmediatos.TipoAviso.Error);
                
            }

            return Redirect("/CrearPizza/" + pizzaQuantity + "/" + orderComplete);
        }

        public IActionResult OnPostContinue()
        {
            orderComplete = 0;
            if (Valid() == 1)
            {
                PizzaModel pizza = pizzaController.InitPizza(ingredients,mass,toastOption);
                pizzas = pizzaController.AddPizza(pizzas, pizza);
                pizzaQuantity = pizzaQuantity + 1;
                HttpContext.Session.SetComplexData("pizzas", pizzas);
                
                return Redirect("/CalculatePrice/"+pizzaQuantity+"/"+orderComplete);
            }
            else {
                AvisosInmediatos.Set(this, "Fail", "Please select only 1 mass and toast option and at least one ingredient", AvisosInmediatos.TipoAviso.Error);
                return Redirect("/CrearPizza/" + pizzaQuantity + "/" + orderComplete);
            }

            
        }

        public IActionResult OnPostDelete()
        {
            orderComplete = 0;
            pizzas = pizzaController.DeletePizza(pizzas, deletePizzas);
            pizzaQuantity = pizzaQuantity - 1;
            HttpContext.Session.SetComplexData("pizzas", pizzas);
            
            AvisosInmediatos.Set(this, "Delete", "The pizza you selected has been deleted", AvisosInmediatos.TipoAviso.Exito);
            return Redirect("/CrearPizza/" + pizzaQuantity + "/" + orderComplete);
        }
    }

}