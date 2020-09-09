namespace editeca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rutas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rutas()
        {
            Archivos = new HashSet<Archivos>();
            ElementosRuta = new HashSet<ElementosRuta>();
            Mides = new HashSet<Mides>();
            Tracks = new HashSet<Tracks>();
        }

        public int Id { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Archivos> Archivos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ElementosRuta> ElementosRuta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mides> Mides { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tracks> Tracks { get; set; }
    }
}
