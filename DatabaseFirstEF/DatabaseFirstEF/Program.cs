using System;
using System.Linq;

namespace DatabaseFirstEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext()) 
            {
                Console.WriteLine(db.ContextId);


                //foreach (var c in db.Customers) 
                //{
                //    Console.WriteLine($"Customer {c.ContactName} had ID {c.CustomerId} and lives in {c.City}");
                //    Console.WriteLine(c);
                //}

                //db.Customers.ToList().ForEach(c => Console.WriteLine(c));

                // ADD 

                //var newCustomer = new Customer
                //{
                //    CustomerId = "BLOGG",
                //    ContactName = "Joe Bloggs",
                //    CompanyName = "ToysRme"
                //};

                //db.Customers.Add(newCustomer);

                // UPDATE

                //var selectedCustomer = db.Customers.Where(c => c.CustomerId == "BLOGG").FirstOrDefault();
                //selectedCustomer.City = "New Paris";


                // DELETE

                var deletedCustomer = db.Customers.Where(c => c.CustomerId == "BLOGG").FirstOrDefault();

                db.Customers.Remove(deletedCustomer);

                db.SaveChanges();

                var p = db.Customers.Find("BLOGG");

            }
            


        }
    }


    public partial class Customer
    {

        public override string ToString()
        {
            return $"{CustomerId} - {ContactName} - {City}";
        }

    }
}
