using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RuSpeak.Models.Things
{
    public abstract class BaseContent
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public AudioContent AudioContent { get; set; }
    }
}