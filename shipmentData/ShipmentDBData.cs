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
                Shipment shipment = new Shipment { ShipmentId = Guid.NewGuid(), Buyer = "clark", Number = "9876543210", Address = "santolan" };

                Add(shipment);
            }
        }
        public void Add(Shipment shipment)
        {
            var insertStatement = "INSERT INTO Shipments VALUES (@ShipmentId, @Buyer, @Number, @Address)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
            insertCommand.Parameters.AddWithValue("@ShipmentId", shipment.ShipmentId);
            insertCommand.Parameters.AddWithValue("@Buyer", shipment.Buyer);
            insertCommand.Parameters.AddWithValue("@Number", shipment.Number);
            insertCommand.Parameters.AddWithValue("@Address", shipment.Address);
            sqlConnection.Open();

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
        public List<Shipment> GetShipment()
        {
            string selectStatement = "SELECT ShipmentId, Buyer, Number, Address FROM Shipments";

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

                shipments.Add(shipment);
            }
            sqlConnection.Close();
            return shipments;
        }
        public Shipment? GetById(Guid id)
        {
            var selectStatement = "SELECT ShipmentId, Buyer, Number, Adress FROM Shipments WHERE ShipmentId = @ShipmentId";
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
            }

            sqlConnection.Close();
            return shipment;
        }
        public Shipment? GetByBuyer(string buyer)
        {
            var selectStatement = "SELECT ShipmentId, Buyer, Number, Address FROM Shipments WHERE Buyer = @buyer";
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
            }

            sqlConnection.Close();
            return shipment;
        }

        public void Update(Shipment shipment)
        {
            sqlConnection.Open();

            var updateStatement = $"UPDATE Shipments SET Buyer = @Buyer, Number = @Number, Address = @Address WHERE ShipmentId = @ShipmentId";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@Buyer", shipment.Buyer);
            updateCommand.Parameters.AddWithValue("@Number", shipment.Number);
            updateCommand.Parameters.AddWithValue("@Address", shipment.Address);
            updateCommand.Parameters.AddWithValue("@ShipmentId", shipment.ShipmentId);
            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public bool BuyerExists(string buyer)
        {
            var selectStatement = "SELECT ShipmentId, Buyer, Number, Address FROM Shipments WHERE Buyer = @Buyer";
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
            }

            sqlConnection.Close();
            return shipment.Buyer != null;
        }
    }
}
