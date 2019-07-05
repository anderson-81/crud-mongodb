using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace libCrud
{
    public class Connection
    {
        public static IMongoDatabase Connect()
        {
            try
            {
                MongoClient client = new MongoClient("mongodb://localhost:27017");
                IMongoDatabase db = client.GetDatabase("dbSharp");
                return db;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
