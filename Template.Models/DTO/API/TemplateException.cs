using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Models.DTO.API
{
    public class TemplateException : ApplicationException
    {
        public TemplateException()
        {
        }

        public TemplateException(string message)
            : base(message)
        {
        }

        public TemplateException(string message, Exception? inner)
            : base(message, inner)
        {
        }

        //Overriding the HelpLink Property
        public override string HelpLink
        {
            get
            {
                return "Get More Information from here: https://sitelink.com/customPageForErrorDescription";
            }
        }
    }
}
