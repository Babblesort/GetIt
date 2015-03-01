using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetIt.Web.Models
{
    public class ShoppingItemModel
    {
        public string Url { get; set; }
        public int ShoppingItemId { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public string Notes { get; set; }
        public bool IsComplete { get; set; }
        public int ShoppingListId { get; set; }
    }
}