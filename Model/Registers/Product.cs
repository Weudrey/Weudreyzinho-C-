using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Model.Tables;

namespace Model.Registers
{
    public class Product
    {
        public long? ProductID { get; set; }
        public string Name { get; set; }
        public long? CategoryId { get; set; }
        public long? SupplierId { get; set; }
        [DisplayName("Registred Categories")]
        public Category Category { get; set; }
        [DisplayName("Registred Suppliers")]
        public Supplier Supplier { get; set; }
    }
}