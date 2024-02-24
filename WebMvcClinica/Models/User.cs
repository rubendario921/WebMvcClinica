using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebMvcClinica.Models
{
    public partial class User
    {
        [DisplayName("Codigo")]
        public int UsuId { get; set; }
        [DisplayName("Usuario")]
        public string UsuUser { get; set; } = null!;
        [DisplayName("Contraseña")]
        public string UsuPassword { get; set; } = null!;
        [DisplayName("Nombres")]
        public string UsuName { get; set; } = null!;
        [DisplayName("Apellidos")]
        public string UsuLastname { get; set; } = null!;
        [DisplayName("Correo")]
        public string UsuEmail { get; set; } = null!;
        [DisplayName("Sueldo")]
        public decimal UsuSueldo { get; set; }
        [DisplayName("Estado")]
        public string UsuStatus { get; set; } = null!;
        [DisplayName("Imagen")]
        public byte[]? UsuImage { get; set; } = null;
        [DisplayName("Intentos")]
        public int? UsuIntentos { get; set; }
        [DisplayName("Perfil")]
        public int? UsuPerfil { get; set; }
        public DateTime? UsuAdd { get; set; }
        public DateTime? UsuUpdate { get; set; }
        public DateTime? UsuDelete { get; set; }
        public int RolId { get; set; }
        public virtual Role Rol { get; set; } = null!;


    }
}
