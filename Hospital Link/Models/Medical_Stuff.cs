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
    
    public partial class Medical_Stuff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medical_Stuff()
        {
            this.Chemists = new HashSet<Chemist>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public int Contact { get; set; }
        public string Email { get; set; }
        public string Qualifications { get; set; }
        public Nullable<int> Hospital_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chemist> Chemists { get; set; }
        public virtual Hospital Hospital { get; set; }
    }
}
