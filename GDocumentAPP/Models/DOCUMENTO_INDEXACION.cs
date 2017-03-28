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

        [Required]
        [Display(Name = "Documento")]
        public int DOCUMENTO_ID { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "La Fecha Indexación es requerida")]
        [Display(Name = "Fecha Indexación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FECHA_INDEXACION { get; set; }

        [Display(Name = "Tipo Documento")]
        public int TIPO_DOCUMENTO_ID { get; set; }

        [Display(Name = "Nivel Calidad")]
        public int? NIVEL_CALIDAD { get; set; }

        [Required(ErrorMessage = "Las Etiquetas son requerida")]
        [StringLength(50)]
        [Display(Name = "Etiquetas Documento")]
        public string CLAVE_DOCUMENTO { get; set; }

        [Display(Name = "Descripción")]
        public string DESCRIPCION { get; set; }

        [Display(Name = "Usuario")]
        public int USUARIO_ID { get; set; }

        public virtual DOCUMENTO DOCUMENTO { get; set; }

        public virtual TIPO_DOCUMENTO TIPO_DOCUMENTO { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
