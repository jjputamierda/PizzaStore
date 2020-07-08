﻿using System;
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
    public class CrearPizzaModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int pizzaQuantity { set; get; }
        [BindProperty]
        public List<PizzaModel> pizzas { set; get; }

        [BindProperty]
        public List<string> newIngredients { set; get; }

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
        [BindProperty]
        public List<int> deletePizzas { set; get; }



        public List<ToastOptionModel> oldToastOption { set; get; }


        public IngredientController ingredientController { set; get; }

        public MassController massController { set; get; }

        public ToastOptionController toastOptionController { set; get; }
        public PizzaController pizzaController { set; get; }
        [BindProperty(SupportsGet = true)]
        public int orderComplete { set; get; }

        public CrearPizzaModel()
        {
  
            pizzaController = new PizzaController();


            

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
            HttpContext.Session.SetComplexData("pizzaQuantity", pizzaQuantity);
            HttpContext.Session.SetComplexData("orderComplete", orderComplete);
            if (orderComplete == 1)
            {
                AvisosInmediatos.Set(this, "Complete", "The order has been completed", AvisosInmediatos.TipoAviso.Exito);
            }
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
            pizzaQuantity = HttpContext.Session.GetComplexData<int>("pizzaQuantity");

            orderComplete = HttpContext.Session.GetComplexData<int>("orderComplete" );
            if (pizzaQuantity == 0)
            {
                pizzas = new List<PizzaModel>();

            }
            else
            {

                pizzas = HttpContext.Session.GetComplexData<List<PizzaModel>>("pizzas");


            }

            orderComplete = 0;
            ingredients = ingredientController.NewIngredients(oldIngredients, newIngredients);
            toastOption = toastOptionController.NewToastOption(oldToastOption, newToastOption);
            mass = massController.NewMass(oldMass, newMass);
            if (Valid() == 1)
            {
                PizzaModel pizza = pizzaController.InitPizza(ingredients, mass, toastOption);
                pizzas = pizzaController.AddPizza(pizzas, pizza);
                pizzaQuantity = pizzaQuantity + 1;
                HttpContext.Session.SetComplexData("pizzas", pizzas);
                
                AvisosInmediatos.Set(this, "Done", "The pizza has been added, you have "+pizzaQuantity+ " pizzas", AvisosInmediatos.TipoAviso.Exito);
                return Redirect("/CrearPizza/" + pizzaQuantity + "/" + orderComplete);
            }
            else
            {

                AvisosInmediatos.Set(this, "Fail", "Please select only 1 mass and toast option and at least one ingredient", AvisosInmediatos.TipoAviso.Error);
                HttpContext.Session.SetComplexData("pizzas", pizzas);

                return Redirect("/CrearPizza/" + pizzaQuantity + "/" + orderComplete);
            }

            
        }

        public IActionResult OnPostContinue()
        {
            pizzaQuantity = HttpContext.Session.GetComplexData<int>("pizzaQuantity");
            orderComplete = HttpContext.Session.GetComplexData<int>("orderComplete");
            if (pizzaQuantity == 0)
            {
                pizzas = new List<PizzaModel>();

            }
            else
            {

                pizzas = HttpContext.Session.GetComplexData<List<PizzaModel>>("pizzas");


            }


            ingredients = ingredientController.NewIngredients(oldIngredients, newIngredients);
            toastOption = toastOptionController.NewToastOption(oldToastOption, newToastOption);
            mass = massController.NewMass(oldMass, newMass);
            orderComplete = 0;
            if (Valid() == 1)
            {
                PizzaModel pizza = pizzaController.InitPizza(ingredients, mass, toastOption);
                pizzas = pizzaController.AddPizza(pizzas, pizza);
                pizzaQuantity = pizzaQuantity + 1;
                HttpContext.Session.SetComplexData("pizzas", pizzas);

                return Redirect("/CalculatePrice/" + pizzaQuantity + "/" + orderComplete);
            }
            else
            {
                AvisosInmediatos.Set(this, "Fail", "Please select only 1 mass and toast option and at least one ingredient", AvisosInmediatos.TipoAviso.Error);
                HttpContext.Session.SetComplexData("pizzas", pizzas);

                return Redirect("/CrearPizza/" + pizzaQuantity + "/" + orderComplete);

            }


        }

        public IActionResult OnPostDelete()
        {
            
            pizzaQuantity = HttpContext.Session.GetComplexData<int>("pizzaQuantity");
            orderComplete = HttpContext.Session.GetComplexData<int>("orderComplete");


            pizzas = HttpContext.Session.GetComplexData<List<PizzaModel>>("pizzas");


            

            orderComplete = 0;
            if (deletePizzas.Count() > 0)
            {
                pizzas = pizzaController.DeletePizza(pizzas, deletePizzas);

                pizzaQuantity = pizzas.Count();
                AvisosInmediatos.Set(this, "Delete", "The pizza(s) you selected has been deleted", AvisosInmediatos.TipoAviso.Exito);
            }
            else {
                AvisosInmediatos.Set(this, "DeleteE", "You must select pizza(s) to delete", AvisosInmediatos.TipoAviso.Error);
            }

            HttpContext.Session.SetComplexData("pizzas", pizzas);
            
            return Redirect("/CrearPizza/" + pizzaQuantity + "/" + orderComplete);
        }
    }
}

