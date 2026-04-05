using shipmentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace shipmentData
{
    public interface iShipmentData
    {
        void Add(Shipment shipment);
        Shipment? GetById(Guid id);
        Shipment? GetByBuyer(string buyer);
        bool BuyerExists(string buyer);
        void Update(Shipment shipment);
        List<Shipment> GetShipment();
    }
}
