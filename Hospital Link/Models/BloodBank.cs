//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hospital_Link.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BloodBank
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BloodBank()
        {
            this.Quantity = 0;
        }
    
        public int Id { get; set; }
        public string Blood_type { get; set; }
        public int Quantity { get; set; }
        public int Hospital_Id { get; set; }
    
        public virtual Hospital Hospital { get; set; }
    }
}
