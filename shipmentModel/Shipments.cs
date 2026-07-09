using System;

namespace shipmentModel
{
    public class Shipments
    {
        public Guid ShipmentId { get; set; }
        public string Product { get; set; }
        public short Quantity { get; set; }
        public int Price { get; set; }
        public int Fee { get; set; }
    }
}
