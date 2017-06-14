namespace GDocumentAPP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ESTATUS")]
    public partial class ESTATU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ESTATU()
        {
            DOCUMENTOes = new HashSet<DOCUMENTO>();
            EMPLEADOes = new HashSet<EMPLEADO>();
            RASTREO_EXPEDIENTE = new HashSet<RASTREO_EXPEDIENTE>();
            USUARIOs = new HashSet<USUARIO>();
        }

        [Key]
        [Display(Name = "Estatus")]
        public int ESTATUS_ID { get; set; }

        [Required(ErrorMessage = "El Estatus es requerido")]
        [StringLength(50)]
        [Display(Name = "Estatus")]
        public string DESCRIPCION { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "El Tipo es requerido")]
        [Display(Name = "Entidad")]
        public string TIPO { get; set; }

        [StringLength(1)]
        [Required(ErrorMessage = "El Valor Logico es requerido")]
        [Display(Name = "Valor Logico")]
        public string VALOR_LOGICO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCUMENTO> DOCUMENTOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLEADO> EMPLEADOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RASTREO_EXPEDIENTE> RASTREO_EXPEDIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO> USUARIOs { get; set; }
    }
}
