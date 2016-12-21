namespace GDocumentAPP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TELEFONO")]
    public partial class TELEFONO
    {
        [Key]
        public int TELEFONO_ID { get; set; }

        public int PERSONA_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string TIPO { get; set; }

        [Required]
        [StringLength(12)]
        public string NUMERO { get; set; }

        public virtual PERSONA PERSONA { get; set; }
    }
}
