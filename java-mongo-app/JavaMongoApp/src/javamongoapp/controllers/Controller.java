package javamongoapp.controllers;

import com.mongodb.client.FindIterable;
import com.mongodb.client.MongoCollection;
import com.mongodb.client.MongoDatabase;
import com.mongodb.client.model.Filters;
import java.util.ArrayList;
import java.util.List;
import java.util.regex.Pattern;
import javamongoapp.entities.Person;
import javamongoapp.connections.Connection;
import org.bson.Document;
import org.bson.conversions.Bson;

public class Controller {

    //Atributtes
    private final MongoDatabase conn;
    private Person p;

    //Constructors
    public Controller() {
        this.conn = Connection.Connect();
    }

    public Controller(Person p) {
        this.conn = Connection.Connect();
        this.p = p;
    }

    //Methods of registering Person.
    //Insert Person.
    public int Insert_Person() {
        try {
            MongoCollection<Document> col = this.conn.getCollection("persons");
            Document docPerson = new Document();
            docPerson.put("Name", p.getName());
            docPerson.put("Email", p.getEmail());
            Document docPhysicalPerson = new Document();
            docPhysicalPerson.put("Salary", p.getPhysicalPerson().getSalary());
            docPhysicalPerson.put("Birthday", p.getPhysicalPerson().getBirthday());
            docPhysicalPerson.put("Gender", p.getPhysicalPerson().getGender());
            docPerson.put("PhysicalPerson", docPhysicalPerson);
            col.insertOne(docPerson);
            return 1;
        } catch (Exception e) {
            return -1;
        }
    }

    //Edit Person.
    public int Edit_Person() {
        try {
            MongoCollection<Document> col = this.conn.getCollection("persons");
            Document docPerson = new Document();
            docPerson.put("_id", p.getId());
            docPerson.put("Name", p.getName());
            docPerson.put("Email", p.getEmail());
            Document docPhysicalPerson = new Document();
            docPhysicalPerson.put("Salary", p.getPhysicalPerson().getSalary());
            docPhysicalPerson.put("Birthday", p.getPhysicalPerson().getBirthday());
            docPhysicalPerson.put("Gender", p.getPhysicalPerson().getGender());
            docPerson.put("PhysicalPerson", docPhysicalPerson);
            col.replaceOne(Filters.eq("_id", p.getId()), docPerson);
            return 1;
        } catch (Exception e) {
            return -1;
        }
    }

    //Delete Person
    public int Delete_Person() {
        try {
            MongoCollection<Document> col = this.conn.getCollection("persons");
            Document docPerson = new Document();
            docPerson.put("_id", p.getId());
            col.deleteOne(docPerson);
            return 1;
        } catch (Exception e) {
            return -1;
        }
    }

    //Search Person
    //Get Person by ID.
    public Person GetPersonByID() {
        try {
            MongoCollection<Document> col = this.conn.getCollection("persons");
            Bson filter = Filters.eq("_id", p.getId());
            Document doc = col.find(filter).first();
            this.p = this.CreatePerson(doc);
            return this.p;
        } catch (Exception e) {
            return null;
        }
    }

    //Get Person by Name.
    public List<Person> GetPersonByName() {
        try {
            MongoCollection<Document> col = this.conn.getCollection("persons");
            Bson filter = Filters.regex("Name", Pattern.compile(this.p.getName()));
            FindIterable<Document> docs = col.find(filter);
            return this.CreatePersonList(docs);
        } catch (Exception e) {
            return null;
        }
    }

    //Method for Create persons list from FindIterable.
    private List<Person> CreatePersonList(FindIterable<Document> docs) {
        try {
            List<Person> list = new ArrayList<>();
            for (Document doc : docs) {
                Person _p = new Person();
                Document _pp = (Document) doc.get("PhysicalPerson");
                _p.setId(doc.getObjectId("_id"));
                _p.setName(doc.getString("Name"));
                _p.setEmail(doc.getString("Email"));
                //_p.getPhysicalPerson().setSalary(Double.parseDouble(_pp.getDouble("Salary")));
                _p.getPhysicalPerson().setBirthday(_pp.getDate("Birthday"));
                _p.getPhysicalPerson().setGender(_pp.getString("Gender"));
                list.add(_p);
            }
            return list;
        } catch (NumberFormatException e) {
            return null;
        }
    }

    //Method for Create persons object from FindIterable.
    private Person CreatePerson(Document doc) {
        try {
            Person _p = new Person();
            Document _pp = (Document) doc.get("PhysicalPerson");
            _p.setId(doc.getObjectId("_id"));
            _p.setName(doc.getString("Name"));
            _p.setEmail(doc.getString("Email"));
            //_p.getPhysicalPerson().setSalary(Double.parseDouble(_pp.getString("Salary")));
            _p.getPhysicalPerson().setBirthday(_pp.getDate("Birthday"));
            _p.getPhysicalPerson().setGender(_pp.getString("Gender"));
            return _p;
        } catch (NumberFormatException e) {
            return null;
        }
    }

    //Validations methods
    //Check id. 
    public Boolean CheckIdRegistered() {
        try {
            MongoCollection<Document> col = this.conn.getCollection("persons");
            Bson filter = Filters.eq("_id", p.getId());
            FindIterable<Document> doc = col.find(filter);
            try {
                if (doc.first() != null) {
                    return true;
                } else {
                    return false;
                }
            } catch (Exception e) {
                return false;
            }
        } catch (Exception e) {
            return false;
        }
    }

    //Check email.
    public Boolean CheckEmailRegistered() {
        try {
            MongoCollection<Document> col = this.conn.getCollection("persons");
            Bson filter = Filters.eq("Email", p.getEmail());
            FindIterable<Document> doc = col.find(filter);
            try {
                if (doc.first() != null) {
                    return true;
                } else {
                    return false;
                }
            } catch (Exception e) {
                return false;
            }
        } catch (Exception e) {
            return false;
        }
    }
}
