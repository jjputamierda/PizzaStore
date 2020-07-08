using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaStore.Models.Handlers;
using PizzaStore.Models;


namespace PizzaStore.Controllers
{
    public class MassController
    {
        public MassHandler massHandler;
        public MassController()
        {
            massHandler = new MassHandler();
        }

        public int VerifyMass(List<MassModel> mass)
        {
            int answer = massHandler.VerifyMass(mass);
            return answer;
        }

        public double GetPriceMass(List<MassModel> masses)
        {



            return massHandler.GetPriceMass(masses);
        }
        public List<MassModel> InitMass()
        {


            return massHandler.InitMasses();


        }
        public List<MassModel> NewMass(List<MassModel> masses, List<string> names)
        {
            
            return massHandler.NewMass(masses,names);
        }
    }


}


