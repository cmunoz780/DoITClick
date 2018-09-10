using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Doitclick.Models.Helper.Mantenedores;
using Doitclick.Models.Security;
using Doitclick.Data;

namespace Doitclick.Controllers.Api
{
    [Route("api/mantenedores")]
    [ApiController]
    public class MantenedoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MantenedoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("organizacion/guardar")]
        public IActionResult GuardarOrganzacion([FromBody] FormOrganizacion entrada)
        {
            Organizacion laOrganizacion = null;
            if(entrada.Id > 0)
            {
                laOrganizacion = _context.Organizaciones.Find(entrada.Id);
                laOrganizacion.Nombre = entrada.Nombre;
                laOrganizacion.TipoOrganizacion = Enum.Parse<TipoOrganizacion>(entrada.TipoOrganizacion);
            }
            else
            {
                laOrganizacion = new Organizacion();
                laOrganizacion.Nombre = entrada.Nombre;
                laOrganizacion.TipoOrganizacion = Enum.Parse<TipoOrganizacion>(entrada.TipoOrganizacion);
                _context.Organizaciones.Add(laOrganizacion);
            }
            _context.SaveChanges();

            return Ok("Salimos cauros!! " + entrada.Nombre);
        }

        [Route("organizacion/eliminar/{id}")]
        public IActionResult EliminarOrganzacion([FromRoute] int id)
        {
            _context.Organizaciones.Remove(_context.Organizaciones.Find(id));
            _context.SaveChanges();
            return Ok("Eliminamos cauros: " + id);
        }

    }
}