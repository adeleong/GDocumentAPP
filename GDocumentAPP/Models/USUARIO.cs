namespace GDocumentAPP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USUARIO")]
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            DOCUMENTOes = new HashSet<DOCUMENTO>();
            DOCUMENTO_INDEXACION = new HashSet<DOCUMENTO_INDEXACION>();
            RASTREO_EXPEDIENTE = new HashSet<RASTREO_EXPEDIENTE>();
            USUARIO_ROL = new HashSet<USUARIO_ROL>();
        }

        [Key]
        public int USUARIO_ID { get; set; }

        public int? ESTATUS_ID { get; set; }

        [Required(ErrorMessage = "La Persona es requerida")]
        [Display(Name = "Persona")]
        public int PERSONA_ID { get; set; }

        [Required(ErrorMessage = "El Usuario es requerido")]
        [StringLength(20)]
        [Display(Name = "Usuario")]
        public string LOGIN { get; set; }

        [Required(ErrorMessage = "La Contraseña es requerida")]
        [StringLength(20)]
        [Display(Name = "Contraseña")]
        public string CONTRASENIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCUMENTO> DOCUMENTOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCUMENTO_INDEXACION> DOCUMENTO_INDEXACION { get; set; }

        public virtual ESTATU ESTATU { get; set; }

        public virtual PERSONA PERSONA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RASTREO_EXPEDIENTE> RASTREO_EXPEDIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO_ROL> USUARIO_ROL { get; set; }
    }
}
