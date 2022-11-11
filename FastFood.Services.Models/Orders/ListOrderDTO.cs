using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Services.Models.Orders
{
    public class ListOrderDTO
    {
        /*public int OrderId { get; set; }

        public string Customer { get; set; }

        public string Employee { get; set; }

        public string DateTime { get; set; }*/

         public List<int> Items { get; set; }

         public List<int> Employees { get; set; }
    }
}
