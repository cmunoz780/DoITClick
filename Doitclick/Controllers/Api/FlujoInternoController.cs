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
    [Route("api/flujo-interno")]
    [ApiController]
    public class FlujoInternoController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IWorkflowService _wfService;

        public FlujoInternoController(ApplicationDbContext context, IWorkflowService wfService)
        {
            _context = context;
            _wfService = wfService;
        }


        [Route("ingreso-datos-paciente")]
        [HttpPost]
        public async Task<IActionResult> GuardarIngresoDatosPaciente([FromBody]  Doitclick.Models.Helper.FomularioIngresoDatosPaciente paciente)
        {
            //Generar modelo de cliente que en este caso es un paciente que viene a la oficina
            Cliente _paciente = new Cliente
            {
                Nombres = paciente.NombrePaciente + " " + paciente.ApellidosPaciente,
                Rut = paciente.RutPaciente,
                TipoCliente = TipoCliente.Paciente,
                EsPersonalidadJuridica = false,
                PrevisionSalud = _context.PrevisionesSalud.Where(p => p.Id == 1).FirstOrDefault()
            };

            /*MetaDatosCliente _pacienteApellidos = new MetaDatosCliente
            {
                Cliente = _paciente,
                Clave = "Apellidos",
                Valor = paciente.ApellidosPaciente,
                Orden = 1
            };

            MetaDatosCliente _pacienteNombres = new MetaDatosCliente
            {
                Cliente = _paciente,
                Clave = "Nombres",
                Valor = paciente.NombrePaciente,
                Orden = 2
            };

            _context.MetadatosClientes.Add(_pacienteApellidos);
            _context.MetadatosClientes.Add(_pacienteNombres);*/

            //Generar instancia WF ya que aqui es donde empieza todo el proceso
            string resumen = "Resumen de pruebas";//paciente.RutPaciente + ", " + _paciente.Nombres + ", [Paciente|"+_paciente.PrevisionSalud.Nombre+"]";
            _wfService.Instanciar("FlujoPruebas", "17042783-1", resumen);

            //Guardar datos paciente en base de datos
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