using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using PizzaStore.Models;
using PizzaStore.Controllers;
using PizzaStore.Models.Handlers;
using PizzaStore.Pages;
namespace UnitTestPizzaStore
{
    [TestClass]
    public class IngredientControllerTest
    {
        private static IngredientController ingredientController = new IngredientController();

        [TestMethod]
        public void ValidateSizes()

        {



            List<IngredientModel> ingredients = new List<IngredientModel> {
            new IngredientModel { name ="jam", price = 700 , type = "salty" },
            new IngredientModel { name ="bacon", price = 640 , type = "salty" },
            new IngredientModel { name ="meat", price = 650, type = "salty" },
            new IngredientModel { name ="olive", price = 630, type = "salty" },
            new IngredientModel { name ="sausage", price = 660, type = "salty" },
            
            new IngredientModel { name ="pineapple", price = 400, type = "sweet" },
            new IngredientModel { name ="chocolate", price = 500, type = "sweet" },
            new IngredientModel { name ="strawberries", price = 700, type = "sweet" },
            new IngredientModel { name ="nutella", price = 650, type = "sweet" },
            new IngredientModel { name ="banana", price = 600, type = "sweet" }
        };
            Assert.AreEqual(ingredientController.VerifyIngredients(ingredients), 1);
        }
        [TestMethod]
        public void GetPrice()
        {

            List<IngredientModel> ingredients = new List<IngredientModel> {
            new IngredientModel { name ="jam", price = 700 , type = "salty" },
            new IngredientModel { name ="bacon", price = 640 , type = "salty" },
            new IngredientModel { name ="meat", price = 650, type = "salty" },
            new IngredientModel { name ="olive", price = 630, type = "salty" },
     
        };

            Assert.AreEqual(ingredientController.GetPriceIngredients(ingredients), 2620);
        }


        [TestMethod]
        public void GetInitIngredients()
        {

            List<IngredientModel> ingredients = ingredientController.InitIngredients();

            Assert.AreEqual(ingredients[0].name, "jam");
            Assert.AreEqual(ingredients[1].price, 640);
            Assert.AreEqual(ingredients[2].name, "meat");
            Assert.AreEqual(ingredients[3].price, 630);



        }

        public void NewIngredients()
        {
            List<IngredientModel> oldIngredients = ingredientController.InitIngredients();

            List<String> newIngredients = new List<string>();
            newIngredients.Add("pineapple");
            newIngredients.Add("chocolate");
            newIngredients.Add("strawberries");
            newIngredients.Add("nutella");
            



            List<IngredientModel> ingredients = new List<IngredientModel>();

            ingredients = ingredientController.NewIngredients(oldIngredients, newIngredients);

            Assert.AreEqual(ingredients[0].name, "pineapple");
            Assert.AreEqual(ingredients[1].name, "chocolate");
            Assert.AreEqual(ingredients[2].name, "strwberries");
            Assert.AreEqual(ingredients[3].name, "nutella");
        }
    }
}
