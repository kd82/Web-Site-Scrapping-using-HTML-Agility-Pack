using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            var webGet = new HtmlWeb();
            
            for(int k=1;k<15;k++)
            {
                
            var doc = webGet.Load("http://www.carsoup.com/for-sale/used/Sedan/?radius=50&pagenum="+k+"");//To repeat the code for 15 web pages
            HtmlNodeCollection ourNode = doc.DocumentNode.SelectNodes("//div[@class='grid-75']//div[@id='vehiclelisting']");
            if (ourNode != null)
            {
                List<string> name = new List<string>();
                List<string> prices = new List<string>();
                List<string> locations = new List<String>();
                List<string> desc = new List<String>();
                for (int i = 0; i < ourNode.Count; i++)
                {
                    HtmlNode price = ourNode[i].SelectSingleNode(".//div[@class='grid-25 vehicle-info']//span[@class='price']");
                    prices.Add((price.InnerText).ToString());
                    HtmlNode Name = ourNode[i].SelectSingleNode(".//div[@class='grid-75']//h2[@class='vehicleMakeModel']//span[@itemprop='name']");
                    name.Add((Name.InnerText).ToString());
                    HtmlNode place = ourNode[i].SelectSingleNode(".//div[@class='grid-25 vehicle-info']//span[@itemprop='address']");
                    locations.Add((place.InnerText).ToString());
                    HtmlNode Dates = ourNode[i].SelectSingleNode(".//div[@class='grid-75']//div[@class='vehicleWhyBuy']");
                    desc.Add((Dates.InnerText).ToString());
                }

                for (int i = 0; i < desc.Count; i++)
                {
                    Console.WriteLine("Name  " + name[i].ToString());
                    Console.WriteLine("Price  " + prices[i].ToString());
                    Console.WriteLine("Location  " + locations[i].ToString());
                    Console.WriteLine("Description  " + desc[i].ToString());
                }
                k++;
            }
           
            }
                Console.ReadLine();
        }
    }
}
