using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace OOP04
{
    public struct DeliveryAddress
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int BuildingNumber { get; set; }

        public DeliveryAddress(string city, string street, int buildingNumber) 
        {
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
        }

        public String GetFullAddress() 
        {
            return $"{BuildingNumber} : {Street} : {City}";
        }

    }
}
