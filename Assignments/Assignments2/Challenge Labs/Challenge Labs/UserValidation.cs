using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Challenge_Labs
{
    internal class UserValidation
    {
        //Write a C# Sharp program that takes userid and password as input (type string). After 3 wrong attempts, user will be rejected.
        private const string correctUserId = "admin";
        private const string correctPassword = "password123";

        public void ValidateUser()
        {
            int attempts = 0;
            const int maxAttempts = 3;
            while (attempts < maxAttempts)
            {
                Console.Write("Enter User ID: ");
                string? userId = Console.ReadLine();
                Console.Write("Enter Password: ");
                string? password = Console.ReadLine();
                if (userId == correctUserId && password == correctPassword)
                {
                    Console.WriteLine("Access Granted.");
                    return;
                }
                else
                {
                    attempts++;
                    Console.WriteLine("Invalid User ID or Password. Try again.");
                }
            }
            Console.WriteLine("Maximum attempts reached. Access Denied.");
        }
    }
}
