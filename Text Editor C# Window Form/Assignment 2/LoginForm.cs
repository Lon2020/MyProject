using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace Assignment_2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        //Calling User model
        User user = new User();

        //boolean to check if username exists
        bool userExisted = false;

        //Username text box
        private void usernameBox_TextChanged(object sender, EventArgs e)
        {
            //set username
            user.setUsername(usernameBox.Text);
        }

        //Password text box
        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            //set password
            user.setPassword(passwordBox.Text);
        }

        //Exit button to exit application
        private void exit_Click(object sender, EventArgs e)
        {
            //Alert message if the user want to exit the application
            MessageBoxResult result = System.Windows.MessageBox.Show("Exit the Text Editor Application", "Exit Application", (MessageBoxButton)MessageBoxButtons.YesNo);


            if (result == MessageBoxResult.Yes) // if yes
            {
                System.Windows.Forms.Application.Exit(); // exit application
            }
            else if (result == MessageBoxResult.No) // if no
            {
                // close the message box and allow user to stay in the application
            }
        }

        //Login button to login to Text Editor
        private void login_Click(object sender, EventArgs e)
        {
            // Check if user entered username or password
            if (user.getUsername().Equals("") || user.getPassword().Equals(""))
            {
                // if username or password is empty, show error message
                MessageBox.Show("Please enter username or password", "Empty user input", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
            }
            else
            {
                //read all lines login.txt and store in lines array
                string[] lines = System.IO.File.ReadAllLines(@"login.txt");
                //create another array to check store username and password from lines array
                string[] userDetails;

                //loop inside lines array
                foreach (string line in lines)
                {
                    //spilt , from login.txt
                    userDetails = line.Split(',');

                    // if username and password match with the username and password in login.txt
                    if (user.getUsername().Equals(userDetails[0]) && user.getPassword().Equals(userDetails[1]))
                    {

                        user.setType(userDetails[2]); //set type of user
                        user.setFirstName(userDetails[3]); //set first name
                        user.setLastName(userDetails[4]); // set last name
                        userExisted = true; // change userExisted from false to true

                        //break the loop, so if it found matched username and password, it will break the loop
                        break;
                    }
                }

                //if username and password exist
                if (userExisted == true)
                {
                    //hide login form
                    this.Visible = false;

                    //pass user's firstname and permission to text editor form
                    TextEditorForm afterLoginForm = new TextEditorForm(user.getFirstName(), user.getType());
                    afterLoginForm.Show(); // Shows textEditorForm
                }
                else// if username and password not existed
                {
                    //show error account not found
                    MessageBox.Show("Account not found! Please try again", "Account not Found", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                }

            }
        }

        //New username button
        private void newusername_Click(object sender, EventArgs e)
        {
            //hide login form
            this.Visible = false;

            //show register form
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }



        //Unused function
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void welcome_Click(object sender, EventArgs e)
        {

        }
    }
}
