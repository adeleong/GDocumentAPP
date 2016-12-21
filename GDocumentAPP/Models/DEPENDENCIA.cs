namespace GDocumentAPP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEPENDENCIA")]
    public partial class DEPENDENCIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEPENDENCIA()
        {
            EMPLEADOes = new HashSet<EMPLEADO>();
            RASTREO_EXPEDIENTE = new HashSet<RASTREO_EXPEDIENTE>();
        }

        [Key]
        public int DEPENDENCIA_ID { get; set; }

       
        [StringLength(50)]
        [Required(ErrorMessage = "La Dependencia es requerida")]
        [Display(Name = "Dependencia", Description = "Dependencia")]
        public string DEPENDENCIA_NOMBRE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLEADO> EMPLEADOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RASTREO_EXPEDIENTE> RASTREO_EXPEDIENTE { get; set; }
    }
}
