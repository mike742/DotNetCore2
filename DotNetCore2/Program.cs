using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;

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
            string path = @"d:\temp\text.json";
            string jsonString = File.ReadAllText(path);
            var res2 = JsonSerializer.Deserialize<Top>(jsonString);
            
            Console.WriteLine("=============================================================");
            /*
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
            */

            /*
            XDocument xmlDoc = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    // new XComment("Creating xml file using linq to xml"),
                    new XElement("Students",
                        new XElement("Student", 
                                new XAttribute("Id", 101),
                                new XElement("Name", "Lucy"),
                                new XElement("TotalMarks", 850)
                            ),
                        new XElement("Student", 
                                new XAttribute("Id", 102),
                                new XElement("Name", "Mark"),
                                new XElement("TotalMarks", 1020)
                            ),
                        new XElement("Student",
                                new XAttribute("Id", 103),
                                new XElement("Name", "Rosy"),
                                new XElement("TotalMarks", 1015)
                            )
                    )
                );
            */
            //XDocument xmlDoc = new XDocument(
            //       new XDeclaration("1.0", "utf-8", "yes"),
            //       // new XComment("Creating xml file using linq to xml"),
            //       new XElement("Students",
            //           Student.LoadData()
            //                .Select(s => new XElement("Student",
            //                    new XAttribute("Id", s.Id),
            //                    new XElement("Name", s.Name),
            //                    new XElement("TotalMarks", s.TotalMarks)
            //                ))
            //       )
            //   ); xmlDoc.Save(@"d:\temp\Example.xml");

            XDocument xmlDoc = new XDocument(
                   new XElement("menu",
                        new XElement("header", "Adobe " + res2.menu.header),
                        res2.menu.items
                            .Select(i => i != null ? 
                                new XElement("item", 
                                    new XAttribute("action", i.id),
                                    new XAttribute("id", i.id),
                                        i.label != null ?
                                            i.label : i.id
                                ) :
                                new XElement("separator")
                            )
                   )
                   
               );
            // <input value="" />
            xmlDoc.Save(@"d:\temp\Menu.xml");

            Console.WriteLine(ToXml(res2));
        }

        static string ToXml<T>(T obj)
        {
            using (StringWriter sw = new StringWriter(new StringBuilder()))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(sw, obj);

                return sw.ToString();
            }
        }

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
