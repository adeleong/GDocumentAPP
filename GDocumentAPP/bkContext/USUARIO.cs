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
    
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            this.DOCUMENTOes = new HashSet<DOCUMENTO>();
            this.DOCUMENTO_INDEXACION = new HashSet<DOCUMENTO_INDEXACION>();
            this.RASTREO_EXPEDIENTE = new HashSet<RASTREO_EXPEDIENTE>();
            this.USUARIO_ROL = new HashSet<USUARIO_ROL>();
        }
    
        public int USUARIO_ID { get; set; }
        public Nullable<int> ESTATUS_ID { get; set; }
        public int PERSONA_ID { get; set; }
        public string LOGIN { get; set; }
        public string CONTRASENIA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCUMENTO> DOCUMENTOes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCUMENTO_INDEXACION> DOCUMENTO_INDEXACION { get; set; }
        public virtual ESTATU ESTATU { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RASTREO_EXPEDIENTE> RASTREO_EXPEDIENTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO_ROL> USUARIO_ROL { get; set; }
    }
}
