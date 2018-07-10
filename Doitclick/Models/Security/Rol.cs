using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doitclick.Models.Security
{
    public class Rol
    {
        public int Id { get; set; }
        public int RolPadreId { get; set; }
        public string Nombre { get; set; }
        public Organizacion Orzanizacion { get; set; }
        public bool Activo { get; set; }
        public List<UsuarioRoles> UsuarioRoles { get; set; }
    }
}
