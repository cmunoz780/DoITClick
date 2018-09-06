using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Doitclick.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Doitclick.Models.Application;

namespace Doitclick.Controllers
{
  //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MantenedorClienteController : Controller
    {
         private readonly ApplicationDbContext _context;
        public MantenedorClienteController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Formulario()
        {
            ViewBag.TiposCliente = (TipoCliente[])Enum.GetValues(typeof(TipoCliente));
            ViewBag.PrevisionesSalud = _context.PrevisionesSalud.ToList();
            return View();
        }
    }
}