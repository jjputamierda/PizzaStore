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

        public int VerifyToastOption(List<ToastOptionModel> toastOptions) {
            int answer = 0;
            if (toastOptions.Count() ==1) {
                answer = 1;
            }
            return answer;
        }

        public string GetToastOptions(List<ToastOptionModel> toastOptions)
        {
           
            

            return toastOptions[0].name;
        }
        public List<ToastOptionModel> NewToastOption(List<ToastOptionModel> toastOption, List<string> names)
        {
            List<ToastOptionModel> newToastOption = new List<ToastOptionModel>();
            int i = 0;
            foreach (var top in toastOption)
            {
                if (i < names.Count())
                {

                    if (top.name == names[i])
                    {
                        ToastOptionModel t = new ToastOptionModel();
                        t.name = top.name;

                        newToastOption.Add(t);
                        i++;
                    }
                }
            }
            return newToastOption;
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

