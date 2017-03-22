using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clickers.Models
{
    public class Soldier
    {
        string name;
        int attackValue;
        int price;

        public Soldier(string name, int attackValue, int price)
        {
            this.name = name;
            this.attackValue = attackValue;
            this.price = price;
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
    }
}
