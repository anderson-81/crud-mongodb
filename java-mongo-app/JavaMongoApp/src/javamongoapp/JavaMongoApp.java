package javamongoapp;

import java.util.Date;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.List;
import java.util.Scanner;
import javamongoapp.entities.Person;

public class JavaMongoApp {

    public static void main(String[] args) {

        String cnt = "";

        while (!"0".equals(cnt)) {
            switch (GetOperation()) {
                case "1":
                    ShowMessageOperation(SetDataPerson(0), 0);
                    break;
                case "2":
                    ShowMessageOperation(SetDataPerson(1), 1);
                    break;
                case "3":
                    ShowMessageOperation(DeletePerson(), 2);
                    break;
                case "4":
                    GetPerson(1);
                    break;
                case "5":
                    GetPerson(2);
                    break;
                default:
                    break;
            }
            cnt = Read(1);
        }
    }

    public static String GetOperation() {
        System.out.println("-------------------------------------------------");
        System.out.println("|REGISTRATION PERSON ----------------------------");
        System.out.println("-------------------------------------------------");
        System.out.println("\n");
        System.out.println("-------------------------------------------------");
        System.out.println("|OPTIONS:----------------------------------------");
        System.out.println("|1- INSERT PERSON -------------------------------");
        System.out.println("|2- EDIT PERSON ---------------------------------");
        System.out.println("|3- DELETE PERSON -------------------------------");
        System.out.println("|4- GET PERSON BY NAME --------------------------");
        System.out.println("|5- GET PERSON BY ID ----------------------------");
        System.out.println("-------------------------------------------------");
        return JavaMongoApp.Read(0);
    }

    private static String Read(int op) {
        Scanner keyboard = new Scanner(System.in);
        if (op == 0) {
            System.out.print("Option: ");
        }
        if (op == 1) {
            System.out.print("Do you want continue? (0 to Finish): ");
        }
        String opc = keyboard.nextLine();
        return opc;
    }

    private static int SetDataPerson(int opc) {
        String temp = "";
        int result = 0;
        Scanner keyboard = new Scanner(System.in);
        String id = null;

        if (opc == 1) {
            System.out.print("ID: ");
            temp = keyboard.nextLine();
            result = Validation.ValidateID(temp);
            if (result != 1) {
                ShowMessage(result, "ID");
                return -1;
            }
            id = temp;
        }

        System.out.print("NAME: ");
        temp = keyboard.nextLine();
        result = Validation.ValidateName(temp);
        if (result != 1) {
            ShowMessage(result, "Name");
            return -1;
        }
        String name = temp;

        System.out.print("EMAIL: ");
        temp = keyboard.nextLine();
        result = Validation.ValidateEmail(temp);
        if (result != 1) {
            ShowMessage(result, "E-mail");
            return -1;
        }
        String email = temp;

        System.out.print("SALARY: ");
        temp = keyboard.nextLine();
        result = Validation.ValidateSalary(temp);
        if (result != 1) {
            ShowMessage(result, "Salary");
            return -1;
        }
        String salary = temp;

        System.out.print("BIRTHDAY ex:(12/11/1981): ");
        temp = keyboard.nextLine();
        result = Validation.ValidateBirthday(temp);
        if (result != 1) {
            ShowMessage(result, "Birthday");
            return -1;
        }
        String birthday = temp;

        System.out.print("GENDER: ");
        temp = keyboard.nextLine();
        result = Validation.ValidateGender(temp);
        if (result != 1) {
            ShowMessage(result, "Gender");
            return -1;
        }
        String gender = temp;

        if (opc == 0) {
            return Crud.Insert_Person(name, email, Double.parseDouble(salary), GetBirthday(birthday), gender);
        }

        if (opc == 1) {
            return Crud.Edit_Person(id, name, email, Double.parseDouble(salary), GetBirthday(birthday), gender);
        }

        return -1;
    }

    private static int DeletePerson() {
        String temp = "";
        int result = 0;
        Scanner keyboard = new Scanner(System.in);
        String id = null;
        System.out.print("ID: ");
        temp = keyboard.nextLine();
        result = Validation.ValidateID(temp);
        if (result != 1) {
            ShowMessage(result, "ID");
            return -1;
        }
        id = temp;
        return Crud.Delete_Person(id);
    }

    private static int GetPerson(int opc) {
        String temp;
        int result = 0;
        Scanner keyboard = new Scanner(System.in);

        if (opc == 2) {
            System.out.println("-------------------------------------------------");
            System.out.println("|GET PERSON BY ID -------------------------------");
            System.out.println("-------------------------------------------------");
            System.out.print("ID: ");
            temp = keyboard.nextLine();
            result = Validation.ValidateID(temp);
            if (result != 1) {
                ShowMessage(result, "ID");
                return -1;
            }
            String id = temp;
            ShowPerson(Crud.GetPersonByID(id));
        }

        if (opc == 1) {
            System.out.println("-------------------------------------------------");
            System.out.println("|GET PERSON BY NAME------------------------------");
            System.out.println("-------------------------------------------------");
            System.out.print("NAME: ");
            temp = keyboard.nextLine();
            ShowPersonList(Crud.GetPersonByName(temp));
        }
        return 1;
    }

    private static void ShowPersonList(List<Person> list) {
        if (!list.isEmpty()) {
            list.forEach((p) -> {
                System.out.println(p.toString());
            });
        } else {
            System.out.println("No data found.");
        }
    }

    private static void ShowPerson(Person p) {
        if (p.getName() != null) {
            System.out.println(p.toString());
        } else {
            System.out.println("No data found.");
        }
    }

    private static void ShowMessage(int result, String label) {

        if (result == 0) {
            System.out.println(label + " is empty.");
        }

        if (result == -1) {
            System.out.println("Invalid " + label + ".");
        }

        if (result == 2) {
            System.out.println("ID does not exist.");
        }

        if (result == 3) {
            System.out.println("Email already registered.");
        }

        if (result == 4) {
            System.out.println("Salary cannot be below zero.");
        }
    }

    private static Date GetBirthday(String birthday) {
        SimpleDateFormat dateParse = new SimpleDateFormat("dd/MM/yyyy");
        try {
            return dateParse.parse(birthday);
        } catch (ParseException ex) {
            return null;
        }
    }

    private static void ShowMessageOperation(int result, int op) {

        if (op == 0) {
            if (result == 1) {
                System.out.println("Successfully inserted.");
            } else {
                System.err.println("Unsuccessfully inserted.");
            }
        }

        if (op == 1) {
            if (result == 1) {
                System.out.println("Successfully edited.");
            } else {
                System.err.println("Unsuccessfully edited.");
            }
        }

        if (op == 2) {
            if (result == 1) {
                System.out.println("Successfully deleted.");
            } else {
                System.err.println("Unsuccessfully deleted.");
            }
        }
    }
}
