//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Preco
    {
        public string tipo { get; set; }
        public double valor { get; set; }
        public System.TimeSpan duracao { get; set; }
        public System.DateTime validade { get; set; }
    
        public virtual Tipo Tipo1 { get; set; }
    }
}
