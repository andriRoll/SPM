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
    
    public partial class KelompokSale
    {
        public int id_kelompokSales { get; set; }
        public int id_kelompok { get; set; }
        public int id_karyawan { get; set; }
    
        public virtual Karyawan Karyawan { get; set; }
        public virtual Kelompok Kelompok { get; set; }
    }
}
