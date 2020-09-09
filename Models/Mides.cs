namespace editeca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mides
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? IdRuta { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Medio { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Itinerario { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Desplazamiento { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Esfuerzo { get; set; }

        [StringLength(50)]
        public string Origen { get; set; }

        public virtual Rutas Rutas { get; set; }
    }
}
