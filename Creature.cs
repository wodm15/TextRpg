using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c__Project
{   
    public enum CreatureType
    {
        None = 0,
        Player = 1,
        Monster = 2,
    }
    public class Creature
    {
        CreatureType type;
        protected Creature(CreatureType type)
        {
            this.type = type;
        }
        protected int hp;
        protected int attack;

        public int GetHp() {return hp;}
        public int GetAttack() { return attack;}
        public bool isDead() {return hp <=0; }
        public void OnDamage(int damage)
        {
            hp -= damage;

            if(hp < 0)
            {
                hp = 0;
            }
        }

        public void SetInfo(int hp, int attack)
        {
            this.hp = hp;
            this.attack = attack;
        }
    }
}