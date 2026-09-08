using OOP04;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP04
{
    internal class DeliveryHelper
    {
        public static void PrintShipmentDetails(Shipment shipment)
        {
            shipment.PrintShipment();
            Console.WriteLine($"{shipment.ShipmentTypeName} Printed Successfully.");
            Console.WriteLine();
        }
    }
}
