using TaskStudent.Models;
using System;

namespace TaskStudent
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string name = "";
            string surname = "";
            int age = 0;
            double salaryOfHour = 0;
            double workingHour = 0;
            double iqRank = 0;
            double  languageRank = 0;
            int choice;
            do
            {
                Console.WriteLine("[0]-About program ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine($"[1]-Calculate employee salary\n[2]-Calculate student exam\n[3]-Stop program");
                        break;
                    case 1:
                        InputEmployee(name, surname, age, ref workingHour, ref salaryOfHour);
                        Employee employeer = new Employee(name, surname, age, workingHour, salaryOfHour);
                        Console.WriteLine($"Result: {employeer.CalculateSalary()} Azn");
                        break;
                    case 2:
                        InputStudent(name, surname, age, ref iqRank, ref languageRank);
                        Student stdudent = new Student(name, surname, age, iqRank, languageRank);
                        Console.WriteLine($"Result: {stdudent.ExamResult()} Point");
                        double result = stdudent.ExamResult();
                        StudentIsPass(result);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Program stopped");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong input [0]-About program");
                        break;
                }
            } while (choice != 3);
        }

        static void InputEmployee(string name, string surname, int age, ref double workingHour, ref double salaryOfHour)
        {
            CheckName(name);
            CheckSurname(surname);
            CheckEmployeeAge(age);
            CheckSalaryWorkingHour(ref workingHour, ref salaryOfHour);
        }
        static void InputStudent(string name, string surname, int age, ref double mathPoint, ref double azLangPoint)
        {
            CheckName(name);
            CheckSurname(surname);
            CheckStudentAge(age);
            CheckMathPointInput(ref mathPoint);
            CheckAzLangPointInput(ref azLangPoint);
        }

        static void CheckName(string name)
        {
            do
            {
                Console.Write("Enter name : ");
                name = Console.ReadLine();
            } while (String.IsNullOrEmpty(name));
        }

        static void CheckSurname(string surname)
        {
            do
            {
                Console.Write("Enter surname: ");
                surname = Console.ReadLine();
            } while (String.IsNullOrEmpty(surname));
        }

        static void CheckEmployeeAge(int age)
        {
            do
            {
                Console.Write("Enter age: ");
                age = Convert.ToInt32(Console.ReadLine());
                if (age < 18 || age > 70)Console.WriteLine("Can't work");
            } while (age < 18 || age > 70);
        }

        static void CheckSalaryWorkingHour(ref double salaryOfHour, ref double workingHour)
        {
            do
            {
                Console.Write("Enter monthly work hour: ");
                workingHour = Convert.ToDouble(Console.ReadLine());
                if (workingHour < 0 || workingHour > 246)Console.WriteLine("Montly work time must 1-246 interval");//31day working in 8 housr 246hour.I dont select
            } while (workingHour < 0 || workingHour > 246);
            do
            {
                Console.Write("Enter your hourly salary: ");
                salaryOfHour = Convert.ToDouble(Console.ReadLine());
                if (salaryOfHour != 0&& salaryOfHour>0)Console.WriteLine($"Minumum monthly salary is 250Azn\nYou monthly salary is:{salaryOfHour * workingHour}");
                else
                {
                    Console.WriteLine("Salary can't 0 or negative.!");
                }
            } while (salaryOfHour <= 0 || (salaryOfHour * workingHour) < 250);
        }

        static void CheckStudentAge(int age)
        {
            do
            {
                Console.Write("Enter age: ");
                age = Convert.ToInt32(Console.ReadLine());
                if (age < 6 || age > 20)
                    Console.WriteLine("Your age not compatible");
            } while (age < 6 || age > 20);
        }

        static void CheckMathPointInput(ref double mathPoint)
        {
            do
            {
                Console.Write("Enter math result : ");
                mathPoint = Convert.ToDouble(Console.ReadLine());
                if (mathPoint > 100 || mathPoint < 0)
                    Console.WriteLine("Math result must be 0-100 interval");
            } while (mathPoint > 100 || mathPoint < 0);
        }

        static void CheckAzLangPointInput(ref double azLangPoint)
        {
            do
            {
                Console.Write("Enetr Az language point: ");
                azLangPoint = Convert.ToDouble(Console.ReadLine());
                if (azLangPoint > 100 || azLangPoint < 0)
                    Console.WriteLine("Az language result must be 0-100 interval");
            } while (azLangPoint > 100 || azLangPoint < 0);
        }
        static void StudentIsPass(double result)
        {
            if (result >= 120)
                Console.WriteLine("Your passed exam\nCongrualation!..");
            Console.WriteLine("Failed exam!:(");
        }
    }
    
}
