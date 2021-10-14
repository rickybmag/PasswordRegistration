using System;
using System.Collections.Generic;
using System.Linq;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> users = new List<string>();
            users.Add("Username1");
            users.Add("Username2");

            List<string> pword = new List<string>();
            pword.Add("Password1!");
            pword.Add("Password2!");



            bool keepGoing = true;
            while (keepGoing)
            {

                string user = Input("Please input your username. Please include 7-12 characters");

                bool checkUser = Username(user);
                if (checkUser == false)
                {
                    Console.WriteLine("Please try again");                    
                }
                else
                {
                    users.Add(user);
                    foreach (string names in users)
                    {
                        Console.WriteLine(names);
                    }
                }

                string password = Input("Please input your password. Please include 7-12 characters, 1 upper and lowercase letter, and 1 special character");

                bool pwCheck = Password(password);
                if (pwCheck == false)
                {
                    Console.WriteLine("Please try your password again");
                    Password(password);
                }
                else
                {
                    pword.Add(password);
                    foreach (string pass in pword)
                    {
                        Console.WriteLine(pass);
                    }
                }

                keepGoing = Continue();
                
            }
        }

        public static string Input(string prompt)
        {
            Console.WriteLine(prompt);
            string output = Console.ReadLine();
            return output;
        }

        public static bool Username(string user)
        {
            if (user.Length < 7 || user.Length > 12)
            {
                Console.WriteLine("Username must be a minimum of 7 characters and less that 12 characters");
                return false;
            }
            else if(user.Any(char.IsLetter) == false || user.Count(char.IsLetter) < 5)
            {
                Console.WriteLine("Please enter a username that includes letters. Make sure you have atleast 5");
                return false;
            }
            else if(user.Any(char.IsDigit) == false)
            {
                Console.WriteLine("Please include a number in your username");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool SpecialCharacter(string input)
        {
            string special = @"!@#$%^&*";
            char[] specialChar = special.ToCharArray();

            foreach (char items in specialChar)
            {
                if (input.Contains(items))
                    return true;
            }

            return false;
        }

        public static bool Password(string input)
        {
            if (input.Length < 7 || input.Length > 12)
            {
                Console.WriteLine("Please input a password between 7-12 characters.");
                return false;
            }
            else if (input.Any(char.IsDigit) == false)
            {
                Console.WriteLine("Please include a number in your password");
                return false;
            }
            else if(input.Any(char.IsLetter) == false || input.ToLower() == input || input.ToUpper() == input)
            {
                Console.WriteLine("Please include a letter in your password. Also make sure you include atleast 1 uppercase and 1 lowercase");
                return false;
            }
            else if (SpecialCharacter(input) == false)
            {
                Console.WriteLine("Please include a special character in your password");
                return false;
            }
            else 
            {
                return true;
            }
        }

        public static bool Continue()
        {
            string answer = Input("Would you like to continue? (Y/N)");
            Console.WriteLine();

            if (answer == "y")
            {
                return true;
            }
            else if (answer == "n")
            {
                Console.WriteLine("Thank you! See you soon!");
                return false;                
            }
            else
            {
                Console.WriteLine("Please Try again");
                return Continue();
            }
        }

    }
}
