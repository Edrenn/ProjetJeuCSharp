using Clickers.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clickers.Models
{
    public class Castle : BaseDBEntity
    {
        private string name;
        private int life;
        private Army army;

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

        public Army Army
        {
            get
            {
                return army;
            }

            set
            {
                army = value;
            }
        }

        public Castle(string Name)
        {
            this.Name = Name;
            this.Life = 100;
            this.Army = new Army();
        }
    }
}
