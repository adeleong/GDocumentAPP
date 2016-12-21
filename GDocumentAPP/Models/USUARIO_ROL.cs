namespace GDocumentAPP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USUARIO_ROL
    {
        [Key]
        public int USUARIO_ROL_ID { get; set; }

        public int USUARIO_ID { get; set; }

        public int ROL_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FECHA { get; set; }

        public virtual ROL ROL { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
