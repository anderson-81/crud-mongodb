using libCrud;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libCrud
{
    public class Crud
    {
        #region Search for Person
        public static List<Person> Get_Persons_By_Name(String name)
        {
            Person p = new Person();
            p.Name = name;
            Controller ctr = new Controller(p);
            return ctr.Get_Persons_By_Name();
        }

        public static Person Get_Person_By_ID(String id)
        {
            Person p = new Person();
            p.Id = new ObjectId(id);
            Controller ctr = new Controller(p);
            return ctr.Get_Person_By_ID();
        }
        #endregion

        public static Decimal Get_AVG_Salary_Person()
        {
            Controller ctr = new Controller();
            return ctr.Get_AVG_Salary_Person();
        }

        #region Reports
        public static List<Person> Get_Persons_Salary_Above_AVG()
        {
            Controller ctr = new Controller();
            return ctr.Get_Persons_Salary_Above_AVG();
        }
        
        public static List<Person> Get_Persons_Salary_Under_AVG()
        {
            Controller ctr = new Controller();
            return ctr.Get_Persons_Salary_Under_AVG();
        }

        public static List<Person> Get_Persons_Salary_Equal_AVG()
        {
            Controller ctr = new Controller();
            return ctr.Get_Persons_Salary_Equal_AVG();
        }
        
        public static Person Get_Person_Higher_Salary()
        {
            Controller ctr = new Controller();
            return ctr.Get_Person_Higher_Salary();
        }

        public static Person Get_Person_Lower_Salary()
        {
            Controller ctr = new Controller();
            return ctr.Get_Person_Lower_Salary();
        }

        public static List<Person> Get_Persons_By_Month_Birthday(int month)
        {
            Controller ctr = new Controller();
            return ctr.Get_Persons_By_Month_Birthday(month);
        }
        
        public static List<Person> Get_Persons_By_Salary_Range(decimal sal1, decimal sal2)
        {
            Controller ctr = new Controller();
            return ctr.Get_Persons_By_Salary_Range(sal1, sal2);
        }

        public static int Get_Count_Persons_By_Gender(String gender)
        {
            Controller ctr = new Controller();
            return ctr.Get_Count_Persons_By_Gender(gender);
        }
        #endregion

        #region LOGIN
        public static int Login(String username, String password)
        {
            UserSys u = new UserSys();
            u.Username = username;
            u.Password = password;
            Controller ctr = new Controller(u);
            return ctr.Login();
        }
        #endregion
        
        #region CRUD
        public static int Insert_Person(String name, String email, Decimal salary, DateTime birthday, String gender)
        {
            Person p = new Person();
            p.Name = name;
            p.Email = email;
            p.PhysicalPerson.Salary = salary;
            p.PhysicalPerson.Birthday = birthday;
            p.PhysicalPerson.Gender = gender;
            Controller ctr = new Controller(p);
            return ctr.Insert_Person();
        }

        public static int Edit_Person(String id, String name, String email, Decimal salary, DateTime birthday, String gender)
        {
            Person p = new Person();
            p.Id = new ObjectId(id);
            p.Name = name;
            p.Email = email;
            p.PhysicalPerson.Salary = salary;
            p.PhysicalPerson.Birthday = birthday;
            p.PhysicalPerson.Gender = gender;
            Controller ctr = new Controller(p);
            return ctr.Edit_Person();
        }

        public static int Delete_Person(String id)
        {
            Person p = new Person();
            p.Id = new ObjectId(id);
            Controller ctr = new Controller(p);
            return ctr.Delete_Person();
        }
     
        public static int Insert_UserSys(String username, String password)
        {
            UserSys u = new UserSys();
            u.Username = username;
            u.Password = password;
            Controller ctr = new Controller(u);
            return ctr.Insert_UserSys();
        }

        public static int Delete_UserSys(String id)
        {
            UserSys u = new UserSys();
            u.Id = new ObjectId(id);
            Controller ctr = new Controller(u);
            return ctr.Delete_UserSys();
        }
        #endregion

        #region VALIDATIONS
        public static bool CheckEmailPerson(string email)
        {
            Controller ctr = new Controller();
            return ctr.CheckEmailPerson(email);
        }
        #endregion
    }
}
