namespace GDocumentAPP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DOCUMENTO_INDEXACION
    {
        [Key]
        public int INDEXACION_ID { get; set; }

        public int DOCUMENTO_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHA_INDEXACION { get; set; }

        public int TIPO_DOCUMENTO_ID { get; set; }

        public int? NIVEL_CALIDAD { get; set; }

        [Required]
        [StringLength(50)]
        public string CLAVE_DOCUMENTO { get; set; }

        public string DESCRIPCION { get; set; }

        public int USUARIO_ID { get; set; }

        public virtual DOCUMENTO DOCUMENTO { get; set; }

        public virtual TIPO_DOCUMENTO TIPO_DOCUMENTO { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
