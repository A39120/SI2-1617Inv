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
    
    public partial class Cliente
    {
        public Cliente()
        {
            this.Aluguer = new HashSet<Aluguer>();
        }
    
        public int cId { get; set; }
        public Nullable<int> nif { get; set; }
        public string nome { get; set; }
        public string morada { get; set; }
        public Nullable<bool> valido { get; set; }
    
        public virtual ICollection<Aluguer> Aluguer { get; set; }
    }
}
