using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHangServer.Models
{
    public class Image : BaseModel
    {
        public byte[] Binary { get; set; }
    }
}
