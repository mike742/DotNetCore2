using System;

namespace DotNetCore2
{
    class Program
    {
        static void Main(string[] args)
        {
            // ConsoleKeyInfo cki = Console.ReadKey();

            /*
            if (cki.Key == ConsoleKey.Enter)
            {
                Console.WriteLine("Enter key has been pressed");
            }
            if (cki.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Esc key has been pressed");
            }
            */

            // Reflaction
            // Type T = Type.GetType("DotNetCore2.Customer");
            Type T = typeof(DotNetCore2.Customer);
            // Type T = typeof(System.Object);

            var propsInfo = T.GetProperties();

            foreach (var p in propsInfo)
            {
                Console.WriteLine(p.Name + "  " + p.PropertyType.Name);
            }

            Console.WriteLine("---------------------------------------------------------");

            var methodsInfo = T.GetMethods();

            foreach (var m in methodsInfo)
            {
                Console.WriteLine(m.Name + " returns " + m.ReturnType.Name);
            }

            Console.WriteLine("---------------------------------------------------------");

            var fieldsInfo = T.GetFields();

            foreach (var f in fieldsInfo)
            {
                Console.WriteLine(f.Name + " " + f.FieldType + " " + f.IsStatic);
            }

            Console.WriteLine("---------------------------------------------------------");

            var ctorsInfo = T.GetConstructors();

            foreach (var ct in ctorsInfo)
            {
                Console.WriteLine( ct );
            }


            Console.WriteLine("---------------------------------------------------------");

            Customer c = new Customer(101, "John", "ddd@ddd.com");

            Console.WriteLine(c.ToString());
        }
    }

    class Customer
    {
        private int _id;
        private string _name;
        private string _email;

        internal protected static string email2;
        public string email3;

        public Customer()
        {
        }

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
