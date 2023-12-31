﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Sign_and_login
{


    internal class PerfectedSign
    {
        static string project_Path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();

        static DirectoryInfo Users_Folder = new DirectoryInfo($"{project_Path}\\Sign and login");

        static int user_Count
        {
            get 
            {
                int file_Count = Directory.GetFiles(Users_Folder.FullName).Length;
                return file_Count;
            }
        }

        public static void Start()
        {
            Console.WriteLine("Welcome !"); // Welcome!
            Select_Entrance_Option();
        }

        private static void Select_Entrance_Option()
        {
            Console.WriteLine("\n\t\t\t[1] Sign\t[2] Login\t[Esc] Exit");
            Console.Write("Choose options : ");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:

                    Console.Clear();
                    CreateAccaunt();

                    break;

                case ConsoleKey.D2:

                    Console.Clear();
                    Login();

                    break;

                case ConsoleKey.Escape:
                    return;

                default:

                    // EnterError();
                    Select_Entrance_Option();

                    break;
            }


        }

        private static void CreateAccaunt()
        {
            Console.WriteLine("\n\tCreating accaunt.");
            User user = new User();

            #region Accept Information from Console
            try
            {

                Console.Write("\nEnter User name : ");
                user.UserName = Console.ReadLine();

                if (Search_UsersTxt(user.UserName) && Search_UsersTxt(user.Password))
                {
                    Console.Clear();

                    SignEx.UserAlreadySigned();

                    Select_Entrance_Option();
                }


                Console.Write("Enter your name : ");
                user.FullName = Console.ReadLine();

                Console.Write("Enter phone number : +998 ");
                user.PhoneNumber = Int64.Parse(Console.ReadLine());

                Console.Write("Enter Password : ");
                user.Password = Console.ReadLine();

            }
            catch (Exception e)
            {
                SignEx.EnterError(e);

                CreateAccaunt();
            }

            #endregion

            CheckFix_Users_Directory(); // this method creates a Users.txt file if it doesn't exist.

            FileInfo user_txt = new FileInfo($"{Users_Folder.FullName}\\{user.UserName}.txt");

            using (StreamWriter stream_Writer = user_txt.AppendText())
            {
                stream_Writer.WriteLineAsync($"\t<---- [{user_Count}] - User ---->");

                stream_Writer.WriteLineAsync($" Username :         {user.UserName}\n" +
                                                $" Full name :        {user.FullName}\n" +
                                                $" Phone number : +998{user.PhoneNumber}\n" +
                                                $" Password :         {user.Password}\n");
            }

            Console_Green("Accaunt succerfully created!");

            SelectMenu();
        }

        private static void Login()
        {
            Console.WriteLine("\n\tLog in.");

            User user = new User();

            #region accepting information from console
            try
            {
                Console.Write("\nEnter User name : ");
                user.UserName = Console.ReadLine();

                if (!Search_UsersTxt(user.UserName))
                {
                    Console.Clear();
                    SignEx.UserNotDetected();
                }

                Console.Write("\nEnter Password : ");
                user.Password = Console.ReadLine();

                #region Checking password

                if (!Search_UsersTxt(user.Password))
                {
                    SignEx.ErrorPassword();

                    //short attempt = 3;
                    //bool isnot_Correct_Password = true;

                    //while (attempt != 0 && isnot_Correct_Password)
                    //{
                    //    Console.Write("Enter Password : ");
                    //    user.Password = Console.ReadLine();

                    //    if (Search_UsersTxt(user.Password))
                    //        isnot_Correct_Password = false;
                    //    else
                    //        attempt--;
                    //}

                    CreateAccaunt();
                }
                #endregion



            }
            catch (Exception ex)
            {
                SignEx.EnterError(ex);
                Console.Clear();

                Select_Entrance_Option();
            }

            #endregion

            Console_Green("You succerfully logined !");

            Show_User_Info(user);

            SelectMenu();
        }

        private static void SelectMenu()
        {
            // Console.Clear();
            Console.WriteLine("\n\t\tMenu : ");

            Console.WriteLine("\n\t\t[1] Another user information\t[2] Delete another user\t\t[3] Log out\t[Esc] Exit");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:

                    Console.Clear();
                    Show_Another_User_Info();

                    break;

                case ConsoleKey.D2:

                    Console.Clear();
                    Delete_Another_User();

                    break;

                case ConsoleKey.D3:

                    Console.Clear();
                    Select_Entrance_Option();

                    break;

                case ConsoleKey.Escape:
                    return;

                default:

                    SignEx.EnterError();
                    SelectMenu();

                    break;
            }
        }

        private static void Show_Another_User_Info()
        {
            User user = new User();
            Console_Yellow("Enter user to show it information.");
            try
            {
                Console.Write("User name : ");
                user.UserName = Console.ReadLine();
            }
            catch (Exception ex)
            {
                SignEx.EnterError(ex);
            }

            Show_User_Info(user);
        }
        private static void Delete_Another_User()
        {
            User user = new User();
            try
            {
                Console_Red("Enter user to delete it.");
                user.UserName = Console.ReadLine();
            }
            catch (Exception ex)
            {
                SignEx.EnterError(ex);
            }

            Console_Red("tbh i need learn how to work with files");
        }

        #region DRY methods

        public static void CheckFix_Users_Directory()
        {
            if (!Users_Folder.Exists)
                Users_Folder.Create();
        }


        private static void Show_User_Info(User user)
        {
            if (Search_UsersTxt(user.UserName))
            {
                Console.WriteLine("\n\tInformation : ");
                Console_Red("i need learn how to search xd");
            }
        }


        private static bool Search_UsersTxt(string SearchThis)
        {
            string Text = File.ReadAllText(Users_Folder.FullName);

            return Text.Contains(SearchThis);
        }

        // color
        public static void Console_Green(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"\n\t{text}\n");

            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void Console_Red(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"\n\t{text}\n");

            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void Console_Yellow(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"\n\t{text}\n");

            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion
    }
}
