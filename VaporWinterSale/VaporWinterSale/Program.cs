using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace VaporWinterSale
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] gamesAndDlcs = Console.ReadLine().Split(", ");
            char[] splitters = new char[2];
            splitters[0]= '-';
            splitters[1] = ':';
            Dictionary<string, decimal> games = new Dictionary<string, decimal>();
            Dictionary<string, decimal> gamesWithDlcs = new Dictionary<string, decimal>();
            for (int i = 0; i < gamesAndDlcs.Length; i++)
            {
                string[] gamePriceOrDlc = gamesAndDlcs[i].Split(splitters);
                string game = gamePriceOrDlc[0];
                decimal price = 0M;
                if (char.IsDigit(gamePriceOrDlc[1][0]) && char.IsDigit(gamePriceOrDlc[1][gamePriceOrDlc[1].Length-1]))
                {
                    price = decimal.Parse(gamePriceOrDlc[1]);
                }
                if (price != 0)
                {
                    if (!games.ContainsKey(game))
                    {
                        games.Add(game, price);
                    }
                }
                else
                {
                    string dlc = gamePriceOrDlc[1];
                    if (games.ContainsKey(game))
                    {
                        decimal gamePrice = games[game];
                        games.Remove(game);
                        decimal offFromPrice = gamePrice * 0.20M;
                        gamePrice += offFromPrice;
                        string gameWithDlc = $"{game} - {dlc}";
                        gamesWithDlcs.Add(gameWithDlc, gamePrice);
                    }
                }
            }
            foreach (var game in games.ToList())
            {
                decimal gamePriceOff = game.Value * 0.20M;
                games[game.Key] -= gamePriceOff;
            }
            foreach (var game in gamesWithDlcs.ToList())
            {
                decimal offPrice = game.Value * 0.50M;
                gamesWithDlcs[game.Key] -= offPrice;
            }
            gamesWithDlcs = gamesWithDlcs.OrderBy(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            foreach (var game in gamesWithDlcs)
            {
                Console.WriteLine($"{game.Key} - {game.Value:f2}");
            }

            games = games.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Key} - {game.Value:f2}");
            }
        }
    }
}
