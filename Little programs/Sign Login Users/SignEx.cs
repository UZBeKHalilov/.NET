using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Sign_and_login
{
    public class SignEx : Exception
    {
        public SignEx() { }

        public SignEx(string message)
            : base(message) { }

        public static void EnterError()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;

            Console.WriteLine("\n\tYou entered an error! Please enter again!\n");

            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void EnterError(Exception e)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;

            Console.WriteLine(e.Message);
            Console.WriteLine("\n\tYou entered an error! Please enter again!\n");

            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void UserAlreadySigned()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\n\tThis account is already signed! Please Login.\n");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void UserNotDetected()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\n\tUser not found! Please Sign in.\n");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ErrorPassword()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\n\tThe password is incorrect.\n");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
        
    public class Invalid_FullName : SignEx
    {
        public string message { get; set; }

        public Invalid_FullName() { }


        public Invalid_FullName(string message)
            : base(message) { }
    }
}
