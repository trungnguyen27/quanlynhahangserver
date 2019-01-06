using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHangServer.Models
{
    public class FoodWithOrder : BaseModel
    {
        public int Quantities { get; set; }

        public virtual Order Order { get; set; }
        public virtual Food Food { get; set; }
    }
}
