namespace editeca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Archivos
    {
        public int Id { get; set; }

        public int IdRuta { get; set; }

        public int Orden { get; set; }

        public int IdTipoArchivo { get; set; }

        public virtual Rutas Rutas { get; set; }

        public virtual TiposArchivo TiposArchivo { get; set; }
    }
}
