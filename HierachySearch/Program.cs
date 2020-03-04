using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace HierachySearch
{
    class Program
    {
        private static XmlDocument hierachy = new XmlDocument();
        static void Main(string[] args)
        {
            hierachy.LoadXml("<Jason><Jody><Stanton></Stanton><Andries><Roscoe></Roscoe></Andries></Jody></Jason>");
            PrintHiearchy(hierachy.FirstChild, 0);
            Console.WriteLine("Enter a username to search for.");

            var search = Console.ReadLine();
            var res = FetchHierachy(search);
            Console.Clear();
            Console.WriteLine($"Searched for {search}, here are the Results:");
            if (res == null)
                Console.WriteLine("No results returned");
            else
                PrintHiearchy(res, 0);
            Console.ReadLine();
        }

        static void PrintHiearchy(XmlNode node, int level)
        {
            string outStr = string.Empty;
            for (int i = 0; i < level; i++)
                outStr += "--";
            Console.WriteLine($"{outStr} {node.Name}");
            level++;
            foreach (XmlNode cNode in node.ChildNodes)
                PrintHiearchy(cNode, level);
            level--;
        }

        static XmlNode FetchHierachy(string input)
        {
            var res = hierachy.SelectSingleNode($"//{input}");
            return res;
        }
    }
}
