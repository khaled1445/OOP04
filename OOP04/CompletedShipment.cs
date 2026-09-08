using OOP04;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP04
{
    internal sealed class CompletedShipment : Shipment
    {
        public CompletedShipment(string trackingCode, string description, decimal weight,
                                  decimal deliveryFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }

        public override string ShipmentTypeName => "Completed Shipment";
    }
}
