using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libCrud
{
    public class UserSys
    {
        private ObjectId _id;
        public ObjectId Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        private String username;
        public String Username
        {
            get { return username; }
            set { username = value; }
        }

        private String password;
        public String Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
