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

        public int EMPLEADO_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string CANAL_GENERACION { get; set; }

        public byte[] DOCUMENTO_DATA { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHA_CREACION { get; set; }

        public int USUARIO_ID { get; set; }

        [StringLength(200)]
        public string EXTENSION { get; set; }

        public int? SIZE { get; set; }

        [StringLength(50)]
        public string NOMBRE_DOCUMENTO { get; set; }

        public int ESTATUS_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCUMENTO_INDEXACION> DOCUMENTO_INDEXACION { get; set; }

        public virtual EMPLEADO EMPLEADO { get; set; }

        public virtual ESTATU ESTATU { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
