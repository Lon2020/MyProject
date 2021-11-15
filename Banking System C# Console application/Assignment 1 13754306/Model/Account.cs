using Assignment_1_13754306.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_13754306.Model
{
    //Model for Account
    class Account
    {
        // Data types and variable
        private int accountID;
        private string customerName;
        private double accountBal = 0; // every new account created, the account balance will always be $0

        //Constructor requires account id and customer name used in createAccount view
        public Account(int accountID, string customerName)
        {
            this.accountID = accountID;
            this.customerName = customerName;
        }

        //Constructor for just calling Account model
        public Account()
        {
        }

        //get account id
        public int getAccountID()
        {
            return accountID;
        }

        //set account id with new value
        public void setAccountID(int accountID)
        {
            this.accountID = accountID;
        }

        //get customer name
        public string getCustomerName()
        {
            return customerName;
        }

        //set customer name with new value
        public void setCustomerName(string customerName)
        {
            this.customerName = customerName;
        }

        //get account balance used in deposit and withdraw views
        public double getAccountBal()
        {
            return accountBal;
        }

        //set account balance with new value used in deposit and withdraw views
        public void setCustomerNameAccountBal(double accountBal)
        {
            this.accountBal = accountBal;
        }


        //Data Validation for Account Id
        public int checkAccountId()
        {
            string accountId;
            bool checkAccountIdLength = true;
            bool checkAccountInteger = true;
            do
            {
                // set cursor position and read the user input for account id
                Console.SetCursorPosition(40, 6);
                accountId = Console.ReadLine();

                //check if account id is not empty and less than 10 digits
                checkAccountIdLength = accountId.ToString().Length != 0 && accountId.ToString().Length < 10;
                //check if account id contains only number
                checkAccountInteger = accountId.All(char.IsDigit);

                //if account id contains any letter
                if (!checkAccountInteger)
                {
                    viewBorder.cursor("Please enter only number", 55, 6); // display error
                }
                else if (!checkAccountIdLength) // if account id is empty and more than 10 digits
                {
                    viewBorder.cursor("The number should be less than 10 digits", 55, 6);//display error
                }

            } while (!checkAccountIdLength || !checkAccountInteger); // break the do while loop when account id is validated

            // return account id in Int32
            return Convert.ToInt32(accountId);
        }


        //Data Validation for Deposit Amount
        public double checkDepositAmount()
        {
            double depositAmount = 0;
            bool checkDeposit = true;
            do
            {
                Console.SetCursorPosition(42, 8);

                try
                {
                    // read deposit amount 
                    depositAmount = Convert.ToDouble(Console.ReadLine());

                    // if deposit amount is negative number
                    if (depositAmount < 0)
                    {
                        viewBorder.cursor("Please enter only positive number", 25, 9); // display error
                        checkDeposit = true;  // checkDeposit = true and stay in the loop;
                    }
                    else // if deposit amount is positive amount
                    {
                        // break the loop
                        checkDeposit = false; 
                    }
                }
                catch (FormatException e)//catch error if deposit amount input contains string
                {
                    viewBorder.cursor("Please enter only number", 55, 8); // display error
                    checkDeposit = true; // checkDeposit = true and stay in the loop;
                }
            } while (checkDeposit);

            // return deposit amount
            return depositAmount;
        }

        //Data Validation for Withdrawal Amount
        public double checkWithdrawAmount()
        {
            double withdrawAmount = 0;
            bool checkWithdraw = true;
            do
            {
                Console.SetCursorPosition(44, 8);
                try
                {
                    // read withdraw amount 
                    withdrawAmount = Convert.ToDouble(Console.ReadLine());

                    // if withdraw amount is negative number
                    if (withdrawAmount < 0)
                    {
                        viewBorder.cursor("Please enter only positive number", 25, 9); // display error
                        checkWithdraw = true; // checkWithdraw = true and stay in the loop;
                    }
                    else // if withdraw amount is positive amount
                    {
                        // break the loop
                        checkWithdraw = false; 
                    }
                }
                catch (FormatException e)//catch error if withdraw amount input contains string
                {
                    viewBorder.cursor("Please enter only number", 55, 8); // display error
                    checkWithdraw = true; // checkWithdraw = true and stay in the loop;
                }
            } while (checkWithdraw);

            // return withdraw amount
            return withdrawAmount;
        }

        public bool checkChoice()
        {
            string choice;
            bool checkChoice = true;
            do
            {
                // display when user entered account id and file is not found
                viewBorder.cursor("Account not found, Check another account (y/n):", 25, 7);
                Console.SetCursorPosition(73, 7);
                choice = Console.ReadLine();

                //remove white space from choice e.g. "y " to "y" with no spaces
                string choiceTrim = choice.Trim();
                if (choiceTrim.Equals("y") || choiceTrim.Equals("Y"))// if user enter y or Y
                {
                    checkChoice = false; // break the loop
                }
                else if (choiceTrim.Equals("n") || choiceTrim.Equals("N"))// if user enter n or N
                {
                    //go back to main menu and break the loop
                    mainMenuView.mainMenu(); 
                    checkChoice = false;
                }
                else
                {
                    //break the loop
                    checkChoice = true;
                }
            } while (checkChoice);

            // return true
            return true;
        }
    }
}

