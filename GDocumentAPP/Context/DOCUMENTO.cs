//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GDocumentAPP.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class DOCUMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOCUMENTO()
        {
            this.DOCUMENTO_INDEXACION = new HashSet<DOCUMENTO_INDEXACION>();
        }
    
        public int DOCUMENTO_ID { get; set; }
        public int EMPLEADO_ID { get; set; }
        public string CANAL_GENERACION { get; set; }
        public byte[] DOCUMENTO_DATA { get; set; }
        public System.DateTime FECHA_CREACION { get; set; }
        public int USUARIO_ID { get; set; }
        public string EXTENSION { get; set; }
        public Nullable<int> SIZE { get; set; }
        public string NOMBRE_DOCUMENTO { get; set; }
        public int ESTATUS_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
               
        public virtual ICollection<DOCUMENTO_INDEXACION> DOCUMENTO_INDEXACION { get; set; }
        public virtual EMPLEADO EMPLEADO { get; set; }
        public virtual ESTATU ESTATU { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
