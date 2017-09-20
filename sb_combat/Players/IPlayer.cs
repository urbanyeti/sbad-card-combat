using System;
using System.Collections.Generic;
using SuperBaddy.Combat.Cards;

namespace SuperBaddy.Combat.Players
{
    public interface IPlayer
    {
        ICard ActiveCard { get; set; }
        int ATK { get; set; }
        List<ICard> Deck { get; set; }
        int DEF { get; set; }
        List<ICard> Hand { get; set; }
        int HP { get; set; }
        bool IsUser { get; }
        string Name { get; set; }
        int SPD { get; set; }
        event EventHandler<PlayerDeadEventArgs> PlayerDead;
        void OnPlayerDead(PlayerDeadEventArgs e);
        void PickHand();
    }
    public struct PlayerStats
    {
        public readonly int HP;
        public readonly int ATK;
        public readonly int DEF;
        public readonly int SPD;

        public PlayerStats(int hp, int atk, int def, int spd)
        {
            HP = hp;
            ATK = atk;
            DEF = def;
            SPD = spd;
        }

        public override string ToString()
        {
            return $"PlayerStats: [HP: {HP} ATK: {ATK} DEF: {DEF} SPD: {SPD}]";
        }
    }

    public class PlayerDeadEventArgs : EventArgs
    {
        public IPlayer DeadPlayer { get; set; }

        public override string ToString()
        {
            return $"PlayerDead: [Name: {DeadPlayer.Name}] [IsUser: {DeadPlayer.IsUser}]";
        }
    }
}