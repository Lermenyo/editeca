namespace editeca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Elementos_Foto
    {
        public DateTime? Fecha { get; set; }

        [Key]
        [Column(Order = 0)]
        public bool Propia { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdElemento { get; set; }

        public bool? Seleccion { get; set; }

        public virtual Elementos Elementos { get; set; }
    }
}
