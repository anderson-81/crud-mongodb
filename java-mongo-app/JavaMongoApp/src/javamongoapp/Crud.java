package javamongoapp;

import java.util.Date;
import java.util.List;
import javamongoapp.entities.Person;
import javamongoapp.controllers.Controller;
import org.bson.types.ObjectId;

public class Crud {

    public static int Insert_Person(String name, String email, Double salary, Date birthday, String Gender) {
        Person p = new Person();
        p.setName(name);
        p.setEmail(email);
        p.getPhysicalPerson().setSalary(salary);
        p.getPhysicalPerson().setBirthday(birthday);
        p.getPhysicalPerson().setGender(Gender);
        Controller ctr = new Controller(p);
        return ctr.Insert_Person();
    }

    public static int Edit_Person(String id, String name, String email, Double salary, Date birthday, String Gender) {
        Person p = new Person();
        p.setId(new ObjectId(id));
        p.setName(name);
        p.setEmail(email);
        p.getPhysicalPerson().setSalary(salary);
        p.getPhysicalPerson().setBirthday(birthday);
        p.getPhysicalPerson().setGender(Gender);
        Controller ctr = new Controller(p);
        return ctr.Edit_Person();
    }

    public static int Delete_Person(String id) {
        Person p = new Person();
        p.setId(new ObjectId(id));
        Controller ctr = new Controller(p);
        return ctr.Delete_Person();
    }

    public static Person GetPersonByID(String id) {
        Person p = new Person();
        p.setId(new ObjectId(id));
        Controller ctr = new Controller(p);
        return ctr.GetPersonByID();
    }

    public static List<Person> GetPersonByName(String name) {
        Person p = new Person();
        p.setName(name);
        Controller ctr = new Controller(p);
        return ctr.GetPersonByName();
    }

    public static Boolean CheckEmailRegistered(String email) {
        Person p = new Person();
        p.setEmail(email);
        Controller ctr = new Controller(p);
        return ctr.CheckEmailRegistered();
    }

    public static Boolean CheckIdRegistered(String id) {
        Person p = new Person();
        p.setId(new ObjectId(id));
        Controller ctr = new Controller(p);
        return ctr.CheckIdRegistered();
    }
}
