namespace GDocumentAPP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DOCUMENTO")]
    public partial class DOCUMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOCUMENTO()
        {
            DOCUMENTO_INDEXACION = new HashSet<DOCUMENTO_INDEXACION>();
        }

        [Key]
        public int DOCUMENTO_ID { get; set; }

        [Required(ErrorMessage = "El Empleado es requerido")]
        [Display(Name = "Empleado", Description = "Nombre + Identificación")]
        public int EMPLEADO_ID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Canal Generación")]
        public string CANAL_GENERACION { get; set; }

        public byte[] DOCUMENTO_DATA { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "La Fecha Creación es requerida")]
        [Display(Name = "Fecha Creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FECHA_CREACION { get; set; }

        [Display(Name = "Usuario")]
        public int USUARIO_ID { get; set; }

        [StringLength(200)]
        [Display(Name = "Ruta del Documento")]
        public string EXTENSION { get; set; }

        [Display(Name = "Tamaño")]
        public int? SIZE { get; set; }

        [StringLength(50)]
        [Display(Name = "Nombre Documento")]
        public string NOMBRE_DOCUMENTO { get; set; }

        [Display(Name = "Estatus")]
        public int ESTATUS_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCUMENTO_INDEXACION> DOCUMENTO_INDEXACION { get; set; }

        public virtual EMPLEADO EMPLEADO { get; set; }

        public virtual ESTATU ESTATU { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
