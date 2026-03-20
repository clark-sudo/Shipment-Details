using System;
using shipmentBase;
using shipmentData;
using shipmentModel;

namespace shipmentDetails
{
    internal class Program
    {
        static List<string> accesslogs = new List<string>();

        static List<string> buyerName = new List<string>();
        static List<string> numberC = new List<string>();
        static List<string> addressM = new List<string>();

        static Compare compare = new Compare();
        static savedData data = new savedData();

        static void Main(string[] args)
        {
            Console.WriteLine("Order Confirmation");
            bool given = Option();
            while (given)
            {
                Given();
                break;
                //given = showDetailsOption();
            }
        }

        static bool Option()
        {
            Console.Write("Do you want to use the default info(y/n)? ");
            bool given = false;
            string firstAnswer = Console.ReadLine();
            char input = Char.ToLower(firstAnswer[0]);

            switch (input)
            {
                case 'y':
                    given = true;
                    break;
                case 'n':
                    Register();
                    Given();
                    break;
                default:
                    Console.WriteLine("()Loading....");
                    Environment.Exit(0);
                    break;
            }
            return given;
        }

        static bool Register()
        {
            Console.Write("Enter your Name: ");
            string buyer = Console.ReadLine();
            //for (int i = 0; i < buyerName.Count; i++)
            //{
            //    if (buyerName[i] == buyer)
            //    {
            //        Console.WriteLine("enter new username: ");
            //        string newusername = Console.ReadLine();
            //        Console.WriteLine("enter new password: ");
            //        string newpassword = Console.ReadLine();

            //        if (ValidateUserName(newusername))
            //        {
            //            buyerName[i] = newusername;
            //            numberC[i] = newpassword;
            //        }
            //        else
            //        {
            //            Console.WriteLine("user name already exists.");
            //        }
            //    }
            //}
            Console.Write("Enter your Contact +63 ");
            string number = Console.ReadLine();
            Console.Write("Enter your Address: ");
            string address = Console.ReadLine();
            //bool isMatched = compare.Authenticate(number, address);

            //AddAccessLogs(buyer, number, address, isMatched);
            Console.Write("Do you want to use it as default info(y/n)? ");
            bool given = false;
            string secondAnswer = Console.ReadLine();
            //Shipment newShipment = new Shipment { ShipmentId = Guid.NewGuid(), Buyer = buyer, Number = number, Address = address };
            //compare.Register(newShipment);

            switch (secondAnswer)
            {
                case "y":
                    given = true;
                    break;
                case "n":
                    Option();
                    break;
                default:
                    Console.WriteLine("()Loading....");
                    Environment.Exit(0);
                    break;
            }
            return given;
        }

        static bool ValidateUserName(string buyer)
        {
            bool valid = true;
            foreach (var un in buyerName)
            {
                if (un == buyer)
                {
                    valid = false;
                }
            }
            return valid;
        }

        static void Given()
        {
            Console.WriteLine("");
            Console.WriteLine($"{data.GetShipment().First().Buyer} | +63 {data.GetShipment().First().Number}");
            Console.WriteLine($"{data.GetShipment().First().Address}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"{data.GetDetails().First().Store}");
            Console.WriteLine($"Product for example: {data.GetDetails().First().Product}");
            Console.WriteLine($"Price: P{data.GetDetails().First().Price} Quantity: {data.GetDetails().First().Quantity}x");
            Console.WriteLine("");
            Console.WriteLine($"Range of Date to receive: {data.GetDetails().First().Month} {data.GetDetails().First().Day}");
            Console.WriteLine($"Shop discount: {data.GetDetails().First().Discount}");
            Console.WriteLine("");
            Console.WriteLine("Order Summary");
            Console.WriteLine("Product Subtotal: " + data.getSub());
            Console.WriteLine($"Shipping Subtotal: {data.GetDetails().First().Fee}");
            Console.WriteLine($"                  -{data.GetDetails().First().Fee}");
            Console.WriteLine("Total: " + data.getTotal());
            Console.WriteLine("Payment Method: ");
            Console.WriteLine("Type(1) COD");
            Console.WriteLine("Type(2) Maya");
            Console.WriteLine("Type(3) G-Cash");
            Console.WriteLine("Type(4) Bank account");
            Choices();
        }

        static bool Choices()
        {
            Console.Write("Please Enter: ");
            bool given = false;
            string payment = Console.ReadLine();
            switch (payment)
            {
                case "1":
                    Console.WriteLine("Cash on Delivery");
                    break;
                case "2":
                    Console.WriteLine("Maya");
                    break;
                case "3":
                    Console.WriteLine("G-Cash");
                    break;
                case "4":
                    Console.WriteLine("Bank account");
                    break;
                default:
                    Console.WriteLine(Choices());
                    break;
            }
            Console.WriteLine("                             Place Order");
            Environment.Exit(0);
            return given;
        }

        static void AddAccessLogs(string buyer, string number, string address, bool status)
        {
            accesslogs.Add($"username: {buyer}, phone: {number}, home: {address}, Is Successful?: {status}");
        }

    }
}