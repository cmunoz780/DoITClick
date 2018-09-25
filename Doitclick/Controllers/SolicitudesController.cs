using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Doitclick.Models.Security;
using Doitclick.Data;
using Microsoft.EntityFrameworkCore;

namespace Doitclick.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SolicitudesController (ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult SolicitudMaterialMensual()
        {
            ViewBag.listMat = _context.MaterialesMensuales.ToList();
            return View();
        }

    }
}