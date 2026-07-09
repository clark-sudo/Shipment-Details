using shipmentBusiness;
using shipmentData;
using shipmentModel;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System;
using static Microsoft.Data.SqlClient.Internal.SqlClientEventSource;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace testRun
{
    internal class Program
    {
        static string[] availableItems = new string[] { "Monitor", "Printer", "Speaker", "System Unit", "Projector" };
        static int x, price, fee;
        static short quantity, index;
        static string product;
        static bool given;

        static Compare compare = new Compare();
        static void Main(string[] args)
        {
            Console.WriteLine("E-commerce Store\n");
            showItems(availableItems);
            Add();
        }
        static void Add()
        {
            var unitPrice = compare.GetShipments();
            for (x = 0; x <= 100; x--)
            {
                Console.Write("\nType 0 if nothing to add.\nEnter the number of the item to order: ");
                string order = Console.ReadLine();

                switch (order)
                {
                    case "0":
                        x = 1000;
                        break;
                    case "1":
                        Console.Write($"Enter how many {availableItems[0]} you want to order: ");
                        quantity = Convert.ToInt16(Console.ReadLine());
                        product = availableItems[0];
                        fee = unitPrice[x].Fee;
                        price = unitPrice[x].Price;
                        Shipments add1 = new Shipments { ShipmentId = Guid.NewGuid(), Product = product, Quantity = quantity, Price = price, Fee = fee };

                        compare.Create(add1);

                        Console.WriteLine($"Successfully added order {add1.ShipmentId}");
                        x += 1;
                        break;
                    case "2":
                        Console.Write($"Enter how many {availableItems[1]} you want to order: ");
                        quantity = Convert.ToInt16(Console.ReadLine());
                        product = availableItems[1];
                        fee = unitPrice[x].Fee;
                        price = unitPrice[x].Price;
                        Shipments add2 = new Shipments { ShipmentId = Guid.NewGuid(), Product = product, Quantity = quantity, Price = price, Fee = fee };

                        compare.Create(add2);

                        Console.WriteLine($"Successfully added order {add2.ShipmentId}");
                        x += 1;
                        break;
                    case "3":
                        Console.Write($"Enter how many {availableItems[2]} you want to order: ");
                        quantity = Convert.ToInt16(Console.ReadLine());
                        product = availableItems[2];
                        fee = unitPrice[x].Fee;
                        price = unitPrice[x].Price;
                        Shipments add3 = new Shipments { ShipmentId = Guid.NewGuid(), Product = product, Quantity = quantity, Price = price, Fee = fee };

                        compare.Create(add3);

                        Console.WriteLine($"Successfully added order {add3.ShipmentId}");
                        x += 1;
                        break;
                    case "4":
                        Console.Write($"Enter how many {availableItems[3]} you want to order: ");
                        quantity = Convert.ToInt16(Console.ReadLine());
                        product = availableItems[3];
                        fee = unitPrice[x].Fee;
                        price = unitPrice[x].Price;
                        Shipments add4 = new Shipments { ShipmentId = Guid.NewGuid(), Product = product, Quantity = quantity, Price = price, Fee = fee };

                        compare.Create(add4);

                        Console.WriteLine($"Successfully added order {add4.ShipmentId}");
                        x += 1;
                        break;
                    case "5":
                        Console.Write($"Enter how many {availableItems[4]} you want to order: ");
                        quantity = Convert.ToInt16(Console.ReadLine());
                        product = availableItems[4];
                        fee = unitPrice[x].Fee;
                        price = unitPrice[x].Price;
                        Shipments add5 = new Shipments { ShipmentId = Guid.NewGuid(), Product = product, Quantity = quantity, Price = price, Fee = fee };

                        compare.Create(add5);

                        Console.WriteLine($"Successfully added order {add5.ShipmentId}");
                        x += 1;
                        break;
                    default:
                        Console.WriteLine("Incorrect input. Please check the list of available items above.");
                        x +=1;
                        break;
                }
            }
            Confirmation();
        }
        static void Edit()
        {
            var example = compare.GetShipments();
            Console.Write("\nChoose the order number to Update: ");
            index = Convert.ToInt16(Console.ReadLine());
            if (index - 1 >= 0 && index - 1 <= example.Count)
            {
                Guid selectedId = example[index - 1].ShipmentId;
                product = example[index - 1].Product;
                Console.Write("How many pieces would you like to keep? ");
                quantity = Convert.ToInt16(Console.ReadLine());
                price = example[index - 1].Price;
                Shipments edit = new Shipments { ShipmentId = selectedId, Product = product, Quantity = quantity, Price = price };
                if (quantity == 0)
                {
                    bool sample = Remove();

                    while (sample)
                    {
                        Confirmation();
                        break;
                    }
                    return;
                }
                compare.Update(edit);
                Console.WriteLine("Successfully updated!");
                Confirmation();
            }
            else
            {
                Console.WriteLine("\nPlease choose the order number.");
                Confirmation();
                return;
            }
            return;
        }
        static bool Remove()
        {
            var example = compare.GetShipments();
            Console.Write("\nChoose the order number to Delete: ");
            index = Convert.ToInt16(Console.ReadLine());
            if (index - 1 >= 0 && index - 1 <= example.Count)
            {
            Guid selectedId = example[index - 1].ShipmentId;
            Console.Write("Are you sure you want to cancel your order(y/n)? ");
            given = false;
            string secondAnswer = Console.ReadLine();
            switch (secondAnswer)
            {
                case "y":
                        compare.Delete(selectedId);
                        Confirmation();
                        given = false;
                    break;
                case "n":
                    given = true;
                    break;
                default:
                    Console.WriteLine("\nPlease answer with 'y' or 'n' only.");
                    Confirmation();
                    break;
            }
            }
            else
            {
                Console.WriteLine("\nPlease choose the order number.");
                Confirmation();
            }
            return given;
        }
        static void Confirmation()
        {
            Console.WriteLine("\nOrder confirmation");
            Console.WriteLine("\nclark | (+63)9876543210 | santolan");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("\nE-commerce Store");
            var order = compare.GetShipments();
            for (x = 0; x < order.Count; x++)
            {
                Console.WriteLine($"{x + 1}. Product : {order[x].Product} \n" +
                    $"Price: P{order[x].Price}    -| {order[x].Quantity} |+\n");
            }
            Console.WriteLine("Order Summary");
            if (compare.GetShipments().First().Fee == null)
            {
                Console.WriteLine("Product Subtotal: 0");
                Console.WriteLine("Shipping Subtotal: 0");
            }
            else
            {
                Console.WriteLine("Product Subtotal: " + compare.SubTotal());
                Console.WriteLine($"Shipping Subtotal: {compare.GetShipments().First().Fee}");
            }
            Console.WriteLine($"                  -" + compare.Shipping(fee));
            Console.WriteLine("Total: " + compare.Total(fee));
            Console.Write("Would you like to change anything on your order(y/n)? ");
            string firstAnswer = Console.ReadLine();
            char input = Char.ToLower(firstAnswer[0]);

            switch (input)
            {
                case 'y':
                    string[] options = new string[] { "Add order", "Edit quantity", "Cancel order" };
                    showOptions(options);
                    break;
                case 'n':
                    Console.WriteLine("\nPayment Method: ");
                    string[] paymentMethod = new string[] { "COD", "Maya", "G-Cash", "Bank account" };
                    showMethods(paymentMethod);
                    break;
                default:
                    Console.WriteLine("()Loading....");
                    Environment.Exit(0);
                    break;
            }
        }
        static void showOptions(string[] options)
        {
            for (x = 0; x < options.Length; x++)
            {
                Console.WriteLine($"({x + 1}) {options[x]}");
            }
            Options();
        }
        static bool Options()
        {
            Console.Write("\nWhat number would you like to do? ");
            given = false;
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Add();
                    break;
                case "2":
                    Edit();
                    break;
                case "3":

                    bool sample = Remove();

                    while (sample)
                    {
                        Confirmation();
                        break;
                    }
                    break;
                default:
                    Console.WriteLine(Options());
                    break;
            }
            return given;
        }
        static void showMethods(string[] methods)
        {
            for (x = 0; x < methods.Length; x++)
            {
                Console.WriteLine($"[{x + 1}] {methods[x]}");
            }
            Choices();
        }
        static bool Choices()
        {
            Console.Write("Please Enter: ");
            given = false;
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
        static void showItems(string[] items)
        {
            for (x = 0; x < items.Length; x++)
            {
                Console.WriteLine($"{x + 1}. {items[x]}");
            }
        }
    }
}
