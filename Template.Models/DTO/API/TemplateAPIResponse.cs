using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Template.Models.DTO.API;

namespace Template.Models
{
    public class TemplateAPIResponse<T>
    {
        public T Data { get; set; }

        public string Message { get; set; }

        public HttpStatusCode Status { get; set; }
        public bool Success { get; set; }
        public TemplateException Error { get; set; }
    }
}
