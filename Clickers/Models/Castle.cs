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
        private List<RessourceProducer> goldProducers;
        private List<SoldiersProducer> soldiersProducers;

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

        public List<RessourceProducer> GoldProcucers
        {
            get { return goldProducers; }
            set { goldProducers = value; }
        }

        public List<SoldiersProducer> SoldiersProducers
        {
            get { return soldiersProducers; }
            set { soldiersProducers = value; }
        }

        public Castle() { }

        public Castle(string Name)
        {
            this.Name = Name;
            this.Life = 100;
            this.Army = new Army();
            this.GoldProcucers = new List<RessourceProducer>();
            this.SoldiersProducers = new List<SoldiersProducer>();
        }
    }
}
