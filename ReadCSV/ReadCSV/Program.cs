using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "C:\\temp\\Customers.txt";

            List<Customer> customers = new List<Customer>();

            Customer cust = new Customer();
            cust.FirstName = "Fred";
            cust.LastName = "Flintstone";
            cust.Email = "fred@gmail.com";
            cust.StreetAddress = "1 First Street";
            cust.City = "Bedrock";
            cust.State = "Idaho";
            cust.ZipCode = "55555";
            customers.Add(cust);

            for (int i = 0; i < 10; i++)
            {
                Customer c = new Customer();
                c.FirstName = string.Format("Customer {0}", i);
                c.LastName = string.Format("Customer {0}", i);
                c.Email = string.Format("{0}@gmail.com", i);
                c.StreetAddress = string.Format("{0}{0}{0}", i);
                c.StreetName = string.Format("{0} Street", i);
                c.City = string.Format("City {0}", i);
                c.State = string.Format("State {0}", i);
                c.ZipCode = string.Format("{0}{0}{0}{0}{1}", i, i + 1);
                customers.Add(c);
            }

            StreamWriter sw = new StreamWriter(fileName, true);

            foreach (Customer c in customers)
            {
                sw.Write(c.FirstName);
            }
            sw.Close();

            StreamReader sr = new StreamReader(fileName);
            if (File.Exists(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string temp = sr.ReadLine();
                    string[] values = temp.Split(',');

                    Customer c2 = new Customer();
                    c2.FirstName = values[0];
                    c2.LastName = values[1];
                    c2.Email = values[2];
                    c2.StreetAddress = values[3];
                    c2.StreetName = values[4];
                    c2.City = values[5];
                    c2.State = values[6];
                    c2.ZipCode = values[7];

                    customers.Add(c2);
                }
            }
            else
            {
                Console.WriteLine("File not found");
            }

            foreach (Customer c in customers)
            {
                Console.WriteLine("Customer Name {0} {1}", c.FirstName, c.LastName);
            }

            Console.ReadKey();
        }
    }
}
