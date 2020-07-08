using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaStore.Models;
using PizzaStore.Controllers;


namespace PizzaStore.Models.Handlers
{
    public class PizzaHandler
    {
        public PizzaHandler() {
        }

        
        public PizzaModel InitPizza(List<IngredientModel> ingredientModels, List<MassModel> mass, List<ToastOptionModel> toastOptions)
        {
            PizzaModel pizza = new PizzaModel();
            pizza.ingredients = ingredientModels;
            pizza.mass = mass;
            pizza.tostOption = toastOptions;

            return pizza;


        }

        public List<PizzaModel> DeletePizza(List<PizzaModel> pizzas, int pos)
        {
            pizzas.RemoveAt(pos);

            return pizzas;


        }

        public  List <PizzaModel> AddPizza(List<PizzaModel> pizzas, PizzaModel pizza)
        {
            pizzas.Add(pizza);

            return pizzas;


        }

        public double GetPricePizza(List<PizzaModel> pizzas, IngredientController ingredientController, MassController massController) {
            double price = 0;
            foreach(var pizza in pizzas)
            {
                price = ingredientController.GetPriceIngredients(pizza.ingredients) + price;
                price = massController.GetPriceMass(pizza.mass) + price;
                
            }
            price = price + price * 0.3;
            price = price + 13 * price;
            return price;
        } 
    }


}

