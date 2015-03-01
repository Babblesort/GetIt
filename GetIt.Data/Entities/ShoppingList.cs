using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Data.Entities
{
    public class ShoppingList
    {
        public int ShoppingListId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ShoppingItem> Items { get; set; }

        public ShoppingList()
        {
            Items = new List<ShoppingItem>();
        }
    }
}
