using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doitclick.Models.Workflow
{
    public class Etapa
    {
        public int Id { get; set; }
        public Proceso Proceso { get; set; }
        public TipoEtapa TipoEtapa { get; set; }
        public string Nombre { get; set; }
        public string NombreInterno { get; set; }
        public TipoUsuarioAsignado TipoUsuarioAsignado { get; set; }
        public string ValorUsuarioAsignado { get; set; }
        public TipoDuracion? TipoDuracion { get; set; }
        public string ValorDuracion { get; set; }
        public TipoDuracion? TipoDuracionRetardo { get; set; }
        public string ValorDuracionRetardo { get; set; }
        public int Secuencia { get; set; }
        public IEnumerable<TareaAutomatica> TareasAutomaticas { get; set; }
        public IEnumerable<Transito> Destinos { get; set; }
        public IEnumerable<Transito> Actuales { get; set; }
        public IEnumerable<Tarea> Tareas { get; set; }
    }
}
