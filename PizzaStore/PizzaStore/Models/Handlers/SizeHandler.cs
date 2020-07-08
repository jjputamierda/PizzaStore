using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaStore.Models;


namespace PizzaStore.Models.Handlers
{
    public class SizeHandler
    {
        public SizeHandler()
        {
        }

        public List<SizeModel> NewSize(List<SizeModel> sizes, List<string> names) {
            List<SizeModel> newSize = new List<SizeModel>();
            int i = 0;
            foreach (var size in sizes) {

                if (i < names.Count())
                {
                    if (size.name == names[i])
                    {
                        SizeModel s = new SizeModel();
                        s.name = size.name;
                        s.price = size.price;
                        newSize.Add(s);
                        i++;
                    }
                }
            }
            return newSize;
        }

        public int VerifySize(List<SizeModel> sizes)
        {
            int answer = 0;
            if (sizes.Count() == 1)
            {
                answer = 1;
            }
            return answer;
        }

        public double GetPriceSize(List<SizeModel> sizes)
        {
            double totalPrice = 0;

            foreach (var size in sizes)
            {
                totalPrice = size.price + totalPrice;
            }


            return totalPrice;
        }
        public List<SizeModel> InitSizes()
        {
            List<SizeModel> sizes = new List<SizeModel> {
            new SizeModel { name ="4 slices", price = 1200  },
            new SizeModel { name ="6 silces", price = 2400  },
            new SizeModel { name ="8 slices", price = 3600  },
            new SizeModel { name ="10 silces", price = 4800  },
            new SizeModel { name ="12 slices", price = 6000  }
         

            };

            return sizes;


        }

    }


}