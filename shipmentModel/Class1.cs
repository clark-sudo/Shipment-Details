using System;

namespace shipmentModel
{
    public class Shipment
    {
        public Guid ShipmentId { get; set; }
        public string buyer { get; set; }
        public string number { get; set; }
        public string address { get; set; }
    }
}