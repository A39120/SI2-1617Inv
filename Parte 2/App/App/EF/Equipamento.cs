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
    
    public partial class Equipamento
    {
        public Equipamento()
        {
            this.Aluguer = new HashSet<Aluguer>();
            this.Aluguer1 = new HashSet<Aluguer>();
        }
    
        public int eqId { get; set; }
        public string descr { get; set; }
        public string tipo { get; set; }
        public Nullable<bool> valid { get; set; }
    
        public virtual ICollection<Aluguer> Aluguer { get; set; }
        public virtual ICollection<Aluguer> Aluguer1 { get; set; }
        public virtual Tipo Tipo1 { get; set; }
    }
}
