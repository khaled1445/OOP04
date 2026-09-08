using OOP04;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace OOP04
{
    public abstract class Shipment
    {
        private string trackingCode;
        private string description;
        private decimal weight;
        private decimal deliveryFee;
        internal DeliveryAddress Destination { get; set; }

            
        public string TrackingCode
        {
            get
            {
                return trackingCode;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("TrackingCode cannot be empty or whitespace");
                    return;
                }
                trackingCode = value;

            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Description cannot be empty or whitespace");
                    return;
                }
                description = value;

            }
        }

        public decimal Weight
        {
            get
            {
                return weight;
            }

            set
            {
                if (value > 0)
                {
                    weight = value;
                }
                else
                    Console.WriteLine("Enter a Valid number");
            }
        }
        public decimal DeliveryFee
        {
            get
            {
                return deliveryFee;
            }
            private set
            {
                if (value > 0)
                    deliveryFee = value;
                else
                    Console.WriteLine("Enter a Valid Number");
            }
        }

        public virtual string ShipmentTypeName => "Standard Shipment";

        public abstract decimal EstimatedCost { get; }

        protected Shipment(string trackingCode)
        {
            TrackingCode = string.IsNullOrWhiteSpace(trackingCode) ? "wrong" : trackingCode;
            Description = "Unknown";
            Weight = 1;
            DeliveryFee = 50;
            Destination = new DeliveryAddress("Unknown", "Unknown", 0);
        }

        protected Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
        {
            TrackingCode = string.IsNullOrWhiteSpace(trackingCode) ? "UNKNOWN" : trackingCode;
            Description = string.IsNullOrWhiteSpace(description) ? "Unknown" : description;
            Weight = weight > 0 ? weight : 1;
            DeliveryFee = deliveryFee > 0 ? deliveryFee : 50;
            Destination = (destination);
        }

        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
                DeliveryFee = newFee;
        }

        protected virtual void PrintExtraDetails()
        {

        }

        public abstract void PrintShipment();

        public void UpdateWeight(decimal newWeight)
        {
            Weight = newWeight; 
        }

        public void UpdateWeight(decimal newWeight, decimal extraPackingWeight)
        {
            Weight = newWeight + extraPackingWeight;
        }

    }
}