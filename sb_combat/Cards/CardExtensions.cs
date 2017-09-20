using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBaddy.Combat.Cards
{
    public static class CardExtensions
    {
        public static List<ICard> FindCards(this List<ICard> deck, string property)
        {
            return deck.Where(x => x.Properties.Contains(property)).ToList();
        }

        public static ICard PickCard(this List<ICard> cards, ICard card)
        {
            cards.Remove(card);
            return card;
        }

        public static ICard PickRandomCard(this List<ICard> cards)
        {
            Random random = new Random();
            ICard card = cards.ElementAtOrDefault(random.Next(cards.Count));
            return cards.PickCard(card);
        }
    }
}
