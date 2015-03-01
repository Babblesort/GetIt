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
    public class ShoppingItemsController : BaseApiController
    {
        public ShoppingItemsController(IGetItRepository repo) : base(repo) { }

        public IEnumerable<ShoppingItemModel> Get()
        {
            IQueryable<ShoppingItem> query;
            query = Repository.GetAllShoppingItems();

            var results = query.ToList()
                .Select(s => ModelFactory.Create(s));

            return results;

        }

        public HttpResponseMessage GetShoppingItem(int id)
        {
            try
            {
                var item = Repository.GetShoppingItem(id);
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

        [HttpPost]
        public HttpResponseMessage Post([FromBody] ShoppingItemModel itemModel)
        {
            try
            {
                var entity = ModelFactory.Parse(itemModel);

                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read itemModel from body.");
                }

                if (Repository.Insert(entity) && Repository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.Created, ModelFactory.Create(entity));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not save to the database.");
                }
            }
            catch
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error in post handler.");
            }
        }

        [HttpPut]
        [HttpPatch]
        public HttpResponseMessage Put(int id, [FromBody] ShoppingItemModel itemModel)
        {
            try
            {
                var updatedItem = ModelFactory.Parse(itemModel);

                if (updatedItem == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read itemModel from body.");
                }

                var originalItem = Repository.GetShoppingItem(id);

                if (originalItem == null || originalItem.ShoppingItemId != id)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Item to update not found.");
                }
                else
                {
                    updatedItem.ShoppingItemId = id;
                }

                if (Repository.Update(originalItem, updatedItem) && Repository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ModelFactory.Create(updatedItem));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified);
                }
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error in put/patch handler.");
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var item = Repository.GetShoppingItem(id);

                if (item == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                if (Repository.DeleteShoppingItem(id) && Repository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error deleting item.");
            }
        }




    }
}
