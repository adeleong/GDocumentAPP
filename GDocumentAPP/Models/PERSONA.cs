namespace GDocumentAPP
{
    using Services;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PERSONA")]
    public partial class PERSONA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PERSONA()
        {
            EMPLEADOes = new HashSet<EMPLEADO>();
            RASTREO_EXPEDIENTE = new HashSet<RASTREO_EXPEDIENTE>();
            TELEFONOes = new HashSet<TELEFONO>();
        }

        [Key]
        public int PERSONA_ID { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre")]
        [RegularExpression(@"^[a-zA-Záéíóúñ''-'\s]{1,40}$", ErrorMessage = "Números y Caracteres especiales no son permitido en el Nombre.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "La longitud debe ser entre 3 y 30")]
        public string NOMBRE { get; set; }

        [Required(ErrorMessage = "El Primer Apellido es requerido")]
        [Display(Name = "Primer Apellido")]
        [RegularExpression(@"^[a-zA-Záéíóúñ''-'\s]{1,40}$", ErrorMessage = "Numeros y Caracteres especiales no son permitido en el Primer Apellido.")]
        [StringLength(18, MinimumLength = 4, ErrorMessage = "La longitud debe ser entre 4 y 18")]
        public string PRIMER_APELLIDO { get; set; }

        [RegularExpression(@"^[a-zA-Záéíóúñ''-'\s]{1,40}$", ErrorMessage = "Numeros y Caracteres especiales no son permitido en el Segundo Apellido.")]
        [Display(Name = "Segundo Apellido")]
        [StringLength(18, MinimumLength = 4, ErrorMessage = "La longitud debe ser entre 4 y 18")]
        public string SEGUNDO_APELLIDO { get; set; }

        [Required(ErrorMessage = "El Tipo Identificación es requerido")]
        [Display(Name = "Tipo Identificación")]
        public string TIPO_IDENTIFICACION { get; set; }

       
        [Display(Name = "Identificación")]
        [CustomIdentificacionValidator]
        public string IDENTIFICACION { get; set; }

        [Required(ErrorMessage = "El Sexo es requerido")]
        [Display(Name = "Sexo")]
        public string SEXO { get; set; }

        [Display(Name = "Correo")]
        [EmailAddress(ErrorMessage = "El Correo es Invalido")]
        public string EMAIL { get; set; }

        public string getPersonaDisplay()
        {
            return String.Format("{0} {1} - {2}", NOMBRE, PRIMER_APELLIDO, IDENTIFICACION);
        }
        public string getPersonaDisplayFull()
        {
            return String.Format("{0} {1} | {2} | {3}", NOMBRE, PRIMER_APELLIDO, TIPO_IDENTIFICACION, IDENTIFICACION);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLEADO> EMPLEADOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RASTREO_EXPEDIENTE> RASTREO_EXPEDIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TELEFONO> TELEFONOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO> USUARIOS { get; set; }
    }
}
