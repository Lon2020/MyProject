using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace Assignment_2
{
    public partial class RegisterForm : Form
    {

        public RegisterForm()
        {
            InitializeComponent();
        }

        //call user model
        User user = new User();

        //Unused function
        private void RegisterForm_Load(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void label1_Click_1(object sender, EventArgs e)
        {
        }


        //cancel button to go back to login form
        private void Cancel_Click(object sender, EventArgs e)
        {
            //show meesage to user if they are sure to exit a registration page
            MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure to cancel? Your input will not be saved for the next registration", "Cancel Registration", (MessageBoxButton)MessageBoxButtons.YesNo);

            if (result == MessageBoxResult.Yes) // if yes
            {
                //hide register form
                this.Visible = false;

                //show loginform
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            else if (result == MessageBoxResult.No) //if no
            {
                // close the message box and allow user to stay in the register form
            }
        }

        //username text box
        private void username_TextChanged(object sender, EventArgs e)
        {
            //set username
            user.setUsername(username.Text);
        }

        //password text box
        private void password_TextChanged(object sender, EventArgs e)
        {
            //set password
            user.setPassword(password.Text);
        }

        //confirm password text box
        private void confirmPassword_TextChanged(object sender, EventArgs e)
        {
            //set confirm password
            user.setConfirmPassword(confirmPassword.Text);
        }

        //first name text box
        private void firstName_TextChanged(object sender, EventArgs e)
        {
            user.setFirstName(firstName.Text);
        }

        //last name text box
        private void LastName_TextChanged(object sender, EventArgs e)
        {
            //set last name
            user.setLastName(LastName.Text);
        }

        //date of birth date time picker
        private void dob_ValueChanged(object sender, EventArgs e)
        {
            //customise date format to dd-MM-yyyy (10-10-2021)
            dob.Format = DateTimePickerFormat.Custom;
            dob.CustomFormat = "dd-MM-yyyy";

            //check if user selectes date of birth greater than the today date
            if (dob.Value >= DateTime.UtcNow)
            {
                //show error message
                MessageBox.Show("Date of Birth cannot be selected more than the current date", "Date of Birth error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                user.setDob("");
            }
            else
            {
                //set date of birth
                user.setDob(dob.Text);
            }
        }

        //type drop down list
        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set type
            user.setType(type.SelectedItem.ToString());
        }

        //reset button to reset the whole form
        private void Reset_Click(object sender, EventArgs e)
        {
            //show message to ask if the user want to reset the whole form
            MessageBoxResult reset = System.Windows.MessageBox.Show("Are you sure to reset? Your input will be removed", "Reset Data", (MessageBoxButton)MessageBoxButtons.YesNo);

            if (reset == MessageBoxResult.Yes) //if yes
            {
                //all text boxes will be empty
                username.Text = String.Empty;
                password.Text = String.Empty;
                confirmPassword.Text = String.Empty;
                firstName.Text = String.Empty;
                LastName.Text = String.Empty;
                dob.Text = String.Empty;
                type.Text = String.Empty;
            }
            else if (reset == MessageBoxResult.No)
            {
                // close the message box and do nothing
            }

        }


        //submit form button
        private void loginButton_Click(object sender, EventArgs e)
        {
            //if any text box if empty
            if (user.getUsername().Equals("") || user.getPassword().Equals("") || user.getConfirmPassword().Equals("")
                || user.getFirstName().Equals("") || user.getLastName().Equals("") || user.getDoB().Equals("") || user.getType().Equals(""))
            {
                // show error message
                MessageBox.Show("Please enter all the fields", "Missing field", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
            }
            else
            {

                try
                {
                    //read all data from login.txt
                    string[] lines = System.IO.File.ReadAllLines(@"login.txt");
                    //boolean checking if user name is already existed
                    bool existedUsername = false;
                    //userDetails array to store username
                    string[] userDetails;

                    //loop inside lines array
                    foreach (string line in lines)
                    {
                        //spilt ,
                        userDetails = line.Split(',');

                        //check if username equals to the username in login.txt
                        if (user.getUsername().Equals(userDetails[0]))
                        {
                            //change existedUsername = true if username is already existed;
                            existedUsername = true;
                            break;
                        }
                    }

                    //if username is already existed
                    if (existedUsername == true)
                    {
                        //show error message
                        MessageBox.Show("Username is already existed! Please try again", "Existed Username", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                    }
                    else
                    {
                        //check if password and confirm password are not equal
                        if (!user.getPassword().Equals(user.getConfirmPassword()))
                        {
                            //show error message
                            MessageBox.Show("Password and Confirm password is not the same", "Not matched Password", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                        }
                        else
                        {
                            //create a new format which has , to seperate each detail
                            string formatDetails = user.getUsername() + "," + user.getPassword() + "," + user.getType() + "," + user.getFirstName() + "," + user.getLastName() + "," + user.getDoB();
                            // create specific path to the file that just got deleted from line 130
                            string path = @"login.txt";

                            // update texts
                            using (StreamWriter sw = File.AppendText(path))
                            {
                                //add a new format to the next line in login.txt
                                sw.WriteLine(formatDetails);
                            }

                            //after that show message say new account is created
                            MessageBox.Show("congratulation! New account is successfully created", "New account");

                            //hide register form
                            this.Visible = false;

                            //show login form
                            LoginForm loginForm = new LoginForm();
                            loginForm.Show();

                        }
                    }
                }
                catch (FileNotFoundException error) // catch error
                {
                    //show error message, hide register form and show login form
                    MessageBox.Show(error.Message, "File not found", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);

                    //hide register form and show login form
                    this.Visible = false;
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                }
            }
        }
    }
}
