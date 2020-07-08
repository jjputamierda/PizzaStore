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

        public int VerifyPizzas(List<PizzaModel> pizzas)
        {
            int answer = 0;
            if (pizzas.Count() > 0)
            {
                answer = 1;
            }
            return answer;
        }
        public PizzaModel InitPizza(List<IngredientModel> ingredientModels, List<MassModel> mass, List<ToastOptionModel> toastOptions)
        {
            PizzaModel pizza = new PizzaModel();
            pizza.ingredients = ingredientModels;
            pizza.mass = mass;
            pizza.toastOption = toastOptions;

            return pizza;


        }

        public List<PizzaModel> DeletePizza(List<PizzaModel> pizzas, List<int> pos)
        {
            foreach (var p in pos) {
                pizzas.RemoveAt(p);
            }
            

            return pizzas;


        }

        public  List <PizzaModel> AddPizza(List<PizzaModel> pizzas, PizzaModel pizza)
        {
            pizzas.Add(pizza);

            return pizzas;


        }

        public double GetPricePizza(List<PizzaModel> pizzas, double priceIngredient, double priceMass) {
            double price = 0;
            foreach(var pizza in pizzas)
            {
                
                price = priceIngredient + priceMass;
                
            }
            price = price + price * 0.3;
            price = price + 13 * price;
            return price;
        } 
    }


}

