using System;
using System.Collections.Generic;
using DioBank.Domain.Accounts;
using DioBank.Domain.Enums;

namespace DioBank.Application {
    class Program {
        static List<Account> accountsList = new List<Account>();
        public static void Main(string[] args) {

            Console.WriteLine();
            Console.WriteLine("**********************************");
            Console.WriteLine("*\tWelcome to DioBank\t *");
            Console.WriteLine("**********************************");
            Console.WriteLine();

            string option = GetMenuOption();

            while (option != "X") {
                switch (option) {
                    case "1":
                        ListAccounts();
                        break;
                    case "2":
                        InsertNewAccount();
                        break;
                    case "3":
                        Deposit();
                        break;
                    case "4":
                        Withdrawal();
                        break;
                    case "5":
                        Transfer();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Console.WriteLine();
                Console.WriteLine("========================================");
                option = GetMenuOption();
            }
            Console.WriteLine("Thank you and come back soon");
            Console.WriteLine();

        }
        static string GetMenuOption() {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - List Accounts");
            Console.WriteLine("2 - Insert New Account");
            Console.WriteLine("3 - Deposit");
            Console.WriteLine("4 - Withdrawal");
            Console.WriteLine("5 - Transfer");
            Console.WriteLine("C - Clear");
            Console.WriteLine("X - Leave");
            string option = Console.ReadLine().ToUpper();
            Console.WriteLine("========================================");
            Console.WriteLine();
            return option;

        }

        private static void ListAccounts() {
            if (accountsList.Count <= 0) Console.WriteLine("There are no accounts");
            foreach (var account in accountsList) {
                Console.WriteLine(account);
                Console.WriteLine();
            }
        }
        private static void InsertNewAccount() {

            Console.WriteLine("1 - Savings Account");
            Console.WriteLine("2 - Checking Account");
            int type = int.Parse(Console.ReadLine());
            while (type != 1 && type != 2) {
                Console.WriteLine("Wrong type. Please try again:");
                Console.WriteLine("1 - Savings Account");
                Console.WriteLine("2 - Checking Account");
                type = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter holder name:");
            string holder = Console.ReadLine();

            Console.WriteLine("Enter number account:");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose type person:");
            Console.WriteLine("\t1 - Natural person");
            Console.WriteLine("\t2 - Legal person");
            int typePerson = int.Parse(Console.ReadLine());

            if (type == 1) {
                accountsList.Add(new SavingsAccount(holder: holder, number: number, typePerson: (TypePerson)typePerson));

            } else if (type == 2) {
                Console.WriteLine("Enter account fee (%):");
                double fee = double.Parse(Console.ReadLine());
                accountsList.Add(new CheckingAccount(holder: holder, number: number, typePerson: (TypePerson)typePerson, fee: fee));
            }

        }

        private static void Transfer() {

        }

        private static void Withdrawal() {

        }

        private static void Deposit() {

        }



    }
}
