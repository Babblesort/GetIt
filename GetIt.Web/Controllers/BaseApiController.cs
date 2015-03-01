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
    public class BaseApiController : ApiController
    {
        private IGetItRepository _repo;
        private ModelFactory _modelFactory;

        public BaseApiController(IGetItRepository repo)
        {
            _repo = repo;
        }

        protected IGetItRepository Repository
        {
            get
            {
                return _repo;
            }
        }

        protected ModelFactory ModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(Request, Repository);
                }
                return _modelFactory;
            }
        }
    }
}
