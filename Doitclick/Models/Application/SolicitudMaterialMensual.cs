using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doitclick.Models.Application
{
    public class SolicitudMaterialMensual
    {
        public int Id { get; set; }
        public string Solicitante {get;set;}
        public int Cantidad {get;set;}
        public string Descripcion {get;set;}
        public DateTime FechaSolicitud {get;set;}
        public int Estado {get;set;}
        public string MotivoRechazo {get;set;}
        public DateTime FechaCierre {get;set;}
        
    }
}
