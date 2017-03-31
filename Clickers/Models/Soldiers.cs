using Clickers.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clickers.Models
{
    public class Soldier : BaseDBEntity
    {
        int health;
        string name;
        int attackValue;
        int price;
        private string imagePath;

        public Soldier(string name, int attackValue, int price, string imagePath)
        {
            this.name = name;
            this.attackValue = attackValue;
            this.price = price;
            this.imagePath = imagePath;
            this.health = 10;
        }

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
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

        public int Health
        {
            get
            {
                return health;
            }

            set
            {
                health = value;
            }
        }
    }
}
