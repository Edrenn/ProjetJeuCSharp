using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clickers.Models
{
    public class Hero
    {
        string name;
        int life;
        int armor;
        int attackValue;
        int level;
        int price;
        List<Item> inventory;

        public Hero(string name, int life, int armor, int attackValue, int level, List<Item> inventory)
        {
            this.Name = name;
            this.Life = life;
            this.Armor = armor;
            this.AttackValue = attackValue;
            this.Level = level;
            this.Inventory = inventory;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Life
        {
            get
            {
                return life;
            }

            set
            {
                life = value;
            }
        }

        public int Armor
        {
            get
            {
                return armor;
            }

            set
            {
                armor = value;
            }
        }

        public int AttackValue
        {
            get
            {
                return attackValue;
            }

            set
            {
                attackValue = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }

        public List<Item> Inventory
        {
            get
            {
                return inventory;
            }

            set
            {
                inventory = value;
            }
        }

        public int Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
    }
}
