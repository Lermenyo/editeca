namespace editeca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Elementos_Imagen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdElemento { get; set; }

        public int? Height { get; set; }

        public int? Width { get; set; }

        [StringLength(4)]
        public string Extension { get; set; }

        public int? Tipo { get; set; }

        public virtual Elementos Elementos { get; set; }
    }
}
