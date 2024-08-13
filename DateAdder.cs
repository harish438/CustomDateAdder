// code for displaying the output date in dd/mm/yyyy format along with a number of days to add to the input date.

using System;

namespace DateAdder
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Array of number of days in all months in a year
            int[] totalDaysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            
            // Input date
            Console.WriteLine("Enter the date in dd/mm/yyyy format: ");
            string inputDate = Console.ReadLine();

            // Input days 
            Console.WriteLine("Enter the number of days: ");
            string numberOfDays = Console.ReadLine();

            string[] splitDate = inputDate.Split('/');
            int day = int.Parse(splitDate[0]);
            int month = int.Parse(splitDate[1]);
            int year = int.Parse(splitDate[2]);
            int daysToAdd = int.Parse(numberOfDays);

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
            Console.WriteLine($"The new date is: {day:D2}/{month:D2}/{year}");
        }
        
        // Function to check if a year is a leap year
        static bool IsLeapYear(int year)
        {
            bool leap_year = false;
            if (year % 4 == 0){
                leap_year = true;
            }
            if (year % 100 == 0){
                leap_year = false;
            }
            if (year % 400 == 0){
                leap_year = true;
            }
            return leap_year;
        }
        
    }
}
