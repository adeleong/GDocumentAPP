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
    
    public partial class USUARIO_ROL
    {
        public int USUARIO_ROL_ID { get; set; }
        public int USUARIO_ID { get; set; }
        public int ROL_ID { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
    
        public virtual ROL ROL { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}