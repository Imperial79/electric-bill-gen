using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electricity_Bill_Generator
{

    public class Bill
    {
        public int id = 0;
        public string customerName = "";
        public double units = 0;
        public double amount = 0;
        public string date = "";
    }
    public class BillGenerator
    {
        string adminUsername = "admin";
        string adminPassword = "1234";
        int counter = 0;
        double perUnitCharge = 10.0;
        List<Bill> billList = new List<Bill>();

        double CalculateBill(double units) {
            return units * perUnitCharge;
        }

        void NewBill(string customerName, double units) {
             Bill newBill = new Bill {
                id = counter++,
                customerName = customerName,
                units = units,
                amount = CalculateBill(units),
                date = Convert.ToString(DateTime.Now)
            };
            billList.Add(newBill);

            Console.WriteLine($"-----------Bill Generated {newBill.date}----------");
            Console.WriteLine($"Bill ID: {newBill.id}");
            Console.WriteLine($"Name: {newBill.customerName}");
            Console.WriteLine($"Units Consumed: {newBill.units}");
            Console.WriteLine($"Amount: {newBill.amount}");
        }

        void AdminModule() {
            while (true) {
                Console.WriteLine("_________ADMIN CORNER_________");
                Console.WriteLine("1. Update Per Unit Charge.");
                Console.WriteLine("2. Logout.");
                Console.Write("Enter Choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("_________ Update Per Unit Charge ________");
                        double pervCharge = perUnitCharge;
                        Console.Write("Enter Charge/Unit: INR ");
                        perUnitCharge = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"Successfully updated Charge/Unit from INR {pervCharge} to INR {perUnitCharge}!");
                        break;

                    case "2":
                        return;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            BillGenerator billGen = new BillGenerator();

            while (true)
            {
                Console.WriteLine("--------MENU---------");
                Console.WriteLine("1. Generate New Bill.");
                Console.WriteLine("2. View Previous Bills.");
                Console.WriteLine("3. Admin Login");
                Console.WriteLine("4. Exit.");

                Console.Write("Enter Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Fullname: ");
                        string name = Console.ReadLine(); 
                        Console.Write("Enter Units Consumed: ");
                        double units = Convert.ToDouble(Console.ReadLine());
                        billGen.NewBill(name, units);
                        break;

                    case "2":
                        Console.WriteLine("New Bill");
                        break;

                    case "3":
                        Console.WriteLine("---------ADMIN LOGIN---------");
                        Console.Write("Enter Unsername: ");
                        string username = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        string password = Console.ReadLine();

                        if (username == billGen.adminUsername && password == billGen.adminPassword) {
                            billGen.AdminModule();
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
