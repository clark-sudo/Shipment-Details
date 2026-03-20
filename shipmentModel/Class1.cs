using System;

namespace shipmentModel
{
    public class Shipment
    {
        public Guid ShipmentId { get; set; }
        public string Buyer { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
    }
    public class Details
    {
        public Guid DetailsId { get; set; }
        public string Store { get; set; }
        public string Product { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Month { get; set; }
        public int Day { get; set; }
        public int Fee { get; set; }
        public string Discount { get; set; }
        public int Sub { get; set; }
    }
}