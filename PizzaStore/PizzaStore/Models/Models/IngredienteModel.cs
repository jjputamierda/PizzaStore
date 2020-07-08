using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.Models.Models
{
    public class IngredienteModel
    {
        [BindProperty]
        public string  nombre{ get; set; }

        [BindProperty]

        public double precio { get; set; }
    }
}
