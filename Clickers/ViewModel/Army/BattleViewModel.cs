using Clickers.Models;
using Clickers.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clickers.ViewModel.Army
{
    public class BattleViewModel
    {
        BattleReport view;
        Battle newBattle;
        public BattleViewModel()
        {
            newBattle = new Battle(GameViewModel.Instance.MainCastle.Army, GameViewModel.Instance.MainCastle.Army.AllSoldiers, GameViewModel.Instance.EnnemyCastle);
            view = new BattleReport();
            if (newBattle.AttackWin == true)
            {
                view.WinOrLoseLabel.Content = "VICTOIRE";
            }
            else
                view.WinOrLoseLabel.Content = "DÉFAITE..";

            view.AllyUnitslose.Text = "Unités attaquantes perdue : " + newBattle.AttackDeaths.Count;
            view.EnnemyUnitslose.Text = "Unités défendantes perdue : " + newBattle.DefenseDeaths.Count;
            Switcher.Switch(view);
            EventGenerator();
        }

        private void EventGenerator()
        {
            view.ToCastle.Click += ToCastle_Click;
        }

        private void ToCastle_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            WashingBodies();
            MainCastleView castleView = new MainCastleView();
            Switcher.Switch(castleView);
        }
        
        private void WashingBodies()
        {
            foreach (Soldier soldier in newBattle.AttackDeaths)
            {
                if (newBattle.AttackArmy.Contains(soldier))
                {
                    newBattle.AttackArmy.Remove(soldier);
                }
            }
            GameViewModel.Instance.MainCastle.Army.AllSoldiers.Clear();
            foreach (Soldier soldier in newBattle.AttackArmy)
            {
                Soldier newSoldier = new Soldier(soldier.Name, soldier.AttackValue, soldier.Price, soldier.ImagePath);
                GameViewModel.Instance.MainCastle.Army.AllSoldiers.Add(newSoldier);
            }
            //foreach (Soldier soldier in newBattle.DefenseDeaths)
            //{
            //    if (newBattle.DefenseArmy.Contains(soldier))
            //    {
            //        newBattle.DefenseArmy.Remove(soldier);
            //    }
            //}
        }
    }
}
