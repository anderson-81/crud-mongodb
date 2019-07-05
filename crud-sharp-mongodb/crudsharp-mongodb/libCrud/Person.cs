using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libCrud
{
    public class Person
    {
        private ObjectId id;
        public ObjectId Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private PhysicalPerson physicalPerson = new PhysicalPerson();
        public PhysicalPerson PhysicalPerson
        {
            get { return physicalPerson; }
            set { physicalPerson = value; }
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} - {2} - {3} - {4} - {5}", this.Id, this.Name, this.Email, this.PhysicalPerson.Salary, this.PhysicalPerson.Birthday, this.PhysicalPerson.Gender);
        }
    }
}
