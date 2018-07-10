using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doitclick.Models.Security
{
    public class Organizacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<Rol> Roles { get; set; }
    }
}
