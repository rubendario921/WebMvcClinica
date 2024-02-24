using System;
using System.Collections.Generic;

namespace WebMvcClinica.Models
{
    public partial class Auditorium
    {
        public int AudiId { get; set; }
        public DateTime AudiFecha { get; set; }
        public string AudiUsuario { get; set; } = null!;
        public string AudiTipo { get; set; } = null!;
        public int AudiCodRegistro { get; set; }
        public string AudiEstado { get; set; } = null!;
    }
}
