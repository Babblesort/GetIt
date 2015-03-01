using GetIt.Data.Entities;
using GetIt.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GetIt.Web.Controllers
{
    public class ShoppingListsController : BaseApiController
    {
        public ShoppingListsController(IGetItRepository repo) : base(repo) { }

        public IEnumerable<ShoppingListModel> Get()
        {
            IQueryable<ShoppingList> query;
            query = Repository.GetAllShoppingLists();

            var results = query.ToList()
                .Select(s => ModelFactory.Create(s));

            return results;

        }

        public HttpResponseMessage GetShoppingList(int id)
        {
            try
            {
                var item = Repository.GetShoppingList(id);
                if (item != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ModelFactory.Create(item));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}