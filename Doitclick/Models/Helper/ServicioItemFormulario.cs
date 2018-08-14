using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doitclick.Models.Helper
{
    public class ServicioItemFormulario
    {
        public string id { get; set; }
        public string texto { get; set; }
        public string descripcion { get; set; }
        public string valor { get; set; }
        public string cantidad { get; set; }
    }
    public class ServicioFormularioIngreso
    {
                public string NombreServicio     {get;set;}
                public string DescripcionServicio{get;set;}
                public string CodigoServicio     {get;set;}
                public int VManoObra          {get;set;}
                public int ValorMateriales    {get;set;}
                public int ValorComision      {get;set;}
                public int PorcentajeComision {get;set;}
                public int ValorTotal         {get;set;}        

    }
    
}
