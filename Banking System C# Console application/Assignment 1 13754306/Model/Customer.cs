using Assignment_1_13754306.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment_1_13754306.Model
{
    //Model for Customer
    public class Customer
    {
        // Data types and variable for customer
        private string firstName;
        private string lastName;
        private string address;
        private long phone;
        private string email;

        //Constructor
        public Customer(string firstName, string lastName, string address, long phone, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.phone = phone;
            this.email = email;
        }

        //Constructor for just calling Customer model
        public Customer()
        {
        }

        //get customer first name
        public string getFirstName()
        {
            return firstName;
        }

        //set first name with a new value
        public void setFiestName(string firstName)
        {
            this.firstName = firstName;
        }

        // get customer last name
        public string getLastName()
        {
            return lastName;
        }

        // set customer last name with a new value
        public void setLastName(string lastName)
        {
            this.lastName = lastName;
        }

        // get customer address
        public string getAddress()
        {
            return address;
        }

        // set customer address with new address
        public void setAddress(string address)
        {
            this.address = address;
        }

        // get customer phone 
        public long getPhone()
        {
            return phone;
        }

        //set customer phone with a new phone
        public void setPhone(long phone)
        {
            this.phone = phone;
        }

        // get customer email
        public string getEmail()
        {
            return email;
        }

        // set customer email with a new email
        public void setEmail(string email)
        {
            this.email = email;
        }


        //method for searching all acounts and return in string array
        public string[] searchAccountCustomer(int accountId)
        {
            string[] files = new string[12];
            try
            {
                DirectoryInfo filePath = new DirectoryInfo(@"./");//Retrieve all files' name inside the Debug folder
                FileInfo[] Files = filePath.GetFiles("*.txt");//Retrieve all files' name inside the Debug folder
                bool fileExist = false;
                string accountIdString = "";

                //reformat account id to accountid.txt
                accountIdString = accountId.ToString() + ".txt";

                //loop for all existing files
                foreach (FileInfo file in Files)
                {
                    //boolean to check if account id equals to existing file
                    fileExist = accountIdString.Equals(file.Name);
                    if (fileExist == true)
                    {
                        // if account id exists, break a for loop for a better performance, so that it does not to loop until the last file
                        break;
                    }
                }

                // if account exists
                if (fileExist)
                {
                    //display found!
                    viewBorder.cursor("Account Found!!!", 25, 11);
                    try
                    {
                        //read all lines for that file and stored in files array declared above
                        files = System.IO.File.ReadAllLines($@"{accountIdString}");
                        
                    }
                    catch (FileNotFoundException e)//catch if file not fould
                    {
                        Console.WriteLine(e.Message);
                    }

                }
                else//if account is not exist
                {
                    // set files index 0 to be empty to be check in views
                    files[0] = "empty";
                }
            }
            catch (FileNotFoundException e) // catch the file not found
            {
                // display error
                Console.WriteLine(e.Message);
            }

            // return files
            return files;

        }
    }
}
