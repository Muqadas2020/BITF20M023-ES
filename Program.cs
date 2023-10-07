//Name: Muqadas Arshad
//Roll no: BITF20M023
//Assignment-03
using System;
using System.Collections.Generic;
namespace Assignment_3
{
    class Program
    {
        /************************* TASK 1 (a) *****************************/
        public static void Greet(string greeting = "Hello", string name = "World")
        {
            Console.WriteLine($"{greeting}, {name}!");
        }

        /************************* TASK 1 (b) *****************************/
        public static double CalculateArea(double length = 1.0, double width = 1.0)
        {
            double area = length * width;
            return area;
        }

        /************************* TASK 1 (c) *****************************/
        public static int AddNumbers(int a, int b)
        {
            return a + b;
        }
        public static int AddNumbers(int a, int b, int c = 0)
        {
            return a + b + c;
        }

        /************************* TASK 1 (d) *****************************/
        public class Book
        {
            private string title;
            private string author;
            public Book(string title, string author = "Unknown")
            {
                this.title = title;
                this.author = author;
            }
            public void DisplayDetails()
            {
                Console.WriteLine($"Title: {title}");
                Console.WriteLine($"Author: {author}");
            }
        }

        /************************* TASK 2 (a) *****************************/
        public class MyList<T>
        {
            private List<T> list;

            public MyList()
            {
                list = new List<T>();
            }
            public void AddElement(T element)
            {
                list.Add(element);
            }
            public void RemoveElement(T element)
            {
                list.Remove(element);
            }
            public void DisplayList()
            {
                Console.WriteLine("Elements in the list:");
                foreach (var element in list)
                {
                    Console.WriteLine(element);
                }
            }
        }

        /************************* TASK 2 (b) *****************************/
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }


        /************************* TASK 2 (c) *****************************/
        public static T ComputeSum<T>(T[] array) where T : struct, IConvertible
        {
            if (!typeof(T).IsPrimitive || typeof(T) == typeof(bool) || typeof(T) == typeof(char))
            {
                throw new ArgumentException("Unsupported data type");
            }

            T sum = default(T);
            foreach (T element in array)
            {
                sum = (T)Convert.ChangeType(Convert.ToDouble(sum) + Convert.ToDouble(element), typeof(T));
            }
            return sum;
        }


        /************************* TASK 2 (d) *****************************/
        public class StudentDatabase
        {
            private Dictionary<int, string> studentDictionary;

            public StudentDatabase()
            {
                studentDictionary = new Dictionary<int, string>();
            }

            public void AddStudent(int studentID, string name)
            {
                studentDictionary[studentID] = name;
            }

            public string GetStudentName(int studentID)
            {
                if (studentDictionary.ContainsKey(studentID))
                {
                    return studentDictionary[studentID];
                }
                else
                {
                    return "Student ID not found.";
                }
            }

            public void UpdateStudentName(int studentID, string newName)
            {
                if (studentDictionary.ContainsKey(studentID))
                {
                    studentDictionary[studentID] = newName;
                    Console.WriteLine("Student name updated successfully.");
                    DisplayStudentDatabase();
                }
                else
                {
                    Console.WriteLine("Student ID not found. Cannot update name.");
                }
            }

            public void DisplayStudentDatabase()
            {
                foreach (var student in studentDictionary)
                {
                    Console.WriteLine($"Student ID: {student.Key}, Name: {student.Value}");
                }
            }

            public void Run()
            {
                while (true)
                {
                    Console.WriteLine("\nStudent Database System Menu:");
                    Console.WriteLine("1. View the student database");
                    Console.WriteLine("2. Search for a student by ID");
                    Console.WriteLine("3. Update a student's name");
                    Console.WriteLine("4. Exit");

                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\nStudent Database:");
                            DisplayStudentDatabase();
                            break;
                        case 2:
                            Console.Write("Enter student ID to search: ");
                            int searchID = int.Parse(Console.ReadLine());
                            Console.WriteLine($"Student Name: {GetStudentName(searchID)}");
                            break;
                        case 3:
                            Console.Write("Enter student ID to update name: ");
                            int updateID = int.Parse(Console.ReadLine());
                            Console.Write("Enter new name: ");
                            string newName = Console.ReadLine();
                            UpdateStudentName(updateID, newName);
                            break;
                        case 4:
                            Console.WriteLine("Exiting the program. Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            //Task 1 (a)
            Console.WriteLine("Task - 1 (a) ");
            Console.WriteLine("*************************");
            Greet();
            Greet("Hi");
            Greet("Hey", "Alice");
            Console.WriteLine("\n\n");

            //Task 1 (b)
            Console.WriteLine("Task - 1 (b) ");
            Console.WriteLine("*************************");
            double defaultArea = CalculateArea();
            Console.WriteLine($"Area of the rectangle with default length and width: {defaultArea}");
            double customLengthArea = CalculateArea(5.0);
            Console.WriteLine($"Area of the rectangle with length 5.0 and default width: {customLengthArea}");
            double customArea = CalculateArea(3.0, 4.0);
            Console.WriteLine($"Area of the rectangle with length 3.0 and width 4.0: {customArea}");
            Console.WriteLine("\n\n");

            //Task 1 (c)
            Console.WriteLine("Task - 1 (c) ");
            Console.WriteLine("*************************");
            int sum1 = AddNumbers(3, 5);
            Console.WriteLine($"Sum of 3 and 5: {sum1}");
            int sum2 = AddNumbers(2, 4, 6);
            Console.WriteLine($"Sum of 2, 4, and 6: {sum2}");
            int sum3 = AddNumbers(1, 2);
            Console.WriteLine($"Sum of 1 and 2: {sum3}");
            Console.WriteLine("\n\n");

            //Task 1 (d)
            Console.WriteLine("Task - 1 (d) ");
            Console.WriteLine("*************************");
            Book book1 = new Book("The Catcher in the Rye");
            Book book2 = new Book("To Kill a Mockingbird", "Harper Lee");
            Console.WriteLine("Book 1 Details:");
            book1.DisplayDetails();
            Console.WriteLine("\nBook 2 Details:");
            book2.DisplayDetails();
            Console.WriteLine("\n\n");

            //Task 2 (a)
            Console.WriteLine("Task - 2 (a) ");
            Console.WriteLine("*************************");
            //For Integer
            MyList<int> intList = new MyList<int>();
            intList.AddElement(1);
            intList.AddElement(2);
            intList.AddElement(3);
            intList.DisplayList();
            //For String
            MyList<string> stringList = new MyList<string>();
            stringList.AddElement("Hello");
            stringList.AddElement("World");
            stringList.DisplayList();
            // Removing an element and displaying the updated list
            intList.RemoveElement(2);
            intList.DisplayList();
            Console.WriteLine("\n\n");

            //Task 2 (b)
            Console.WriteLine("Task - 2 (b) ");
            Console.WriteLine("*************************");
            //Testing the swap method for integers
            int num1 = 5;
            int num2 = 10;
            Console.WriteLine($"Before swapping: num1 = {num1}, num2 = {num2}");
            Swap(ref num1, ref num2);
            Console.WriteLine($"After swapping: num1 = {num1}, num2 = {num2}");

            // Testing the Swap method with strings
            string str1 = "Hello";
            string str2 = "World";
            Console.WriteLine($"Before swapping: str1 = {str1}, str2 = {str2}");
            Swap(ref str1, ref str2);
            Console.WriteLine($"After swapping: str1 = {str1}, str2 = {str2}");
            Console.WriteLine("\n\n");

            //Task 2 (c)
            Console.WriteLine("Task - 2 (c) ");
            Console.WriteLine("*************************");
            int[] intArray = { 1, 2, 3, 4, 5 };
            double[] doubleArray = { 1.1, 2.2, 3.3, 4.4, 5.5 };
            int intSum = ComputeSum(intArray);
            double doubleSum = ComputeSum(doubleArray);
            Console.WriteLine($"Sum of integers: {intSum}");
            Console.WriteLine($"Sum of doubles: {doubleSum}");
            Console.WriteLine("\n\n");

            //Task 2 (d)
            Console.WriteLine("Task - 2 (d) ");
            Console.WriteLine("*************************");
            StudentDatabase studentDB = new StudentDatabase();
            studentDB.AddStudent(101, "Alice");
            studentDB.AddStudent(102, "Bob");
            studentDB.AddStudent(103, "Charlie");
            studentDB.AddStudent(104, "David");
            studentDB.Run();
            Console.WriteLine("\n\n");
        }
        
    }
}
