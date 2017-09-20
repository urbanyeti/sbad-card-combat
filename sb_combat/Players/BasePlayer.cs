using SuperBaddy.Combat.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBaddy.Combat.Players
{
    public abstract class BasePlayer : IPlayer
    {
        public string Name { get; set; }
        public bool IsUser { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int SPD { get; set; }
        public int HP
        {
            get { return HP; }
            set
            {
                HP = value;
                if (value <= 0)
                {
                    PlayerDeadEventArgs args = new PlayerDeadEventArgs
                    {
                        DeadPlayer = this
                    };
                    OnPlayerDead(args);
                }
            }
        }

        public List<ICard> Deck { get; set; }
        public List<ICard> Hand { get; set; }
        public ICard ActiveCard { get; set; }

        public event EventHandler<PlayerDeadEventArgs> PlayerDead;
        public virtual void OnPlayerDead(PlayerDeadEventArgs e)
        {
            EventHandler<PlayerDeadEventArgs> handler = PlayerDead;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public override string ToString()
        {
            return $"Player: [Name: {Name}] [IsUser: {IsUser}] [HP: {HP} ATK: {ATK} DEF: {DEF} SPD: {SPD}]";
        }

        public abstract void PickHand();
    }
}
