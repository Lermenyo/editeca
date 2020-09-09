using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace editeca.Models.ViewModel
{
    public class RutaViewModel
    {
        public int? IdElemento { get; set; }

        [StringLength(50)]
        public string Codigo { get; set; }

        [StringLength(500)]
        public string Nombre { get; set; }

        public decimal? Longitud { get; set; }

        [StringLength(250)]
        public string Dificultad { get; set; }

        [StringLength(250)]
        public string Duración { get; set; }

        public bool? Bicicleta { get; set; }

        public bool? Caballo { get; set; }

        [StringLength(500)]
        public string Acceso { get; set; }

        public string Descripcion { get; set; }

        public string Nota { get; set; }

        public string Informacion { get; set; }

        [StringLength(500)]
        public string Cartografia { get; set; }

        public int? IBP { get; set; }

        public bool? Circular { get; set; }
    }
}