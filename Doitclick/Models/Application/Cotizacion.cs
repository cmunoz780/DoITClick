using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doitclick.Models.Application
{
    public class Cotizacion
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string NumeroTicket { get; set; }
        public string Resumen { get; set; }
        public int PrecioCotizacion { get; set; }
        public IEnumerable<ItemCotizar> ItemsCotizar { get; set; }
    }
}
