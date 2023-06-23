using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public static class Threads
    {
        #region Task 1
        /*
         * Write a program that receives a number from the user and displays all numbers from 1 to the entered numbers.
         * Use the Thread class for display, and display the number as follows: "Thread name: 1"
         */

        public static void Task1_Start()
        {
            Console.Write("Enter number for create threads and show it in console : ");

            int threads = int.Parse(Console.ReadLine());

            for (int i = 1; i <= threads; i++)
            {
                Thread Shownumber = new Thread(() => ShowNumber(i));
                Shownumber.Name = i.ToString();
                Shownumber.Start();
            }
        }

        private static void ShowNumber(int number)
        {
            Console.WriteLine($"Thread name : {Thread.CurrentThread.Name}");
        }

        #endregion

        #region Task 2
        //Accept a number from the user and display all prime and even numbers up to the number entered
        
        public static void Task2_Start()
        {
            Console.Write("Enter for display all prime and even numbers up to the number : ");
            int number = int.Parse(Console.ReadLine());

            for (int i = 2; i <= number; i++)
            {
                Thread thread = new Thread(() => ShowNumberType(i));
                thread.Start();
            }

        }

        private static void ShowNumberType(int number)
        {
            if (number%2==0)
            {                
                Console.WriteLine($" <= {number} - even number =>");

                // for Task 3
                WriteToText($" <= {number} - even number =>");
                return;
            }

            bool isDivided = false;

            for (int i = 3; i < number; i++)
            {
                if (number % i == 0)
                {
                    isDivided = true;
                    return;
                }
            }

            Console.WriteLine($" < === {number} - odd number === >");

            // for Task 3
            WriteToText($" < === {number} - odd number === >");
        }        

        #endregion


        #region Task 3
        // Write task 2 to file
        
        private static void WriteToText(string text)
        {
            // creating task2.txt
            string task2Txt_Path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();

            if (!File.Exists(task2Txt_Path))
                File.Create($"{task2Txt_Path}\\Task2.txt").Close();

            using(StreamWriter writer = File.AppendText(task2Txt_Path))
            {
                writer.Write(text);
            }
        }

        #endregion
    }
}