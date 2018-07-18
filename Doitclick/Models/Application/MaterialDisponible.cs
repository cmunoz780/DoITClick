using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doitclick.Models.Application
{
    public class MaterialDisponible
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public UnidadMedida UnidadMedida { get; set; }
        public int PrecioUnidad { get; set; }
        public int StockAlerta { get; set; }

        public IEnumerable<MovimientoMaterialDisponoble> Movimientos { get; set; }
        public IEnumerable<MaterialPresupuestado> Presupuestado { get; set; }
    }
}