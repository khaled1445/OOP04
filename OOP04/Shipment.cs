using OOP04;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace OOP04
{
    public abstract partial class Shipment : ITrackable
    {
        private string trackingCode;
        private string description;
        private decimal weight;
        private decimal deliveryFee;

        public string TrackingCode
        {
            get { return trackingCode; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    trackingCode = value;
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    description = value;
            }
        }

        public decimal Weight
        {
            get { return weight; }
            set
            {
                if (value > 0)
                    weight = value;
            }
        }

        public decimal DeliveryFee
        {
            get { return deliveryFee; }
            private set
            {
                if (value > 0)
                    deliveryFee = value;
            }
        }

        public DeliveryAddress Destination { get; set; }

        public abstract decimal EstimatedCost { get; }
        public abstract void PrintShipment();
        public virtual string ShipmentTypeName => "Shipment";

      
        private static int totalShipmentsCreated;

        
        static Shipment()
        {
            totalShipmentsCreated = 0;
            Console.WriteLine("Shipment System Initialized");
        }

        
        public static int GetTotalShipmentsCreated()
        {
            return totalShipmentsCreated;
        }

       

        protected Shipment(string trackingCode)
        {
            TrackingCode = string.IsNullOrWhiteSpace(trackingCode) ? "UNKNOWN" : trackingCode;
            Description = "Unknown";
            Weight = 1;
            DeliveryFee = 50;
            Destination = new DeliveryAddress("Unknown", "Unknown", 0);
            TrackingStatus = "In Transit"; 
            totalShipmentsCreated++;
        }

        protected Shipment(string trackingCode, string description, decimal weight,
                            decimal deliveryFee, DeliveryAddress destination)
        {
            TrackingCode = string.IsNullOrWhiteSpace(trackingCode) ? "UNKNOWN" : trackingCode;
            Description = string.IsNullOrWhiteSpace(description) ? "Unknown" : description;
            Weight = weight > 0 ? weight : 1;
            DeliveryFee = deliveryFee > 0 ? deliveryFee : 50;
            Destination = destination;
            TrackingStatus = "In Transit"; 
            totalShipmentsCreated++;
        }

        public void UpdateDeliveryFee(decimal newFee)
        {
            DeliveryFee = newFee;
        }

        public void UpdateWeight(decimal newWeight)
        {
            Weight = newWeight;
        }

        public void UpdateWeight(decimal newWeight, decimal extraPackingWeight)
        {
            Weight = newWeight + extraPackingWeight;
        }

        
        partial void OnTrackingStatusChanged(string newStatus);

        
        public Shipment CopyShipment()
        {
            return (Shipment)this.MemberwiseClone();
        }

        public Shipment ShallowCopy()
        {
            return (Shipment)this.MemberwiseClone();
        }

        public Shipment DeepCopy()
        {
            Shipment copy = (Shipment)this.MemberwiseClone();
            copy.Destination = new DeliveryAddress(
                Destination.City, Destination.Street, Destination.BuildingNumber);
            return copy;
        }
    }
}