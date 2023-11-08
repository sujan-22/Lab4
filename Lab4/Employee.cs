//I, Sujan Rokad, 000882948 certify that this material is my origianl work. No other person's work has been used without due acknowledgement.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Employee
    {
        // Private fields to store employee information
        public string Name { get; set; }
        public int Number { get; set; }
        public decimal Rate { get; set; }
        public double Hours { get; set; }

        // Constructor to initialize employee information
        public Employee(string name, int number, decimal rate, double hours)
        {
            Name = name;
            Number = number;
            Rate = rate;
            Hours = hours;
        }

        // Getter methods
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
        
        // ToString method to format employee information
        public override string ToString()
        {
            return $"{Name,-21} {Number,-(int)9.5} {Rate,-(int)9.5:C} {Hours,-8:F2} {GetGross(),-(int)9.5:C}";
        }
    }

}

