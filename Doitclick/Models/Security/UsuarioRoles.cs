using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doitclick.Models.Security
{
    public class UsuarioRoles
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Rol Rol { get; set; }
        public bool Activo { get; set; }
    }
}
