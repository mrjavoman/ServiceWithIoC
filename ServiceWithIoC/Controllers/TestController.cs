using ServiceWithIoC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceWithIoC.Controllers
{
    public class TestController : ApiController
    {
        private ITestRepository _repository;

        public TestController(ITestRepository repository)
        {
            this._repository = repository;
        }

        public string Get()
        {
            var queriableObject = _repository.Get();
            return "Hello World!";
        }
    }
}
