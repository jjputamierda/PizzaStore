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
    public class MassControllerTest
    {
        
        private static MassController massController = new MassController();

        [TestMethod]
        public void ValidateSizes()

        {



            List<MassModel> masses = new List<MassModel> {
            new MassModel { name ="thin crust", price = 700  }
            
        };

            Assert.AreEqual(massController.VerifyMass(masses), 1);
        }
        [TestMethod]
        public void GetPrice()
        {

            List<MassModel> masses = new List<MassModel> {
           
            new MassModel { name ="classic", price = 700  }
        };

            Assert.AreEqual(massController.GetPriceMass(masses), 700);
        }


        [TestMethod]
        public void GetInitMasses()
        {

            List<MassModel> masses = massController.InitMass();

            Assert.AreEqual(masses[0].name, "thin crust");
            Assert.AreEqual(masses[1].name, "classic");
            
        }

        public void NewMasses()
        {
            List<MassModel> oldMasses = massController.InitMass();

            List<String> newMasses = new List<string>();
            newMasses.Add("thin crust");




            List<MassModel> masses = new List<MassModel>();

            masses = massController.NewMass(oldMasses, newMasses);

            Assert.AreEqual(masses[0].price, 1200);

        }
    }
}
