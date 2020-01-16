using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_Reservations_System_
{
    class Program
    {
        public static bool[] seats;
        public static int totalAssignedFirstClass;
        public static int totalAssignedEconomyClass;
        static void Main(string[] args)
        {
            
            seats = new bool[11];
            int choice = 0;

            for (int i = 1; i < seats.Length; i++)
            {
                try
                {
                    Console.WriteLine("Please enter 1 for First Class and Please type 2 for Economy.");
                    choice = Convert.ToInt32(Console.ReadLine());
                    while (choice < 1 || choice > 2)
                    {
                        Console.WriteLine("Wrong choice! Please enter 1 or 2");
                        choice = Convert.ToInt32(Console.ReadLine());
                        i--;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n\n" + ex.GetType().ToString() + "\n" +
                                 ex.StackTrace, "Exception");
                    i--;
                }
                if (choice == 1)
                {
                    
                    if (totalAssignedFirstClass == 5 && totalAssignedEconomyClass < 5)
                    {
                        try
                        {
                            Console.WriteLine("FIRST class is full. ECONOMY class is still available. Press 2 for reservation, or " +
                                             "press a number bigger than 2 to exit");
                            int secondChoice = Convert.ToInt32(Console.ReadLine());
                            if (secondChoice == 2)
                            {
                                assignEconomyClass();
                            }
                            else
                            {
                                Console.WriteLine("next plane leaves in 3 hours");
                                break;
                                
                               
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid numeric format. Please check all entries.",
                                             "Entry Error");
                            i--;
                        }
                    }
                    else if (totalAssignedFirstClass < 5)
                    {
                        assignFirstClass();

                    }
                }
                else 
                {
                    try
                    {
                        if (totalAssignedEconomyClass == 5 && totalAssignedFirstClass < 5)
                        {
                            Console.WriteLine("Economy class is full. First class is still available. Press 1 for reservation, or press a " +
                                              "number bigger than 2 to exit");
                            int thirdChoice = Convert.ToInt32(Console.ReadLine());
                            if (thirdChoice == 1)
                            {
                                assignFirstClass();
                            }
                            else
                            {
                                Console.WriteLine("next plane leaves in 3 hours");
                                break;
                            }
                        }

                        else if (totalAssignedEconomyClass < 5)
                        {
                            assignEconomyClass();
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid numeric format. Please check all entries.",
                                         "Entry Error");
                        i--;
                    }
                }

            }
        }


        public static int assignFirstClass()
        {

            for (int i = 1; i < 6; i++)
            {
                if (seats[i] == false)
                {
                    seats[i] = true;
                    totalAssignedFirstClass++;
                    Console.WriteLine("You reserved first class seat {0}", i);
                    return i; 
                }
            }
            return -1;
           
        }

        public static int assignEconomyClass()
        {


            for (int i = 6; i <seats.Length; i++)
            {
                if (seats[i] == false)
                {
                    seats[i] = true;
                    totalAssignedEconomyClass++;
                    Console.WriteLine("You reserved economy class seat {0}", i);
                    return i; 
                }
            }
            return -1;

           
        }

    }

}

