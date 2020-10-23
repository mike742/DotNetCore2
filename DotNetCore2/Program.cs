using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"I do not like them 
In a house.
I do not like them
With a mouse.
I do not like them
Here or there.
I do not like them
Anywhere.
I do not like green eggs and ham.
I do not like them, Sam - I - am.";

            // Console.WriteLine(input);

            StringBuilder sb = new StringBuilder(input);

            sb.Replace("not", string.Empty);
            sb.Replace("  ", " ");

            // Console.WriteLine(sb.ToString());



            string cs = @"server=127.0.0.1;userid=root;password=;database=sql_classes";

            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select count(*) from Products";
                cmd.Connection = conn;

                conn.Open();

                var count = Int32.Parse( cmd.ExecuteScalar().ToString() );

                Console.WriteLine(count);


                // cmd.CommandText = @"insert into Products(title, price, qtyAvailable) values
                //                        ('Calculator', 5, 777')";

                //cmd.CommandText = @"update Products set qtyAvailable=1024 "; // where id=4
                
                cmd.CommandText = @"delete from Products where id=4"; // 
                
                count = Int32.Parse( cmd.ExecuteNonQuery().ToString() );

                Console.WriteLine(count + " row(s) inserted" );
            }
        }
    }
}
