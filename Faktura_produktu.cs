//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sklep_Internetowy
{
    using System;
    using System.Collections.Generic;
    
    public partial class Faktura_produktu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Faktura_produktu()
        {
            this.Produkt = new HashSet<Produkt>();
        }
    
        public int Id_faktura_produktu { get; set; }
        public int Id_produktu { get; set; }
        public int numer_faktury { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produkt> Produkt { get; set; }
        public virtual Faktura FakturaSet { get; set; }
    }
}
