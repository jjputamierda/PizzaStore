using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaStore.Models.Handlers;
using PizzaStore.Models;


namespace PizzaStore.Controllers
{
    public class IngredientController
    {
        public IngredientHandler ingredientHandler;
        public IngredientController() {
            ingredientHandler = new IngredientHandler();
        }

        public int VerifyIngredients(List<IngredientModel> ingredients) {
            int answer = ingredientHandler.VerifyIngredients(ingredients);
            return answer;
        }

        public double GetPriceIngredients(List<IngredientModel> ingredients)
        {
            
            

            return ingredientHandler.GetPriceIngredients(ingredients);
        }
        public List<IngredientModel> InitIngredients()
        {
           
     
            return ingredientHandler.InitIngredients();


        }
        public List<IngredientModel> NewIngredients(List<IngredientModel> ingredients, List<string> names)
        {
            
            return ingredientHandler.NewIngredients(ingredients,names);
        }
    }


}

