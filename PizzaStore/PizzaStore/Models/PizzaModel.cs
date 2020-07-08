using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.Models
{
    public class PizzaModel
    {
        [BindProperty]
        public List <IngredientModel> ingredients{ get; set; }

        [BindProperty]

        public List<MassModel> mass { get; set; }

        [BindProperty]

        public List<ToastOptionModel> tostOption { get; set; }
    }
}
