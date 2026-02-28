namespace Shipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string store = "E-commerce Store";
            string product = "Apple";
            long price = (long)Convert.ToInt64(99999999);
            int quantity = (int)Convert.ToInt64(9);
            string month = "March";
            int day = (int)Convert.ToInt16(30);
            int pro = (int)Convert.ToInt64(price * quantity);
            int fee = (int)Convert.ToInt16(30);
            int total = (int)Convert.ToInt64(pro + fee);
            int method = (int)Convert.ToInt16(1);
            Console.WriteLine("Order confirmation");
            Console.Write("Enter your Name: ");
            string buyer = Console.ReadLine();
            Console.Write("Enter your Contact +63 ");
            int number = (int)Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter your Address: ");
            string address = Console.ReadLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine(store);
            Console.WriteLine("Product for example : " + product);
            Console.WriteLine("Price: P" + price + " quantity: " + quantity + "x");
            Console.WriteLine("");
            Console.WriteLine("Range of date to receive: " + month + " " + day);
            Console.WriteLine("");
            Console.Write("Shop discount: ");
            if (price > 50)
            {
                Console.WriteLine("Free shipping");
            }
            Console.WriteLine("");
            Console.WriteLine("Order Summary");
            Console.WriteLine("Product Subtotal: " + pro);
            Console.WriteLine("Shipping Subtotal: " + fee);
            if (price > 50)
            {
                Console.WriteLine("                  -" + fee);
            }
            Console.WriteLine("Total: " + total);
            Console.WriteLine("");
            Console.WriteLine("Payment Method");
            if (method == 1)
            {
                Console.WriteLine("Cash on delivery");
            }
            Console.WriteLine("                         Place Order");
        }
    }
}