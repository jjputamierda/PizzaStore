﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.Models
{
    public class GeneralUbicationModel
    {
        [BindProperty]
        public string provincia{ get; set; }

        [BindProperty]

        public double canton{ get; set; }


    }
}
