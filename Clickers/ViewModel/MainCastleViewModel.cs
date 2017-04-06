using Clickers.DataBaseManager;
using Clickers.Models;
using Clickers.ViewModel.Army;
using Clickers.Views;
using Clickers.Views.ArmyView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Clickers.ViewModel
{
    public class MainCastleViewModel
    {
        MainCastleView view;

        public MainCastleViewModel(MainCastleView view)
        {
            this.view = view;
            EventGenerator();
        }

        private void EventGenerator()
        {
            view.GoldFieldButton.Click += GoldFieldButton_Click;
            view.CaserneButton.Click += CaserneButton_Click;
            view.ArmyButton.Click += ArmyButton_Click;
            view.ToBattleButton.Click += ToBattleButton_Click;
            view.TaverneButton.Click += TaverneButton_Click;
        }

        private void TaverneButton_Click(object sender, RoutedEventArgs e)
        {
            TaverneViewModel Taverne = TaverneViewModel.Instance;
            Switcher.Switch(Taverne.View);
        }

        private void ToBattleButton_Click(object sender, RoutedEventArgs e)
        {
            GameViewModel.Instance.EnnemyCastle.Army.GenerateHero();
            if (GameViewModel.Instance.MainCastle.Army.Hero != null && GameViewModel.Instance.EnnemyCastle.Army.Hero != null)
            {
                HeroFightViewModel newDuel = new HeroFightViewModel(GameViewModel.Instance.MainCastle.Army.Hero, GameViewModel.Instance.EnnemyCastle.Army.Hero);
            }
            else
            {
                Battle newBattle = new Battle(GameViewModel.Instance.MainCastle.Army, GameViewModel.Instance.EnnemyCastle.Army, GameViewModel.Instance.EnnemyCastle);
            }
        }

        private void ArmyButton_Click(object sender, RoutedEventArgs e)
        {
            ArmyView newArmyView = new ArmyView();
            Switcher.Switch(newArmyView);
        }

        private void CaserneButton_Click(object sender, RoutedEventArgs e)
        {
            SoldiersBuildingsView newSoldiersBuildingView = new SoldiersBuildingsView();
            Switcher.Switch(newSoldiersBuildingView);
        }

        private void GoldFieldButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            GoldFieldView newGoldFieldView = new GoldFieldView();
            Switcher.Switch(newGoldFieldView);
        }
    }
}
