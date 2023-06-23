using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public static class Threads
    {
        #region Task1
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

        public static void ShowNumber(int number)
        {
            Console.WriteLine($"Thread name : {Thread.CurrentThread.Name}");
        }

        #endregion
    }
}
