using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity_Bill_Generator
{
    public class AdminService
    {
        private readonly string username = "admin";
        private readonly string password = "1234";
        public double perUnitCharge = 10.0;

        public double UpdateCharge(double newCharge) {
            perUnitCharge = newCharge;
            return newCharge;
        }

        public bool isAdminAuth(string username, string password) { 
            return username == this.username && password == this.password;
        }
        public void AdminLogin()
        {
            Console.WriteLine("_________ADMIN LOGIN_________");
            Console.Write("Username: ");
            string inputUsername = Console.ReadLine();
            Console.Write("Password: ");
            string inputPassword = Console.ReadLine();
            if (isAdminAuth(inputUsername, inputPassword))
            {
                Console.WriteLine("Login Successful!");
                AdminMenu();
                return;
            }
            else
            {
                Console.WriteLine("Invalid Username or Password!");
            }
        }

        public void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("_________ADMIN MENU_________");
                Console.WriteLine("[1] Update Per Unit Charge.");
                Console.WriteLine("[2] Logout.");
                Console.Write("Enter Choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("_________ Update Per Unit Charge ________");
                        double pervCharge = perUnitCharge;
                        Console.Write("Enter Charge/Unit: Rs. ");
                        double newCharge = UpdateCharge(Convert.ToDouble(Console.ReadLine()));
                        Console.WriteLine($"Successfully updated Charge/Unit from INR {pervCharge} to INR {newCharge}!");
                        break;

                    case "2":
                        Console.WriteLine("Logging out...");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
            }
        }

    }
}
