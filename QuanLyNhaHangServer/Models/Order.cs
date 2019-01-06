using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHangServer.Models
{
    public class Order : BaseModel
    {
        public string Note { get; set; }
        public decimal MoneyReceive { get; set; }
        public decimal MoneyReturn { get; set; }
        public virtual ICollection<FoodWithOrder> FoodWithOrders { get; set; }
        public virtual Table Table { get; set; }
    }
}
