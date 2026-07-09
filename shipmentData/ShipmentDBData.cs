using shipmentModel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
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
            var example = GetShipments();

            if (example.Count == 0)
            {
                Shipments shipments = new Shipments
                {
                    ShipmentId = Guid.NewGuid(),
                    //Buyer = "clark",
                    //Number = "9876543210",
                    //Address = "santolan",
                    //Store = "E-commerce Store",
                    Product = "Apple",
                    Price = 999,
                    Quantity = 7,
                    Fee = 30
                };

                Add(shipments);
            }
        }
        public void Add(Shipments shipments)
        {
            var insertStatement = "INSERT INTO Shipments VALUES (@ShipmentId, @Product, @Quantity, @Price, @Fee)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
            insertCommand.Parameters.AddWithValue("@ShipmentId", shipments.ShipmentId);
            //insertCommand.Parameters.AddWithValue("@Buyer", shipments.Buyer);
            //insertCommand.Parameters.AddWithValue("@Number", shipments.Number);
            //insertCommand.Parameters.AddWithValue("@Address", shipments.Address);
            //insertCommand.Parameters.AddWithValue("@Store", shipments.Store);
            insertCommand.Parameters.AddWithValue("@Product", shipments.Product);
            insertCommand.Parameters.AddWithValue("@Quantity", shipments.Quantity);
            insertCommand.Parameters.AddWithValue("@Price", shipments.Price);
            insertCommand.Parameters.AddWithValue("@Fee", shipments.Fee);
            sqlConnection.Open();

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
        public List<Shipments> GetShipments()
        {
            string selectStatement = "SELECT ShipmentId, Product, Quantity, Price, Fee FROM Shipments";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var shipments = new List<Shipments>();

            while (reader.Read())
            {
                Shipments shipment = new Shipments();
                shipment.ShipmentId = Guid.Parse(reader["ShipmentId"].ToString());
                //shipment.Buyer = reader["Buyer"].ToString();
                //shipment.Number = reader["Number"].ToString();
                //shipment.Address = reader["Address"].ToString();
                //shipment.Store = reader["Store"].ToString();
                shipment.Product = reader["Product"].ToString();
                shipment.Quantity = Convert.ToInt16(reader["Quantity"]);
                shipment.Price = Convert.ToInt32(reader["Price"]);
                shipment.Fee = Convert.ToInt32(reader["Fee"]);

                shipments.Add(shipment);
            }
            sqlConnection.Close();
            return shipments;
        }
        public Shipments? GetById(Guid id)
        {
            var selectStatement = "SELECT ShipmentId, Product, Quantity, Price, Fee FROM Shipments WHERE ShipmentId = @ShipmentId";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@ShipmentId", id.ToString());
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var shipment = new Shipments();

            while (reader.Read())
            {
                shipment.ShipmentId = Guid.Parse(reader["ShipmentId"].ToString());
                //shipment.Buyer = reader["Buyer"].ToString();
                //shipment.Number = reader["Number"].ToString();
                //shipment.Address = reader["Address"].ToString();
                //shipment.Store = reader["Store"].ToString();
                shipment.Product = reader["Product"].ToString();
                shipment.Quantity = Convert.ToInt16(reader["Quantity"]);
                shipment.Price = Convert.ToInt32(reader["Price"]);
                shipment.Fee = Convert.ToInt32(reader["Fee"]);
            }

            sqlConnection.Close();
            return shipment;
        }
        public Shipments? GetByProduct(string product)
        {
            var selectStatement = "SELECT ShipmentId, Product, Quantity, Price, Fee FROM Shipments WHERE Product = @product";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@Product", product);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var shipment = new Shipments();

            while (reader.Read())
            {
                shipment.ShipmentId = Guid.Parse(reader["ShipmentId"].ToString());
                //shipment.Buyer = reader["Buyer"].ToString();
                //shipment.Number = reader["Number"].ToString();
                //shipment.Address = reader["Address"].ToString();
                //shipment.Store = reader["Store"].ToString();
                shipment.Product = reader["Product"].ToString();
                shipment.Quantity = Convert.ToInt16(reader["Quantity"]);
                shipment.Price = Convert.ToInt32(reader["Price"]);
                shipment.Fee = Convert.ToInt32(reader["Fee"]);
            }

            sqlConnection.Close();
            return shipment;
        }
        public void Edit(Shipments shipment)
        {
            var updateStatement = $"UPDATE Shipments SET Product = @Product, Quantity = @Quantity, Price = @Price, Fee = @Fee WHERE ShipmentId = @ShipmentId";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            //updateCommand.Parameters.AddWithValue("@Buyer", shipment.Buyer);
            //updateCommand.Parameters.AddWithValue("@Number", shipment.Number);
            //updateCommand.Parameters.AddWithValue("@Address", shipment.Address);
            //updateCommand.Parameters.AddWithValue("@Store", shipment.Store);
            updateCommand.Parameters.AddWithValue("@Product", shipment.Product);
            updateCommand.Parameters.AddWithValue("@Quantity", shipment.Quantity);
            updateCommand.Parameters.AddWithValue("@Price", shipment.Price);
            updateCommand.Parameters.AddWithValue("@Fee", shipment.Fee);
            updateCommand.Parameters.AddWithValue("@ShipmentId", shipment.ShipmentId);
            updateCommand.ExecuteNonQuery();

            sqlConnection.Open();

            sqlConnection.Close();
        }
        public bool ProductExists(string product)
        {
            var selectStatement = "SELECT ShipmentId, Product, Quantity, Price, Fee FROM Shipments WHERE Product = @Product";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@Product", product);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var shipment = new Shipments();

            while (reader.Read())
            {
                shipment.ShipmentId = Guid.Parse(reader["ShipmentId"].ToString());
                //shipment.Buyer = reader["Buyer"].ToString();
                //shipment.Number = reader["Number"].ToString();
                //shipment.Address = reader["Address"].ToString();
                //shipment.Store = reader["Store"].ToString();
                shipment.Product = reader["Product"].ToString();
                shipment.Quantity = Convert.ToInt16(reader["Quantity"]);
                shipment.Price = Convert.ToInt32(reader["Price"]);
                shipment.Fee = Convert.ToInt32(reader["Fee"]);
            }

            sqlConnection.Close();
            return shipment.Product != null;
        }
        public void Remove(Guid id)
        {
            sqlConnection.Open();

            var deleteStatement = "DELETE FROM Shipments WHERE ShipmentId = @ShipmentId";

            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);

            deleteCommand.Parameters.AddWithValue("@ShipmentId", id.ToString());
            //deleteCommand.Parameters.AddWithValue("@Buyer", shipments.Buyer);
            //deleteCommand.Parameters.AddWithValue("@Number", shipments.Number);
            //deleteCommand.Parameters.AddWithValue("@Address", shipments.Address);
            //deleteCommand.Parameters.AddWithValue("@Store", shipments.Store);
            //deleteCommand.Parameters.AddWithValue("@Product", shipments.Product);
            //deleteCommand.Parameters.AddWithValue("@Quantity", shipments.Quantity);
            //deleteCommand.Parameters.AddWithValue("@Price", shipments.Price);
            //deleteCommand.Parameters.AddWithValue("@Fee", shipments.Fee);

            deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
