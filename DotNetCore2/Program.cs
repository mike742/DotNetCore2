using System;
using Cripto;
using MySql.Data.MySqlClient;

namespace DotNetCore2
{
    class Program
    {
        static void Main(string[] args)
        {

            string str = "123456";
            Console.WriteLine(Cripto.Cripto.toMD5(str));

            string cs =
                @"server=127.0.0.1;userid=root;password=;database=sql_classes";

            using (var conn = new MySqlConnection(cs))
            {
                var cmd = new MySqlCommand("SELECT username, password from Passwords", conn);

                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    // Console.WriteLine( rdr.GetString(0) + " " + rdr.GetString(1));

                    Console.WriteLine(
                            Cripto.Cripto.toMD5(str) == rdr.GetString(1)
                        );
                }

                Console.WriteLine("Salted hashes: " + Cripto.Cripto.SaltAndHash(str));

                //Console.WriteLine(Cripto.Cripto.GenerateSecretString());
                
                
                Console.WriteLine( (int)'a' );
                Console.WriteLine( (int)'0');
                Console.WriteLine( (int)'z');

                string ccn = "1234-5678-9012-3456";
                string sk = Cripto.Cripto.GenerateSecretString();

                string encCcn = Cripto.Cripto.EncryptString(sk, ccn);

                Console.WriteLine(encCcn);

                Console.WriteLine( Cripto.Cripto.DecryptString(sk, encCcn) );


            }
        }
    }
}
