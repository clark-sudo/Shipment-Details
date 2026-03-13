using shipmentModel;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace shipmentData
{
    public class savedData
    {
        public string getBuyer()
        {
            string buyer = "clark";
            return buyer;
        }
        public string getNumber()
        {
            string number = "987 654 3210";
            return number;
        }
        public string getAddress()
        {
            string address = "santolan";
            return address;
        }
        public string getStore()
        {
            string store = "E-commerce Store";
            return store;
        }
        public string getProduct()
        {
            string store = "Apple";
            return store;
        }
        public int getPrice()
        {
            int price = 99999999;
            return price;
        }
        public int getQuantity()
        {
            int quantity = 9;
            return quantity;
        }
        public int getMonth()
        {
            int month = 1;
            return month;
        }
        public int getDay()
        {
            int day = 20;
            return day;
        }
        public int getSub()
        {
            int sub = getPrice() * getQuantity();
            return sub;
        }
        public int getFee()
        {
            int fee = 30;
            return fee;
        }
        public int getTotal()
        {
            int total = getSub();
            return total;
        }
    }
}