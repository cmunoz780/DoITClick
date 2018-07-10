using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doitclick.Models.Security
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Identificador { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string EstadoCuenta { get; set; }
        public string TokenRecuerdaAcceso { get; set; }
        public bool Activo { get; set; }

        public List<UsuarioRoles> UsuarioRoles { get; set; }
    }
}
