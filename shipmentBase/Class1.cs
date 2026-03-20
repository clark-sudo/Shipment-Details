using shipmentData;
using shipmentModel;
using System.Security.Principal;

namespace shipmentBase
{
    public class Compare
    {
        savedData data = new savedData();

        public bool Register(Shipment newShipment)
        {

            if (data.BuyerExists(newShipment.Buyer))
                return false;
            //var account = new Shipment
            //{
            //    Buyer = newShipment.Buyer,
            //    Number = newShipment.Number

            //};
            data.Add(newShipment);
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

        //public void compare()
        //{
        //    savedData data = new savedData();
        //    if (data.getSub() >= 50)
        //    {
        //        Console.Write("Shop Discount: Free Shipping");
        //        Console.WriteLine("");
        //        Console.WriteLine("Order Summary");
        //        Console.WriteLine("Product Subtotal: " + data.getSub());
        //        Console.WriteLine("Shipping Subtotal:  " + data.getFee());
        //        Console.WriteLine("                   -" + data.getFee());
        //    }
        //}

        public bool Authenticate(string number, string address)
        {
            var account = data.GetByBuyer(number);

            if (account == null)
                return false;

            return account.Address == address;
        }

        public List<Shipment> GetShipment()
        {
            return data.GetShipment();

        }
        public Shipment? GetShipment(Guid shipmentId)
        {
            return data.GetById(shipmentId);
        }
    }
}