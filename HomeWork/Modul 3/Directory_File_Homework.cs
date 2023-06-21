using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public class Directory_File_Homework
    {
        public Directory_File_Homework(){}

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

        public int Get_LinesCount(string filePath)
        {
            int lineCount = 0;

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (reader.ReadLine() != null)
                    {
                        lineCount++;
                    }
                }

            }
            return lineCount;
        }

        #endregion

        #region task3

        // Task 3 - Create a program that copies the given file (in any format).

        public void Copy_to(string copyFile_Path, string copyHere_Folder_Path)
        {
            FileInfo file = new FileInfo(copyFile_Path);
            DirectoryInfo directory = new DirectoryInfo(copyHere_Folder_Path);

            if(!file.Exists)
            {
                file.Create().Close();
            }

            string file_text = File.ReadAllText(copyFile_Path);

            if(!directory.Exists)
            {
                directory.Create();
            }

            string newFile_FullPath = $"{directory.FullName}\\{file.Name}";

            File.WriteAllText(newFile_FullPath,file_text);

        }

        #endregion

        #region task4
        // Task 4 - Write a program that combines the contents of two text files and writes them to a third file.

        public void CombineTwoFile(string firstFile_path, string secondFile_path, string theyMerge_FilePath)
        { 
            //fixing
            if(!File.Exists(firstFile_path))            
                File.Create(firstFile_path).Close();

            if (!File.Exists(secondFile_path))
                File.Create(secondFile_path).Close();

            if (!File.Exists(theyMerge_FilePath))
                File.Create(theyMerge_FilePath).Close();


            string firstFile_txt = File.ReadAllText(firstFile_path);
            string secondFile_txt = File.ReadAllText(secondFile_path);

            using (StreamWriter writer = File.AppendText(theyMerge_FilePath))
            {
                writer.WriteLine(firstFile_txt);
                writer.WriteLine(secondFile_txt);
            }
        }

        #endregion

        #region task5
        // Task 5 - Write a program to display the files and folders in the given folder whose names contain the searched text.
        // In this case, if there are folders inside the given folder, they should be searched (recursion is used)

        public void Search_Folder_File(string folderPath, string searchText) // text
        {
            string[] files = Directory.GetFiles(folderPath);
            foreach (string filePath in files)
            {
                string fileName = Path.GetFileName(filePath);
                string fileName_LowerCase = fileName.ToLower();

                if (fileName_LowerCase.Contains(searchText))
                {               
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine($"\n File ->{GetDirectory_Name(Path.GetDirectoryName(filePath))}\\{fileName}");

                    Console.ForegroundColor = ConsoleColor.White;
                }
            }


            string[] directoryes = Directory.GetDirectories(folderPath);
            foreach (string directoryPath in directoryes)
            {
                string directoryName = GetDirectory_Name(directoryPath);
                string directoryName_LowerCase = directoryName.ToLower();
                

                if (directoryName_LowerCase.Contains(searchText))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    
                    Console.WriteLine($"\n Directory --> {directoryName}");
                    
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Search_Folder_File(directoryPath, searchText);
            }

        }

        public static string GetDirectory_Name(string directoryPath)
        {
            return directoryPath.Substring( directoryPath.LastIndexOf(@"\") + 1);
        }

        #endregion
    }
}
