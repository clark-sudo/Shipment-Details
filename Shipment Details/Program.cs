namespace Shipment_Details
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Order confirmation");
            Console.Write("Enter your Name: ");
            string buyer = Console.ReadLine();
            Console.Write("Enter your Contact +63 ");
            int number = (int)Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter your Address: ");
            string address = Console.ReadLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("E-commerce store");
            Console.WriteLine("Product for example : Apple");
            Console.WriteLine("Price:   " + "quantity: ");
            Console.WriteLine("");
            Console.WriteLine("Range of date to receive");
            Console.WriteLine("");
            Console.WriteLine("Shop discount: ");
            Console.WriteLine("");
            Console.WriteLine("Order Summary");
            Console.WriteLine("Product Subtotal: ");
            Console.WriteLine("Shipping Subtotal: ");
            Console.WriteLine("Total: ");
            Console.WriteLine("");
            Console.WriteLine("Payment Method");
            Console.WriteLine("                         Place Order");
        }
    }
}
