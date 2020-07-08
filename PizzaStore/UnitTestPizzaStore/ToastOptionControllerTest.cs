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
    public class ToastOptionControllerTest
    {
        
        private static ToastOptionController toastOptionController = new ToastOptionController();

        [TestMethod]
        public void ValidateSizes()

        {



            List<ToastOptionModel> toastOption = new List<ToastOptionModel>
            {

                new ToastOptionModel { name ="crunchy" }

            };

            Assert.AreEqual(toastOptionController.VerifyToastOption(toastOption), 1);
        }
       


        [TestMethod]
        public void GetInitSizes()
        {

            List<ToastOptionModel> toastOption = toastOptionController.InitToastOptions();

            Assert.AreEqual(toastOption[0].name, "crunchy");
            Assert.AreEqual(toastOption[1].name, "soft");
            Assert.AreEqual(toastOption[2].name, "middle");
           



        }

        public void newToastOption()
        {
            List<ToastOptionModel> oldToastOption = toastOptionController.InitToastOptions();

            List<String> newToastOption = new List<string>();
            newToastOption.Add("crunchy");




            List<ToastOptionModel> toastOption = new List<ToastOptionModel>();

            toastOption = toastOptionController.NewToastOption(oldToastOption, newToastOption);

            Assert.AreEqual(toastOption[0].name, "crunchy");

        }

    }
}
