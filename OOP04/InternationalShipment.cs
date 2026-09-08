using OOP04;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP04
{
    public class InternationalShipment : Shipment, ITrackable, IInsurable
    {
        private string destinationCountry;
        private decimal customsFee;

        public string DestinationCountry
        {
            get { return destinationCountry; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    destinationCountry = value;
            }
        }

        public decimal CustomsFee
        {
            get { return customsFee; }
            set
            {
                if (value >= 0)
                    customsFee = value;
            }
        }

        public override string ShipmentTypeName => "International Shipment";

        public InternationalShipment(string trackingCode, string description, decimal weight,
                                      decimal deliveryFee, DeliveryAddress destination,
                                      string destinationCountry, decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            DestinationCountry = string.IsNullOrWhiteSpace(destinationCountry) ? "Unknown" : destinationCountry;
            CustomsFee = customsFee >= 0 ? customsFee : 0;
        }

        public override decimal EstimatedCost => DeliveryFee + (Weight * 5) + CustomsFee;

        public override void PrintShipment()
        {
            Console.WriteLine($"Tracking Code        : {TrackingCode}");
            Console.WriteLine($"Description          : {Description}");
            Console.WriteLine($"Weight               : {Weight} KG");
            Console.WriteLine($"Delivery Fee         : {DeliveryFee} EGP");
            Console.WriteLine($"Destination Country  : {DestinationCountry}");
            Console.WriteLine($"Customs Fee          : {CustomsFee} EGP");
            Console.WriteLine($"Estimated Cost       : {EstimatedCost} EGP");
        }

        public string GetTrackingStatus() => $"Shipment {TrackingCode} has been Delivered.";

        public decimal CalculateInsurance() => EstimatedCost * 0.12m;

        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine($"Customs report for {TrackingCode}: destination {DestinationCountry}, " +
                               $"customs fee {CustomsFee} EGP.");
        }
    }
}
