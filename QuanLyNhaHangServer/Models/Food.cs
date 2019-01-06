using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHangServer.Models
{
    public class Food : BaseModel
    {
        public String name { get; set; }
        public decimal Price { get; set; }
        public int? ImageId { get; set; }

        public virtual FoodCategory FoodCategory { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
