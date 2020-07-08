using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaStore.Models.Handlers;
using PizzaStore.Models;


namespace PizzaStore.Controllers
{
    public class SizeController
    {
        public SizeHandler sizeHandler;
        public SizeController()
        {
            sizeHandler = new SizeHandler();
        }

        public int VerifySize(List<SizeModel> size)
        {
            int answer = sizeHandler.VerifySize(size);
            return answer;
        }

        public double GetPriceSize(List<SizeModel> sizes)
        {



            return sizeHandler.GetPriceSize(sizes);
        }
        public List<SizeModel> InitSizes()
        {


            return sizeHandler.InitSizes();


        }
        public List<SizeModel> NewSize(List<SizeModel> sizes, List<string> names)
        {
            
            return sizeHandler.NewSize(sizes,names);
        }
    }


}


