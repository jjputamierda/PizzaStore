using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaStore.Models.Handlers;
using PizzaStore.Models;


namespace PizzaStore.Controllers
{
    public class ToastOptionController
    {
        public ToastOptionHandler toastOptionHandler;
        public ToastOptionController()
        {
            toastOptionHandler = new ToastOptionHandler();
        }

        public int VerifyToastOption(List<ToastOptionModel> toastOption)
        {
            int answer = toastOptionHandler.VerifyToastOption(toastOption);
            return answer;
        }

        public string GetToastOptions(List<ToastOptionModel> toastOption)
        {



            return toastOptionHandler.GetToastOptions(toastOption);
        }
        public List<ToastOptionModel> InitToastOptions()
        {


            return toastOptionHandler.InitToastOption();


        }
        public List<ToastOptionModel> NewToastOption(List<ToastOptionModel> toastOption, List<string> names)
        {
            return toastOptionHandler.NewToastOption(toastOption, names);
        }

    }
}

