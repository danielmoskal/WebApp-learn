//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace drugaApka.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BALANCES
    {
        public int BALANCE_ID { get; set; }
        public System.DateTime validFrom { get; set; }
        public float value { get; set; }
    
        public virtual PAYS PAYS { get; set; }
        public virtual USERS USERS { get; set; }
    }
}
