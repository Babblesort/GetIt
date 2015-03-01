using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Data.Entities
{
    public class ShoppingItem
    {
        public int ShoppingItemId { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public string Notes { get; set; }
        public bool IsComplete { get; set; }

        public int ShoppingListId { get; set; }
        public virtual ShoppingList ParentShoppingList { get; set; }
    }
}
