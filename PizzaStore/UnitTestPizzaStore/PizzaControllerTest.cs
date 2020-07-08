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
    public class PizzaControllerTest
    {
        private static PizzaController pizzaController = new PizzaController();
        private static MassController massController = new MassController();
        private static IngredientController ingredientController = new IngredientController();
        private static SizeController sizeController = new SizeController();
        [TestMethod]
        public void GetPrice()

        {
            List <MassModel >mass = new List<MassModel> { new MassModel { name = "thin crust", price = 700 } };
            List<SizeModel> sizes = new List<SizeModel> {
            new SizeModel { name ="4 slices", price = 1200  }
            };
            List<ToastOptionModel> toastOption = new List<ToastOptionModel> {
            new ToastOptionModel { name ="crunchy" } };

            List<IngredientModel> ingredients = new List<IngredientModel> {
            new IngredientModel { name ="jam", price = 700 , type = "salty" },
            
        };



            List<PizzaModel> pizzasMock = new List<PizzaModel> {
                new PizzaModel{mass= mass, size = sizes, toastOption= toastOption,ingredients = ingredients}
                
            };
            Assert.AreEqual(pizzaController.GetPricePizza(pizzasMock,ingredientController,massController,sizeController), 3819.4);


        }
        [TestMethod]
        public void VeryfyPizza() {
            List<MassModel> mass = new List<MassModel> { new MassModel { name = "classic", price = 700 } };
            List<SizeModel> sizes = new List<SizeModel> {
            new SizeModel { name ="6 slices", price = 2400  }
            };
            List<ToastOptionModel> toastOption = new List<ToastOptionModel> {
            new ToastOptionModel { name ="soft" } };

            List<IngredientModel> ingredients = new List<IngredientModel> {
            new IngredientModel { name ="pineapple", price = 400 , type = "sweet" },

        };
            List<PizzaModel> pizzasMock = new List<PizzaModel> {
                new PizzaModel{mass= mass, size = sizes, toastOption= toastOption,ingredients = ingredients}

            };
            Assert.AreEqual(pizzaController.VerifyPizzas(pizzasMock), 1);

        }

        [TestMethod]
        public void DeletePizza()
        {
            List<MassModel> mass = new List<MassModel> { new MassModel { name = "thin crust", price = 700 } };
            List<SizeModel> sizes = new List<SizeModel> {
            new SizeModel { name ="8 slices", price = 3600  }
            };
            List<ToastOptionModel> toastOption = new List<ToastOptionModel> {
            new ToastOptionModel { name ="crunchy" } };

            List<IngredientModel> ingredients = new List<IngredientModel> {
            new IngredientModel { name ="pineapple", price = 400 , type = "sweet" },

        };
            List<PizzaModel> pizzasMock = new List<PizzaModel> {
                new PizzaModel{mass= mass, size = sizes, toastOption= toastOption,ingredients = ingredients}

            };
            List<int> num = new List<int>();
            num.Add(0);
            pizzasMock = pizzaController.DeletePizza(pizzasMock, num);

            Assert.AreEqual(pizzaController.VerifyPizzas(pizzasMock), 0);

        }
    }
}
