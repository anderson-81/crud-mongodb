using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libCrud
{
    public class PhysicalPerson
    {
        private decimal salary;
        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        private DateTime birthday;
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        private String gender;
        public String Gender
        {
            get { return gender; }
            set { gender = value; }
        }
    }
}
