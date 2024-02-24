using System;
using System.Collections.Generic;

namespace WebMvcClinica.Models
{
    public partial class Empleado
    {
        public int EmpleId { get; set; }
        public string EmpleName { get; set; } = null!;
        public string EmpleLastname { get; set; } = null!;
        public string? EmpleAndress { get; set; }
        public string EmplePhone { get; set; } = null!;
        public string? EmpleGenero { get; set; }
        public string EmpleIdentify { get; set; } = null!;
        public DateTime EmpleDatebrithay { get; set; }
        public string EmpleStatus { get; set; } = null!;
        public string EmpleEmail { get; set; } = null!;
        public DateTime EmpleAdd { get; set; }
        public DateTime? EmpleUpdate { get; set; }
        public DateTime? EmpleDelete { get; set; }
    }
}
