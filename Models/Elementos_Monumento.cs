namespace editeca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Elementos_Monumento
    {
        public int Id { get; set; }

        public int IdElemento { get; set; }

        [StringLength(500)]
        public string OtrasDenominaciones { get; set; }

        [StringLength(500)]
        public string Origen { get; set; }

        public int? IdExterno { get; set; }

        public int? IdSuperior { get; set; }

        [StringLength(11)]
        public string Codigo { get; set; }

        public string CodigoSuperior { get; set; }

        public bool? Visitable { get; set; }

        public bool? AccesoLibre { get; set; }

        public string Horario { get; set; }

        public decimal? Precio { get; set; }

        public DateTime? FechaPrecio { get; set; }

        public virtual Elementos Elementos { get; set; }
    }
}
