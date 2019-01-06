using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHangServer.Models
{
    public class User : BaseModel
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public int RoleOrder { get; set; }
        public int RoleFood { get; set; }
        public int RoleTable { get; set; }
        public int RoleIngredient { get; set; }
        public int RolePrepareFood { get; set; }
    }
}
