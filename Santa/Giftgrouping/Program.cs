using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Giftgrouping
{
    class Program
    {
        private static double longitudeAmericaEurope = -22;
        private static double northSouthAmarica = 13;
        private static double europaAfrica = 37.5;
        private static double longitueEuropeAsia = 51;
        private static double asiaAustralia = 8;
        private static double southPolar = -60;

        static void Main(string[] args)
        {
            var file = @"C:\Users\linri\Desktop\Santa\gifts.csv";
            var gifts = GetGifts(file);

            var southUnderPolar = South(gifts);
                      
            var giftsForNorthAmerica = GetGiftsForNorthAmerica(gifts);
            var forSouthAmerica = GetGiftsForSouthAmerica(gifts);
            var giftsForEurope = Europa(gifts);
            var africa = Aftrica(gifts);
            var giftsForAsia = Asia(gifts);
            var australia = Australia(gifts);

            Plot(australia);

            Console.WriteLine(gifts.Count);
            Console.WriteLine(
                giftsForNorthAmerica.Count
                + forSouthAmerica.Count
                + giftsForEurope.Count
                + africa.Count
                + giftsForAsia.Count
                + australia.Count
                + southUnderPolar.Count);
            
            Console.ReadLine();
        }
              
        private static void Plot(List<Gift> gifts)
        {
            var subset = gifts.Take(100);
            foreach (var gift in subset)
            {
                Console.WriteLine("{0},{1}", gift.Latitude, gift.Longitude);
            }
        }

        private static List<Gift> South(List<Gift> gifts)
        {
            return gifts
                .Where(g => g.Latitude < - 60)
                .ToList();
        }

        private static List<Gift> Asia(List<Gift> gifts)
        {
            return AsiaAndAustralia(gifts)
                .Where(g => g.Latitude > asiaAustralia)
                .ToList();
        }

        private static List<Gift> Australia(List<Gift> gifts)
        {
            return AsiaAndAustralia(gifts)
                .Where(g => g.Latitude < asiaAustralia)
                .Where(g => g.Latitude > southPolar)
                .ToList();
        }

        private static IEnumerable<Gift> AsiaAndAustralia(List<Gift> gifts)
        {
            return gifts
                .Where(g => g.Longitude > longitueEuropeAsia);
        }

        private static List<Gift> Aftrica(List<Gift> gifts)
        {
            return EuropaAfrica(gifts)
                .Where(g => g.Latitude < europaAfrica)
                .Where(g => g.Latitude > southPolar)
                .ToList();
        }

        private static List<Gift> Europa(List<Gift> gifts)
        {
            return EuropaAfrica(gifts)
                .Where(g => g.Latitude > europaAfrica)
                .ToList();
        }

        private static IEnumerable<Gift> EuropaAfrica(List<Gift> gifts)
        {
            return gifts
                .Where(g => g.Longitude > longitudeAmericaEurope)
                .Where(g => g.Longitude < longitueEuropeAsia);
        }

        private static List<Gift> GetGiftsForNorthAmerica(List<Gift> gifts)
        {
            return GetAmerica(gifts)
                .Where(g => g.Latitude > northSouthAmarica)
                .ToList();
        }

        private static List<Gift> GetGiftsForSouthAmerica(List<Gift> gifts)
        {
            return GetAmerica(gifts)
                .Where(g => g.Latitude < northSouthAmarica)
                .Where(g => g.Latitude > - 60)
                .ToList();
        }

        private static IEnumerable<Gift> GetAmerica(List<Gift> gifts)
        {
            return gifts
                .Where(g => g.Longitude < longitudeAmericaEurope);
        }

        private static List<Gift> GetGifts(string file)
        {
            var reader = new StreamReader(File.OpenRead(file));

            var gifts = new List<Gift>();

            var header = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                var lineList = new Gift(
                    int.Parse(values[0]),
                    double.Parse(values[3]),
                    double.Parse(values[1]),
                    double.Parse(values[2]));

                gifts.Add(lineList);
            }

            return gifts;
        }
    }
}
