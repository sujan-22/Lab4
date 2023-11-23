//I, Sujan Rokad, 000882948 certify that this material is my origianl work. No other person's work has been used without due acknowledgement.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    /// <summary>
    /// Represents an employee with basic information and methods to calculate gross pay.
    /// </summary>
    internal class Employee
    {
        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the employee number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the hourly rate of the employee.
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// Gets or sets the number of hours worked by the employee.
        /// </summary>
        public double Hours { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="name">The name of the employee.</param>
        /// <param name="number">The employee number.</param>
        /// <param name="rate">The hourly rate of the employee.</param>
        /// <param name="hours">The number of hours worked by the employee.</param>
        public Employee(string name, int number, decimal rate, double hours)
        {
            Name = name;
            Number = number;
            Rate = rate;
            Hours = hours;
        }

        /// <summary>
        /// Calculates the gross pay for the employee.
        /// </summary>
        /// <returns>The gross pay for the employee.</returns>
        public decimal GetGross()
        {
            // Calculate gross pay with overtime
            if (Hours > 40)
            {
                double regularHours = 40;
                double overtimeHours = Hours - regularHours;
                return (decimal)((regularHours * (double)Rate) + (overtimeHours * (double)Rate * 1.5));
            }
            else
            {
                return (decimal)(Hours * (double)Rate);
            }
        }

        /// <summary>
        /// Converts the employee information to a formatted string.
        /// </summary>
        /// <returns>A formatted string representing the employee information.</returns>
        public override string ToString()
        {
            return $"{Name,-21} {Number,-(int)9.5} {Rate,-(int)9.5:C} {Hours,-8:F2} {GetGross(),-(int)9.5:C}";
        }
    }
}

