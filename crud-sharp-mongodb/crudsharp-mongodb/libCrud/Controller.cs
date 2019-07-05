using libCrud;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace libCrud
{
    public class Controller
    {
        //Atributtes
        #region Attributes
        private IMongoDatabase conn;
        private Person p;
        private UserSys u;
        #endregion

        //Constructors
        #region Constructors
        public Controller()
        {
            this.conn = Connection.Connect();
        }

        public Controller(Person p)
        {
            this.conn = Connection.Connect();
            this.p = p;
        }

        public Controller(UserSys u)
        {
            this.conn = Connection.Connect();
            this.u = u;
        }
        #endregion

        //Methods of registering Person.
        #region PERSON

        //Insert Person.
        public int Insert_Person()
        {
            try
            {
                IMongoCollection<Person> col = this.conn.GetCollection<Person>("persons");
                col.InsertOne(p);
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //Edit Person.
        public int Edit_Person()
        {
            try
            {
                IMongoCollection<Person> col = this.conn.GetCollection<Person>("persons");
                FilterDefinition<Person> filter = Builders<Person>.Filter.Where(person => person.Id == this.p.Id);
                col.ReplaceOne(filter, p);
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //Delete Person
        public int Delete_Person()
        {
            try
            {
                IMongoCollection<Person> col = this.conn.GetCollection<Person>("persons");
                FilterDefinition<Person> filter = Builders<Person>.Filter.Where(person => person.Id == this.p.Id);
                col.DeleteOne(filter);
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        #endregion

        //Methods of registering UserSys.
        #region UserSys
        //Insert UserSys.
        public int Insert_UserSys()
        {
            try
            {
                IMongoCollection<UserSys> col = this.conn.GetCollection<UserSys>("usersys");
                SHA512 hash = new SHA512Managed();
                this.u.Username = Hash.GenerateSHA512String(this.u.Username);
                this.u.Password = Hash.GenerateSHA512String(this.u.Password);
                col.InsertOne(this.u);
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //Delete UserSys.
        public int Delete_UserSys()
        {
            try
            {
                IMongoCollection<UserSys> col = this.conn.GetCollection<UserSys>("usersys");
                FilterDefinition<UserSys> filter = Builders<UserSys>.Filter.Where(usersys => usersys.Id == this.u.Id);
                col.DeleteOne(filter);
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        #endregion

        
        //Methods for searching for Persons.
        #region Search for PhysicalPerson

        //Search Persons by name.
        public List<Person> Get_Persons_By_Name()
        {
            try
            {
                IMongoCollection<Person> col = this.conn.GetCollection<Person>("persons");
                FilterDefinition<Person> filter = Builders<Person>.Filter.Where(person => person.Name.StartsWith(this.p.Name));
                return col.Find<Person>(filter).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Search Person by Id.
        public Person Get_Person_By_ID()
        {
            try
            {
                IMongoCollection<Person> col = this.conn.GetCollection<Person>("persons");
                IMongoQueryable<Person> persons = from p in col.AsQueryable<Person>() where p.Id == this.p.Id select p;
                return persons.First();
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        //Methods for generating reports.
        #region Reports
        //Get Average salary of Persons.
        public Decimal Get_AVG_Salary_Person()
        {
            try
            {
                IMongoCollection<Person> col = this.conn.GetCollection<Person>("persons");
                IMongoQueryable<Person> persons = from p in col.AsQueryable<Person>() select p;
                return (from p in persons select p.PhysicalPerson.Salary).ToList().Average();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //Get Persons with salary above average salary.
        public List<Person> Get_Persons_Salary_Above_AVG()
        {
            try
            {
                IMongoCollection<Person> col = this.conn.GetCollection<Person>("persons");
                IMongoQueryable<Person> persons = from p in col.AsQueryable<Person>() select p;
                Decimal avgSal = (from p in persons select p.PhysicalPerson.Salary).ToList().Average();
                return persons.Where(p => p.PhysicalPerson.Salary > avgSal).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Get Persons with salary under average salary.
        public List<Person> Get_Persons_Salary_Under_AVG()
        {
            try
            {
                IMongoCollection<Person> col = this.conn.GetCollection<Person>("persons");
                IMongoQueryable<Person> persons = from p in col.AsQueryable<Person>() select p;
                Decimal avgSal = (from p in persons select p.PhysicalPerson.Salary).ToList().Average();
                return persons.Where(p => p.PhysicalPerson.Salary < avgSal).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Get Persons with salary equal average salary.
        public List<Person> Get_Persons_Salary_Equal_AVG()
        {
            try
            {
                IMongoCollection<Person> col = this.conn.GetCollection<Person>("persons");
                IMongoQueryable<Person> persons = from p in col.AsQueryable<Person>() select p;
                Decimal avgSal = (from p in persons select p.PhysicalPerson.Salary).ToList().Average();
                return persons.Where(p => p.PhysicalPerson.Salary == avgSal).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Get Person with higher salary.
        public Person Get_Person_Higher_Salary()
        {
            try
            {
                IMongoCollection<Person> col = this.conn.GetCollection<Person>("persons");
                IMongoQueryable<Person> persons = from p in col.AsQueryable<Person>() select p;
                Decimal maxSal = (from p in persons select p.PhysicalPerson.Salary).ToList().Max();
                return persons.Where(p => p.PhysicalPerson.Salary == maxSal).First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Get Person with lower salary.
        public Person Get_Person_Lower_Salary()
        {
            try
            {
                IMongoCollection<Person> col = this.conn.GetCollection<Person>("persons");
                IMongoQueryable<Person> persons = from p in col.AsQueryable<Person>() select p;
                Decimal minSal = (from p in persons select p.PhysicalPerson.Salary).ToList().Min();
                return persons.Where(p => p.PhysicalPerson.Salary == minSal).First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Get Persons by birthday month.
        public List<Person> Get_Persons_By_Month_Birthday(int month)
        {
            try
            {
                IMongoCollection<Person> col = this.conn.GetCollection<Person>("persons");
                IMongoQueryable<Person> persons = from p in col.AsQueryable<Person>() select p;
                List<Person> list = persons.ToList();
                return list.Where(p => p.PhysicalPerson.Birthday.Month == month).ToList<Person>(); 
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Get Persons by salary range.
        public List<Person> Get_Persons_By_Salary_Range(decimal sal1, decimal sal2)
        {
            try
            {
                IMongoCollection<Person> col = this.conn.GetCollection<Person>("persons");
                IMongoQueryable<Person> persons = from p in col.AsQueryable<Person>() select p;
                List<Person> list = persons.Where(p => p.PhysicalPerson.Salary >= sal1 && p.PhysicalPerson.Salary <= sal2).ToList();
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Get Person's count by gender.
        public int Get_Count_Persons_By_Gender(string gender)
        {
            try
            {
                IMongoCollection<Person> col = this.conn.GetCollection<Person>("persons");
                IMongoQueryable<Person> persons = from p in col.AsQueryable<Person>() select p;
                return  persons.Where(p => p.PhysicalPerson.Gender == gender).Count();
            }
            catch (Exception)
            {
                return -1;
            }
        }
        #endregion

        //Methods of login.
        #region LOGIN
        //Login method.
        public int Login()
        {
            try
            {
                IMongoCollection<UserSys> col = this.conn.GetCollection<UserSys>("usersys");
                IMongoQueryable<UserSys> usersys = from x in col.AsQueryable<UserSys>() where x.Username == Hash.GenerateSHA512String(this.u.Username) && x.Password == Hash.GenerateSHA512String(this.u.Password) select x;
                return (usersys.Count() > 0) ? 1 : 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        #endregion

        //Validation's methods.
        #region VALIDATIONS
        //Method for email validation.
        public bool CheckEmailPerson(string email)
        {
            try
            {
                IMongoCollection<Person> col = this.conn.GetCollection<Person>("persons");
                IMongoQueryable<Person> persons = from person in col.AsQueryable<Person>() where person.Email == email select person;
                return persons.Count() == 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}