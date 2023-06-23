using System;
using System.Text.Json;

namespace Department_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2 ta console application yarating (  Json Serialization,XML Serialization). Har bir project ichida Employee sinfi (EmployeeName) va Department(DepartmentName, Employee'lar to'plami). Main metod ichida Department object'ini serializatsiya qilish orqali faylga yozish va deserializatsiya qilish orqali qayta object'ga o'tkazish imkoniyatini shakllantiring.

            /* 
             * Create 2 console applications (Json Serialization,XML Serialization). 
             * Within each project, there is a class Employee(EmployeeName) and Department(DepartmentName, Employee list).
             * Within the main method, create the ability to serialize the Department object by writing it to a file and deserialize it back to the object.
            */

            Department department1 = new Department()
            {
                DepartmentName = "Department1"
            };

            Employee employee1 = new Employee("John");

            department1.AddEmployee(employee1); // ERROR NULL reference exception. please comment how to fix

            SerializeDepartment(department1);
            
        }

        public static void SerializeDepartment(Department department)
        {
            string Project_Path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            string jsonFile = $"{Project_Path}\\DepartmentObject.json";

            string jsonSerialized = JsonSerializer.Serialize(department);

            File.WriteAllText(jsonFile, jsonSerialized);

            Console.WriteLine(File.ReadAllText(jsonFile));
        }

        public static void DeserializeDepartment(Department department)
        {
            string Project_Path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            string jsonFile = $"{Project_Path}\\DepartmentObject.json";

            string jsonText = File.OpenRead(jsonFile).ToString();

            var JsonDepartment = JsonSerializer.Deserialize<Department>(jsonText);

            department.DepartmentName = JsonDepartment.DepartmentName;
            department.Employees = JsonDepartment.Employees;

        }
    }   
}