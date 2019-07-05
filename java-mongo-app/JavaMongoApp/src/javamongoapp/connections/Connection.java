package javamongoapp.connections;

import com.mongodb.MongoClient;
import com.mongodb.client.MongoDatabase;

public class Connection {
    
     public static MongoDatabase Connect() {
        MongoClient client = new MongoClient("localhost", 27017);
        MongoDatabase db = client.getDatabase("dbSharp");
        return db;
    }
}
