using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUtility
{
    public class UserInfo
    {
        private static string username = "xinhnguyen987";
        public static string Username
        {
            get { return username; }
            set { username = value; }
        }

        private static string email = "xinhnguyen1608@gmail.com";
        public static string Email
        {
            get { return email; }
            set { email = value; }
        }

        private static string password = "xinhnguyen987!@#";
        public static string Password
        {
            get { return password; }
            set { password = value; }
        }

        private static string fullname = "Nguyễn Thị Xinh";
        public static string Fullname
        {
            get { return fullname; }
            set { fullname = value; }
        }
    }
}
