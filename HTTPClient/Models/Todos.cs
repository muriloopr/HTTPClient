using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClient.Models
{
    class Todos
    {
        public string userId { get; set; }
        public string id { get; set; }
        public string Title { get; set; }
        public string completed { get; set; }
    }
}
