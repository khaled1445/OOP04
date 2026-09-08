using OOP04;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP04
{
    internal class DeliveryCenter
    {
        private const int capacity = 20;
        private Shipment[] shipments = new Shipment[capacity];

        public Driver AssignedDriver { get; set; }
        public string CenterName { get; set; }
        public int Count { get; set; }
        public Shipment this[int index]
        {
            get
            {
                if (shipments == null || index < 0 || index >= shipments.Length)
                {
                    return default;

                }
                return shipments[index];

            }

            set
            {
                if (shipments == null)
                {
                    shipments = new Shipment[capacity];
                }

                if (index < 0 || index > shipments.Length)
                {
                    return;
                }
                shipments[index] = value;

            }

        }

        public Shipment this[string trackingCode]
        {
            get
            {
                if (shipments != null)
                {
                    foreach (Shipment shipment in shipments)
                    {
                        if (shipment.TrackingCode == trackingCode)
                            return shipment;
                    }
                    return default;
                }
                return default;
            }
        }

        public bool AddShipment(Shipment shipment)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] == null)
                {
                    shipments[i] = shipment;
                    return true;
                }
            }
            return false;
        }

        public bool RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] != null &&
                    shipments[i].TrackingCode.Equals(trackingCode, StringComparison.OrdinalIgnoreCase))
                {
                    shipments[i] = null;
                    return true;
                }
            }
            return false;
        }

        public void PrintAllShipments()
        {
            Console.WriteLine($"Driver : {AssignedDriver?.Name}");
            Console.WriteLine();
            Console.WriteLine(new string('-', 42));
            Console.WriteLine();

            foreach (var shipment in shipments)
            {
                if (shipment == null)
                    continue;

                Console.WriteLine(shipment.ShipmentTypeName);
                Console.WriteLine();
                shipment.PrintShipment();
                Console.WriteLine();
                Console.WriteLine(new string('-', 50));
                Console.WriteLine();
            }
        }
    }
}