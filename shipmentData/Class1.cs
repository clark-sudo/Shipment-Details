using shipmentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace shipmentData
{
    public class savedData
    {
        iShipmentData _savedData;
        public savedData(iShipmentData SavedData)
        {
            _savedData = SavedData;
        }
        public void Add(Shipment shipment)
        {
            _savedData.Add(shipment);
        }
        public List<Shipment> GetShipment()
        {
            return _savedData.GetShipment();
        }
        public Shipment? GetById(Guid id)
        {
            return _savedData.GetById(id);
        }
        public Shipment? GetByBuyer(string buyer)
        {
            return _savedData.GetByBuyer(buyer);
        }
        public void Update(Shipment shipment)
        {
            _savedData.Update(shipment);
        }
        public bool BuyerExists(string buyer)
        {
            return _savedData.BuyerExists(buyer);
        }
    }
}
