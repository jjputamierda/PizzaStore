using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.Models
{
    public class IngredientModel
    {
        [BindProperty]
        public string name{ get; set; }

        [BindProperty]

        public double price { get; set; }

        [BindProperty]

        public string type { get; set; }
    }
}
