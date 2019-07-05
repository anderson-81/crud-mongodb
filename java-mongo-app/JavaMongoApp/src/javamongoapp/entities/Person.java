package javamongoapp.entities;

import org.bson.types.ObjectId;

public class Person {

    private ObjectId id;
    private String name;
    private String email;
    private PhysicalPerson physicalPerson = new PhysicalPerson();

    public ObjectId getId() {
        return id;
    }

    public void setId(ObjectId id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public PhysicalPerson getPhysicalPerson() {
        return physicalPerson;
    }

    public void setPhysicalPerson(PhysicalPerson physicalPerson) {
        this.physicalPerson = physicalPerson;
    }

    @Override
    public String toString() {
        StringBuilder stb = new StringBuilder();
        stb.append("ID: ");
        stb.append(this.getId());
        stb.append(" |Name: ");
        stb.append(this.getName());
        stb.append(" |E-mail: ");
        stb.append(this.getEmail());
        stb.append(" |Salary: ");
        stb.append(this.getPhysicalPerson().getSalary());
        stb.append(" |Birthday: ");
        stb.append(this.getPhysicalPerson().getBirthday());
        stb.append(" |Gender: ");
        stb.append(this.getPhysicalPerson().getGender());
        return stb.toString();
    }
}
