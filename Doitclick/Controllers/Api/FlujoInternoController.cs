using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Doitclick.Data;
using Doitclick.Models.Application;

namespace Doitclick.Controllers.Api
{
    [Route("api/flujo-interno")]
    [ApiController]
    public class FlujoInternoController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public FlujoInternoController(ApplicationDbContext context)
        {
            _context = context;
        }


        [Route("ingreso-datos-paciente")]
        [HttpPost]
        public async Task<IActionResult> GuardarIngresoDatosPaciente([FromBody]  Doitclick.Models.Helper.FomularioIngresoDatosPaciente paciente)
        {

            Cliente _paciente = new Cliente
            {
                Nombres = paciente.NombrePaciente + " " + paciente.ApellidosPaciente,
                Rut = paciente.RutPaciente,
                TipoCliente = TipoCliente.Paciente,
                EsPersonalidadJuridica = false,
                PrevisionSalud = _context.PrevisionesSalud.Where(p => p.Id == 1).FirstOrDefault()
            };

            _context.Clientes.Add(_paciente);


            var respuesta = await _context.SaveChangesAsync();

            return Ok("Datos guardados");

        }


        [Route("listado-pacientes")]
        [HttpGet]
        public IActionResult ListarPacientes()
        {

            var clientes = _context.Clientes;
            
            return Ok(clientes);

        }



    }
}