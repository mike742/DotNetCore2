using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace DotNetCore2
{
    class Program
    {
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        static void Main(string[] args)
        {
            
            string path = @"d:\temp\MyTest.txt";
            /*
            //Create the file.
            using (FileStream fs = File.Create(path))
            {
                AddText(fs, "Hello C# Files");
                
            }
            */
            File.AppendAllText(path, "Hello Files\n");
            File.AppendAllText(path, "Hello Files2\n");

            /*
            using (FileStream fs = File.OpenRead(path))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }
            }
            */

            Console.WriteLine(File.ReadAllText(path));

            if (File.Exists(path))
            {
                File.Delete(path);
            }



            string jsonString = string.Empty;

            jsonString = JsonSerializer.Serialize(Student.LoadData());
            // jsonString = JsonSerializer
            //     .Serialize(new Student() { Id = 777, Name = "John", TotalMarks = 222 });
            //                             // {"Id":777,"Name":"John","TotalMarks":222}
            Console.WriteLine(jsonString);

            path = @"d:\temp\json.txt";
            File.AppendAllText(path, jsonString);


            var res = JsonSerializer.Deserialize<List<Student>>(jsonString);

            Console.WriteLine("=============================================================");

            foreach (var s in res)
            {
                Console.WriteLine(s.Id + " " + s.Name + " " + s.TotalMarks);
            }

            Console.WriteLine("=============================================================");

            path = @"d:\temp\text.json";
            // C:\Users\mykha\source\repos\DotNetCore2\DotNetCore2

            jsonString = File.ReadAllText(path);

            Console.WriteLine(jsonString);

            var res2 = JsonSerializer.Deserialize<Top>(jsonString);
            
            Console.WriteLine("=============================================================");

            Console.WriteLine(res2.menu.header);
            foreach (var i in res2.menu.items)
            {
                if (i != null)
                {
                    Console.Write("\t id = " + i.id);

                    if (i.label != null)
                        Console.Write("; label = " + i.label);

                    Console.WriteLine();
                }
                else
                    Console.WriteLine("\t null");
            }
        }
    }

    class Item
    {
        public string id { set; get; }
        public string label { set; get; }
    }

    class Menu
    {
        public string header { set; get; }
        public List<Item> items { set; get; }
    }

    class Top
    {
        public Menu menu { set; get; }
    }
}
