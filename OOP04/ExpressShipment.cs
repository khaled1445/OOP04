using System;
using System.Collections.Generic;
using System.Text;

namespace OOP04
{
    internal class ExpressShipment : Shipment
    {
        private decimal extraFee;

        public decimal ExtraFee
        {
            get { return extraFee; }
            set
            {
                if (value >= 0)
                    extraFee = value;
            }
        }

        public override string ShipmentTypeName => "Express Shipment";

        public override decimal EstimatedCost => base.EstimatedCost + ExtraFee;

        public ExpressShipment(string trackingCode) : base(trackingCode)
        {
            ExtraFee = 0;
        }

        public ExpressShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, decimal extraFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee >= 0 ? extraFee : 0;
        }

        public override void PrintShipment()
        {
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description   : {Description}");
            Console.WriteLine($"Weight        : {Weight} KG");
            Console.WriteLine($"Delivery Fee  : {DeliveryFee} EGP");
            Console.WriteLine($"Extra Fee     : {ExtraFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }
    }
}
