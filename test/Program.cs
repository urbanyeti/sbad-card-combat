using Newtonsoft.Json;
using SuperBaddy.Combat;
using SuperBaddy.Combat.Cards;
using SuperBaddy.Combat.Players;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<AttackCard> cards;
            string directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string cardsDir = Path.Combine(directory, "Cards");

            string json = File.ReadAllText(Path.Combine(cardsDir, "cards.json"));
            cards = JsonConvert.DeserializeObject<List<AttackCard>>(json);
            Debug.WriteLine(cards[0]);
            //var stats = new PlayerStats(100, 10, 10, 10);
            //var bot1 = new BotBasic("bot1", stats, );
            //var bot2 = new BotBasic("bot2", stats,);
            //Game g = new Game(bot1, bot2);
        }
    }
}
