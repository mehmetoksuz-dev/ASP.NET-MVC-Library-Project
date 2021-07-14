using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryProject.SupporterClasses
{
    public class LogInfo //bu kısma db de tablo eklenip log tutabilirim belki.
    {
        public string Url { get; set; }
        public DateTime whenAdded { get; set; }
        public string errorMsg { get; set; }
        public string memberIp { get; set; }
        public string Browser { get; set; }
        public string Lang { get; set; }
    }
}