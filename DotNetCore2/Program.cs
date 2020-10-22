using System;
using System.Collections.Generic;

namespace DotNetCore2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listInt = new List<int>() { 2, 14, 4, 10, 78, 91, 5 };
            listInt.Sort();
            listInt.Reverse();

            foreach (var i in listInt)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            List<string> listSrt = new List<string>() { "B", "E", "C", "A", "D" };
            listSrt.Sort();
            listSrt.Reverse();
            foreach (var c in listSrt)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();

            Customer c1 = new Customer() { Id = 102, Name = "Mark", Email = "aaa@aaa.com" };
            Customer c2 = new Customer() { Id = 101, Name = "Lucy", Email = "bbb@aaa.com" };
            Customer c3 = new Customer() { Id = 103, Name = "John", Email = "ccc@aaa.com" };

            List<Customer> listCustomers = new List<Customer>(222);
            listCustomers.Add(c1);
            listCustomers.Add(c2);
            listCustomers.Add(c3);

            Span<Customer> sc = listCustomers.asS


            SortByName sbn = new SortByName();
            // listCustomers.Sort(sbn);

            // Comparison<Customer> cd = new Comparison<Customer>(CompareCustomers);
            // listCustomers.Sort(cd);

            // listCustomers
            //     .Sort( delegate (Customer x, Customer y) { return x.Email.CompareTo(y.Email); } );
            // listCustomers.Sort((Customer x, Customer y) => x.Email.CompareTo(y.Email));
            
            listCustomers.Sort((x, y) => x.Name.CompareTo(y.Name));
            
            //listCustomers.Reverse();
            foreach (var c in listCustomers)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine();
            
            Console.WriteLine("===============================================================");

            Console.WriteLine( listCustomers.TrueForAll(c => c.Id > 102) );

            var roc = listCustomers.AsReadOnly();

            Console.WriteLine( roc[0] );
            Console.WriteLine( listCustomers.Capacity );
            listCustomers.TrimExcess();
            Console.WriteLine(listCustomers.Capacity);

            Country ct1 = new Country() { Code = "CAN", Name = "Canada", Capital = "Ottawa" };
            Country ct2 = new Country() { Code = "USA", Name = "United States", Capital = "Washington" };
            Country ct3 = new Country() { Code = "GRB", Name = "United Kingdom", Capital = "London" };
            Country ct4 = new Country() { Code = "IND", Name = "India", Capital = "New Delhi" };

            List<Country> ctrList = new List<Country>();
            ctrList.Add(ct1);
            ctrList.Add(ct2);
            ctrList.Add(ct3);
            ctrList.Add(ct4);
            ctrList.Add(ct4);

            string code = "can".ToUpper();

            var res = ctrList.Find(c => c.Code == code);
            Console.WriteLine( res == null ? "not found" : res.ToString());

            Dictionary<string, Country> dict = new Dictionary<string, Country>();
            dict.Add(ct1.Code, ct1);
            dict.Add(ct2.Code, ct2);
            dict.Add(ct3.Code, ct3);

            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

            
            if( dict.ContainsKey(code) )
                Console.WriteLine(dict[code]);
            else
                Console.WriteLine("not found");


            Console.WriteLine("================================================================");

            // Queue = line = FIFO "first in - first out"
            // LIFO
            Queue<Customer> qc = new Queue<Customer>();

            qc.Enqueue(c1);
            qc.Enqueue(c2);
            qc.Enqueue(c3);

            var decCus = qc.Dequeue();
            // var decCus = qc.Peek();

            Console.WriteLine(" first = " + decCus);
            Console.WriteLine(" Contains = " + qc.Contains(c1));

            foreach (var c in qc)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine("================================================================");

            Stack<Customer> sc = new Stack<Customer>();
            sc.Push(c1); 
            sc.Push(c2);
            sc.Push(c3);

            // var pc = sc.Pop();
            var pc = sc.Peek();
            Console.WriteLine("has been popped" + pc);

            foreach (var c in sc)
            {
                Console.WriteLine(c);
            }

        }

        static int CompareCustomers(Customer x, Customer y)
        {
            return x.Email.CompareTo(y.Email);
        }
    }

    class Country
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public string Capital { set; get; }

        public override string ToString()
        {
            return Name + " - " + Capital;
        }
    }


    class SortByName : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }


    class Customer : IComparable<Customer>
    {
        private int _id;
        private string _name;
        private string _email;

        // 1
        // -1
        // 0
        public int CompareTo(Customer other)
        {
            /*
            if (this.Id > other.Id)
            {
                return 1;   
            }
            else if (this.Id < other.Id)
            {
                return -1;
            }
            */
            return this.Id.CompareTo(other.Id);
        }

        public Customer() { }

        public Customer(int id, string name, string email)
        {
            _id = id;
            _name = name;
            _email = email;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Email { get => _email; set => _email = value; }



        public void PrintId()
        {
            Console.WriteLine(Id);
        }
        public void PrintInfo()
        {
            Console.WriteLine(Id + ": " + Name + " " + Email);
        }
        public void PrintInfo3()
        {
            Console.WriteLine(Id + ": " + Name + " " + Email);
        }

        public override string ToString()
        {
            return Id + ": " + Name + " " + Email;
        }
    }
}
