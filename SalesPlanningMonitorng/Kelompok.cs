//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SalesPlanningMonitorng
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kelompok
    {
        public Kelompok()
        {
            this.KelompokSales = new HashSet<KelompokSale>();
        }
    
        public int id_kelompok { get; set; }
        public string nama_kelompok { get; set; }
    
        public virtual ICollection<KelompokSale> KelompokSales { get; set; }
    }
}
