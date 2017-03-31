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

        int life;
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

        int armor;
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

        int attackValue;
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

        int level;
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

        int price;
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

        List<Item> inventory;
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

        private string imagePath;
        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }

        public Hero(string name, int life, int armor, int attackValue, int level, string imagePath)
        {
            this.Name = name;
            this.Life = life;
            this.Armor = armor;
            this.AttackValue = attackValue;
            this.Level = level;
            this.Inventory = new List<Item>();
            this.ImagePath = imagePath;






        }
    }
}
