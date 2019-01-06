using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHangServer.Models
{
    public class Ingredient : BaseModel
    {
        public String Name { get; set; }
        public int? imageId { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
