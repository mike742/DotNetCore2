using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DotNetCore2
{
    class Student
    {
        private int _id;
        private string _name;
        private string _email;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Email { get => _email; set => _email = value; }
    }

    class Employee
    {
        private int _id;
        private string _name;
        private string _email;
        private float _salary;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Email { get => _email; set => _email = value; }
        public float Salary { get => _salary; set => _salary = value; }
    }

    class Program
    {

        static void PrintInfo(Tuple<int, string, string> obj)
        {
            Console.WriteLine( obj.Item1 + " - " + obj.Item2 + ": " + obj.Item3 );
        }
        /*
        static void PrintInfo(int id, string name, string email, float salary, 
            string dob, string address, string KPIcalculation_classLibrary_Helper_shortTitleForUser, string gender)
        {
            Console.WriteLine(id + " - " + name + ": " + email);
        }
        */
        static void Main(string[] args)
        {
            PrintInfo(Tuple.Create( 101, "Mark", "mark@gmail.com" ));

            Student s1 = new Student() { Id = 102, Name = "John", Email = "" };
            Employee e1 = new Employee() { Id = 103, Name = "Mike", Email = "mike@gmail.com" };

            PrintInfo(Tuple.Create(s1.Id, s1.Name, s1.Email));

            string cs = 
                @"server=localhost;userid=root;password=;database=sql_classes";

            // MySqlConnection conn = new MySqlConnection(cs);
            // conn.ConnectionString = cs;

            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                conn.Open();
                Console.WriteLine(conn.ServerVersion);

                string stm = "select version()";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                var res = cmd.ExecuteScalar(); //.ToString();

                Console.WriteLine(res);

                stm = "select * from people";
                cmd = new MySqlCommand(stm, conn);

                MySqlDataReader rdr = cmd.ExecuteReader();
                
                // ADO.net : CRUD
                while (rdr.Read())
                {
                    Console.WriteLine( "{0} \t {1}", rdr.GetString(0), rdr.GetString(1));
                }

            }

            /*
            try
            {
                conn.Open();
                Console.WriteLine(conn.ServerVersion);

                string stm = "select version()";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                string res = cmd.ExecuteScalar().ToString();

                Console.WriteLine(res);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            */
        }
    }
}
