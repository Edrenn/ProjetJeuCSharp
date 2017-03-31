using Clickers.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clickers.Models
{
    public class Battle : BaseDBEntity
    {
        private Random rng;
        private Castle attackedCastle;
        private List<Soldier> attackArmy;
        private List<Soldier> defenseArmy;
        private List<Soldier> alliesDeaths;
        private List<Soldier> defenseDeaths;
        private bool attackWin;

        public List<Soldier> AttackArmy
        {
            get
            {
                return attackArmy;
            }

            set
            {
                attackArmy = value;
            }
        }

        public List<Soldier> DefenseArmy
        {
            get
            {
                return defenseArmy;
            }

            set
            {
                defenseArmy = value;
            }
        }

        public List<Soldier> AttackDeaths
        {
            get
            {
                return alliesDeaths;
            }

            set
            {
                alliesDeaths = value;
            }
        }

        public List<Soldier> DefenseDeaths
        {
            get
            {
                return defenseDeaths;
            }

            set
            {
                defenseDeaths = value;
            }
        }

        public bool AttackWin
        {
            get
            {
                return attackWin;
            }

            set
            {
                attackWin = value;
            }
        }

        public Castle AttackedCastle
        {
            get
            {
                return attackedCastle;
            }

            set
            {
                attackedCastle = value;
            }
        }

        public Battle(Army alliesArmy, List<Soldier> ennemiesArmy, Castle attackedCastle)
        {
            AttackedCastle = attackedCastle;
            rng = new Random();
            AttackArmy = new List<Soldier>();
            foreach (Soldier soldier in alliesArmy.AllSoldiers)
            {
                Soldier newSoldier = new Soldier(soldier.Name, soldier.AttackValue, soldier.Price, soldier.ImagePath);
                AttackArmy.Add(newSoldier);
            }
            DefenseArmy = new List<Soldier>();
            foreach (Soldier soldier in ennemiesArmy)
            {
                Soldier newSoldier = new Soldier(soldier.Name, soldier.AttackValue, soldier.Price, soldier.ImagePath);
                DefenseArmy.Add(newSoldier);
            }
            
            AttackDeaths = new List<Soldier>();
            DefenseDeaths = new List<Soldier>();
            Shuffle(AttackArmy);
            Shuffle(DefenseArmy);
            Fight();
        }
        
        private void Shuffle(List<Soldier> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Soldier value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void Fight()
        {
            int ennemySoldier = 0;
            foreach (Soldier soldier in AttackArmy)
            {
                while (soldier.Health > 0)
                {
                    DamageTest(soldier,DefenseArmy[ennemySoldier]);
                    if (DefenseArmy[ennemySoldier].Health <= 0)
                    {
                        DefenseDeaths.Add(DefenseArmy[ennemySoldier]);
                        ennemySoldier++;
                        if (ennemySoldier == DefenseArmy.Count)
                        {
                            AttackWin = true;
                            AttackedCastle.Life -= 25;
                            break;
                        }
                    }
                    DamageTest(DefenseArmy[ennemySoldier], soldier);
                    if (soldier.Health <= 0)
                    {
                        AttackDeaths.Add(soldier);
                    }
                }
            }
        }

        private void DamageTest(Soldier soldier1,Soldier soldier2)
        {
            switch (soldier1.Name)
            {
                case "Chevalier":
                    if (soldier2.Name == "Archer")
                    {
                        soldier2.Health -= soldier1.AttackValue * 2;
                    }
                    else
                    {
                        soldier2.Health -= soldier1.AttackValue;
                    }
                    break;
                case "Cavalier":
                    if (soldier2.Name == "Chevalier")
                    {
                        soldier2.Health -= soldier1.AttackValue * 2;
                    }
                    else
                    {
                        soldier2.Health -= soldier1.AttackValue;
                    }
                    break;
                case "Archer":
                    if (soldier2.Name == "Cavalier")
                    {
                        soldier2.Health -= soldier1.AttackValue * 2;
                    }
                    else
                    {
                        soldier2.Health -= soldier1.AttackValue;
                    }
                    break;
            }
        }
    }
}
