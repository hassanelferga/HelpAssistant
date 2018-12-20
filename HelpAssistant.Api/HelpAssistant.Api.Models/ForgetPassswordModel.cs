using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpAssistant.Api.Models
{
    public class ForgetPassswordModel
    {
        public string Code { get; set; }
        public bool StatusCode { get; set; }
        public string ErrorMsg { get; set; }
        public string NewPassword{ get; set; }


    }
}
