using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Doitclick.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FlujoInternoController : Controller
    {
        public IActionResult IngresoDatosPaciente()
        {
            return View();
        }

        public IActionResult AsignarTrabajo()
        {
            return View();
        }

        public IActionResult EvaluarTrabajo()
        {
            return View();
        }

        public IActionResult AsignarCotizacion()
        {
            return View();
        }

        public IActionResult EvaluarCotizacion()
        {
            return View();
        }

        public IActionResult EjecutarTrabajo()
        {
            return View();
        }


    }
}