package javamongoapp;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import org.bson.types.ObjectId;

public class Validation {

    private static Boolean ValidateEmpty(String text) {
        return text.isEmpty();
    }

    public static int ValidateID(String id) {
        if (!ValidateEmpty(id)) {
            try {
                ObjectId objID = new ObjectId(id);
                if (!Crud.CheckIdRegistered(id)) {
                    return 2;
                }
            } catch (Exception e) {
                return -1;
            }
        } else {
            return 0;
        }
        return 1;
    }

    public static int ValidateName(String name) {
        if (!ValidateEmpty(name)) {
            if (name.length() < 2) {
                return -1;
            }
        } else {
            return 0;
        }
        return 1;
    }

    public static int ValidateEmail(String email) {
        if (!ValidateEmpty(email)) {
            String regex = "^([_a-zA-Z0-9-]+(\\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\\.[a-zA-Z0-9-]+)*(\\.[a-zA-Z]{1,6}))?$";
            Pattern pattern = Pattern.compile(regex);
            Matcher matcher = pattern.matcher(email);
            if (!matcher.matches()) {
                return -1;
            }
            if (Crud.CheckEmailRegistered(email)) {
                return 3;
            }
        } else {
            return 0;
        }
        return 1;
    }

    public static int ValidateSalary(String salary) {
        if (!ValidateEmpty(salary)) {
            try {
                Double.parseDouble(salary);
                if (Double.parseDouble(salary) < 0) {
                    return 4;
                }
            } catch (NumberFormatException e) {
                return -1;
            }
        } else {
            return 0;
        }
        return 1;
    }

    public static int ValidateBirthday(String birthday) {
        SimpleDateFormat dateParse = new SimpleDateFormat("dd/MM/yyyy");
        if (!ValidateEmpty(birthday)) {
            try {
                dateParse.parse(birthday);
            } catch (ParseException ex) {
                return -1;
            }
        } else {
            return 0;
        }
        return 1;
    }

    public static int ValidateGender(String gender) {
        if (!ValidateEmpty(gender)) {
            if (("M".equals(gender)) || ("F".equals(gender))) {
                return 1;
            }
        } else {
            return 0;
        }
        return -1;
    }
}
