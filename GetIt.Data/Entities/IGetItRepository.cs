using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Data.Entities
{
    public interface IGetItRepository
    {
        IQueryable<ShoppingList> GetAllShoppingLists();
        ShoppingList GetShoppingList(int id);

        IQueryable<ShoppingItem> GetAllShoppingItems();
        ShoppingItem GetShoppingItem(int id);

        IQueryable<ShoppingItem> GetShoppingListItems(int listId);
        IQueryable<ShoppingItem> GetCompleteShoppingListItems(int listId);
        IQueryable<ShoppingItem> GetIncompleteShoppingListItems(int listId);

        bool Insert(ShoppingItem item);
        bool Update(ShoppingItem originalItem, ShoppingItem updatedItem);
        bool DeleteShoppingItem(int id);

        bool Insert(ShoppingList list);
        bool Update(ShoppingList originalList, ShoppingList updatedList);
        bool DeleteShoppingList(int id);

        bool SaveAll();
    }

}
