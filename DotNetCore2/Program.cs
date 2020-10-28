using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;
using System.Security.Cryptography;

namespace DotNetCore2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path2 = "Menu2.xml";
            if (File.Exists("Menu2.xml"))
            {
                Console.WriteLine("The file exists!");
            }

            string path = @"c:\programs\file.txt";

            Console.WriteLine(Path.GetFullPath(path2));
            Console.WriteLine(Path.GetFileName(path));
            Console.WriteLine(Path.GetFileNameWithoutExtension(path) + ".xml");
            Console.WriteLine(Path.GetExtension(path));

            Console.WriteLine("==============================================");

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // IEnumerable<int> res = numbers.Where(n => n % 2 == 0).Select(n => n);

            var res = numbers.Where(n => n % 2 == 0);//.Select(n => n);

            var res2 = from i in numbers
                       where i % 2 == 0
                       select i;

            var list1 = Student.LoadData().Where(s => s.TotalMarks > 1010)
                                .Select(s => s.Id + " " + s.Name + " " + s.TotalMarks);

            var list2 = from s in Student.LoadData()
                        where s.TotalMarks > 1010
                        select s;

            foreach (var s in res)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine( "=======================================" );
            Console.WriteLine( numbers.Max() );
            Console.WriteLine( numbers.Min() );

            Console.WriteLine( numbers.Where(n => n % 2 == 0).Min() );
            Console.WriteLine( numbers.Where(n => n % 2 == 0).Max() );

            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Average());

            string[] countries = { "Canada", "Usa", "Uk", "India", "Ukraine" };
            Console.WriteLine(countries.Min( c => c.Length ));
            Console.WriteLine(countries.Max( c => c.Length));

            var ls = new List<Shape>
            {
                new Circle { Color = "Red", R = 2.5},
                new Rectangle { Color = "Blue", H = 20, W = 10 },
                new Circle { Color = "Green", R = 8},
                new Circle { Color = "Grey", R = 12.3},
                new Rectangle { Color = "Blue", H = 45, W = 18 }
            };

            foreach (var s in ls)
            {
                Console.WriteLine( s.GetType().Name + " " +  s.Color + " " + s.Area);
            }

            var xs = new XmlSerializer( typeof(List<Shape>) );
            string pathXML = "Shapes.xml";

            using (FileStream fs = File.Create(pathXML))
            {
                xs.Serialize(fs, ls);
            }


            using (StringReader sr = new StringReader( File.ReadAllText( pathXML ) ))
            {
                var res22 = xs.Deserialize(sr) as List<Shape>;

                foreach (var s in res22)
                {
                    Console.WriteLine(s.Color + " " + s.Area);
                }
            }
        }
    }

    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Rectangle))]
    public class Shape
    {
        public string Color { get; set; }
        public virtual double Area { get; }
    }

    public class Circle : Shape
    {
        public double R { set; get; }
        public override double Area => Math.PI * Math.Pow(R, 2);
    }

    public class Rectangle : Shape
    {
        public double H { set; get; }
        public double W { set; get; }
        public override double Area => H * W;
    }




    public class Item
    {
        public string id { set; get; }
        public string label { set; get; }
    }

    public class Menu
    {
        public string header { set; get; }
        public List<Item> items { set; get; }
    }

    public class Top
    {
        public Menu menu { set; get; }
    }
}
