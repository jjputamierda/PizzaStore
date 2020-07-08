using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaStore.Models;


namespace PizzaStore.Models.Handlers
{
    public class IngredientHandler
    {
        public IngredientHandler() {
        }

        public int VerifyIngredients(List<IngredientModel> ingredients) {
            int answer = 0;
            if (ingredients.Count() > 0) {
                answer = 1;
            }
            return answer;
        }

        public double getPriceIngredients(List<IngredientModel> ingredients)
        {
            double totalPrice = 0;
            
            foreach (var ingredient in ingredients)
            {
                totalPrice = ingredient.price + totalPrice;
            }
            

            return totalPrice;
        }
        public List<IngredientModel> InitIngredients()
        {
            List<IngredientModel> ingredients = new List<IngredientModel> {
            new IngredientModel { name ="jam", price = 700 , type = "salty" },
            new IngredientModel { name ="bacon", price = 640 , type = "salty" },
            new IngredientModel { name ="meat", price = 650, type = "salty" },
            new IngredientModel { name ="olive", price = 630, type = "salty" },
            new IngredientModel { name ="sausage", price = 660, type = "salty" },
            new IngredientModel { name ="pepperoni", price = 620, type = "salty" },
            new IngredientModel { name ="chicken", price = 690, type = "salty" },
            new IngredientModel { name ="mushrooms", price = 650, type = "salty" },
            new IngredientModel { name ="pineapple", price = 400, type = "sweet" },
            new IngredientModel { name ="tomato", price = 500, type = "salty" },
            new IngredientModel { name ="onion", price = 650, type = "salty" },
            new IngredientModel { name ="parmesan cheese", price = 700, type = "salty" },
            new IngredientModel { name ="roman cheese", price = 660, type = "salty" },
            new IngredientModel { name ="mozzarella extra cheese", price = 700, type = "salty" },
            new IngredientModel { name ="chocolate", price = 500, type = "sweet" },
            new IngredientModel { name ="strawberries", price = 700, type = "sweet" },
            new IngredientModel { name ="nutella", price = 650, type = "sweet" },
            new IngredientModel { name ="banana", price = 600, type = "sweet" }
        };

            return ingredients;


        }

    }


}

