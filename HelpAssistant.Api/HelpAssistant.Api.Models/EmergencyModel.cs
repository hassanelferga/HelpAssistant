﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpAssistant.Api.Models
{

    public class EmergencyModel
    {
        public int EmergencyId { get; set; }
        public string MobileNumber { get; set; }
        public string ContentSMS { get; set; }
    }
}