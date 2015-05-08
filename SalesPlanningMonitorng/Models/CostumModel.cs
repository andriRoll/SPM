using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesPlanningMonitorng.Models
{
    public class CostumModel
    {
        public IEnumerable<Barang> Barangs { get; set; }
        public Stok Stok { get; set; }
        public IEnumerable<Stok> Stoks { get; set; }
        public Barang Barang { get; set; }
    }
}