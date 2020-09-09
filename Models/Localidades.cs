namespace editeca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Localidades
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Localidades()
        {
            Elementos_Vertice = new HashSet<Elementos_Vertice>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int IdElemento { get; set; }

        public int? Habitantes { get; set; }

        [StringLength(100)]
        public string NombreCapital { get; set; }

        [StringLength(100)]
        public string NombreOrigen { get; set; }

        public int? Tipo { get; set; }

        [StringLength(11)]
        public string CodigoINESuperior { get; set; }

        [Required]
        [StringLength(11)]
        public string CodigoINE { get; set; }

        [StringLength(8)]
        public string IdREL { get; set; }

        public decimal? Superficie { get; set; }

        public int? Perimetro { get; set; }

        [StringLength(6)]
        public string CodigoHojaMTN25 { get; set; }

        public virtual Elementos Elementos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elementos_Vertice> Elementos_Vertice { get; set; }
    }
}
