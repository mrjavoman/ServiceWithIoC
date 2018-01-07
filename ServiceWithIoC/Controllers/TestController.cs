using ServiceWithIoC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;
using System.Diagnostics.Tracing;
using ServiceWithIoC.Models;

namespace ServiceWithIoC.Controllers
{
    public class TestController : ApiController
    {
        private ITestRepository _repository;

        public TestController(ITestRepository repository)
        {
            this._repository = repository;
        }

        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
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

        public HttpResponseMessage Post(FormContents form)
        {
            var attchments = form.Attachments;
            //LZString.decompressFromUTF16();
            

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
