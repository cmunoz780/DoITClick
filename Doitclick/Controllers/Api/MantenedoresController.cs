﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Doitclick.Models.Helper.Mantenedores;
using Doitclick.Models.Security;
using Doitclick.Models.Application;
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

        
        [Route("servicios/eliminar/{id}")]
        public IActionResult EliminarServicio([FromRoute] int id)
        {
           try{
                _context.Servicios.Remove(_context.Servicios.Find(id));
                _context.SaveChanges();
                return Ok("Eliminamos cauros: " + id);
           }catch(Exception ex){
               return BadRequest("Error registo con dependencias");
           }
           
        }
        [Route("instrumento/guardar")]
        public IActionResult GuardarInstrumento([FromBody] FormInstrumento entrada)
        {
            Instrumento elInstrumento = null;
            if(entrada.Id > 0)
            {
                elInstrumento = _context.Instrumentos.Find(entrada.Id);
                elInstrumento.Codigo = entrada.CodigoInstrumento;
                elInstrumento.Nombre = entrada.NombreInstrumento;
            }
            else
            {
                elInstrumento = new Instrumento();
                elInstrumento.Nombre = entrada.NombreInstrumento;
                elInstrumento.Codigo = entrada.CodigoInstrumento;
                _context.Instrumentos.Add(elInstrumento);
            }
            _context.SaveChanges();

            return Ok("Datos guardados exitosamnte");
        }
        
        [Route("instrumento/eliminar/{id}")]
        public IActionResult Eliminarinstrumento([FromRoute] int id)
        {
            _context.Instrumentos.Remove(_context.Instrumentos.Find(id));
            _context.SaveChanges();
            return Ok("Instrumento Eliminado");
        }
         [Route("tipounidadmedida/guardar")]
        public IActionResult GuardarTipoMedida([FromBody] FormTipoMedida entrada)
        {
            TipoUnidadMedida eltipounidadmedida = null;
            if(entrada.Id > 0)
            {
                eltipounidadmedida = _context.TiposUnidadMedidas.Find(entrada.Id);
                eltipounidadmedida.Nombre = entrada.NombreTipoMedida;
            }
            else
            {
                eltipounidadmedida = new TipoUnidadMedida();
                 eltipounidadmedida.Nombre = entrada.NombreTipoMedida;
                _context.TiposUnidadMedidas.Add(eltipounidadmedida);
            }
            _context.SaveChanges();

            return Ok("Datos Guardados");
        }

        [Route("tipounidadmedida/eliminar/{id}")]
        public IActionResult EliminarTipoMedida([FromRoute] int id)
        {
            _context.TiposUnidadMedidas.Remove(_context.TiposUnidadMedidas.Find(id));
            _context.SaveChanges();
            return Ok("Unidad Medida Eliminado");
        }
        [Route("materialmensual/guardar")]
        public IActionResult GuardarMaterialMensual([FromBody] FormMaterialMensual entrada)
        {
            MaterialMensual elmaterialmensual = null;
            if(entrada.Id > 0)
            {
                elmaterialmensual= _context.MaterialesMensuales.Find(entrada.Id);
                elmaterialmensual.Nombre=entrada.Nombre;
                elmaterialmensual.Descripcion=entrada.Descripcion;
                elmaterialmensual.UnidadMedida=_context.TiposUnidadMedidas.Find(entrada.sslUnidadMedida);
                elmaterialmensual.Cantidad=entrada.Cantidad;
                elmaterialmensual.StockAlerta=entrada.Stock;
            }
            else
            {
                elmaterialmensual = new MaterialMensual();
                elmaterialmensual.Nombre = entrada.Nombre;
                elmaterialmensual.Descripcion=entrada.Descripcion;
                elmaterialmensual.UnidadMedida=_context.TiposUnidadMedidas.Find(entrada.sslUnidadMedida);
                elmaterialmensual.Cantidad=entrada.Cantidad;
                elmaterialmensual.StockAlerta=entrada.Stock;

                _context.MaterialesMensuales.Add(elmaterialmensual);
            }
            _context.SaveChanges();

            return Ok("Datos Guardados");
        }
        [Route("materialmensual/eliminar/{id}")]
        public IActionResult EliminarMaterialMensual([FromRoute] int id)
        {
            _context.MaterialesMensuales.Remove(_context.MaterialesMensuales.Find(id));
            _context.SaveChanges();
            return Ok("Material Eliminado");
        }

        [Route("cliente/guardar")]
        public IActionResult GuardarCliente([FromBody] FormCliente entrada)
        {
            Cliente elcliente = null;
            if(entrada.Id > 0)
            {
                elcliente= _context.Clientes.Find(entrada.Id);
                elcliente.Rut=entrada.RutCliente;
                elcliente.Nombres=entrada.NombreCliente;
                elcliente.TipoCliente=Enum.Parse<TipoCliente>(entrada.tipocliente);
                elcliente.EsPersonalidadJuridica=entrada.optradio==1;
                elcliente.PrevisionSalud=_context.PrevisionesSalud.Find(entrada.prevision);
            }
            else
            {
                elcliente = new Cliente();
                elcliente.Rut=entrada.RutCliente;
                elcliente.Nombres=entrada.NombreCliente;
                elcliente.TipoCliente=Enum.Parse<TipoCliente>(entrada.tipocliente);
                elcliente.EsPersonalidadJuridica=(entrada.optradio==1);
                elcliente.PrevisionSalud=_context.PrevisionesSalud.Find(entrada.prevision);

                _context.Clientes.Add(elcliente);
            }
            _context.SaveChanges();

            return Ok("Datos Guardados");
        }
        [Route("cliente/eliminar/{id}")]
        public IActionResult EliminarCliente([FromRoute] int id)
        {
            _context.Clientes.Remove(_context.Clientes.Find(id));
            _context.SaveChanges();
            return Ok("Cliente Eliminado");
        }
        

    }
}