using System;
using System.Collections.Generic;

namespace Electricity_Bill_Generator
{

    public class Bill
    {
        public string id;
        public string customerId;
        public double units;
        public double amount;
        public string generatedOn;
    }

    public class Customer
    {
        public string id;
        public string name;
        public string createdAt;
        public string username;
        public string password;
    }
    public class BillGenerator
    {
        string currentUser = "";
        int billCount = 0;
        int customerCount = 0;
        double perUnitCharge = 10.0;
        public List<Bill> billsList = new List<Bill>();
        public List<Customer> customersList = new List<Customer>();
        private readonly AdminService adminService;

        BillGenerator(AdminService adminService) {
            this.adminService = adminService;
        }

        public void CreateBill(double units, string customerId) {
            Bill newBill = new Bill{
                id = $"B{billCount}",
                amount = adminService.perUnitCharge * units,
                customerId = currentUser,
                units = units,
                generatedOn = Convert.ToString(DateTime.Now),
            };
        }

        static void Main(string[] args)
        {
            AdminService adminService = new AdminService();
            BillGenerator billGen = new BillGenerator(adminService);

            while (true)
            {
                Console.WriteLine("____MENU____");
                Console.WriteLine("[1] Admin Login");
                Console.WriteLine("[2] New User? Create Account");
                Console.WriteLine("[3] User Login");
                Console.WriteLine("[4] Exit");

                Console.Write("Enter Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Admin Login
                        adminService.AdminLogin();
                        break;

                    case "2":
                        // Create Account

                        break;

                    case "3":
                        Console.WriteLine("---------ADMIN LOGIN---------");
                        Console.Write("Enter Unsername: ");
                        string username = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        string password = Console.ReadLine();

                        if (username == billGen.adminUsername && password == billGen.adminPassword) {
                            adminService.AdminMenu();
                        }
                        else {
                            Console.WriteLine("Invalid Credentials!");
                        }                           
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;                     
                }
            }
        }
    }
}
