using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBikes_1830508
{
    class LoginClass
    {
        private string userName1;
        private string password1;
        private string userName2;
        private string password2;
        public string User_Name1
        {
            get
            {
                return userName1;
            }

            set
            {
                userName1 = value;
            }
        }
        public string User_Password1
        {
            get
            {
                return password1;
            }

            set
            {
                password1 = value;
            }
        }
        public string User_Name2
        {
            get
            {
                return userName2;
            }

            set
            {
                userName2 = value;
            }
        }
        public string User_Password2
        {
            get
            {
                return password2;
            }

            set
            {
                password2 = value;
            }
        }
        public LoginClass()
        {
            this.userName1 = "undefined";
            this.password1 = "undefined";
            this.userName2 = "undefined";
            this.password2 = "undefined";

        }
        public LoginClass(string uName1, string pass1, string uName2, string pass2)
        {
            this.userName1 = uName1;
            this.password1 = pass1;

            this.userName2 = uName2;
            this.password2 = pass2;
        }
        public override string ToString()
        {
            String output;
            output = this.userName1 + "\t" + this.password1 +
                     this.userName2 + "\t" + this.password2 + "\t"+"\n";
            return output;
        }
    }
}
