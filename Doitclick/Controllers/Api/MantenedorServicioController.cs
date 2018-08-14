using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Doitclick.Data;
using Doitclick.Models.Application;
using Doitclick.Services.Workflow;

namespace Doitclick.Controllers.Api
{
    [Route("api/mantenedor/servicios")]
    [ApiController]
    public class MantenedorServicioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        public MantenedorServicioController(ApplicationDbContext context )
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> GuardarIngresoServicio([FromBody]  Doitclick.Models.Helper.ServicioFormularioIngreso servicios)
        {
            //Generar modelo de cliente que en este caso es un paciente que viene a la oficina
           Servicio _servicio = new Servicio
           {
                Nombre=servicios.NombreServicio,
                Resumen=servicios.DescripcionServicio,
                Codigo=servicios.CodigoServicio,
                ValorManoObra= servicios.VManoObra,
                ValorMateriales= servicios.ValorMateriales,
                ValorComision=servicios.ValorComision,
                PorcentajeComision=servicios.PorcentajeComision,
                ValorTotal=servicios.ValorTotal
           };
            //_context.MaterialesDiponibles.Add(_servicio);
            _context.Servicios.Add(_servicio);
            var respuesta = await _context.SaveChangesAsync();
                return Ok("Datos guardados");
        }

       
        


    }
}