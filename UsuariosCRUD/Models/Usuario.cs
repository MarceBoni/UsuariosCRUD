using System;
using System.Collections.Generic;

#nullable disable

namespace UsuariosCRUD.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public int IdTipoUsuario { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
