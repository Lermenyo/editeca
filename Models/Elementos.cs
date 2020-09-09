namespace editeca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Elementos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Elementos()
        {
            Elementos_Documento = new HashSet<Elementos_Documento>();
            Elementos_Entidad = new HashSet<Elementos_Entidad>();
            Elementos_Foto = new HashSet<Elementos_Foto>();
            Elementos_Monumento = new HashSet<Elementos_Monumento>();
            Elementos_Vertice = new HashSet<Elementos_Vertice>();
            ElementosRuta = new HashSet<ElementosRuta>();
            Localidades = new HashSet<Localidades>();
            Coordenadas = new HashSet<Coordenadas>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Icono { get; set; }

        [Required]
        [StringLength(150)]
        public string Permalink { get; set; }

        [StringLength(150)]
        public string DescripcionCorta { get; set; }

        public DateTime Create { get; set; }

        public int ImportanciaIntrinseca { get; set; }

        public int? IdTipoElemento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elementos_Documento> Elementos_Documento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elementos_Entidad> Elementos_Entidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elementos_Foto> Elementos_Foto { get; set; }

        public virtual Elementos_Imagen Elementos_Imagen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elementos_Monumento> Elementos_Monumento { get; set; }

        public virtual TiposElemento TiposElemento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elementos_Vertice> Elementos_Vertice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ElementosRuta> ElementosRuta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Localidades> Localidades { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Coordenadas> Coordenadas { get; set; }
    }
}
