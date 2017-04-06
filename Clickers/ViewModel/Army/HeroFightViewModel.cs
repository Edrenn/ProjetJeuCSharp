using Clickers.Models;
using Clickers.ViewModel.SoldierProducer;
using Clickers.Views.HeroFightVIew;
using Clickers.Views.TaverneView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                AllyHeroView.DataContext = allyHero;
                this.View.AllyHeroSP.Children.Add(AllyHeroView);

                HeroView EnnemyHeroView = new HeroView();
                EnnemyHeroView.DataContext = ennemyHero;
                this.View.EnnemyHeroSP.Children.Add(EnnemyHeroView);
        }
    }
}
