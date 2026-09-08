using OOP04;
using System;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP04
{
    public class StandardShipment : Shipment, IInsurable
    {
        public override string ShipmentTypeName => "Standard Shipment";

        public StandardShipment(string trackingCode, string description, decimal weight,
                                 decimal deliveryFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }

        public override decimal EstimatedCost => DeliveryFee + (Weight * 5);

        public override void PrintShipment()
        {
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description   : {Description}");
            Console.WriteLine($"Weight        : {Weight} KG");
            Console.WriteLine($"Delivery Fee  : {DeliveryFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }

        public decimal CalculateInsurance() => EstimatedCost * 0.05m;
    }
}