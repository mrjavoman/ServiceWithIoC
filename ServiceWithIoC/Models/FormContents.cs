using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceWithIoC.Models
{
    public class FormContents
    {
        public List<string> Attachments { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}