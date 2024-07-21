using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using HtmlAgilityPack;

namespace HTTPClient_APP
{
    class Programm
    {
        static async Task Main(string[] args)
        {
            string urlSteam = "https://store.steampowered.com/search/?hidef2p=1&filter=topsellers&ndl=1";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            var response = await client.GetStringAsync(urlSteam);
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(response);

            var topSellers = htmlDoc.DocumentNode.SelectSingleNode("//div[@data-panel]");
            for (int i = 0; i < 10; i++)
            {
                var gameName = topSellers.SelectNodes("//span[@class='title']")[i].InnerText;
                var gamePrice = topSellers.SelectNodes("//div[@class='discount_final_price']")[i].InnerText;
                Console.WriteLine($"Место: {i + 1}. {gameName}. Цена: {gamePrice}");
            }
        }

    }
}