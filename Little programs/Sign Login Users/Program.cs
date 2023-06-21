using HomeWork.Sign_and_login;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Directory File Homework

            const string Lab_Path = "C:\\Users\\KHalilov\\Documents\\GitHub\\HomeWork\\Modul 3\\Labaratory\\";

            Directory_File_Homework task = new Directory_File_Homework();

            // Task 1
            // Console.WriteLine(task.what_Is_Inside(Lab_Path));

            // Task 2
            // Console.WriteLine(task.Get_LinesCount($"{Lab_Path}\\Users.txt"));

            // Task 3
            // task.Copy_to($"{Lab_Path}\\Users.txt", $"{Lab_Path}\\here");

            // Task 4
            // task.CombineTwoFile
            //    (
            //        $"{Lab_Path}\\first file.txt", 
            //        $"{Lab_Path}\\second file.txt", 

            //        // combine and copy to
            //        $"{Lab_Path}\\here\\Users.txt"
            //    );

            // Task 5
            // task.Search_Folder_File(Lab_Path, "user");

            #endregion

            #region Sign and Login

            Sign_Login.Start();

            #endregion


        }
    }
}