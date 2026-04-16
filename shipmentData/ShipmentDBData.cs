using Microsoft.Data.SqlClient;
using shipmentModel;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace shipmentData
{
    public class ShipmentDBData : iShipmentData
    {
        private string connectonString
            = "Data Source =localhost\\SQLEXPRESS; Initial Catalog =shipmentDetails; Integrated Security =True; TrustServerCertificate =True;";
        private SqlConnection sqlConnection;
        public ShipmentDBData()
        {
            sqlConnection = new SqlConnection(connectonString);
            AddSeeds();
        }
        private void AddSeeds()
        {
            var existing = GetShipment();

            if (existing.Count == 0)
            {
                Shipment shipment = new Shipment
                {
                    ShipmentId = Guid.NewGuid(),
                    Buyer = "clark",
                    Number = "9876543210",
                    Address = "santolan",
                    Store = "E-commerce Store",
                    Product = "Apple",
                    Price = 99999999,
                    Quantity = 9,
                    Fee = 30
                };

                Add(shipment);
            }
        }
        public void Add(Shipment shipment)
        {
            var insertStatement = "INSERT INTO Shipment VALUES (@ShipmentId, @Buyer, @Number, @Address, @Store, @Product, @Price, @Quantity, @Fee)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
            insertCommand.Parameters.AddWithValue("@ShipmentId", shipment.ShipmentId);
            insertCommand.Parameters.AddWithValue("@Buyer", shipment.Buyer);
            insertCommand.Parameters.AddWithValue("@Number", shipment.Number);
            insertCommand.Parameters.AddWithValue("@Address", shipment.Address);
            insertCommand.Parameters.AddWithValue("@Store", shipment.Store);
            insertCommand.Parameters.AddWithValue("@Product", shipment.Product);
            insertCommand.Parameters.AddWithValue("@Price", shipment.Price);
            insertCommand.Parameters.AddWithValue("@Quantity", shipment.Quantity);
            insertCommand.Parameters.AddWithValue("@Fee", shipment.Fee);
            sqlConnection.Open();

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
        public List<Shipment> GetShipment()
        {
            string selectStatement = "SELECT ShipmentId, Buyer, Number, Address, Store, Product, Price, Quantity, Fee FROM Shipment";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var shipments = new List<Shipment>();

            while (reader.Read())
            {
                Shipment shipment = new Shipment();
                shipment.ShipmentId = Guid.Parse(reader["ShipmentId"].ToString());
                shipment.Buyer = reader["Buyer"].ToString();
                shipment.Number = reader["Number"].ToString();
                shipment.Address = reader["Address"].ToString();
                shipment.Store = reader["Store"].ToString();
                shipment.Product = reader["Product"].ToString();
                shipment.Price = Convert.ToInt32(reader["Price"]);
                shipment.Quantity = Convert.ToInt32(reader["Quantity"]);
                shipment.Fee = Convert.ToInt32(reader["Fee"]);

                shipments.Add(shipment);
            }
            sqlConnection.Close();
            return shipments;
        }
        public Shipment? GetById(Guid id)
        {
            var selectStatement = "SELECT ShipmentId, Buyer, Number, Address, Store, Product, Price, Quantity, Fee FROM Shipment WHERE ShipmentId = @ShipmentId";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@ShipmentId", id.ToString());
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var shipment = new Shipment();

            while (reader.Read())
            {
                shipment.ShipmentId = Guid.Parse(reader["ShipmentId"].ToString());
                shipment.Buyer = reader["Buyer"].ToString();
                shipment.Number = reader["Number"].ToString();
                shipment.Address = reader["Address"].ToString();
                shipment.Store = reader["Store"].ToString();
                shipment.Product = reader["Product"].ToString();
                shipment.Price = Convert.ToInt32(reader["Price"]);
                shipment.Quantity = Convert.ToInt32(reader["Quantity"]);
                shipment.Fee = Convert.ToInt32(reader["Fee"]);
            }

            sqlConnection.Close();
            return shipment;
        }
        public Shipment? GetByBuyer(string buyer)
        {
            var selectStatement = "SELECT ShipmentId, Buyer, Number, Address, Store, Product, Price, Quantity, Fee FROM Shipment WHERE Buyer = @buyer";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@Buyer", buyer);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var shipment = new Shipment();

            while (reader.Read())
            {
                shipment.ShipmentId = Guid.Parse(reader["ShipmentId"].ToString());
                shipment.Buyer = reader["Buyer"].ToString();
                shipment.Number = reader["Number"].ToString();
                shipment.Address = reader["Address"].ToString();
                shipment.Store = reader["Store"].ToString();
                shipment.Product = reader["Product"].ToString();
                shipment.Price = Convert.ToInt32(reader["Price"]);
                shipment.Quantity = Convert.ToInt32(reader["Quantity"]);
                shipment.Fee = Convert.ToInt32(reader["Fee"]);
            }

            sqlConnection.Close();
            return shipment;
        }

        public void Update(Shipment shipment)
        {
            sqlConnection.Open();

            var updateStatement = $"UPDATE Shipment SET Buyer = @Buyer, Number = @Number, Address = @Address, Store = @Store, Product = @Product, Price = @Price, Quantity = @Quantity, Fee = @Fee WHERE ShipmentId = @ShipmentId";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@Buyer", shipment.Buyer);
            updateCommand.Parameters.AddWithValue("@Number", shipment.Number);
            updateCommand.Parameters.AddWithValue("@Address", shipment.Address);
            updateCommand.Parameters.AddWithValue("@Store", shipment.Store);
            updateCommand.Parameters.AddWithValue("@Product", shipment.Product);
            updateCommand.Parameters.AddWithValue("@Price", shipment.Price);
            updateCommand.Parameters.AddWithValue("@Quantity", shipment.Quantity);
            updateCommand.Parameters.AddWithValue("@Fee", shipment.Fee);
            updateCommand.Parameters.AddWithValue("@ShipmentId", shipment.ShipmentId);
            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public bool BuyerExists(string buyer)
        {
            var selectStatement = "SELECT ShipmentId, Buyer, Number, Address, Store, Product, Price, Quantity, Fee FROM Shipment WHERE Buyer = @Buyer";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@Buyer", buyer);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var shipment = new Shipment();

            while (reader.Read())
            {
                shipment.ShipmentId = Guid.Parse(reader["ShipmentId"].ToString());
                shipment.Buyer = reader["Buyer"].ToString();
                shipment.Number = reader["Number"].ToString();
                shipment.Address = reader["Address"].ToString();
                shipment.Store = reader["Store"].ToString();
                shipment.Product = reader["Product"].ToString();
                shipment.Price = Convert.ToInt32(reader["Price"]);
                shipment.Quantity = Convert.ToInt32(reader["Quantity"]);
                shipment.Fee = Convert.ToInt32(reader["Fee"]);
            }

            sqlConnection.Close();
            return shipment.Buyer != null;
        }
    }
}
