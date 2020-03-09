using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Wczytywanie pliku
            string FilePath = @"C:\Users\s18731\Desktop\APBD_CW2-master\ConsoleApp1\ConsoleApp1\Data\dane.csv";

            FileInfo f = new FileInfo(FilePath);
            using (StreamReader stream = new StreamReader(f.OpenRead()))
            {
                string line = "";
                while ((line = stream.ReadLine()) != null)
                {
                    string[] studentWiersz = line.Split(',');
                    Console.WriteLine(line);
                }
            }
            FileStream witer = new FileStream(@"data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Modele.Student>), 
                                        new XmlRootAttribute("uczelnia"));
            var list = new List<Modele.Student>();
            var st = new Modele.Student
            {
                Imie = "Jan",
                Nazwisko = "Kowalski",
                Email = "kowalski@email.pl"
            };
            list.Add(st);
            serializer.Serialize(witer, list);
        }
    }
}
