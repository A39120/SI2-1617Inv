//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App.EF___Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class AluguerPrecoDuracao
    {
        public string serial_apd { get; set; }
        public System.DateTime duracao { get; set; }
        public int preco { get; set; }
    
        public virtual Aluguer Aluguer { get; set; }
    }
}
