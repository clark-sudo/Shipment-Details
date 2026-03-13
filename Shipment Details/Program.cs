using System;
using shipmentBase;
using shipmentData;

namespace shipmentDetails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Order confirmation");
            bool given = showDetailsOption();
            while (given)
            {
                Given();
                break;
            }
        }

        static bool showDetailsOption()
        {
            Console.Write("Do you want to use the default info(y/n)? ");
            bool given = false;
            string firstAnswer = Console.ReadLine();

            switch (firstAnswer)
            {
                case "y":
                    given = true;
                    break;
                default:
                    Compare c = new Compare();
                    c.register();
                    Given();
                    break;
            }
            return given;
        }

        static void Given()
        {
            savedData data = new savedData();
            Compare c = new Compare();
            Console.WriteLine("");
            Console.WriteLine(data.getBuyer() + " | +63 " + data.getNumber());
            Console.WriteLine(data.getAddress());
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(data.getStore());
            Console.WriteLine("Product for example: " + data.getProduct());
            Console.WriteLine("Price: P" + data.getPrice() + " Quantity: " + data.getQuantity() + "x");
            Console.WriteLine("");
            Console.WriteLine("Range of Date to Receive: " + data.getMonth() + " " + data.getDay());
            Console.WriteLine("Shop Discount: ");
            Console.WriteLine("");
            Console.WriteLine("Order Summary");
            Console.WriteLine("Product Subtotal: " + data.getSub());
            Console.WriteLine("Shipping Subtotal: " + data.getFee());
            Console.WriteLine("");
            Console.WriteLine("Total: " + data.getTotal());
            Console.WriteLine("Payment Method: ");
            Console.WriteLine("Type(1) COD");
            Console.WriteLine("Type(2) Maya");
            Console.WriteLine("Type(3) G-Cash");
            Console.WriteLine("Type(4) Bank account");
            //Console.WriteLine(c.method);
            Console.WriteLine("                             Place Order");
        }
    }
}