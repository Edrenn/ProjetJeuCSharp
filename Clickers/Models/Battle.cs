using Clickers.Models.Base;
using Clickers.ViewModel.Army;
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
        private List<Soldier> attackSoldiers;
        private List<Soldier> defenseSoldiers;
        private List<Soldier> alliesDeaths;
        private List<Soldier> defenseDeaths;
        private bool attackWin;

        public List<Soldier> AttackSoldiers
        {
            get
            {
                return attackSoldiers;
            }

            set
            {
                attackSoldiers = value;
            }
        }

        public List<Soldier> DefenseSoldiers
        {
            get
            {
                return defenseSoldiers;
            }

            set
            {
                defenseSoldiers = value;
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

        public Battle(Army attackingArmy, Army defenseArmy, Castle attackedCastle)
        {
            AttackSoldiers = new List<Soldier>();
            DefenseSoldiers = new List<Soldier>();
            AttackedCastle = attackedCastle;
            rng = new Random();
            if (attackingArmy.Hero != null && defenseArmy.Hero != null)
            {
                List<Hero> attackingHeroList = new List<Hero>();
                attackingHeroList.Add(attackingArmy.Hero);
                List<Hero> defenseHeroList2 = new List<Hero>();
                defenseHeroList2.Add(defenseArmy.Hero);
                FightOfHeroes(attackingHeroList, defenseHeroList2);
            }
            else if (attackingArmy.Hero != null && defenseArmy.Hero == null)
            {
                ArmyCreationWithHero(attackingArmy, AttackSoldiers, attackingArmy.Hero);
                ArmyCreation(defenseArmy, DefenseSoldiers);
            }
            else
            {
                ArmyCreation(attackingArmy, AttackSoldiers);
                ArmyCreationWithHero(defenseArmy, DefenseSoldiers, defenseArmy.Hero);
            }
            //AttackDeaths = new List<Soldier>();
            //DefenseDeaths = new List<Soldier>();
            //Randomizer(AttackSoldiers);
            //Randomizer(DefenseSoldiers);
            //Fight();
        }

        private void FightOfHeroes(List<Hero> hero1, List<Hero> hero2)
        {
            //HeroFightViewModel heroFightViewModel = new HeroFightViewModel(hero1, hero2);
        }

        private void ArmyCreation(Army Army,List<Soldier> listToFill)
        {
            foreach (Soldier soldier in Army.AllSoldiers)
            {
                Soldier newSoldier = new Soldier();
                newSoldier.InitializeSoldier(soldier);
                listToFill.Add(newSoldier);
            }

        }

        private void ArmyCreationWithHero(Army Army, List<Soldier> listToFill,Hero hero)
        {
            foreach (Soldier soldier in Army.AllSoldiers)
            {
                Soldier newSoldier;
                if (hero != null && soldier.Name == hero.Type)
                {
                    newSoldier = new Soldier();
                    newSoldier.InitializeSoldier(soldier);
                    newSoldier.AttackValue += 5;
                }
                else
                {
                    newSoldier = new Soldier();
                    newSoldier.InitializeSoldier(soldier);
                }
                listToFill.Add(newSoldier);
            }

        }

        private void Randomizer(List<Soldier> list)
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
            foreach (Soldier soldier in AttackSoldiers)
            {
                while (soldier.Health > 0)
                {
                    DamageTest(soldier,DefenseSoldiers[ennemySoldier]);
                    if (DefenseSoldiers[ennemySoldier].Health <= 0)
                    {
                        DefenseDeaths.Add(DefenseSoldiers[ennemySoldier]);
                        ennemySoldier++;
                        if (ennemySoldier == DefenseSoldiers.Count)
                        {
                            AttackWin = true;
                            AttackedCastle.Life -= 25;
                            break;
                        }
                    }
                    DamageTest(DefenseSoldiers[ennemySoldier], soldier);
                    if (soldier.Health <= 0)
                    {
                        AttackDeaths.Add(soldier);
                    }
                }
                if (AttackWin == true)
                {
                    break;
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
