
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
namespace AppDBDemo
{
    class Program {

        static void Main(string[] args)
        {
            MONGOCRUD db = new MONGOCRUD("Address");

            //PersonModel person = new PersonModel {
            //FirstName ="Glays",
            //LastName = "Eshun",
            //primaryAddress = new AddressModel
            //{
            //    StreetName ="London Ave",
            //    City = "Durham",
            //    State = "North Carolina",
            //    ZipCode = "3344"

            //}
            //}; 



            //db.InsertRecord("Users",person);

            var recs = db.LoadRecords<PersonModel>("Users");
            //foreach(var rec in recs)
            //{
            //    Console.WriteLine($"{rec.Id}: {rec.FirstName}  {rec.LastName}"); 

            //    if(rec.primaryAddress != null)
            //    {
            //        Console.WriteLine(rec.primaryAddress.City);
            //    }
            //    Console.WriteLine();
            //}

            //db.LoadRecordById<PersonModel>("Users",);

            Console.ReadKey();
        }

    }


    public class PersonModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AddressModel primaryAddress { get; set; }

    }

    public class AddressModel
    {
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

public class MONGOCRUD {
        private IMongoDatabase db;

        public MONGOCRUD(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);  
        }

        public void  InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);   
        }

        public List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();

        }

        public T LoadRecordById<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id",id);

            return collection.Find(filter).First();
        }
    }
}