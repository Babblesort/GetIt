using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetIt.Web.Models
{
    public class ShoppingListModel
    {
        public string Url { get; set; }
        public int ShoppingListId { get; set; }
        public string Name { get; set; }

        public List<ShoppingItemModel> Items { get; set; }
    }
}