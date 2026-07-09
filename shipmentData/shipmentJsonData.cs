using shipmentModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace shipmentData
{
    public class shipmentJsonData : iShipmentData
    {
        private List<Shipments> data1 = new List<Shipments>();
        //private List<Shipments> data2 = new List<Shipments>();

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
                data1.Add(new Shipments
                {
                    ShipmentId = Guid.NewGuid(),
                    //Buyer = "clark",
                    //Number = "987 654 3210",
                    //Address = "santolan",
                    //Store = "E-commerce Store",
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
                JsonSerializer.Serialize<List<Shipments>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true }), data1);
            }
        }
        private void RetrieveDataFromJsonFile()
        {
            using (var jsonFileReader = File.OpenText(this.JsonFileName))
            {
                this.data1 = JsonSerializer.Deserialize<List<Shipments>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true }).ToList();
            }
        }
        public void Add(Shipments shipment)
        {
            //throw new NotImplementedException();
            data1.Add(shipment);
            SaveDataToJsonFile();
        }
        public List<Shipments> GetShipments()
        {
            //throw new NotImplementedException();
            RetrieveDataFromJsonFile();
            return data1;
        }
        public Shipments? GetById(Guid id)
        {
            //throw new NotImplementedException();
            RetrieveDataFromJsonFile();
            return data1.Where(x => x.ShipmentId == id).FirstOrDefault();
        }
        public Shipments? GetByProduct(string product)
        {
            //throw new NotImplementedException();
            RetrieveDataFromJsonFile();
            return data1.Where(x => x.Product == product).FirstOrDefault();
        }
        public void Edit(Shipments shipment)
        {
            //throw new NotImplementedException();
            RetrieveDataFromJsonFile();

            var existingShipment = data1.FirstOrDefault(x => x.ShipmentId == shipment.ShipmentId);
            if (existingShipment != null)
            {
                existingShipment.Quantity =
                shipment.Quantity;
                //existingShipment.Number =
                //shipment.Number;
                //existingShipment.Address =
                //shipment.Address;
            }

            SaveDataToJsonFile();
        }
        public void Remove(Guid id)
        {
            throw new NotImplementedException();
            //data1.Remove(shipment);
            //SaveDataToJsonFile();
        }
        public bool ProductExists(string product)
        {
            //throw new NotImplementedException();
            RetrieveDataFromJsonFile();
            return data1.Where(x => x.Product == product).Any();
        }
    }
}
