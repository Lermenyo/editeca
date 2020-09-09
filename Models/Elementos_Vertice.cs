namespace editeca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Elementos_Vertice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int IdElemento { get; set; }

        public int IdLocalidad { get; set; }

        public int Numero { get; set; }

        public bool Regente { get; set; }

        public bool Inoperativo { get; set; }

        public decimal Pilar { get; set; }

        public int Ubicacion { get; set; }

        public int DistanciaLocalidadMasCercana { get; set; }

        public virtual Elementos Elementos { get; set; }

        public virtual Localidades Localidades { get; set; }
    }
}
