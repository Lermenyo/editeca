namespace editeca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Points
    {
        public long Id { get; set; }

        public decimal? lat { get; set; }

        public decimal? lon { get; set; }

        public decimal? ele { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? date { get; set; }

        public int? IdTrack { get; set; }

        public int? Orden { get; set; }

        public virtual Tracks Tracks { get; set; }
    }
}
