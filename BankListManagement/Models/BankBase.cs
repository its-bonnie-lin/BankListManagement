﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BankListManagement.Models
{
    public class BankBase
    {
        public string id { get; set; }

        public string BankCode { get; set; }
        public string Bank { get; set; }
    }
}