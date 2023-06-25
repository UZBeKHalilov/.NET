using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int year, Month, day;
            bool isInput = false;

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Tug'ilgan yilingizni kiriting: ");

                year = int.Parse(Console.ReadLine());

                if (year <= 2023) isInput = true;  
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hato kiritdingiz.");
                }

            } while (!isInput);

            isInput = false;

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Tug'ilgan oyingizni kiriting: ");

                if (int.TryParse(Console.ReadLine(), out Month) && Month > 0 && Month <= 12)     isInput = true;
                
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hato kiritdingiz. (1-12)");                }

            } while (!isInput);

            isInput = false;

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("tug'ilgan kuningizni kiriting: ");

                if (int.TryParse(Console.ReadLine(), out day) && day > 0 && day <= 31)  isInput = true;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hato kiritdingiz. (1-31).");
                }

            } while (!isInput);


            DateTime dateTime = new DateTime(year, Month, day);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nYour birth: {dateTime}");
            Console.ResetColor();

            DateTime now = DateTime.Now;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\nNow time: {now.Month}/{now.Day}/{now.Year}");
            Console.ResetColor();

            TimeSpan elapsedTime = now - dateTime;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nYou were born {elapsedTime.Days / 365} years, {elapsedTime.Days % 365 / 30} months,{elapsedTime.Days % 365 % 30} days ago");
            Console.ResetColor();

            Console.ReadKey();
        }
    }
}
