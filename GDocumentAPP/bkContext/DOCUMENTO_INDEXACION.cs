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
    
    public partial class DOCUMENTO_INDEXACION
    {
        public int INDEXACION_ID { get; set; }
        public int DOCUMENTO_ID { get; set; }
        public System.DateTime FECHA_INDEXACION { get; set; }
        public int TIPO_DOCUMENTO_ID { get; set; }
        public Nullable<int> NIVEL_CALIDAD { get; set; }
        public string CLAVE_DOCUMENTO { get; set; }
        public string DESCRIPCION { get; set; }
        public int USUARIO_ID { get; set; }
    
        public virtual DOCUMENTO DOCUMENTO { get; set; }
        public virtual TIPO_DOCUMENTO TIPO_DOCUMENTO { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
