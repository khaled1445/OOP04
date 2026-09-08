using System;
using System.Collections.Generic;
using System.Text;

namespace OOP04
{
    public static class ShipmentExtensions
    {
        public static string GetSummary(this Shipment shipment)
        {
            string shortType = shipment.ShipmentTypeName.Replace(" Shipment", "");
            return $"{shipment.TrackingCode} | {shortType} | {shipment.Weight} KG | {shipment.GetTrackingStatus()}";
        }

        public static bool IsDelivered(this Shipment shipment)
        {
            return shipment.GetTrackingStatus() == "Delivered";
        }
    }
}
