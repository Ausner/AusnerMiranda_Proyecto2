using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AusnerMiranda_Proyecto2.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<colaborador> colaborador { get; set; }
        public virtual DbSet<herramientas> herramientas { get; set; }
        public virtual DbSet<prestamos> prestamos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<colaborador>()
                .Property(e => e.cedula)
                .IsUnicode(false);

            modelBuilder.Entity<colaborador>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<colaborador>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<herramientas>()
                .Property(e => e.codigo)
                .IsUnicode(false);

            modelBuilder.Entity<herramientas>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<herramientas>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<prestamos>()
                .Property(e => e.cedula)
                .IsUnicode(false);

            modelBuilder.Entity<prestamos>()
                .Property(e => e.codigo)
                .IsUnicode(false);
        }
    }
}
