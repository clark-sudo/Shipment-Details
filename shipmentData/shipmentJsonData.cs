using shipmentModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace shipmentData
{
    public class shipmentJsonData : iShipmentData
    {
        private List<Shipment> data1 = new List<Shipment>();

        private string JsonFileName;
        public shipmentJsonData()
        {
            JsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Shipment.json";

            PopulateJsonFile();
        }
        private void PopulateJsonFile()
        {
            RetrieveDataFromJsonFile();

            if (data1.Count <= 0)
            {
                data1.Add(new Shipment
                {
                    ShipmentId = Guid.NewGuid(),
                    Buyer = "clark",
                    Number = "987 654 3210",
                    Address = "santolan",
                    Store = "E-commerce Store",
                    Product = "Apple",
                    Price = 99999999,
                    Quantity = 9,
                    Fee = 30
                });
                SaveDataToJsonFile();
            }
        }
        private void SaveDataToJsonFile()
        {
            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<List<Shipment>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true }), data1);
            }
        }
        private void RetrieveDataFromJsonFile()
        {
            using (var jsonFileReader = File.OpenText(this.JsonFileName))
            {
                this.data1 = JsonSerializer.Deserialize<List<Shipment>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true }).ToList();
            }
        }
        public void Add(Shipment shipment)
        {
            //throw new NotImplementedException();
            data1.Add(shipment);
            SaveDataToJsonFile();
        }
        public List<Shipment> GetShipment()
        {
            //throw new NotImplementedException();
            RetrieveDataFromJsonFile();
            return data1;
        }
        public Shipment? GetById(Guid id)
        {
            //throw new NotImplementedException();
            RetrieveDataFromJsonFile();
            return data1.Where(x => x.ShipmentId == id).FirstOrDefault();
        }
        public Shipment? GetByBuyer(string buyer)
        {
            //throw new NotImplementedException();
            RetrieveDataFromJsonFile();
            return data1.Where(x => x.Buyer == buyer).FirstOrDefault();
        }
        public void Update(Shipment shipment)
        {
            //throw new NotImplementedException();
            RetrieveDataFromJsonFile();

            var existingShipment = data1.FirstOrDefault(x => x.ShipmentId == shipment.ShipmentId);
            if (existingShipment != null)
            {
                existingShipment.Buyer =
                shipment.Buyer;
                existingShipment.Number =
                shipment.Number;
                existingShipment.Address =
                shipment.Address;
            }

            SaveDataToJsonFile();
        }
        public bool BuyerExists(string buyer)
        {
            //throw new NotImplementedException();
            RetrieveDataFromJsonFile();
            return data1.Where(x => x.Buyer == buyer).Any();
        }
    }
}
