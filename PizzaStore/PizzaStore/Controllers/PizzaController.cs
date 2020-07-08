using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaStore.Models.Handlers;
using PizzaStore.Models;


namespace PizzaStore.Controllers
{
    public class PizzaController
    {
        public PizzaHandler pizzaHandler;
        public PizzaController() {
            pizzaHandler = new PizzaHandler();
        }

        public int VerifyPizzas(List<PizzaModel> pizzas)
        {
            
            return pizzaHandler.VerifyPizzas(pizzas);
        }
        public PizzaModel InitPizza(List<IngredientModel> ingredientModels, List<MassModel> mass, List<ToastOptionModel> toastOptions)
        {


            return pizzaHandler.InitPizza(ingredientModels,mass,toastOptions);


        }

        public List<PizzaModel> DeletePizza(List<PizzaModel> pizzas, List<int> pos)
        {


            return pizzaHandler.DeletePizza(pizzas,pos);


        }

        public  List <PizzaModel> AddPizza(List<PizzaModel> pizzas, PizzaModel pizza)
        {

            return pizzaHandler.AddPizza(pizzas,pizza);


        }

        public double GetPricePizza(List<PizzaModel> pizzas, double priceIngredients, double priceMass)
        {
          
            return pizzaHandler.GetPricePizza(pizzas,priceIngredients,priceMass);
        } 
    }


}

