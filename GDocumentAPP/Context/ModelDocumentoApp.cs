namespace GDocumentAPP
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelDocumentoApp : DbContext
    {
        public ModelDocumentoApp()
            : base("name=ModelDocumentoApp")
        {
        }

        public virtual DbSet<DEPENDENCIA> DEPENDENCIAs { get; set; }
        public virtual DbSet<DOCUMENTO> DOCUMENTOes { get; set; }
        public virtual DbSet<DOCUMENTO_INDEXACION> DOCUMENTO_INDEXACION { get; set; }
        public virtual DbSet<EMPLEADO> EMPLEADOes { get; set; }
        public virtual DbSet<ESTATU> ESTATUS { get; set; }
        public virtual DbSet<PERSONA> PERSONAs { get; set; }
        public virtual DbSet<RASTREO_EXPEDIENTE> RASTREO_EXPEDIENTE { get; set; }
        public virtual DbSet<ROL> ROLs { get; set; }
        public virtual DbSet<TELEFONO> TELEFONOes { get; set; }
        public virtual DbSet<TIPO_DOCUMENTO> TIPO_DOCUMENTO { get; set; }
        public virtual DbSet<USUARIO> USUARIOs { get; set; }
        public virtual DbSet<USUARIO_ROL> USUARIO_ROL { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DEPENDENCIA>()
                .Property(e => e.DEPENDENCIA_NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<DEPENDENCIA>()
                .HasMany(e => e.EMPLEADOes)
                .WithRequired(e => e.DEPENDENCIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPENDENCIA>()
                .HasMany(e => e.RASTREO_EXPEDIENTE)
                .WithRequired(e => e.DEPENDENCIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOCUMENTO>()
                .Property(e => e.CANAL_GENERACION)
                .IsUnicode(false);

            modelBuilder.Entity<DOCUMENTO>()
                .Property(e => e.EXTENSION)
                .IsUnicode(false);

            modelBuilder.Entity<DOCUMENTO>()
                .Property(e => e.NOMBRE_DOCUMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<DOCUMENTO>()
                .HasMany(e => e.DOCUMENTO_INDEXACION)
                .WithRequired(e => e.DOCUMENTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOCUMENTO_INDEXACION>()
                .Property(e => e.CLAVE_DOCUMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<DOCUMENTO_INDEXACION>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.SUPERVISOR)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.PUESTO)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.SUELDO)
                .HasPrecision(12, 2);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.BANCO)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.CUENTABANCARIA)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.EMPRESA)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .HasMany(e => e.DOCUMENTOes)
                .WithRequired(e => e.EMPLEADO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EMPLEADO>()
                .HasMany(e => e.RASTREO_EXPEDIENTE)
                .WithRequired(e => e.EMPLEADO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ESTATU>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<ESTATU>()
                .Property(e => e.TIPO)
                .IsUnicode(false);

            modelBuilder.Entity<ESTATU>()
                .Property(e => e.VALOR_LOGICO)
                .IsUnicode(false);

            modelBuilder.Entity<ESTATU>()
                .HasMany(e => e.DOCUMENTOes)
                .WithRequired(e => e.ESTATU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ESTATU>()
                .HasMany(e => e.EMPLEADOes)
                .WithRequired(e => e.ESTATU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ESTATU>()
                .HasMany(e => e.RASTREO_EXPEDIENTE)
                .WithRequired(e => e.ESTATU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.PRIMER_APELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.SEGUNDO_APELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.TIPO_IDENTIFICACION)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.IDENTIFICACION)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.SEXO)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .HasMany(e => e.EMPLEADOes)
                .WithRequired(e => e.PERSONA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSONA>()
                .HasMany(e => e.RASTREO_EXPEDIENTE)
                .WithRequired(e => e.PERSONA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSONA>()
                .HasMany(e => e.TELEFONOes)
                .WithRequired(e => e.PERSONA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RASTREO_EXPEDIENTE>()
                .Property(e => e.FIRMA)
                .IsUnicode(false);

            modelBuilder.Entity<RASTREO_EXPEDIENTE>()
                .Property(e => e.COMENTARIO)
                .IsUnicode(false);

            modelBuilder.Entity<ROL>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<ROL>()
                .HasMany(e => e.USUARIO_ROL)
                .WithRequired(e => e.ROL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TELEFONO>()
                .Property(e => e.TIPO)
                .IsUnicode(false);

            modelBuilder.Entity<TELEFONO>()
                .Property(e => e.NUMERO)
                .IsUnicode(false);

            modelBuilder.Entity<TIPO_DOCUMENTO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<TIPO_DOCUMENTO>()
                .Property(e => e.REQUERIDO)
                .IsUnicode(false);

            modelBuilder.Entity<TIPO_DOCUMENTO>()
                .HasMany(e => e.DOCUMENTO_INDEXACION)
                .WithRequired(e => e.TIPO_DOCUMENTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.LOGIN)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.CONTRASENIA)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.DOCUMENTOes)
                .WithRequired(e => e.USUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.DOCUMENTO_INDEXACION)
                .WithRequired(e => e.USUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.RASTREO_EXPEDIENTE)
                .WithRequired(e => e.USUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.USUARIO_ROL)
                .WithRequired(e => e.USUARIO)
                .WillCascadeOnDelete(false);
        }
    }
}
