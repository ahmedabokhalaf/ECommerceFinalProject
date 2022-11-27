using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.ElectroDev.Models
{
    public class Rate
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int NumberOfStars { get; set; }
        public string Comment { get; set; }
        public virtual Product Product { get; set; }
    }
}
