using System;
using System.Linq;
using System.Collections.Generic;

namespace DatabaseFirstEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {

                // WHERE CLAUSE USING METHOD SYNTAX
                var custQuery1 = db.Customers.Where(c => c.City == "Berlin");

                //foreach (var el in custQuery1)
                //{
                //    Console.WriteLine(el.ContactName);
                //}

                // WHERE CLAUSE USING QUERY SYNTAX
                var custQuery2 =
                    from c in db.Customers
                    where c.City == "Berlin"
                    select c;


                // GROUPBY CLAUSE USING METHOD SYNTAX
                var orderProductsByUnitQuery =
                    db.Products.GroupBy(p => p.SupplierId).Select(newGroup => new
                    {
                        Supplier = newGroup.Key,
                        UnitsOnStock = newGroup.Sum(c => c.UnitsInStock)
                    });


                //foreach (var res in orderProductsByUnitQuery) Console.WriteLine($"Supplier {res.Supplier} - Units in stock {res.UnitsOnStock}");


                // ORDERBY CLAUSE USING METHOD SYNTAX
                var customerOrderedQuery = db.Products.OrderBy(p => p.QuantityPerUnit).ThenByDescending(c => c.ReorderLevel);

                //foreach (var res in customerOrderedQuery) Console.WriteLine($"{res.ProductName} - {res.QuantityPerUnit} - {res.ReorderLevel}");



                // CREATE a new customer from customer obj
                var newCustomer2 = new Customer
                {
                    CustomerId = "BLOGG",
                    ContactName = "Joe Bloggs",
                    CompanyName = "ToysRme"
                };


                // READ USING METHOD SYNTAX
                var readCustomerBLOGGQuery = db.Customers.Where(c => c.CustomerId == "BLOGG");

                foreach (var el in readCustomerBLOGGQuery) Console.WriteLine(el.ContactName);


                // DELETE USING METHOD SYNTAX
                var selectedCust = db.Customers.Where(c => c.CustomerId == "BLOGG").FirstOrDefault();

                //db.Customers.Remove(selectedCust);

                db.SaveChanges();

                // END OF LECTURE 





                // START OF LECTURE

                var nums = new List<int> { 3, 7, 1, 2, 8, 3, 0, 4, 5 };

                int allCount = nums.Count();

                // putting a method as a method arguement using linq
                int linqCountEven = nums.Count(isEven);
                int linqCountOdd = nums.Count(isOdd);
                //Console.WriteLine(linqCountEven);
                //Console.WriteLine(linqCountOdd);

                int countEven = 0;

                foreach (var e in nums)
                {
                    if (isEven(e) == true) countEven++;
                }

                //Console.WriteLine(countEven);
                //Console.WriteLine(" ");

                // using delegate
                var evenDCount = nums.Count(delegate (int n) { return n % 2 == 0; });

                // using lambda
                var evenLCount = nums.Count(n => n % 2 == 0);


                //Console.WriteLine("even d count");
                //Console.WriteLine(evenDCount);

                List<Person> people = new List<Person>
                {
                    new Person{Name = "Cathy", Age = 40 },
                    new Person{Name = "Martin", Age = 20 },
                    new Person{Name = "Nish", Age = 55 }

                };

                var youngPeeps = people.Count(isYoung);
                //Console.WriteLine(" ");
                //Console.WriteLine(youngPeeps);
                //Console.WriteLine(" ");


                var peopleCount = people.Count();
                var youngPeopleCount = people.Count(p => p.Age % 2 == 0);
                var totalAge = people.Sum(p => p.Age);
                var olderPeople = people.Sum(p => p.Age >= 30 ? p.Age : 0);


                //Console.WriteLine(" ");
                //Console.WriteLine(youngPeopleCount);
                //Console.WriteLine(totalAge);
                //Console.WriteLine(olderPeople);


                // LAMBDAS
                // referring to bottom
                //foreach (var c in db.Customers) 
                //{
                //    Console.WriteLine(aMethod(c));
                //}


                // USING LINQ TO GIVE SQL QUERIES
                //Console.WriteLine(db.ContextId);


                //var query = db.Customers.Where(c => c.CustomerId == "BONAP");
                //var selectCustomer = query.FirstOrDefault();

                //selectCustomer = db.Customers.Where(c => c.CustomerId == "ANTON").FirstOrDefault();
                //var selectedCustomer2 = db.Customers.Find("BERGS");


                //// DEFINITION 
                //IEnumerable<Customer> query1 = 
                //    from c in db.Customers 
                //    where c.City == "London" 
                //    select c;

                //// FORCED EXECUTION
                //foreach (var c in query1) 
                //{
                //    Console.WriteLine($"Customer {c.ToString()} lives in {c.City}");
                //}

                //// ANOTHER EXAMPLE OF FORCED EXECUTION
                //// using count() method on query
                //int numCustomersInLondon = query1.Count();
                ////Console.WriteLine(numCustomersInLondon);


                //// USING A LIST OF INTEGERS
                //// QUERY
                //var myList = new List<int> { 3, 6, 9 };

                //var numQuery =
                //    from number in myList
                //    select number;

                //// EXECUTION 
                //foreach (int number in numQuery) 
                //{
                //    Console.WriteLine(number);
                //}


                // QUERY SYNTAX
                // order by ID
                //IEnumerable<Customer> LondonCustomerQuery =
                //    from c in db.Customers
                //    where c.City == "London"
                //    orderby c
                //    select c;

                //foreach (var c in LondonCustomerQuery) 
                //{
                //    Console.WriteLine(c);
                //}

                //Console.WriteLine(" ");

                //    // METHOD SYNTAX
                //// order by ContactName
                //IEnumerable<Customer> query2 = db.Customers.Where(c => c.City == "London").OrderBy(c => c.ContactName);

                //foreach (var c in query2) 
                //{
                //    Console.WriteLine(c);
                //}


                // MORE LINQ STATEMENT

                //// LINQ with WHERE statement
                //var LondonBerlinQuery1 =
                //    from customer in db.Customers
                //    where customer.City == "London" || customer.City == "Berlin"
                //    select customer;

                //foreach (var customer in LondonBerlinQuery1)
                //{
                //    Console.WriteLine(customer);
                //}

                //// returns the data as a anonymous object
                //var LondonBerlinQuery2 =
                //    from customer in db.Customers
                //    where customer.City == "London" || customer.City == "Berlin"
                //    select new {Customer = customer.CompanyName, Country = customer.Country};

                //foreach (var customer in LondonBerlinQuery2) 
                //{
                //    Console.WriteLine(customer);
                //}


                //var orderProductsByUnit =
                //    from p in db.Products
                //    orderby p.UnitPrice descending
                //    select p;

                //foreach (var item in orderProductsByUnit) 
                //{
                //    Console.WriteLine($"{item.ProductId} - {item.UnitPrice}");
                //}


                //var groupProductsByUnitInStockQuery =
                //    from p in db.Products
                //    group p by p.SupplierId into newGroup
                //    orderby newGroup.Sum(c => c.UnitsInStock) descending

                //    select new
                //    {
                //        SupplierID = newGroup.Key,
                //        UnitsInStock = newGroup.Sum(c => c.UnitsInStock)
                //    };


                //foreach (var result in groupProductsByUnitInStockQuery) 
                //{
                //    Console.WriteLine(result);
                //}


                // USING SQL TO ACCOMPLISH THE SAME RESULT
                //SELECT SupplierID, SUM(UnitsInStock)
                //FROM[Products]  
                //GROUP BY SupplierID
                //ORDER BY SUM(UnitsInStock) DESC;




                // CRUD OPERATIONS //
                // CREATE 

                //var newCustomer = new Customer
                //{
                //    CustomerId = "BLOGG",
                //    ContactName = "Joe Bloggs",
                //    CompanyName = "ToysRme"
                //};

                //db.Customers.Add(newCustomer);

                // READ

                //foreach (var c in db.Customers) 
                //{
                //    Console.WriteLine($"Customer {c.ContactName} had ID {c.CustomerId} and lives in {c.City}");
                //    Console.WriteLine(c);
                //}

                // using lambda / method query
                //db.Customers.ToList().ForEach(c => Console.WriteLine(c));

                // UPDATE

                //var selectedCustomer = db.Customers.Where(c => c.CustomerId == "BLOGG").FirstOrDefault();
                //selectedCustomer.City = "New Paris";


                // DELETE

                //var deletedCustomer = db.Customers.Where(c => c.CustomerId == "BLOGG").FirstOrDefault();

                //db.Customers.Remove(deletedCustomer);

                // to save/update changes to the DataBase
                //db.SaveChanges();

                //var p = db.Customers.Find("BLOGG");


                //Console.WriteLine(bMethod(5));
                //Console.WriteLine(cMethod(5));



                // EXERCISE
                // query people from 'people' list whos age is more than 25


                // method syntax
                //Console.WriteLine("Method Syntax Result:");
                //IEnumerable<Person> queryBro = people.Where(c => c.Age > 25);

                ////foreach (var c in queryBro)
                ////{
                ////    Console.WriteLine($"{c.Name}, {c.Age}");
                ////}

                //// alternative method syntax 
                //people.Where(x => x.Age > 25).ToList().ForEach(x => Console.WriteLine(x.Name));

                ////// query syntax
                ////Console.WriteLine("Query Syntax Result:");
                //var olderQuery =
                //    from p in people
                //    where p.Age > 25
                //    select p;
                    
                //foreach (var el in olderQuery)
                //{
                //    Console.WriteLine($"{el.Name}, {el.Age}");
                //}





            }







        }


        public static bool isEven(int n)
        {
            return n % 2 == 0;
        }

        public static bool isOdd(int n)
        {
            return n % 2 == 1;
        }


        // LAMBA

        // input => output
        //   x  =>  x * x


        public static string aMethod(Customer c) => c.ContactName;
        public static int bMethod(int x) => x * x;
        public static int cMethod(int x)
        {
            return x * x;
        }



        public static bool isYoung(Person p)
        {
            return p.Age < 30;
        }


    }


    
    

    public class Person
    {
        public string Name {get; set;}
         public int Age {get; set;}
    }

    public partial class Customer
    {

        //public override string ToString()
        //{
        //    return $"{CustomerId} - {ContactName} - {City}";
        //}


        // these two are equivalent


        public override string ToString() => $"{CustomerId} - {ContactName} - {City}";


    }
}
