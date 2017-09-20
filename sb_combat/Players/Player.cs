using SuperBaddy.Combat.Cards;
using System;
using System.Collections.Generic;

namespace SuperBaddy.Combat.Players
{
    public class Player : BasePlayer
    {
        public Player(string name, PlayerStats stats, List<ICard> deck)
        {
            Name = name;
            IsUser = true;

            HP = stats.HP;
            ATK = stats.ATK;
            DEF = stats.DEF;
            SPD = stats.SPD;

            Deck = deck;
            Hand = new List<ICard>();
        }
        public override void PickHand()
        {
            Hand = new List<ICard>();
            var tempDeck = new List<ICard>(Deck);

            // Grab 'pinned' cards first
            Deck.FindCards("pinned").ForEach(x => Hand.Add(tempDeck.PickCard(x)));

            while (Hand.Count < 5)
            {
                Hand.Add(tempDeck.PickRandomCard());
            }
        }
    }


}