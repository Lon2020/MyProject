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
using System.Windows.Documents;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace Assignment_2
{
    public partial class TextEditorForm : Form
    {
        public TextEditorForm()
        {
            InitializeComponent();
        }

        //variable declaration
        string fileContent = string.Empty;
        string filePath = string.Empty;
        string firstName = "";
        string permission = "";


        //get first name and permission from login form and store in firstname and permission strings
        public TextEditorForm(string firstNameLogin, string permissionLogin)
        {
            InitializeComponent();
            firstName = firstNameLogin;
            permission = permissionLogin;

        }

        //Display First name, Last name and permission from login form
        private void Form2_Load(object sender, EventArgs e)
        {
            //Add text to label
            nameAndPermission.Text = "Welcome: " + firstName + " (" + permission + ")";

            //check if permission is view
            if (permission.Equals("View"))
            {
                //disable every function except open and rich text box is read-only
                textbox.ReadOnly = true;
                cutToolStrip.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
                copyToolStrip.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                pasteToolStrip.Enabled = false;
                pasteToolStripMenuItem.Enabled = false;
                sizeComboBox.Enabled = false;
                saveAsToolStrip.Enabled = false;
                saveAsCtrlShiftSToolStripMenuItem.Enabled = false;
                saveToolStrip.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
                newToolStrip.Enabled = false;
                newToolStripMenuItem.Enabled = false;
                underlineToolStrip.Enabled = false;
                italicsToolStrip.Enabled = false;
                boldToolStrip.Enabled = false;
            }
        }



        //Unused function
        private void namePermission_Click(object sender, EventArgs e)
        {

        }
        private void textbox_TextChanged(object sender, EventArgs e)

        {

        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        //Open file function
        public void openFIle()
        {

            

            //open file using openFileDialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //open file with .txt and .rtf
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|Rich Text Format file(*.rtf) | *.rtf";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    //get the path of specified file
                    filePath = openFileDialog.FileName;
                    //get file extension .txt or .rtf
                    string fileExtension = Path.GetExtension(filePath);

                    //read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    if (fileExtension == ".rtf")
                    {
                        using (var rtf = new RichTextBox())
                        {
                            //read all text as rtf format
                            rtf.Rtf = File.ReadAllText(filePath);
                            //rich text box = file path rich text
                            textbox.Rtf = rtf.Rtf;

                        }
                    }
                    else if (fileExtension == ".txt")
                    {
                        //read .txt file
                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            fileContent = reader.ReadToEnd();
                        }
                        //rich text box = fileContent from file path
                        textbox.Text = fileContent;
                    }

                    //close fileStream
                    fileStream.Close();



                }
            }
        }

        //open button
        private void openToolStrip_Click(object sender, EventArgs e)
        {
            //using open file above
            openFIle();
        }

        //open file ctrl+S
        private void openCtrlOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //using open file above
            openFIle();
        }



        //Text bold function
        private void boldToolStrip_Click(object sender, EventArgs e)
        {
            Font text = textbox.SelectionFont;

            //check if text contains italic, bold and underline and change the font style which still keep existing font style
            if (text.Italic && text.Bold && text.Underline)
            {
                textbox.SelectionFont = new Font(text, FontStyle.Regular | FontStyle.Underline | FontStyle.Italic);
            }
            else if (text.Italic && text.Bold)
            {
                textbox.SelectionFont = new Font(text, FontStyle.Regular | FontStyle.Italic);
            }
            else if (text.Bold && text.Underline)
            {
                textbox.SelectionFont = new Font(text, FontStyle.Regular | FontStyle.Underline);
            }
            else if (text.Bold)
            {
                textbox.SelectionFont = new Font(text, FontStyle.Regular);
            }
            else
            {
                textbox.SelectionFont = new Font(text, text.Style | FontStyle.Bold);
            }

        }


        //Text italic function
        private void italicsToolStrip_Click(object sender, EventArgs e)
        {
            Font text = textbox.SelectionFont;

            //check if text contains italic, bold and underline and change the font style which still keep existing font style
            if (text.Italic && text.Bold && text.Underline)
            {
                textbox.SelectionFont = new Font(text, FontStyle.Regular | FontStyle.Bold | FontStyle.Underline);
            }
            else if (text.Italic && text.Bold)
            {
                textbox.SelectionFont = new Font(text, FontStyle.Regular | FontStyle.Bold);
            }
            else if (text.Italic && text.Underline)
            {
                textbox.SelectionFont = new Font(text, FontStyle.Regular | FontStyle.Underline);
            }
            else if (text.Italic)
            {
                textbox.SelectionFont = new Font(text, FontStyle.Regular);
            }
            else
            {
                textbox.SelectionFont = new Font(text, text.Style | FontStyle.Italic);
            }
        }


        //Text underline function
        private void underlineToolStrip_Click(object sender, EventArgs e)
        {

            Font text = textbox.SelectionFont;

            //check if text contains italic, bold and underline and change the font style which still keep existing font style
            if (text.Italic && text.Bold && text.Underline)
            {
                textbox.SelectionFont = new Font(text, FontStyle.Regular | FontStyle.Bold | FontStyle.Italic);
            }
            else if (text.Bold && text.Underline)
            {
                textbox.SelectionFont = new Font(text, FontStyle.Bold);
            }
            else if (text.Italic && text.Underline)
            {
                textbox.SelectionFont = new Font(text, FontStyle.Italic);
            }
            else if (text.Underline)
            {
                textbox.SelectionFont = new Font(text, FontStyle.Regular);
            }
            else
            {
                textbox.SelectionFont = new Font(text, text.Style | FontStyle.Underline);
            }

        }


        //Text cut function
        private void cut()
        {
            //if text selected text is not empty, then cut the text
            if (!textbox.SelectedText.Equals(""))
            {
                textbox.Cut();
            }
        }

        //cut button
        private void cutToolStrip_Click(object sender, EventArgs e)
        {
            //call cut function above
            cut();
        }

        //cut ctrl+X
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //call cut function above
            cut();
        }


        //Text copy function
        private void copy()
        {
            //if selected text length is not empty, then copy the text
            if (textbox.SelectionLength > 0)
            {
                textbox.Copy();
            }
        }

        //copy button
        private void copyToolStrip_Click(object sender, EventArgs e)
        {
            //call copy function above
            copy();
        }

        //copy ctrl + C
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //call copy function above
            copy();
        }



        //Text paste function
        private void pasteToolStrip_Click(object sender, EventArgs e)
        {
            textbox.Paste();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textbox.Paste();
        }




        //Add font sizes function
        private void sizeComboBox_Click(object sender, EventArgs e)
        {
            //check if size items is empty then add font size
            if (sizeComboBox.Items.Count == 0)
            {
                sizeComboBox.Items.Add(8);
                sizeComboBox.Items.Add(9);
                sizeComboBox.Items.Add(10);
                sizeComboBox.Items.Add(11);
                sizeComboBox.Items.Add(12);
                sizeComboBox.Items.Add(14);
                sizeComboBox.Items.Add(16);
                sizeComboBox.Items.Add(18);
                sizeComboBox.Items.Add(20);
            }
        }


        //Change font size function
        private void sizeComboBox_Change(object sender, EventArgs e)
        {
            //change font size when selected text is not empty
            Font currentFont = textbox.SelectionFont;
            if (textbox.SelectionLength > 0)
            {
                textbox.SelectionFont = new Font(currentFont.FontFamily, Convert.ToInt32(sizeComboBox.SelectedItem), currentFont.Style);
            }
        }

        //Create new file function
        private void newFile()
        {
            //check if textbox is not empty
            if (!textbox.Text.Equals(""))
            {
                //show warning message if the user wants to save change before opening new file
                MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save changes before creating new file, otherwise your current data will not be saved", "Create new file", (MessageBoxButton)MessageBoxButtons.YesNo);

                if (result == MessageBoxResult.Yes)// if yes
                {
                    //call function save as
                    saveAs();
                }
                else if (result == MessageBoxResult.No)//if no
                {
                    //clear all texts
                    textbox.Clear();
                    fileContent = string.Empty;
                    filePath = string.Empty;
                }
            }
            else // if text box is empty
            {
                //clear all texts
                textbox.Clear();
            }
        }

        //new button
        private void newToolStrip_Click(object sender, EventArgs e)
        {
            //call new file function above
            newFile();
        }

        //new ctrl + n
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //call new file function above
            newFile();
        }


        //Save as file function
        private void saveAs()
        {
            //call save file dialog object, filtering only .txt and .rth files
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|Rich Text Format file(*.rtf) | *.rtf";
            saveFileDialog1.Title = "Save as new file";

            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    filePath = saveFileDialog1.FileName;
                    string fileExtension = Path.GetExtension(filePath);

                    //if file's extension is rtf
                    if (fileExtension == ".rtf")
                    {
                        //write all text in Rtf format
                        File.WriteAllText(filePath, textbox.Rtf);
                        MessageBox.Show("Saved file successfully", "Save file");
                    }
                    else if (fileExtension == ".txt") //if file's extension is .txt
                    {
                        //write all text in normal text format
                        File.WriteAllText(filePath, textbox.Text);
                        MessageBox.Show("Saved file successfully", "Save file");
                    }

                }
            }
            catch (Exception error)// catch if file not found
            {
                //show error message
                MessageBox.Show("Cannot save file", "File Error");

                //still in text editor form
                TextEditorForm afterLoginForm = new TextEditorForm();
                afterLoginForm.Show();
            }
        }

        //save as button
        private void saveAsToolStrip_Click(object sender, EventArgs e)
        {
            //call save as function above
            saveAs();
        }

        //save as ctrl+shift+s
        private void saveAsCtrlShiftSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //call save as function above
            saveAs();
        }


        //Save file function
        private void save()
        {
            //check if filepath is empty, that mean never open or save before
            if (filePath.Equals(""))
            {
                saveAs();
            }
            else
            {
                // get file extension from the file path
                string fileExtension = Path.GetExtension(filePath);

                // check if filepath exists
                if (File.Exists(filePath))
                {
                    // file's extension is .txt
                    if (fileExtension == ".txt")
                    {
                        try
                        {
                            //delete the file and rewrite the current version of text
                            File.Delete(filePath);
                            using (StreamWriter sw = File.AppendText(filePath))
                            {
                                sw.WriteLine(textbox.Text);
                            }
                            MessageBox.Show("Saved file successfully", "Save file");
                        }
                        catch (IOException e) // catch any error
                        {
                            Console.WriteLine(e);
                        }
                    }
                    // file's extension is .rtf
                    else if (fileExtension == ".rtf")
                    {

                        try
                        {
                            //overwriting the existing file
                            using (var sr = new StreamWriter(filePath))
                            {
                                //writing in rtf format
                                sr.Write(textbox.Rtf);
                                //close the file
                                sr.Close();
                            }
                            MessageBox.Show("Saved file successfully", "Save file");

                        }
                        catch (IOException e) // catch any error
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }
        }

        //save button
        private void saveToolStrip_Click(object sender, EventArgs e)
        {
            //call save function above
            save();
        }

        //save ctrl+s
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //call save function above
            save();
        }

        //log out function
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if the user's permission is edit
            if (permission.Equals("Edit"))
            {



                //show message that are you sure to exit application
                MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure to close the application", "Close application", (MessageBoxButton)MessageBoxButtons.YesNo);

                if (result == MessageBoxResult.Yes)// if yes
                {
                    //hide this form and show login form
                    this.Visible = false;
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                }
                else if (result == MessageBoxResult.No) // if no
                {
                    //do nothing and allow user to stay in the text editor form
                }

            }
            // if user's permission is view
            else
            {
                //hide text editor form and show login form
                this.Visible = false;
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }

        }

        //about us function
        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show about form
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }


    }
}
