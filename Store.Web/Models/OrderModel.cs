using store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public OrderItemModel[] orderItems = new OrderItemModel[0];

        public int State { get; set; }

        public int TotalCount { get; set; }

        public decimal TotalPrice { get; set; }

        public Dictionary<string, string> Errors { get; set; }  = new Dictionary<string,string>();

    }
}
