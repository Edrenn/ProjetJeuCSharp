using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clickers.Models
{
    public class Army
    {
        private Hero hero;
        public Hero Hero
        {
            get { return hero; }
            set { hero = value; }
        }

        List<Soldier> allSoldiers;
        public List<Soldier> AllSoldiers
        {
            get
            {
                return allSoldiers;
            }

            set
            {
                allSoldiers = value;
            }
        }

        public Army()
        {
            allSoldiers = new List<Soldier>();
        }
    }
}
