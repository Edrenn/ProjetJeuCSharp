using Clickers.Models;
using Clickers.ViewModel.SoldierProducer;
using Clickers.Views;
using Clickers.Views.TaverneView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clickers.ViewModel
{
    public class TaverneViewModel
    {
        private TaverneView view;
        public TaverneView View
        {
            get { return view; }
            set { view = value; }
        }

        private Dictionary<string,Hero> heros;
        public Dictionary<string,Hero> Heros
        {
            get { return heros; }
            set { heros = value; }
        }


        private static TaverneViewModel instance;
        public static TaverneViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaverneViewModel();
                }
                return instance;
            }
        }


        public TaverneViewModel()
        {
            Heros = new Dictionary<string, Hero>();
            this.View = new TaverneView();
            Hero hero1 = new Hero("Provencal Le Gaulois", 50, 40, 20, 1, "../../Assets/Image/ProvencalLeGaulois.jpg");
            Heros.Add("ProvencalLeGaulois", hero1);
            Hero hero2 = new Hero("Robinet Des Bosquets", 50, 10, 40, 1, "../../Assets/Image/RobinetDesBosquets.jpg");
            Heros.Add("RobinetDesBosquets", hero2);
            Hero hero3 = new Hero("Cavalier De Waifrer", 50, 30, 30, 1, "../../Assets/Image/CavalierDeWaifrer.jpg");
            Heros.Add("CavalierDeWaifrer", hero3);

            //HeroView heroView1 = new HeroView();
            //heroView1.DataContext = hero1;
            //View.AllHeroesSP.Children.Add(heroView1);

            //HeroView heroView2 = new HeroView();
            //heroView2.DataContext = hero2;
            //View.AllHeroesSP.Children.Add(heroView2);

            //HeroView heroView3 = new HeroView();
            //heroView3.DataContext = hero3;
            //View.AllHeroesSP.Children.Add(heroView3);
            NewHeroView(hero1);
            NewHeroView(hero2);
            NewHeroView(hero3);

            EventGenerator();

        }

        private void NewHeroView(Hero hero)
        {
            HeroViewModel heroViewModel = new HeroViewModel(hero);
            heroViewModel.View.DataContext = hero;
            View.AllHeroesSP.Children.Add(heroViewModel.View);
        }

        private void EventGenerator()
        {
            View.ToCastleButton.Click += ToCastleButton_Click;
        }

        private void ToCastleButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainCastleView castle = new MainCastleView();
            Switcher.Switch(castle);
        }
    }
}
