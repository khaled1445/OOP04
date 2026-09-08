using System;
using System.Collections.Generic;
using System.Text;

namespace OOP04
{
    public abstract partial class Shipment
    {
        public string TrackingStatus { get; protected set; }

        public string GetTrackingStatus()
        {
            return TrackingStatus;
        }

        public void UpdateTrackingStatus(string newStatus)
        {
            if (string.IsNullOrWhiteSpace(newStatus))
                return;

            TrackingStatus = newStatus;

            OnTrackingStatusChanged(newStatus);
        }
        partial void OnTrackingStatusChanged(string newStatus)
        {
            Console.WriteLine($"Tracking status changed to: {newStatus}");
        }
    }
}
