using ServiceWithIoC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;
using System.Diagnostics.Tracing;

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

            var traceWriter = Configuration.Services.GetTraceWriter();

            try
            {
                throw new Exception("This is a test exception");
            }
            catch (Exception e)
            {
                traceWriter.Trace(Request, "My Category", TraceLevel.Info, "{0}",
                    $"This is a test trace message from exception: {e.Message}"); 
            }

            return "Hello World!";
        }
    }
}
