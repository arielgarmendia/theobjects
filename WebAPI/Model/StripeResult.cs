using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace theObjects.WebAPI.Model
{
    public class StripeResult
    {
        public string Code { get; set; }
        public string State { get; set; }
    }
}