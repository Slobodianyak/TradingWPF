using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AddDTO
    {
        public int Id_or_order { get; set; }
        public int Id_of_item { get; set; }
        public int Quantity { get; set; }
    }
}
