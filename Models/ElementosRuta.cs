namespace editeca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ElementosRuta")]
    public partial class ElementosRuta
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdRuta { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdElemento { get; set; }

        public bool? Inicio { get; set; }

        public bool? Fin { get; set; }

        public bool? Intermedia { get; set; }

        public int? Orden { get; set; }

        public virtual Elementos Elementos { get; set; }

        public virtual Rutas Rutas { get; set; }
    }
}
