using GetIt.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace GetIt.Web.Models
{
    public class ModelFactory
    {
        private UrlHelper _urlHelper;
        private IGetItRepository _repo;


        public ModelFactory(HttpRequestMessage request, IGetItRepository repo)
        {
            _urlHelper = new UrlHelper(request);
            _repo = repo;
        }

        public ShoppingItemModel Create(ShoppingItem item)
        {
            return new ShoppingItemModel()
            {
                Url = _urlHelper.Link("ShoppingItemsApi", new { id = item.ShoppingItemId}),
                ShoppingItemId = item.ShoppingItemId,
                Name = item.Name,
                Notes = item.Notes,
                Qty = item.Qty,
                IsComplete = item.IsComplete,
                ShoppingListId = item.ShoppingListId
            };
        }

        public ShoppingListModel Create(ShoppingList list)
        {
            var listModel = new ShoppingListModel();

            listModel.Url = _urlHelper.Link("ShoppingListsApi", new { id = list.ShoppingListId });
            listModel.ShoppingListId = list.ShoppingListId;
            listModel.Name = list.Name;
            listModel.Items = new List<ShoppingItemModel>();

            foreach(var item in list.Items) {
                listModel.Items.Add(this.Create(item));
            }
            return listModel;
        }

        public ShoppingItem Parse(ShoppingItemModel itemModel)
        {
            try
            {
                var item = new ShoppingItem()
                {
                    Name = itemModel.Name,
                    Notes = itemModel.Notes,
                    Qty = itemModel.Qty,
                    IsComplete = itemModel.IsComplete,
                    ParentShoppingList = _repo.GetShoppingList(itemModel.ShoppingListId),
                    ShoppingListId = itemModel.ShoppingListId
                };

                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}