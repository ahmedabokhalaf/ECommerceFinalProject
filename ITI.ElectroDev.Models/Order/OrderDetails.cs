using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.ElectroDev.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public double TotalPrice { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
