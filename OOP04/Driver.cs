using System;
using System.Collections.Generic;
using System.Text;

namespace OOP04
{
    public class Driver
    {
        public string Name { get; set; }

        public Driver(string name)
        {
            Name = string.IsNullOrWhiteSpace(name) ? "Unknown" : name;
        }
    }
}
