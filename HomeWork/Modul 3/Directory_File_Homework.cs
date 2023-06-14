using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Directory_File_Homework
    {

        public string _Path { get; set; }

        public Directory_File_Homework(string path)
        {
            _Path = path;
        }


        #region task1

        // Task 1 - Create a method that determines what is inside the folder corresponding to the given path.

        /* Method returns :
         * "There are folders" - if there are only folders in the path, 
         * "There are files" - if there are only files,
         * "There are folders and files" - if there are folders and files,
         * "The folder is empty" - otherwise. (Easy)
        */


        public string what_Is_Inside(string path)
        {
            // creating arrays
            string[] directoryes = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);

            // creating bools for DRY (Don't Repeat Yourself)
            bool has_File = files.Length > 0;
            bool has_Directory = directoryes.Length > 0;


            //checking and finishing task
            if (has_Directory)
            {
                if (has_File)
                {
                    return "There are folders and files";
                }

                // else                
                return "There are folders";
            }

            else if(has_File)
            {
                return "There are files";
            }

            // else
            return "The folder is empty";                      
        }

        #endregion

        #region task2

        // Task 2 - Write a program that finds the number of lines in a given text file.



        #endregion
    }
}
