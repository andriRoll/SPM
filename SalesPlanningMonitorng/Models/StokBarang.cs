using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesPlanningMonitorng.Models
{
    public class StokBarang
    {
        public IEnumerable<Barang> Barangs { get; set; }
        public IEnumerable<Stok> Stoks { get; set; }
    }
}