using shipmentData;
using shipmentModel;
using System.Security.Principal;

namespace shipmentBusiness
{
    public class Compare
    {
        static int quantity, subTotal;

        savedData data1 = new savedData(new ShipmentDBData());

        public bool Create(Shipments addProduct)
        {
            if (data1.ProductExists(addProduct.Product))
                return false;

            data1.Create(addProduct);
            return true;
        }
        public int SubTotal()
        {
            GetShipments();
            for (int x = 0; x < GetShipments().Count; x++)
            {
                quantity += GetShipments()[x].Quantity;
                int price = data1.GetShipments().First().Price;
                subTotal = price * quantity;
            }
            return subTotal;
        }
        public int Shipping(int fee)
        {
            if (SubTotal() >= 2000000)
            {
                fee = data1.GetShipments().First().Fee;
            }
            else
            {
                fee = 0;
            }
            return fee;
        }
        public int Total(int fee)
        {
            int shippingFee = Shipping(fee);
            int sum = SubTotal() + data1.GetShipments().First().Fee;
            int total = sum - shippingFee;
            return total;
        }
        public bool EditQuantity(Shipments updateQuantity)
        {

            var existingOrders = data1.GetById(updateQuantity.ShipmentId);

            if (existingOrders == null)
                return false;

            existingOrders.Quantity = updateQuantity.Quantity;

            data1.Update(existingOrders);

            return false;
        }
        public List<Shipments> GetShipments()
        {
            return data1.GetShipments();

        }
        public Shipments? GetShipment(Guid shipmentId)
        {
            return data1.GetById(shipmentId);
        }
        public void Update(Shipments shipment)
        {
            data1.Update(shipment);
        }
        public void Delete(Guid shipmentId)
        {
            data1.Delete(shipmentId);
        }
    }
}
