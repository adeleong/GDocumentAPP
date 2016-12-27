namespace GDocumentAPP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RASTREO_EXPEDIENTE
    {
        [Key]
        public int RATRAEO_EXPEDIENTE_ID { get; set; }

        [Required(ErrorMessage = "El Empleado es requerido")]
        [Display(Name = "Empleado", Description = "Nombre + Identificación")]
        public int EMPLEADO_ID { get; set; }


        [Display(Name = "Usuario", Description = "Usuario Login")]
        public int USUARIO_ID { get; set; }

        public int DEPENDENCIA_ID { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "La Fecha Salida es requerida")]
        [Display(Name = "Fecha Salida")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FECHA_SALIDA { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Fecha Devolución")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FECHA_DEVOLUCION { get; set; }

        [Display(Name = "Firma")]
        public string FIRMA { get; set; }


        [Required(ErrorMessage = "El Estatus es requerido")]
        [Display(Name = "Estatus", Description = "Descripcion")]
        public int ESTATUS_ID { get; set; }

        [Required(ErrorMessage = "La Persona es requerida")]
        [Display(Name = "Asignado a", Description = "Persona a Quien se le Entrega el Expediente")]
        public int PERSONA_ID { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "El Comentario es requerido")]
        [Display(Name = "Comentario", Description = "Detalle de los Documentos del Expediente")]
        public string COMENTARIO { get; set; }

        public virtual DEPENDENCIA DEPENDENCIA { get; set; }

        public virtual EMPLEADO EMPLEADO { get; set; }

        public virtual ESTATU ESTATU { get; set; }

        public virtual PERSONA PERSONA { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
