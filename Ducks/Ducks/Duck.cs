using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ducks
{
    public enum DuckColors
    {
        Black,
        White,
        Brown,
        Yellow
    }

    public class Duck
    {
        public string Name { get; set; }
        public int EggsCount { get; set; }
        public DuckColors Color { get; set; }
    }
}