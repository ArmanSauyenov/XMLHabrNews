using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //XmlDocument doc = new XmlDocument();
            //
            //XmlElement root = doc.CreateElement("User");
            //
            //XmlElement name = doc.CreateElement("Name");
            //name.InnerText = "Yevgeniy";
            //
            ////1
            //XmlAttribute atr = doc.CreateAttribute("Iin");
            //atr.InnerText = "880111300392";
            //name.Attributes.Append(atr);
            //
            ////2
            //name.SetAttribute("Iin", "880111300392");
            //
            //root.AppendChild(name);
            //
            //doc.AppendChild(root);
            //
            //doc.Save("UserYevgeniy.xml");

            List<HabrNews> habrNews = new List<HabrNews>();
            XmlDocument doc = new XmlDocument();
            doc.Load("https://habrahabr.ru/rss/interesting/");

            var rootElement = doc.DocumentElement;

            foreach (XmlNode item in rootElement.ChildNodes)
            {
                Console.WriteLine(item.Name);
                foreach (XmlNode ch in item.ChildNodes)
                {
                    Console.WriteLine(ch.Name);
                    if (ch.Name == "item")
                    {
                        HabrNews hNews = new HabrNews();
                        foreach (XmlNode news in ch.ChildNodes)
                        {
                            if (news.Name == "title")
                            {
                                hNews.title = news.InnerText;
                            }
                            else if (news.Name == "link")
                            {
                                hNews.link = news.InnerText;
                            }
                            Console.WriteLine("-->"+news.Name);
                            Console.WriteLine("-->" + news.InnerText);
                        }
                    }
                }
            }

            foreach (var item in habrNews)
            {
                Console.WriteLine(item.title);
                Console.WriteLine(item.link);
                Console.WriteLine("");
            }
            return;

        }
    }
}
