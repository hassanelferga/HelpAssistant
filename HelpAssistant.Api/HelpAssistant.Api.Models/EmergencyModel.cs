using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpAssistant.Api.Models
{

    public class EmergencyModel
    {
        public string UserID { get; set; }
        public string Numbers { get; set; }
        public string Message { get; set; }
    }
}
