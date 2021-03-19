using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace NewsAPI_SQL.Models
{
   
    class Contact
    {
        public int id { get; set; }
        public string name { get; set; }
        public int phone { get; set; }
    }
}
