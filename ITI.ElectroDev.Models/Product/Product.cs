using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.ElectroDev.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<ProductImages> ProductImages { get; set; }
        //public virtual ICollection<Rate> Rates { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
