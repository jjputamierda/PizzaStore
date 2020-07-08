using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaStore.Models;


namespace PizzaStore.Models.Handlers
{
    public class ToastOptionHandler
    {
        public ToastOptionHandler() {
        }

        public int VerifyIngredients(List<ToastOptionModel> toastOptions) {
            int answer = 0;
            if (toastOptions.Count() > 0) {
                answer = 1;
            }
            return answer;
        }

        public string getToastOptions(List<ToastOptionModel> toastOptions)
        {
           
            

            return toastOptions[0].name;
        }
        public List<ToastOptionModel> InitToastOption()
        {
            List<ToastOptionModel> toastOption = new List<ToastOptionModel> {
            new ToastOptionModel { name ="crunchy" },
            new ToastOptionModel { name ="soft" },
            new ToastOptionModel { name ="middle"}
            
        };

            return toastOption;


        }

    }


}

