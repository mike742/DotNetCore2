using System;
using System.Linq;
using System.Xml.Linq;
using static System.Console;
//using ;

namespace DotNetCore2
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"Students.xml";

            var list = XDocument.Load(file)
                .Element("Students")
                .Elements("Student")
                // .Descendants("Student")
                .Where(s => (int)s.Element("TotalMarks") > 1010)
                .Select(s => s.Attribute("Id").Value);

            list.ToList().ForEach(s => WriteLine(s));

            var s = Cripto.Cripto.GenerateSecretString();

            WriteLine(s);

            WriteLine(Cripto.Cripto.SaltAndHash("Pa$$w0rd"));
            WriteLine(Cripto.Cripto.toMD5("Pa$$w0rd"));

            var xml = XDocument.Load(file);

            xml.Element("Students").AddFirst(
                    new XElement("Student", 
                        new XAttribute("Id", 100),
                        new XElement("Name", "Todd"),
                        new XElement("TotalMarks", 5555)
                    )
                );


            xml.Element("Students").Elements("Student")
                .Where(s => s.Attribute("Id").Value == 103.ToString())
                .FirstOrDefault()
                .AddBeforeSelf(
                     new XElement("Student",
                        new XAttribute("Id", 102.5),
                        new XElement("Name", "John"),
                        new XElement("TotalMarks", 123456)
                    )
                );

            xml.Element("Students").Elements("Student")
                .Where(s => s.Attribute("Id").Value == 103.ToString())
                .FirstOrDefault()
                .SetElementValue("TotalMarks", 987654321);

            xml.Root.Elements()
                // .Where(s => s.Attribute("Id").Value == 103.ToString())
                .Remove();


            xml.Save(file);
        }
    }
}
