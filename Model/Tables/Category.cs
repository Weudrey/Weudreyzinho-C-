using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Registers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables
{
    public class Category
    {
        public long? CategoryID { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public virtual ICollection<Product> Products { get; set; }

    }
}