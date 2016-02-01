using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

/*
Jacob Stroop
CIS353 - Assignment 7
1/31/16
*/

namespace Assignment7_Stroop
{
    class Assignment7_Stroop
    {
        static void Main(string[] args)
        {
            // instantiate array of 5 invoices
            Invoice[] invoices = new Invoice[5];

            // loop through array to fill
            for (int i = 0; i < invoices.Length; i++)
            {
                // declare variables to be properties
                int id;
                double balance;
                int dueDate;

                // tracks loop
                Console.WriteLine("Invoice {0} of {1}", i+1, invoices.Length);

                // get new id input
                Console.Write("Enter id: ");
                // if input cannot be parsed to int, assign default
                if(!int.TryParse(Console.ReadLine(), out id))
                {
                    id = 999;
                }

                // get new balance input
                Console.Write("Enter balance: ");
                if (!double.TryParse(Console.ReadLine(), out balance))
                {
                    // if input cannot be parsed to double, assign default
                    balance = 0;
                }

                // get new due date input
                Console.Write("Enter due date: ");
                if (!int.TryParse(Console.ReadLine(), out dueDate))
                {
                    // if input cannot be parsed to int, assign default
                    dueDate = 1;
                }

                Console.WriteLine();

                // try/catch block for Invoice instantiation
                // catches arguement exception for values out of
                // acceptable range, displays error to user,
                // and assigns default values to object, instead
                try
                {
                    invoices[i] = new Invoice(id, balance, dueDate);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    invoices[i] = new Invoice(999, 0, 1);
                    Console.WriteLine("Default Values Assigned.");
                    Console.WriteLine();
                }

            } // end for loop

            // print the array of invoices
            Console.WriteLine("Entered Invoices");         
            foreach (Invoice invoice in invoices)
            {
                Console.WriteLine(invoice.ToString());
                Console.WriteLine();
            }

            // exit program
            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }
    }

    // enum establishes range constants
    enum Ranges
    {
        DueDateLow = 1,
        DueDateHigh = 31,
        IDLow = 100,
        IDHigh = 999
    }

    class Invoice
    {
        // autoproperties with read-only accessors
        public int ID { get; }
        public double Balance { get; }
        public int DueDate { get; }

        // constructor requires 3 arguments
        public Invoice(int id, double bal, int dueDate)
        {
            // test id range
            TestRange(Ranges.IDLow, Ranges.IDHigh, id);
            // test due date range
            TestRange(Ranges.DueDateLow, Ranges.DueDateHigh, dueDate);

            // assign properties
            ID = id;
            Balance = bal;
            DueDate = dueDate;
        }

        // method checks if target value falls within range
        // if argument is out of range, throw argument exception, caught in main
        protected void TestRange(Ranges floor, Ranges ceiling, int target)
        {
            if (target < (int)floor || target > (int)ceiling)
                throw new ArgumentException(string.Format("Warning: {0} is not a valid entry.", target));
        }

        // new to string method to display Invoice information
        public new string ToString()
        {
            return string.Format("ID: {0}\nBalance: {1}\nDue Date:{2}", ID, Balance, DueDate);
        }
    }
}
