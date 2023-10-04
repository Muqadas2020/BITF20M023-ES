//Name : Muqadas Arshad
//Roll-No : BITF20M023
//ASSIGNMENT- 02
using System;
using System.Collections.Generic;
namespace Assignment_2
{

    class Program
    {

        static void Main(string[] args)
        {
            //Task-1
          
            Console.WriteLine("TASK-1");
            Console.WriteLine("****************************************");
            Console.Write("Enter your first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine();
            string fullName = GetFullName(firstName, lastName);
            Console.WriteLine("Your full name is: " + fullName);
      

            //Task-2
            Console.WriteLine("\n\nTASK-2");
            Console.WriteLine("****************************************");
            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine();
            string lastFiveCharacters = ExtractLastFiveCharacters(sentence);
            Console.WriteLine("Last 5 characters: " + lastFiveCharacters);


            //Task-3
            GetTemperatureAndCity();

            //Task-4
            PrintNumbersArray();

            //Task-5a
            string[] fruits = { "Apple", "Banana", "Orange", "Mango", "Grapes" };
            IterateFruitsUsingForLoop(fruits);
            //Task-5b
            string[] colors = { "Red", "Blue", "Green" };
            IterateColorsUsingForeachLoop(colors);


            //Task-6
            CalculateAndDisplaySumOfScores();

            //task-7
            int[] values = { 10, 25, 8, 42, 15, 30, 50 };
            FindAndDisplayMaxValue(values);

            //task-8
            int[] numbers = { 1, 2, 3, 4, 5 };
            ReverseArrayInPlace(numbers);


            //Task-9a
            PerformIntegerBoxingAndUnboxing();
            //Task-9b
            PerformDoubleBoxingAndUnboxing();

            /*************************************** TASK 10 ****************************************/
            // Part a: Unboxing with arrays of integers
            Console.WriteLine("\n\nTASK-10 (part a)");
            Console.WriteLine("****************************************");
            int[] num = { 1, 2, 3, 4, 5 };

            Console.WriteLine("Unboxing with arrays of integers:");
            foreach (int number in num)
            {
                object boxedObject = number; // Box the integer
                int unboxedValue = (int)boxedObject; // Unbox the object back to integer

                int squaredValue = unboxedValue * unboxedValue; // Calculate the square of the unboxed integer
                Console.WriteLine($"Original Integer: {unboxedValue}, Square: {squaredValue}");
            }

            // Part b: Unboxing with generic List containing different value types
            Console.WriteLine("\n\nTASK-10 (part b)");
            Console.WriteLine("****************************************");
            List<object> mixedList = new List<object> { 10, 3.14, 'A' };

            Console.WriteLine("\nUnboxing with generic List containing different value types:");
            foreach (object item in mixedList)
            {
                if (item is int intValue)
                {
                    Console.WriteLine($"Integer Value: {intValue}, Type: {item.GetType()}");
                }
                else if (item is double doubleValue)
                {
                    Console.WriteLine($"Double Value: {doubleValue}, Type: {item.GetType()}");
                }
                else if (item is char charValue)
                {
                    Console.WriteLine($"Char Value: {charValue}, Type: {item.GetType()}");
                }
            }
            /**************************************** Task 11 *********************************/
            // Part a: Dynamic variable with integer and string values
            Console.WriteLine("\n\nTASK-11 (part a)");
            Console.WriteLine("****************************************");
            dynamic myVariable = 42; // Assign an integer value
            Console.WriteLine("myVariable (integer): " + myVariable);

            myVariable = "Hello, Dynamic!"; 
            Console.WriteLine("myVariable (string): " + myVariable);

            // Part b: Dynamic variable with different data types
            Console.WriteLine("\n\nTASK-11 (part b)");
            Console.WriteLine("****************************************");
            dynamic myVariable2 = 10; 
            Console.WriteLine("Type of myVariable2 (integer): " + myVariable2.GetType());

            myVariable2 = 3.14; 
            Console.WriteLine("Type of myVariable2 (double): " + myVariable2.GetType());

            myVariable2 = DateTime.Now; 
            Console.WriteLine("Type of myVariable2 (DateTime): " + myVariable2.GetType());

            myVariable2 = "Dynamic String"; 
            Console.WriteLine("Type of myVariable2 (string): " + myVariable2.GetType());

        }

        /*************************************** TASK 1 ****************************************/
        static string GetFullName(string firstName, string lastName)
        {
            string fullName = $"{firstName} {lastName}";
            return fullName;
        }

        /*************************************** TASK 2 ****************************************/
        static string ExtractLastFiveCharacters(string input)
        {
            if (input.Length <= 5)
            {
                return input;
            }
            else
            {  
                string lastFiveCharacters = input.Substring(input.Length - 5);
                return lastFiveCharacters;
            } 
        }
        /*************************************** TASK 3 ****************************************/
        static void GetTemperatureAndCity()
        {
            Console.WriteLine("\n\nTASK-3");
            Console.WriteLine("****************************************");
            double temperature;
            string city;
            Console.Write("Enter the current temperature: ");
            string temperatureInput = Console.ReadLine();
            if (double.TryParse(temperatureInput, out temperature))
            {
                Console.Write("Enter the name of your city: ");
                city = Console.ReadLine();
                Console.WriteLine($"The temperature in {city} is {temperature} degrees Celsius.");
            }
            else
            {
                Console.WriteLine("Invalid temperature input. Please enter a valid number.");
            }

        }

        /*************************************** TASK 4 ****************************************/
        static void PrintNumbersArray()
        {
            Console.WriteLine("\n\nTASK-4");
            Console.WriteLine("****************************************");
            int[] numbers = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Elements of the 'numbers' array:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        /*************************************** TASK 5 ****************************************/
        static void IterateFruitsUsingForLoop(string[] fruits)
        {
            Console.WriteLine("\n\nTASK-5 (part a)");
            Console.WriteLine("****************************************");
            Console.WriteLine("Fruits using for loop:");
            for (int i = 0; i < fruits.Length; i++)
            {
                Console.WriteLine(fruits[i]);
            }
        }

        static void IterateColorsUsingForeachLoop(string[] colors)
        {
            Console.WriteLine("\n\nTASK-5 (part b)");
            Console.WriteLine("****************************************");
            Console.WriteLine("Colors using foreach loop:");
            foreach (string color in colors)
            {
                Console.Write(color + ", ");
            }
        }
        /*************************************** TASK 6 ****************************************/
        static void CalculateAndDisplaySumOfScores()
        {
            Console.WriteLine("\n\nTASK-6");
            Console.WriteLine("****************************************");
            int[] scores = { 85, 92, 78, 95, 89, 91, 88, 84, 97, 93 };
            int sum = 0;
            int index = 0;
            do
            {
                sum += scores[index];
                index++;
            } while (index < scores.Length);
            Console.WriteLine("Sum of test scores: " + sum);
        }

        /*************************************** TASK 7 ****************************************/
        static void FindAndDisplayMaxValue(int[] values)
        {
            Console.WriteLine("\n\nTASK-7");
            Console.WriteLine("****************************************");
            if (values.Length == 0)
            {
                Console.WriteLine("The array is empty.");
                return;
            }
            int max = values[0];
            int index = 1;
            while (index < values.Length)
            {
                if (values[index] > max)
                {
                    max = values[index];
                }
                index++;
            }
            Console.WriteLine("Maximum value in the array: " + max);
        }

        /*************************************** TASK 8 ****************************************/
        static void ReverseArrayInPlace(int[] numbers)
        {
            Console.WriteLine("\n\nTASK-8");
            Console.WriteLine("****************************************");
            int midpoint = numbers.Length / 2;
            int lastIndex = numbers.Length - 1;
            foreach (int number in numbers)
            {
                int temp = numbers[lastIndex];
                numbers[lastIndex] = number;
                numbers[Array.IndexOf(numbers, number)] = temp;
                lastIndex--;
                if (lastIndex < midpoint)
                {
                    break;
                }
            }

            Console.WriteLine("Reversed array:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        /*************************************** TASK 9 ****************************************/
        static void PerformIntegerBoxingAndUnboxing()
        {
            Console.WriteLine("\n\nTASK-9 (part a)");
            Console.WriteLine("****************************************");
            // Boxing: Convert int to object
            int x = 42;
            object boxedObject = x;

            // Unboxing: Convert object back to int
            int y = (int)boxedObject;

            // Display the unboxed value
            Console.WriteLine("Unboxed Integer Value: " + y);
        }
        static void PerformDoubleBoxingAndUnboxing()
        {
            Console.WriteLine("\n\nTASK-9 (part b)");
            Console.WriteLine("****************************************");
            // Boxing: Convert double to object
            double doubleValue = 3.14159;
            object boxedObject = doubleValue;

            // Unboxing: Convert object back to double
            double unboxedValue = (double)boxedObject;

            // Display the unboxed value
            Console.WriteLine("Unboxed Double Value: " + unboxedValue);
        }
    }
}

