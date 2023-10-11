//Name: Muqadas Arshad
//Roll_No: BITF20M023
//ASSIGNMENT_05
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions; 

namespace AssignmentFive
{
    class Program
    {
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\iAT\\source\\repos\\ES(smester7)\\Assignment-5\\Assignment-5\\AssignmentFive.mdf\";Integrated Security=True";
        static void ShowAllEmployees()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM Employees", connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("*****************************************************************************************************************************************************************");
                        Console.WriteLine(" ID | FirstName  | LastName |     Email    |  PrimaryPhoneNumber  |     SecondaryPhoneNumber  |    CreatedBy  |     CreatedOn      |   ModifiedBy  |    ModifiedOn  ");
                        Console.WriteLine("*****************************************************************************************************************************************************************");

                        while (reader.Read())
                        {
                            Console.WriteLine($"  {reader["ID"],-2}   {reader["FirstName"],-11}   {reader["LastName"],-9}   {reader["Email"],-4}   {reader["PrimaryPhoneNumber"],-19}   {reader["SecondaryPhoneNumber"],-22}   {reader["CreatedBy"],-10}   {reader["CreatedOn"],-10}   {reader["ModifiedBy"],-12}   {reader["ModifiedOn"],-12} ");              }

                        Console.WriteLine("******************************************************************************************************************************************************************");
                    }
                    Console.WriteLine("\n\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }



        static void AddEmployee()
        {
            Console.Write("Enter FirstName: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter LastName: ");
            string lastName = Console.ReadLine();

            string email;
            do
            {
                Console.Write("Enter Email (For Example: user@example.com): ");
                email = Console.ReadLine();
            } while (!IsValidEmail(email));

            string primaryPhoneNumber;
            do
            {
                Console.Write("Enter PrimaryPhoneNumber (11 digits): ");
                primaryPhoneNumber = Console.ReadLine();
            } while (!IsValidPhoneNumber(primaryPhoneNumber));

            Console.Write("Enter SecondaryPhoneNumber (optional, press enter to skip): ");
            string secondaryPhoneNumber = Console.ReadLine();
            if (!string.IsNullOrEmpty(secondaryPhoneNumber) && !IsValidPhoneNumber(secondaryPhoneNumber))
            {
                Console.WriteLine("Invalid secondary phone number. Skipping...");
                secondaryPhoneNumber = null;
            }

            Console.Write("Enter CreatedBy: ");
            string createdBy = Console.ReadLine();
            DateTime createdOn = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Employees (FirstName, LastName, Email, PrimaryPhoneNumber, SecondaryPhoneNumber, CreatedBy, CreatedOn) VALUES (@FirstName, @LastName, @Email, @PrimaryPhoneNumber, @SecondaryPhoneNumber, @CreatedBy, @CreatedOn)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhoneNumber);
                    command.Parameters.AddWithValue("@SecondaryPhoneNumber", string.IsNullOrEmpty(secondaryPhoneNumber) ? DBNull.Value : (object)secondaryPhoneNumber);
                    command.Parameters.AddWithValue("@CreatedBy", createdBy);
                    command.Parameters.AddWithValue("@CreatedOn", createdOn);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Employee added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Error adding employee.");
                    }
                    Console.WriteLine("\n\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }

        static bool IsValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^[0-9]{11}$");
        }


        static void DeleteEmployee()
        {
            SqlConnection connection = null;

            try
            {
                Console.Write("Enter Employee ID to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());

                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "DELETE FROM Employees WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Employee deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
                Console.WriteLine("\n\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }



        static void UpdateEmployee()
        {
            SqlConnection connection = null;
            SqlCommand command = null;

            try
            {
                Console.Write("Enter Employee ID to update: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter FirstName: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter LastName: ");
                string lastName = Console.ReadLine();

                string email;
                do
                {
                    Console.Write("Enter Email (For Example: user@example.com): ");
                    email = Console.ReadLine();
                } while (!IsValidEmail(email));

                string primaryPhoneNumber;
                do
                {
                    Console.Write("Enter PrimaryPhoneNumber (11 digits): ");
                    primaryPhoneNumber = Console.ReadLine();
                } while (!IsValidPhoneNumber(primaryPhoneNumber));

                Console.Write("Enter SecondaryPhoneNumber (optional, press enter to skip): ");
                string secondaryPhoneNumber = Console.ReadLine();
                if (!string.IsNullOrEmpty(secondaryPhoneNumber) && !IsValidPhoneNumber(secondaryPhoneNumber))
                {
                    Console.WriteLine("Invalid secondary phone number. Skipping...");
                    secondaryPhoneNumber = null;
                }

                Console.Write("Enter ModifiedBy: ");
                string modifiedBy = Console.ReadLine();
                DateTime modifiedOn = DateTime.Now;

                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PrimaryPhoneNumber = @PrimaryPhoneNumber, SecondaryPhoneNumber = @SecondaryPhoneNumber, ModifiedBy = @ModifiedBy, ModifiedOn = @ModifiedOn WHERE ID = @ID";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhoneNumber);
                command.Parameters.AddWithValue("@SecondaryPhoneNumber", string.IsNullOrEmpty(secondaryPhoneNumber) ? DBNull.Value : (object)secondaryPhoneNumber);
                command.Parameters.AddWithValue("@ModifiedBy", modifiedBy);
                command.Parameters.AddWithValue("@ModifiedOn", modifiedOn);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Employee updated successfully.");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
                Console.WriteLine("\n\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                
                if (command != null)
                {
                    command.Dispose();
                }

                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("*********************************");
                Console.WriteLine("Menu:");
                Console.WriteLine("*********************************");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Delete Employee");
                Console.WriteLine("3. All Employees");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Exit");
                Console.WriteLine("*********************************\n\n");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        DeleteEmployee();
                        break;
                    case 3:
                        ShowAllEmployees();
                        break;
                    case 4:
                        UpdateEmployee();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        


    }
}
