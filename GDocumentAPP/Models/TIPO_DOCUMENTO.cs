namespace GDocumentAPP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TIPO_DOCUMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPO_DOCUMENTO()
        {
            DOCUMENTO_INDEXACION = new HashSet<DOCUMENTO_INDEXACION>();
        }

        [Key]
        public int TIPO_DOCUMENTO_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string DESCRIPCION { get; set; }

        [Required]
        [StringLength(1)]
        public string REQUERIDO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCUMENTO_INDEXACION> DOCUMENTO_INDEXACION { get; set; }
    }
}
