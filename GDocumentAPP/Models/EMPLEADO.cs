namespace GDocumentAPP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPLEADO")]
    public partial class EMPLEADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLEADO()
        {
            DOCUMENTOes = new HashSet<DOCUMENTO>();
            RASTREO_EXPEDIENTE = new HashSet<RASTREO_EXPEDIENTE>();
        }

        [Key]
        public int EMPLEADO_ID { get; set; }

        [Required(ErrorMessage = "La Persona es requerida")]
        [Display(Name = "Persona", Description = "Nombre + Identificación")]
        public int PERSONA_ID { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "El Supervisor es requerido")]
        [Display(Name = "Supervisor")]
        public string SUPERVISOR { get; set; }

        [Required(ErrorMessage = "La Dependencia es requerida")]
        [Display(Name = "Dependencia", Description = "Dependencia")]
        public int DEPENDENCIA_ID { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "El Puesto es requerido")]
        [Display(Name = "Puesto")]
        public string PUESTO { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "La Fecha Ingreso es requerida")]
        [Display(Name = "Fecha Ingreso")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FECHA_INGRESO { get; set; }

        [Required(ErrorMessage = "El Sueldo es requerida")]
        [Display(Name = "Sueldo", Description = "Sueldo")]
        public decimal SUELDO { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "El Banco es requerido")]
        [Display(Name = "Banco")]
        public string BANCO { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "La Cuenta Bancaria es requerida")]
        [Display(Name = "Cuenta Bancaria")]
        public string CUENTABANCARIA { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "La Empresa es requerida")]
        [Display(Name = "Empresa")]
        public string EMPRESA { get; set; }

        [Required(ErrorMessage = "El Estatus es requerido")]
        [Display(Name = "Estatus")]
        public int ESTATUS_ID { get; set; }

        public string getEmpleadoDisplay() {

            return string.Format("{0} {1} | {2} | {3} ", PERSONA.NOMBRE, PERSONA.PRIMER_APELLIDO, PERSONA.IDENTIFICACION, PUESTO );
        }

        public virtual DEPENDENCIA DEPENDENCIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCUMENTO> DOCUMENTOes { get; set; }

        public virtual ESTATU ESTATU { get; set; }

        public virtual PERSONA PERSONA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RASTREO_EXPEDIENTE> RASTREO_EXPEDIENTE { get; set; }
    }
}
