using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaStore.Models;


namespace PizzaStore.Models.Handlers
{
    public class MassHandler
    {
        public MassHandler()
        {
        }

        public int VerifyMass(List<MassModel> masses)
        {
            int answer = 0;
            if (masses.Count() > 0)
            {
                answer = 1;
            }
            return answer;
        }

        public double GetPriceMass(List<MassModel> masses)
        {
            double totalPrice = 0;

            foreach (var mass in masses)
            {
                totalPrice = mass.price + totalPrice;
            }


            return totalPrice;
        }
        public List<MassModel> InitMasses()
        {
            List<MassModel> masses = new List<MassModel> {
            new MassModel { name ="thin crust", price = 700  },
            new MassModel { name ="classic", price = 700  }
        };

            return masses;


        }

    }


}