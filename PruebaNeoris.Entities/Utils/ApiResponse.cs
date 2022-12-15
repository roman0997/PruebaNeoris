using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNeoris.Entities.Utils
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public List<Error> Errors { get; set; }
        public object Data { get; set; }
        public ApiResponse()
        {
            Errors = new List<Error>();
        }
    }
}
