using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Services.Models.Orders
{
    public class CreateOrderDTO
    {
        public string Customer { get; set; }

        public int ItemId { get; set; }

        public int EmployeeId { get; set; }

        public int Quantity { get; set; }
    }
}
