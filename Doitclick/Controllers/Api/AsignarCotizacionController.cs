using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Doitclick.Data;
using Doitclick.Models.Application;
using Doitclick.Services.Workflow;
using Microsoft.EntityFrameworkCore;

namespace Doitclick.Controllers.Api
{
    [Route("api/asigna-cotizacion")]
    [ApiController]
    public class AsignarCotizacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AsignarCotizacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ICollection<Cotizacion> ListaCotizaciones()
        {
            var cotizaciones = _context.Cotizaciones.Include(c => c.Cliente).Where(c => c.FechaExpiracion >= DateTime.Now && c.EstadoEvaluacion == EstadoEvaluacion.SinEvaluar && c.EsOT == false).ToList();
            return cotizaciones;
        }
    }
}