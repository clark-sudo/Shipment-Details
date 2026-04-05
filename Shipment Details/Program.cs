using shipmentBase;
using shipmentData;
using shipmentModel;
using System;
using static Microsoft.Data.SqlClient.Internal.SqlClientEventSource;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace shipmentDetails
{
    internal class Program
    {
        static Compare compare = new Compare();
        static savedDataInMemory data = new savedDataInMemory();
        static int fee;

        static void Main(string[] args)
        {
            Console.WriteLine("Order confirmation");

            bool given = Option();

            while (given)
            {
                Given();
                break;
            }
        }

        static bool Option()
        {
            var example = compare.GetShipment();
            for (int i = 0; i < example.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {example[i].Buyer} | (+63){example[i].Number} | {example[i].Address}"); ;
            }
            Console.Write("Do you want to change the default info(y/n)? ");
            bool given = false;
            string firstAnswer = Console.ReadLine();
            char input = Char.ToLower(firstAnswer[0]);

            switch (input)
            {
                case 'y':
                    Update();
                    given = true;
                    break;
                case 'n':
                    Register();
                    given = true;
                    break;
                default:
                    Console.WriteLine("()Loading....");
                    Environment.Exit(0);
                    break;
            }
            return given;
        }

        static void Update()
        {
            var example = compare.GetShipment();
            Console.Write("\nChoose a number to Select: ");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;
            if (index < 0 || index >= example.Count)
            {
                Console.WriteLine("\nPlease read or add new contact information.");
                Option();
            }
            Guid selectedId = example[index].ShipmentId;
            Console.Write("Enter new Username: ");
            string newName = Console.ReadLine();
            Console.Write("Enter new Contact +63 ");
            string newContact = Console.ReadLine();
            Console.Write("Enter new Address: ");
            string newAddress = Console.ReadLine();
            compare.Update(selectedId, newName, newContact, newAddress);
            Console.WriteLine("Successfully updated!");
            return;
        }

        static void Register()
        {
            var example = compare.GetShipment();
            Console.Write("Choose a number to Select: ");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;
            if (index < 0 || index >= example.Count)
            {
                Console.WriteLine("Please add new contact information.");
                Console.Write("Enter your Name: ");
                string buyer = Console.ReadLine();
                Console.Write("Enter your Contact +63 ");
                string number = Console.ReadLine();
                Console.Write("Enter your Address: ");
                string address = Console.ReadLine();

                Console.Write("Do you want to use it as default info(y/n)? ");
                bool given = false;
                string secondAnswer = Console.ReadLine();
                Shipment newShipment = new Shipment { ShipmentId = Guid.NewGuid(), Buyer = buyer, Number = number, Address = address };
                compare.Register(newShipment);

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
                return;
            }
        }

        static void Given()
        {

            Console.WriteLine("");
            Console.WriteLine($"{data.GetShipment().Last().Buyer} | (+63){data.GetShipment().Last().Number}");
            Console.WriteLine($"{data.GetShipment().Last().Address}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"{data.GetDetails().First().Store}");
            Console.WriteLine($"Product for example: {data.GetDetails().First().Product}");
            Console.WriteLine($"Price: P{data.GetDetails().First().Price} Quantity: {data.GetDetails().First().Quantity}x");
            Console.WriteLine("");
            Console.WriteLine($"Range of Date to receive: {data.GetDetails().First().Month} {data.GetDetails().First().Day}");
            Console.WriteLine("");
            Console.WriteLine($"Shop discount: {data.GetDetails().First().Discount}");
            Console.WriteLine("");
            Console.WriteLine("Order Summary");
            Console.WriteLine("Product Subtotal: " + compare.SubTotal());
            Console.WriteLine($"Shipping Subtotal: {data.GetDetails().First().Fee}");
            Console.WriteLine($"                  -" + compare.Shipping(fee));
            Console.WriteLine("Total: " + compare.Total(fee));
            Console.WriteLine("");
            Console.WriteLine("Payment Method: ");
            string[] paymentMethod = new string[] { "COD", "Maya", "G-Cash", "Bank account" };
            ShowOptions(paymentMethod);
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

        static void ShowOptions(string[] methods)
        {
            for (int x = 0; x < methods.Length; x++)
            {
                Console.WriteLine($"[{x + 1}] {methods[x]}");
            }
        }
    }
}