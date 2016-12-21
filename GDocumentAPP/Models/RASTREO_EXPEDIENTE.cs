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

        public int EMPLEADO_ID { get; set; }

        public int USUARIO_ID { get; set; }

        public int DEPENDENCIA_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHA_SALIDA { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FECHA_DEVOLUCION { get; set; }

        public string FIRMA { get; set; }

        public int ESTATUS_ID { get; set; }

        public int PERSONA_ID { get; set; }

        [StringLength(150)]
        public string COMENTARIO { get; set; }

        public virtual DEPENDENCIA DEPENDENCIA { get; set; }

        public virtual EMPLEADO EMPLEADO { get; set; }

        public virtual ESTATU ESTATU { get; set; }

        public virtual PERSONA PERSONA { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
