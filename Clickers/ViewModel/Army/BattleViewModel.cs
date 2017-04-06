using Clickers.DataBaseManager;
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
            //newBattle = new Battle(GameViewModel.Instance.MainCastle.Army, GameViewModel.Instance.EnnemyCastle.Army, GameViewModel.Instance.EnnemyCastle);
            //view = new BattleReport();
            //if (newBattle.AttackWin == true)
            //{
            //    view.WinOrLoseLabel.Content = "VICTOIRE";
            //}
            //else
            //    view.WinOrLoseLabel.Content = "DÉFAITE..";

            //view.AllyUnitslose.Text = "Unités attaquantes perdue : " + newBattle.AttackDeaths.Count;
            //view.AllyUnitsRest.Text = "Unités attaquantes restantes : " + (GameViewModel.Instance.MainCastle.Army.AllSoldiers.Count - newBattle.AttackDeaths.Count);
            //view.EnnemyUnitslose.Text = "Unités défendantes perdue : " + newBattle.DefenseDeaths.Count;
            //view.EnnemyUnitsRest.Text = "Unités défendantes restantes : " + (GameViewModel.Instance.EnnemyCastle.Army.AllSoldiers.Count - newBattle.DefenseDeaths.Count);
            //Switcher.Switch(view);
            //EventGenerator();
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
        
        /// <summary>
        /// Refresh the Army
        /// </summary>
        private void WashingBodies()
        {
            foreach (Soldier soldier in newBattle.AttackDeaths)
            {
                if (newBattle.AttackSoldiers.Contains(soldier))
                {
                    newBattle.AttackSoldiers.Remove(soldier);
                }
            }
            GameViewModel.Instance.MainCastle.Army.AllSoldiers.Clear();
            foreach (Soldier soldier in newBattle.AttackSoldiers)
            {
                Soldier newSoldier = new Soldier();
                newSoldier.InitializeSoldier(soldier);
                GameViewModel.Instance.MainCastle.Army.AllSoldiers.Add(newSoldier);
            }
        }
    }
}
