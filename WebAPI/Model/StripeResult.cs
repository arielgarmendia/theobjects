using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.WebAPI.Model
{
    public class StripeResult
    {
        public string Code { get; set; }
        public string State { get; set; }
    }
}