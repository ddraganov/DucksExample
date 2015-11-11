using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace Ducks
{
    public class CreateDuckRequest
    {
        public Guid Id { get; set; }
        public Duck Duck { get; set; }
    }
}