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
        public void Create(Shipments shipments)
        {
            _savedData.Add(shipments);
        }
        public Shipments? GetById(Guid id)
        {
            return _savedData.GetById(id);
        }
        public Shipments? GetByProduct(string product)
        {
            return _savedData.GetByProduct(product);
        }
        public bool ProductExists(string product)
        {
            return _savedData.ProductExists(product);
        }
        public void Update(Shipments shipments)
        {
            _savedData.Edit(shipments);
        }
        public void Delete(Guid id)
        {
            _savedData.Remove(id);
        }
        public List<Shipments> GetShipments()
        {
            return _savedData.GetShipments();
        }
    }
}
