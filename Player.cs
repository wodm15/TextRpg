using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c__Project
{
    public enum PlayerType
    {
        None = 0,
        Knight = 1,
        Archer = 2,
        Mage = 3,
    }
    public class Player : Creature
    {
        protected PlayerType type = PlayerType.None;
        protected Player(PlayerType type) : base(CreatureType.Player)
        {
            this.type = type;
        }
        public PlayerType GetPlayerType() { return type; }
    }

    class Knight : Player
    {
        public Knight() : base(PlayerType.Knight)
        {
            SetInfo(75,10);
        }
    }
    class Archer : Player
    {
        public Archer() : base(PlayerType.Archer)
        {
            SetInfo(100,10);
        }

    }
    class Mage : Player
    {
        public Mage() : base(PlayerType.Mage)
        {
            SetInfo(75, 12);
        }
    }
}