using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Data.Entities
{
    public class GetItRepository : IGetItRepository
    {
        private GetItContext _context;

        public GetItRepository(GetItContext context)
        {
            _context = context;
        }

        public IQueryable<ShoppingList> GetAllShoppingLists()
        {
            return _context.ShoppingLists
                .Include("Items")
                .AsQueryable();
        }

        public ShoppingList GetShoppingList(int id)
        {
            return _context.ShoppingLists
                .Include("Items")
                .Where(s => s.ShoppingListId == id)
                .SingleOrDefault();
        }

        public IQueryable<ShoppingItem> GetAllShoppingItems()
        {
            return _context.ShoppingItems
                .AsQueryable();
        }

        public ShoppingItem GetShoppingItem(int id)
        {
            return _context.ShoppingItems
                .Include("ParentShoppingList")
                .Where(s => s.ShoppingItemId == id)
                .SingleOrDefault();
        }

        public IQueryable<ShoppingItem> GetShoppingListItems(int id)
        {
            return this.GetShoppingList(id)
                .Items
                .AsQueryable();
        }

        public IQueryable<ShoppingItem> GetCompleteShoppingListItems(int id)
        {
            return this.GetShoppingList(id)
                .Items
                .Where(s => s.IsComplete)
                .AsQueryable();
        }

        public IQueryable<ShoppingItem> GetIncompleteShoppingListItems(int id)
        {
            return this.GetShoppingList(id)
                .Items
                .Where(s => !s.IsComplete)
                .AsQueryable();
        }

        public bool Insert(ShoppingItem item)
        {
            try
            {
                _context.ShoppingItems.Add(item);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(ShoppingItem originalItem, ShoppingItem updatedItem)
        {
            try
            {
                _context.Entry(originalItem).CurrentValues.SetValues(updatedItem);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteShoppingItem(int id)
        {
            try
            {
                var entity = _context.ShoppingItems.Find(id);
                if (entity != null)
                {
                    _context.ShoppingItems.Remove(entity);
                    return true;
                }
            }
            catch
            {
                // TODO Logging
            }
            return false;
        }

        public bool Insert(ShoppingList list)
        {
            try
            {
                _context.ShoppingLists.Add(list);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(ShoppingList originalList, ShoppingList updatedList)
        {
            try
            {
                _context.Entry(originalList).CurrentValues.SetValues(updatedList);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteShoppingList(int id)
        {
            try
            {
                var entity = _context.ShoppingLists.Find(id);
                if (entity != null)
                {
                    _context.ShoppingLists.Remove(entity);
                    return true;
                }
            }
            catch
            {
                // TODO Logging
            }
            return false;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
