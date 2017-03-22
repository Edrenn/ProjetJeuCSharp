using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clickers.Models
{
    public class ArmyProducer
    {
        string name;
        int price;
        Soldier unitType;

        public ArmyProducer(string name, int price, Soldier unitType)
        {
            this.name = name;
            this.price = price;
            this.unitType = unitType;
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

        public Soldier UnitType
        {
            get
            {
                return unitType;
            }

            set
            {
                unitType = value;
            }
        }
    }
}
