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
    
    public partial class AluguerDataFim
    {
        public string serial_adf { get; set; }
        public System.DateTime data_fim { get; set; }
    
        public virtual Aluguer Aluguer { get; set; }
    }
}