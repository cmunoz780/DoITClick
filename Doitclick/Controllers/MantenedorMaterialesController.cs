﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Doitclick.Controllers
{
    public class MantenedorMaterialesController : Controller
    {
        public IActionResult Formulario()
        {
            return View();
        }
    }
}