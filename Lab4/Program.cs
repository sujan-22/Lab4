/*
Class:                  Form1.cs
Author:                 Sujan Rokad
Date:                   November 15, 2023
Authorship statement:   I, Sujan Rokad, 000882948 certify that this material is my original work. No other person's work has been used without due acknowledgement.

Purpose:                The Program class represents a console application that reads employee data from a CSV file, allows users to sort the data based on different criteria, and displays the sorted results in a table format. This program serves as a tool for managing and analyzing employee information, offering users the flexibility to sort data by employee name, number, pay rate, hours worked, and gross pay. The primary goal is to provide a user-friendly interface for interacting with employee data and gaining insights through various sorting options.         
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab4
{

    /// <summary>
    /// This program reads employee data from a CSV file, sorts it based on different criteria,
    /// and displays the sorted data in a table.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Employee list to store employee data.
        /// </summary>
        private List<Employee> employees = new List<Employee>();

        /// <summary>
        /// A method that is responsible for reading data from CSV file.
        /// </summary>
        /// <param name="filePath"></param>
        public void Read(string filePath)
        {
            try
            {
                using (StreamReader data = new StreamReader(filePath))
                {
                    string line;
                    while ((line = data.ReadLine()) != null)
                    {
                        // An array of string object that split each CSV file line with comma and stores it in employeeData array.
                        string[] employeeData = line.Split(',');
                        
                        // If statement that checks if splitted data that stored in array has length of 4 and if it does then goes into if condition.
                        if (employeeData.Length == 4)
                        {
                            string name = employeeData[0].Trim(); // Extract the employee name from the first element of 'employeeData' array and stores it in 'name' variable
                            int number = int.Parse(employeeData[1].Trim()); // Parse the employee number from the second element of 'employeeData' array and store it as an integer
                            decimal rate = decimal.Parse(employeeData[2].Trim()); // Parse the employee pay rate from the third element of 'employeeData' array and store it as a decimal
                            double hours = double.Parse(employeeData[3].Trim()); // Parse the employee hours worked from the fourth element of 'employeeData' array and store it as a double

                            employees.Add(new Employee(name, number, rate, hours)); // Create and add new Employee object with the parsed name, number, rate, and hours, then add it in the 'employees' list
                        }
                    }
                }
            } 
            // catch block to handle an exception occurs during file reading or parsing
            catch (Exception e)
            {
                Console.WriteLine("Unable to read file:");
                Console.WriteLine(e.Message); //display the specific error message
            }
        }

        /// <summary>
        /// Display the sorted employee data in a table
        /// </summary>
        public void DisplayTable()
        {
            // Display a horizontal line of '=' characters to separate the table visually
            Console.WriteLine(new string('=', 65));
            
            // Display the table header with column headers and formatting
            Console.WriteLine($"| {"Name",-21} {"Number",-(int)9.5} {"Rate",-(int)9.5} {"Hours",-8} {"Gross Pay  | ",-(int)9.5}");

            // Display another horizontal line of '=' characters for clarity
            Console.WriteLine(new string('=', 65));

            // Loop through each employee in the sorted list
            foreach (var employee in employees)
            {
                Console.WriteLine($"| {employee}  |");
            }

            // Display a final horizontal line of '=' characters to complete the table
            Console.WriteLine(new string('=', 65));
        }

        public static void Main(string[] args)
        {
            // Create an instance of the Program class
            Program employeeSort = new Program();

            // Read employee data from the CSV file
            employeeSort.Read("employees.txt");

            // Initialize a boolean variable to control program exit
            bool exit = false;

            // Display a menu to the user and handle their choice
            while (!exit)
            {
                // Define a formatted text menu with options
                string menu =
$@"
------------------------------------------|
Choose any from below options             |
------------------------------------------|
1) Sort by Employee Name (ascending)      |
2) Sort by Employee Number (ascending)    |  
3) Sort by Employee Pay Rate (descending) |
4) Sort by Employee Hours (descending)    |
5) Sort by Employee Gross Pay (descending)|
6) Exit                                   |
------------------------------------------|
Enter your choice: ";     

                // Display the menu to the user
                Console.Write(menu);

                // variable to store the user's choice
                int choice;

                // Attempt to read the user's choice from the console and convert into an integer
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    // Handle the user's choice based on the selected option
                    switch (choice)
                    {
                        // Sort employees by name in ascending order
                        case 1:
                            employeeSort.employees.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                            employeeSort.DisplayTable();
                            break;

                        // Sort employees by number in ascending order
                        case 2:
                            employeeSort.employees.Sort((e1, e2) => e1.Number.CompareTo(e2.Number));
                            employeeSort.DisplayTable();
                            break;
                        
                        // Sort employees by pay rate in descending order
                        case 3:
                            employeeSort.employees.Sort((e1, e2) => e2.Rate.CompareTo(e1.Rate));
                            employeeSort.DisplayTable();
                            break;
                        
                        // Sort employees by hours in descending order
                        case 4:
                            employeeSort.employees.Sort((e1, e2) => e2.Hours.CompareTo(e1.Hours));
                            employeeSort.DisplayTable();
                            break;
                        
                        // Sort employees by gross pay in descending order
                        case 5:
                            employeeSort.employees.Sort((e1, e2) => e2.GetGross().CompareTo(e1.GetGross()));
                            employeeSort.DisplayTable();
                            break;

                        // Set the 'exit' flag to true, exiting the program    
                        case 6:
                            exit = true;
                            Console.WriteLine("Ciao. "); // Goodbye message
                            Thread.Sleep(2000); // Waits for 2 seconds before exiting
                            break;

                        // Default case to display an error message for an invalid choice
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid choice.");
                }
            }
        }
    }

}
