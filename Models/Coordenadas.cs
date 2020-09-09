namespace editeca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Coordenadas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Coordenadas()
        {
            Elementos = new HashSet<Elementos>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(25)]
        public string ETRS89GeograficasLatitud { get; set; }

        [StringLength(25)]
        public string ETRS89GeograficasLongitud { get; set; }

        public decimal? ETRS89GeograficasHelipBP { get; set; }

        public decimal? ETRS89GeograficasHelipCF { get; set; }

        public decimal? ETRS89GeograficasDesvTipicaMLat { get; set; }

        public decimal? ETRS89GeograficasDesvTipicaMLon { get; set; }

        public decimal? ETRS89GeograficasDesvTipicaMH { get; set; }

        public decimal? ETRS89UTMX { get; set; }

        public decimal? ETRS89UTMY { get; set; }

        public int? ETRS89UTMHuso { get; set; }

        [StringLength(25)]
        public string ED50GeograficasLatitud { get; set; }

        [StringLength(25)]
        public string ED50GeograficasLongitud { get; set; }

        public decimal? ED50UTMX { get; set; }

        public decimal? ED50UTMY { get; set; }

        public int? ED50UTMHuso { get; set; }

        public decimal? HOrtomBP { get; set; }

        public int? Altitud { get; set; }

        public DbGeography CoordenadaGeografica { get; set; }

        public decimal? Latitud { get; set; }

        public decimal? Longitud { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elementos> Elementos { get; set; }
    }
}
