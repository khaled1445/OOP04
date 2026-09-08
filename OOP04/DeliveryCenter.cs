using OOP04;
using System;
using System.Collections.Generic;
using System.Text;
using System;

namespace OOP_04
{
    public class DeliveryCenter
    {
        private const int Capacity = 20;
        private Shipment[] shipments = new Shipment[Capacity];

        public string CenterName { get; set; }
        public Driver AssignedDriver { get; set; }

        public Shipment this[int index]
        {
            get
            {
                if (index < 0 || index >= shipments.Length)
                    return null;
                return shipments[index];
            }
            set
            {
                if (index < 0 || index >= shipments.Length)
                    return;
                shipments[index] = value;
            }
        }

        public Shipment this[string trackingCode]
        {
            get
            {
                foreach (var shipment in shipments)
                {
                    if (shipment != null &&
                        shipment.TrackingCode.Equals(trackingCode, StringComparison.OrdinalIgnoreCase))
                    {
                        return shipment;
                    }
                }
                return null;
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
            if (AssignedDriver != null)
            {
                Console.WriteLine($"Driver : {AssignedDriver.Name}");
                Console.WriteLine();
                Console.WriteLine(new string('-', 42));
                Console.WriteLine();
            }

            foreach (var shipment in shipments)
            {
                if (shipment == null)
                    continue;

                Console.WriteLine(shipment.ShipmentTypeName);
                Console.WriteLine();
                shipment.PrintShipment();
                Console.WriteLine();
                Console.WriteLine(new string('-', 42));
                Console.WriteLine();
            }
        }

        public void PrintTrackingStatuses()
        {
            foreach (var shipment in shipments)
            {
                if (shipment is ITrackable trackable)
                {
                    Console.WriteLine(trackable.GetTrackingStatus());
                }
            }
        }
    }
}