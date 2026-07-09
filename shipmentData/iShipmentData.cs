using shipmentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace shipmentData
{
    public interface iShipmentData
    {
        void Add(Shipments shipments);
        Shipments? GetById(Guid id);
        Shipments? GetByProduct(string product);
        bool ProductExists(string product);
        void Edit(Shipments shipments);
        void Remove(Guid id);
        List<Shipments> GetShipments();
    }
}
