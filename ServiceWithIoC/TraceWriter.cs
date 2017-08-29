using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Tracing;

namespace ServiceWithIoC
{
    public class TraceWriter : ITraceWriter
    {
        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            TraceRecord record = new TraceRecord(request, category, level);
            traceAction(record);
            var date = DateTime.Now.ToShortDateString().Replace('/', '_');
            string path = $"C:/Logs/{date}_MyTestLog.txt";
            File.AppendAllText(path, record.Status + " - " + record.Message + "\r\n");
        }
    }
}