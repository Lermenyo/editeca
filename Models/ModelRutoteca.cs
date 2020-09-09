namespace editeca.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelRutoteca : DbContext
    {
        public ModelRutoteca()
            : base("name=ModelRutoteca")
        {
        }

        public virtual DbSet<Archivos> Archivos { get; set; }
        public virtual DbSet<Coordenadas> Coordenadas { get; set; }
        public virtual DbSet<Elementos> Elementos { get; set; }
        public virtual DbSet<Elementos_Monumento> Elementos_Monumento { get; set; }
        public virtual DbSet<Elementos_Vertice> Elementos_Vertice { get; set; }
        public virtual DbSet<ElementosRuta> ElementosRuta { get; set; }
        public virtual DbSet<Localidades> Localidades { get; set; }
        public virtual DbSet<Mides> Mides { get; set; }
        public virtual DbSet<Points> Points { get; set; }
        public virtual DbSet<Rutas> Rutas { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TiposArchivo> TiposArchivo { get; set; }
        public virtual DbSet<TiposElemento> TiposElemento { get; set; }
        public virtual DbSet<Tracks> Tracks { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Elementos_Documento> Elementos_Documento { get; set; }
        public virtual DbSet<Elementos_Entidad> Elementos_Entidad { get; set; }
        public virtual DbSet<Elementos_Foto> Elementos_Foto { get; set; }
        public virtual DbSet<Elementos_Imagen> Elementos_Imagen { get; set; }
        public virtual DbSet<Elementos_Link> Elementos_Link { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coordenadas>()
                .Property(e => e.ETRS89GeograficasLatitud)
                .IsUnicode(false);

            modelBuilder.Entity<Coordenadas>()
                .Property(e => e.ETRS89GeograficasLongitud)
                .IsUnicode(false);

            modelBuilder.Entity<Coordenadas>()
                .Property(e => e.ETRS89GeograficasHelipBP)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Coordenadas>()
                .Property(e => e.ETRS89GeograficasHelipCF)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Coordenadas>()
                .Property(e => e.ETRS89GeograficasDesvTipicaMLat)
                .HasPrecision(18, 17);

            modelBuilder.Entity<Coordenadas>()
                .Property(e => e.ETRS89GeograficasDesvTipicaMLon)
                .HasPrecision(18, 17);

            modelBuilder.Entity<Coordenadas>()
                .Property(e => e.ETRS89GeograficasDesvTipicaMH)
                .HasPrecision(18, 17);

            modelBuilder.Entity<Coordenadas>()
                .Property(e => e.ETRS89UTMX)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Coordenadas>()
                .Property(e => e.ETRS89UTMY)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Coordenadas>()
                .Property(e => e.ED50GeograficasLatitud)
                .IsUnicode(false);

            modelBuilder.Entity<Coordenadas>()
                .Property(e => e.ED50GeograficasLongitud)
                .IsUnicode(false);

            modelBuilder.Entity<Coordenadas>()
                .Property(e => e.ED50UTMX)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Coordenadas>()
                .Property(e => e.ED50UTMY)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Coordenadas>()
                .Property(e => e.HOrtomBP)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Coordenadas>()
                .Property(e => e.Latitud)
                .HasPrecision(10, 7);

            modelBuilder.Entity<Coordenadas>()
                .Property(e => e.Longitud)
                .HasPrecision(10, 7);

            modelBuilder.Entity<Coordenadas>()
                .HasMany(e => e.Elementos)
                .WithMany(e => e.Coordenadas)
                .Map(m => m.ToTable("Elementos_Lugar").MapLeftKey("IdCoordenada").MapRightKey("IdElemento"));

            modelBuilder.Entity<Elementos>()
                .Property(e => e.Icono)
                .IsUnicode(false);

            modelBuilder.Entity<Elementos>()
                .Property(e => e.Permalink)
                .IsUnicode(false);

            modelBuilder.Entity<Elementos>()
                .HasMany(e => e.Elementos_Documento)
                .WithRequired(e => e.Elementos)
                .HasForeignKey(e => e.IdElemento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Elementos>()
                .HasMany(e => e.Elementos_Entidad)
                .WithRequired(e => e.Elementos)
                .HasForeignKey(e => e.IdElemento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Elementos>()
                .HasMany(e => e.Elementos_Foto)
                .WithRequired(e => e.Elementos)
                .HasForeignKey(e => e.IdElemento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Elementos>()
                .HasOptional(e => e.Elementos_Imagen)
                .WithRequired(e => e.Elementos);

            modelBuilder.Entity<Elementos>()
                .HasMany(e => e.Elementos_Monumento)
                .WithRequired(e => e.Elementos)
                .HasForeignKey(e => e.IdElemento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Elementos>()
                .HasMany(e => e.Elementos_Vertice)
                .WithRequired(e => e.Elementos)
                .HasForeignKey(e => e.IdElemento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Elementos>()
                .HasMany(e => e.ElementosRuta)
                .WithRequired(e => e.Elementos)
                .HasForeignKey(e => e.IdElemento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Elementos>()
                .HasMany(e => e.Localidades)
                .WithRequired(e => e.Elementos)
                .HasForeignKey(e => e.IdElemento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Elementos_Monumento>()
                .Property(e => e.Codigo)
                .IsFixedLength();

            modelBuilder.Entity<Elementos_Monumento>()
                .Property(e => e.Precio)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Elementos_Vertice>()
                .Property(e => e.Pilar)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Localidades>()
                .Property(e => e.NombreCapital)
                .IsUnicode(false);

            modelBuilder.Entity<Localidades>()
                .Property(e => e.CodigoINESuperior)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Localidades>()
                .Property(e => e.CodigoINE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Localidades>()
                .Property(e => e.IdREL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Localidades>()
                .Property(e => e.Superficie)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Localidades>()
                .Property(e => e.CodigoHojaMTN25)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Localidades>()
                .HasMany(e => e.Elementos_Vertice)
                .WithRequired(e => e.Localidades)
                .HasForeignKey(e => e.IdLocalidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mides>()
                .Property(e => e.Medio)
                .HasPrecision(1, 0);

            modelBuilder.Entity<Mides>()
                .Property(e => e.Itinerario)
                .HasPrecision(1, 0);

            modelBuilder.Entity<Mides>()
                .Property(e => e.Desplazamiento)
                .HasPrecision(1, 0);

            modelBuilder.Entity<Mides>()
                .Property(e => e.Esfuerzo)
                .HasPrecision(1, 0);

            modelBuilder.Entity<Points>()
                .Property(e => e.lat)
                .HasPrecision(18, 16);

            modelBuilder.Entity<Points>()
                .Property(e => e.lon)
                .HasPrecision(18, 16);

            modelBuilder.Entity<Points>()
                .Property(e => e.ele)
                .HasPrecision(18, 16);

            modelBuilder.Entity<Rutas>()
                .Property(e => e.Longitud)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Rutas>()
                .HasMany(e => e.Archivos)
                .WithRequired(e => e.Rutas)
                .HasForeignKey(e => e.IdRuta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rutas>()
                .HasMany(e => e.ElementosRuta)
                .WithRequired(e => e.Rutas)
                .HasForeignKey(e => e.IdRuta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rutas>()
                .HasMany(e => e.Mides)
                .WithOptional(e => e.Rutas)
                .HasForeignKey(e => e.IdRuta);

            modelBuilder.Entity<Rutas>()
                .HasMany(e => e.Tracks)
                .WithMany(e => e.Rutas)
                .Map(m => m.ToTable("TrackRuta").MapLeftKey("IdRuta").MapRightKey("IdTrack"));

            modelBuilder.Entity<TiposArchivo>()
                .HasMany(e => e.Archivos)
                .WithRequired(e => e.TiposArchivo)
                .HasForeignKey(e => e.IdTipoArchivo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TiposElemento>()
                .HasMany(e => e.Elementos)
                .WithOptional(e => e.TiposElemento)
                .HasForeignKey(e => e.IdTipoElemento);

            modelBuilder.Entity<Elementos_Entidad>()
                .Property(e => e.VotacionMedia)
                .HasPrecision(18, 0);
        }
    }
}
