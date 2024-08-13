// code for displaying the output date in dd/mm/yyyy format along with a number of days to add to the input date.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DateAdder
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Array of number of days in all months in a year
            int[] totalDaysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            // Input date
            Console.Write("Enter the date in dd/mm/yyyy format: ");
            string inputDate = Console.ReadLine();

            string[] splitDate = inputDate.Split('/');
            
            // check whether entered input day is numerical value
            var isValid = int.TryParse(splitDate[0], out int day);
            if (!isValid)
            {
                Console.Write("Please enter the valid day with numeric value..");
                Console.ReadLine();
                return;
            }
            
            // check whether entered input month is numerical value
            isValid = int.TryParse(splitDate[1], out int month);
            if (!isValid)
            {
                Console.Write("Please enter the valid month with numeric value..");
                Console.ReadLine();
                return;
            }
           
           // check whether entered input year is numerical value
            isValid = int.TryParse(splitDate[2], out int year);
            if (!isValid)
            {
                Console.Write("Please enter the valid year with numeric value..");
                Console.ReadLine();
                return;
            }
            
            // check whether entered input year is valid
            isValid = IsYearValid(year);
            if (!isValid)
            {
                Console.Write("Please enter the valid year..");
                Console.ReadLine();
                return;
            }
            
            // check whether entered input month is valid
            var isMonthValid = IsMonthValid(month);
            if (!isMonthValid)
            {
                Console.Write("Please enter the valid month..");
                Console.ReadLine();
                return;
            }
            
            // check whether entered input day is valid
            var isDayValid = IsDayValid(day, month, year);
            if(!isDayValid)
            {
                Console.Write("Please enter the valid day..");
                Console.ReadLine();
                return;
            }
            
            // Input days 
            Console.Write("Enter the number of days: ");
            string numberOfDays = Console.ReadLine();

            // check whether entered number of days is numerical value
            isValid = int.TryParse(numberOfDays, out int daysToAdd);
            if(!isValid)
            {
                Console.Write("Please enter the valid number of days with numeric value..");
                Console.ReadLine();
                return;
            }

            // Add number of days to current days
            day += daysToAdd;

            while (true)
            {
                int daysInCurrentMonth = totalDaysInMonth[month - 1];

                // Scenario to Handle leap year
                if (month == 2 && IsLeapYear(year))
                {
                    daysInCurrentMonth = 29;
                }

                if (day > daysInCurrentMonth)
                {
                    day -= daysInCurrentMonth;
                    month++;

                    if (month > 12)
                    {
                        month = 1;
                        year++;
                    }
                }
                else
                {
                    break;
                }
            }

            // Output
            Console.WriteLine($"The output date in dd/mm/yyyy format: {day:D2}/{month:D2}/{year:D4}");
        }
        
        public static List<int> GetMonthWith31Days()
        {
            return new List<int>() { 1, 3, 5, 7, 8, 10, 12 };
        }
        
        public static List<int> GetMonthWith30Days()
        {
            return new List<int>() { 4, 6, 9, 11 };
        }
        static bool IsDayValid(int day, int month, int year)
        {
            bool isMonthHaving31Days = GetMonthWith31Days().Any(x => x == month);
            bool isMonthHaving30Days = GetMonthWith30Days().Any(x => x == month);
            
            if(isMonthHaving31Days)
            {
                return day <= 31;
            }
            if (isMonthHaving30Days)
            {
                return day <= 30;
            }
            if (month == 2 && IsLeapYear(year))
            {
                return day <= 29;
            }
            if (month == 2 && !IsLeapYear(year))
            {
                return day <= 28;
            }
            return false; ;
        }
        
        static bool IsMonthValid(int month)
        {
            return month > 0 && month <= 12;
        }
        
        static bool IsYearValid(int year)
        {
            return year > 0 && year <= 9999;
        }
        
        // Function to check if a year is a leap year
        static bool IsLeapYear(int year)
        {
            bool leap_year = false;
            if (year % 4 == 0)
            {
                leap_year = true;
            }
            if (year % 100 == 0)
            {
                leap_year = false;
            }
            if (year % 400 == 0)
            {
                leap_year = true;
            }
            return leap_year;
        }

    }
}
