using shipmentData;
using shipmentModel;

namespace shipmentBase
{
    public class Compare
    {
        savedData data1 = new savedData(new ShipmentDBData());
        savedDataInMemory inMemoryData = new savedDataInMemory();
        shipmentJsonData jsonData = new shipmentJsonData();

        //public Compare()
        //{
        //    ShipmentDBData shipmentDBData = new ShipmentDBData();
        //    //shipmentJsonData jsonData = new shipmentJsonData();
        //}

        public bool Register(Shipment newShipment)
        {

            if (data1.BuyerExists(newShipment.Buyer))
                return false;
            //var account = new Shipment
            //{
            //    Buyer = newShipment.Buyer,
            //    Number = newShipment.Number

            //};
            data1.Add(newShipment);
            return true;
        }

        //public string check()
        //{
        //    savedData data = new savedData();
        //    switch (data.getMonth())
        //    {
        //        case 1:
        //            Console.Write("January ");
        //            break;
        //        case 2:
        //            Console.Write("February ");
        //            break;
        //        case 3:
        //            Console.Write("March ");
        //            break;
        //        case 4:
        //            Console.Write("April ");
        //            break;
        //        case 5:
        //            Console.Write("May ");
        //            break;
        //        case 6:
        //            Console.Write("June ");
        //            break;
        //        case 7:
        //            Console.Write("July ");
        //            break;
        //        case 8:
        //            Console.Write("August ");
        //            break;
        //        case 9:
        //            Console.Write("September ");
        //            break;
        //        case 10:
        //            Console.Write("October ");
        //            break;
        //        case 11:
        //            Console.Write("November ");
        //            break;
        //        case 12:
        //            Console.Write("December ");
        //            break;
        //    }

        //}

        public int SubTotal()
        {
            int quantity = inMemoryData.GetDetails().First().Quantity;
            int price = inMemoryData.GetDetails().First().Price;
            int subTotal = price * quantity;
            return subTotal;
        }

        public int Shipping(int fee)
        {
            if (SubTotal() >= 50)
            {
                fee = inMemoryData.GetDetails().First().Fee;
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
            int subTotal = SubTotal() + inMemoryData.GetDetails().First().Fee;
            int total = subTotal - shippingFee;
            return total;
        }

        public void Update(Guid ShipmentId, string newName, string newContact, string newAddress)
        {
            var info = data1.GetShipment();
            var updInfo = info.FirstOrDefault(t => t.ShipmentId == ShipmentId);
            if (updInfo != null)
            {
                updInfo.Buyer = newName;
                updInfo.Number = newContact;
                updInfo.Address = newAddress;
                data1.Update(updInfo);
                jsonData.Update(updInfo);
                inMemoryData.Update(updInfo);
            }
        }

        public bool Authenticate(string buyer, string number, string address)
        {
            var account = data1.GetByBuyer(buyer);

            if (account == null)
                return false;

            return account.Address == address;
        }

        public List<Shipment> GetShipment()
        {
            return data1.GetShipment();

        }
        public Shipment? GetShipment(Guid shipmentId)
        {
            return data1.GetById(shipmentId);
        }
    }
}