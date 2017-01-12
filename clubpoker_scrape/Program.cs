using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clubpoker_scrape
{
    class Program
    {
        static void Main(string[] args)
        {

            var w = new HtmlWeb();
            var rootDomain = "http://en.clubpoker.net";
            var d = w.Load($"{rootDomain}/poker-dictionary");
            var selectedDiv = d.DocumentNode.SelectNodes("//div[contains(@class,'pageParagraph paragraphNormal')]");
            var writer = new StreamWriter("C:\\temp\\clubpoker.txt");  // set to whatever you
            writer.AutoFlush = true;
            var line = "";
            var anchors = new List<HtmlNode>();

            foreach (var n in selectedDiv)
            {
                var a = n.SelectNodes("//a");
                foreach (var anchor in a)
                {
                    var c = anchor.Attributes["href"];

                    if (c != null)
                    {
                        if (c.Value.Contains("/definition"))
                        {
                            if (!anchors.Contains(anchor))
                            {
                                Console.WriteLine(c.Value);
                                anchors.Add(anchor);
                            }
                        }
                    }
                }
            }

            var total = anchors.Count;
            Console.WriteLine($"About to hit {total} URLs...");
            var remaining = total;

            foreach (var anchor in anchors)
            {
                line = anchor.InnerText + "\t";
                var url = $"{rootDomain}{anchor.Attributes["href"].Value}";
                Console.WriteLine($"Loading {url}");
                var w2 = new HtmlWeb();
                var d2 = w2.Load(url);
                var h2 = d2.DocumentNode.SelectSingleNode("//h2[contains(@class,'dictionaryDefinitionContent')]");
                if (h2 != null)
                {
                    var p = h2.SelectSingleNode("//p");
                    if (p != null)
                    {
                        line += p.InnerText;
                        writer.WriteLine(line);
                        Console.WriteLine(p.InnerText);
                    }
                }
                remaining--;
                Console.WriteLine($"{remaining} remaining");
                // Take a breather... 
                Thread.Sleep(500);
            }

            writer.Close();

            Console.WriteLine("Finished... press any key to quit");
            
            Console.ReadKey();
        }
    }
}
