using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
                        using System.IO;
namespace MyBikes_1830508
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        static String txtFilePath = @"../../Login/Login_Details.txt";        
        int attempts = 0;

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(txtFilePath);
            String line = null;
            LoginClass loginDeatail = new LoginClass();
            while ((line = reader.ReadLine()) != null)
            {                
                String[] tokens = line.Split('|');
                loginDeatail.User_Name1 = tokens[0];
                loginDeatail.User_Password1 = tokens[1];
                loginDeatail.User_Name2 = tokens[2];
                loginDeatail.User_Password2 = tokens[3];
            }

            if (textBoxUname.Text == loginDeatail.User_Name1 && textBoxPassword.Text == loginDeatail.User_Password1)
            {
                this.Hide();
                Form1 fm = new Form1();
                fm.Show();
            }

            else if (textBoxUname.Text == loginDeatail.User_Name2 && textBoxPassword.Text == loginDeatail.User_Password2)
            {
                this.Hide();
                Form1 fm = new Form1();
                fm.Show();
            }
            else if (textBoxUname.Text == "")
            {
                MessageBox.Show("Enter User id");
            }
            else if (textBoxPassword.Text == "")
            {
                MessageBox.Show("Enter Password");
            }
            else 
            {
                MessageBox.Show("Information entered is Incorrect");
                attempts++;
            }
            if (attempts == 3)
            {
                MessageBox.Show("You have Entered Wrong Information 3 times so the Application is Closing!");
                Application.Exit();
            }
            reader.Close();            
        }
    }
}
