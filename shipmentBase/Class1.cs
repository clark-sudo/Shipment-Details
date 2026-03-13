using System;
using System.Security.Cryptography.X509Certificates;
using shipmentData;
using shipmentModel;

namespace shipmentBase
{
    public class Compare
    {
        savedData data = new savedData();
        public void register(char firstChar)
        {
            do
            {
                Console.Write("Enter your Name: ");
                string buyer = Console.ReadLine();
                Console.Write("Enter your Contact +63 ");
                string number = Console.ReadLine();
                Console.Write("Enter your Address: ");
                string address = Console.ReadLine();
                Console.Write("Do you want to use it as default info(y/n)? ");
                string str = Console.ReadLine();
                if (!string.IsNullOrEmpty(str))
                    firstChar = char.ToLower(str[0]);
                else
                    firstChar = 'n';
            } while (firstChar != 'y');
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

        public void register()
        {
            throw new NotImplementedException();
        }

        public void method()
        {
            Console.Write("Please Enter: ");
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
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }

    }
}