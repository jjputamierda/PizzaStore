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
    public class SizeControllerTest
    {
        
        private static SizeController sizeController = new SizeController();
        
        [TestMethod]
        public void ValidateSizes()

        {

            

            List<SizeModel> sizes = new List<SizeModel> {
        


            };
           
            Assert.AreEqual(sizeController.VerifySize(sizes), 0);
        }
        [TestMethod]
        public void GetPrice() {

            List<SizeModel> sizes = new List<SizeModel> {
           
            new SizeModel { name ="12 slices", price = 6000  }


            };

            Assert.AreEqual(sizeController.GetPriceSize(sizes), 6000);
        }

       
        [TestMethod]
        public void GetInitSizes()
        {

            List<SizeModel> sizes = sizeController.InitSizes();

            Assert.AreEqual(sizes[0].name, "4 slices");
            Assert.AreEqual(sizes[1].price, 2400);
            Assert.AreEqual(sizes[2].name, "8 slices");
            Assert.AreEqual(sizes[3].price, 4800);


           
        }

        public void NewSizes() {
            List<SizeModel> oldSizes = sizeController.InitSizes();

            List<String> newSizes = new List<string>();
            newSizes.Add("4 slices");
            



            List<SizeModel> sizes = new List<SizeModel>();

            sizes = sizeController.NewSize(oldSizes, newSizes);

            Assert.AreEqual(sizes[0].price, 1200);

        }

    }
}
