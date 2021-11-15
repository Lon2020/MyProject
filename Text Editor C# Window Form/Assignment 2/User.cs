using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class User
    {
        private string username = "";
        private string password = "";
        private string confirmPassword = "";
        private string firstName = "";
        private string lastName = "";
        private string dob = "";
        private string type = "";

        public User()
        {

        }

        public User(string username, string password, string confirmPassword, string firstName, string lastName, string dob, string type)
        {
            this.username = username;
            this.password = password;
            this.confirmPassword = confirmPassword;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dob = dob;
            this.type = type;
        }

        public string getUsername()
        {
            return username;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }
        public string getPassword()
        {
            return password;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        public string getConfirmPassword()
        {
            return confirmPassword;
        }

        public void setConfirmPassword(string confirmPassword)
        {
            this.confirmPassword = confirmPassword;
        }
        public string getFirstName()
        {
            return firstName;
        }

        public void setFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public string getLastName()
        {
            return lastName;
        }

        public void setLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public string getDoB()
        {
            return dob;
        }

        public void setDob(string dob)
        {
            this.dob = dob;
        }

        public string getType()
        {
            return type;
        }

        public void setType(string type)
        {
            this.type = type;
        }
    }
}
