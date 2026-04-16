using shipmentBusiness;
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
        static int fee;

        static void Main(string[] args)
        {
            Console.WriteLine("Order confirmation");

            Orders();
        }

        static void Orders()
        {
            var example = compare.GetShipment();
            for (int i = 0; i < example.Count; i++)
            {
                Console.WriteLine($"\n{example[i].Buyer} | (+63){example[i].Number} | {example[i].Address}"); ;
            }
            Console.WriteLine("----------------------------------------");
            for (int i = 0; i < example.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {example[i].Store} \nProduct for example: {example[i].Product} \n" +
                    $"Price: P{example[i].Price}    -| {example[i].Quantity} |+\n"); ;
            }
            Console.WriteLine("Order Summary");
            Console.WriteLine("Product Subtotal: " + compare.SubTotal());
            Console.WriteLine($"Shipping Subtotal: {compare.GetShipment().Last().Fee}");
            Console.WriteLine($"                  -" + compare.Shipping(fee));
            Console.WriteLine("Total: " + compare.Total(fee));
            Console.Write("Would you like to change anything on your order(y/n)? ");
            string firstAnswer = Console.ReadLine();
            char input = Char.ToLower(firstAnswer[0]);

            switch (input)
            {
                case 'y':
                    showOptions();
                    break;
                case 'n':
                    Console.WriteLine("\nPayment Method: ");
                    string[] paymentMethod = new string[] { "COD", "Maya", "G-Cash", "Bank account" };
                    showMethods(paymentMethod);
                    Choices();
                    break;
                default:
                    Console.WriteLine("()Loading....");
                    Environment.Exit(0);
                    break;
            }
        }

        static void Options()
        {
            Console.Write("\nWhat number would you like to do? ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Add();
                    break;
                case "2":
                    Update();
                    break;
                case "3":

                    bool sample = Delete();

                    while (sample)
                    {
                        Orders();
                        break;
                    }
                    break;
                default:
                    Orders();
                    break;
            }
        }

        static bool Delete()
        {
            var example = compare.GetShipment();
            Guid selectedId = example[0].ShipmentId;
            Console.Write("Are you sure you want to cancel your order(y/n)? ");
            bool sample = false;
            string secondAnswer = Console.ReadLine();
            switch (secondAnswer)
            {
                case "y":
                    compare.Delete(selectedId);
                    Environment.Exit(0);
                    sample = false;
                    break;
                case "n":
                    sample = true;
                    break;
                default:
                    Console.WriteLine("\nPlease answer with 'y' or 'n' only.");
                    Orders();
                    break;
            }
            return sample;
        }

        static void Update()
        {
            var example = compare.GetShipment();
            Console.Write("\nChoose a number to Select: ");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;
            if (index < 0 || index >= example.Count)
            {
                Console.WriteLine("\nPlease choose the order number.");
                Orders();
                return;
            }
            Guid selectedId = example[index].ShipmentId;
            Console.Write("How many pieces would you like to keep? ");
            int subQuantity = Convert.ToInt32(Console.ReadLine());
            if (subQuantity == 0)
            {
                bool sample = Delete();

                while (sample)
                {
                    Orders();
                    break;
                }
                return;
            }
            compare.Update(selectedId, subQuantity);
            Console.WriteLine("Successfully updated!");
            Orders();
            return;
        }

        static void Add()
        {
            var example = compare.GetShipment();
            Console.Write("\nChoose a number to Select: ");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;
            if (index < 0 || index >= example.Count)
            {
                Console.WriteLine("\nPlease choose the order number.");
                Orders();
                return;
            }
            Guid selectedId = example[index].ShipmentId;
            Console.Write("How many would you like to add? ");
            int addQuantity = Convert.ToInt32(Console.ReadLine());
            compare.Add(selectedId, addQuantity);
            Console.WriteLine("Successfully added!");
            Orders();
            return;
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

        static void showOptions()
        {
            string[] options = new string[] { "Add quantity", "Edit quantity", "Cancel order" };
            for (int x = 0; x < options.Length; x++)
            {
                Console.WriteLine($"[{x + 1}] {options[x]}");
            }
            Options();
        }

        static void showMethods(string[] methods)
        {
            for (int x = 0; x < methods.Length; x++)
            {
                Console.WriteLine($"[{x + 1}] {methods[x]}");
            }
        }
    }
}