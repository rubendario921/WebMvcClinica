using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebMvcClinica.Models
{
    public partial class Especialidade
    {
        [DisplayName("Codigo")]
        public int EspId { get; set; }
        [DisplayName("Nombre")]
        public string EspName { get; set; } = null!;
        [DisplayName("Descripción")]
        public string EspDescription { get; set; } = null!;
        [DisplayName("Imagen")]
        public byte[]? EspImage { get; set; } = null;
        [DisplayName("Estado")]
        [StringLength(1)]
        public string EspStatus { get; set; } = null!;
        [DisplayName("Fecha Registro")]
        public DateTime EspAdd { get; set; }
        [DisplayName("Fecha Modificado")]
        public DateTime? EspUpdate { get; set; }
        [DisplayName("Fecha Eliminado")]
        public DateTime? EspDelete { get; set; }
    }
}
