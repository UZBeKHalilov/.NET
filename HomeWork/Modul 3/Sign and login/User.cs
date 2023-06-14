using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Sign_and_login
{
    internal class User
    {
        // main
        private string FullName_Main { get; set; }
        private string UserName_Main { get; set; }
        private string Password_Main { get; set; }
        private Int64 PhoneNumber_Main { get; set; }

        // alt for Exceptions
        public string FullName
        {
            get { return FullName_Main; }
            set
            {
                FullName_Main = value;
            }
        }

        public string UserName
        {
            get { return UserName_Main; }

            set
            {
                UserName_Main = value;
            }

        }

        public string Password
        {
            get { return Password_Main; }
            set
            {
                Password_Main = Hash.getHashSha256(value);
            }
        }
        public Int64 PhoneNumber
        {
            get { return PhoneNumber_Main; }
            set
            {
                PhoneNumber_Main = value;
            }
        }

        public User()
        {
            FullName = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
            PhoneNumber = 0;
        }

    }
}
