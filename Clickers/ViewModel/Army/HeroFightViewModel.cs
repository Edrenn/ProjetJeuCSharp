using Clickers.Models;
using Clickers.Models.Skills;
using Clickers.ViewModel.SoldierProducer;
using Clickers.Views.HeroFightVIew;
using Clickers.Views.TaverneView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Clickers.ViewModel.Army
{
    public class HeroFightViewModel
    {
        private HeroFightView view;
        public HeroFightView View
        {
            get { return view; }
            set { view = value; }
        }

        private Hero allyHeroesList;
        public Hero AllyHeroesList
        {
            get { return allyHeroesList; }
            set { allyHeroesList = value; }
        }

        private Hero ennemyHeroesList;
        public Hero EnnemyHeroesList
        {
            get { return ennemyHeroesList; }
            set { ennemyHeroesList = value; }
        }

        public HeroFightViewModel(Hero allyHeroesList, Hero ennemyHeroesList)
        {
            this.View = new HeroFightView();
            this.AllyHeroesList = allyHeroesList;
            this.EnnemyHeroesList = ennemyHeroesList;
            GenerateUI(allyHeroesList, ennemyHeroesList);
            Switcher.Switch(this.View);

        }

        private void GenerateUI(Hero allyHero, Hero ennemyHero)
        {
            HeroView AllyHeroView = new HeroView();
            AllyHeroView.HeroInfoSP.Visibility = System.Windows.Visibility.Collapsed;
            AllyHeroView.SelectHeroButton.Visibility = System.Windows.Visibility.Collapsed;
            AllyHeroView.DataContext = allyHero;
            foreach (Skill skill in allyHero.Skills)
            {
                switch (skill.Type)
                {
                    case "Attaque":
                        SkillViewModel newSkill = new SkillViewModel(skill);
                        newSkill.View.CounterTB.Visibility = System.Windows.Visibility.Collapsed;
                        newSkill.View.SetValue(Grid.ColumnProperty, 0);
                        View.SkillsGrid.Children.Add(newSkill.View);
                        break;
                    case "Parade":
                        newSkill = new SkillViewModel(skill);
                        newSkill.View.SetValue(Grid.ColumnProperty, 1);
                        View.SkillsGrid.Children.Add(newSkill.View);
                        break;
                    case "Feinte":
                        newSkill = new SkillViewModel(skill);
                        newSkill.View.SetValue(Grid.ColumnProperty, 2);
                        View.SkillsGrid.Children.Add(newSkill.View);
                        break;
                    default:
                        break;
                }

            }
            this.View.AllyHeroSP.Children.Add(AllyHeroView);

            HeroView EnnemyHeroView = new HeroView();
            EnnemyHeroView.HeroInfoSP.Visibility = System.Windows.Visibility.Collapsed;
            EnnemyHeroView.SelectHeroButton.Visibility = System.Windows.Visibility.Collapsed;
            EnnemyHeroView.DataContext = ennemyHero;
            this.View.EnnemyHeroSP.Children.Add(EnnemyHeroView);
        }

        public void Feinte(Hero ennemyHero)
        {
            ennemyHero.IsParing = false;
        }

        public void Parade(Hero allyHero)
        {
            allyHero.IsParing = true;
        }

        public void Attack(Hero attackingHero, Hero defendingHero)
        {
            if (defendingHero.IsParing == false)
            {
                if (defendingHero.Armor > attackingHero.AttackValue)
                {
                    defendingHero.Armor -= attackingHero.AttackValue;
                }
                else if (defendingHero.Armor == 0)
                {
                    defendingHero.Life -= attackingHero.AttackValue;
                }
                else
                {
                    defendingHero.Life -= (attackingHero.AttackValue - defendingHero.Armor);
                    defendingHero.Armor = 0;
                }
            }
        }
    }
}
