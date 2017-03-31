using Clickers.DataBaseManager.EntitiesLink;
using Clickers.Models;
using Clickers.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Clickers.ViewModel.SoldierProducer
{
    public class SoldierProducerViewModel
    {
        private SoldierProducerView view;
        public SoldierProducerView View
        {
            get { return view; }
            set { view = value; }
        }

        private SoldiersProducer soldiersProducer;
        public SoldiersProducer SoldiersProducer
        {
            get { return soldiersProducer; }
            set { soldiersProducer = value; }
        }

        private static Dictionary<SoldiersProducer, SoldierProducerViewModel> _instances = new Dictionary<SoldiersProducer, SoldierProducerViewModel>();
        private static object _lock = new object();

        public static SoldierProducerViewModel GetProducersViewModelMultition(SoldiersProducer Key)
        {
            lock (_lock)
            {
                if (!_instances.ContainsKey(Key))
                {
                    _instances.Add(Key, new SoldierProducerViewModel(Key));
                }
                return _instances[Key];
            }
        }

        public SoldierProducerViewModel(SoldiersProducer soldiersProducer)
        {
            this.View = new SoldierProducerView(this);
            View.SoldierView.BuyButton.Click += SoldierViewBuyButtonClick;
            SoldiersProducer = soldiersProducer;
            View.DataContext = SoldiersProducer;
            View.PriceTB.Text = "Prix : " + SoldiersProducer.Price.ToString();
            EventGenerator();
        }

        private void SoldierViewBuyButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GameViewModel.Instance.GoldCounter >= SoldiersProducer.AllUnitsType.Price)
            {
                Soldier newSoldier = new Soldier(SoldiersProducer.AllUnitsType.Name, SoldiersProducer.AllUnitsType.AttackValue, SoldiersProducer.AllUnitsType.Price, SoldiersProducer.AllUnitsType.ImagePath);
                GameViewModel.Instance.MainCastle.Army.AllSoldiers.Add(newSoldier);
                GameViewModel.Instance.GoldCounter -= SoldiersProducer.AllUnitsType.Price;
            }
            else
            {
                System.Windows.MessageBox.Show("Il vous manque " + (SoldiersProducer.AllUnitsType.Price - GameViewModel.Instance.GoldCounter) + " d'Or");
            }
        }

        private void EventGenerator()
        {
            View.BuyButton.Click += BuyButton_Click;
            View.CloseButton.Click += CloseButton_Click;
            View.UpgradeButton.Click += UpgradeButton_Click;
        }

        private void UpgradeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GameViewModel.Instance.GoldCounter < SoldiersProducer.Price)
            {
                int rest = SoldiersProducer.Price - GameViewModel.Instance.GoldCounter;
                System.Windows.MessageBox.Show("Il vous manque " + rest + " Golds !");
            }
            else
            {
                GameViewModel.Instance.GoldCounter -= SoldiersProducer.Price;
                SoldiersProducer.Price *= 2;
                SoldiersProducer.IsActive = true;
            }
        }

        private void CloseButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            View.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void BuyButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GameViewModel.Instance.GoldCounter < SoldiersProducer.Price)
            {
                int rest = SoldiersProducer.Price - GameViewModel.Instance.GoldCounter;
                System.Windows.MessageBox.Show("Il vous manque " + rest + " Golds !");
            }
            else
            {
                GameViewModel.Instance.GoldCounter -= SoldiersProducer.Price;
                SoldiersProducer.Price *= 2;
                SoldiersProducer.IsActive = true;
                View.MainGrid.Background = Brushes.Green;
                View.SoldierView.DataContext = SoldiersProducer.AllUnitsType;
                View.SoldierView.Visibility = System.Windows.Visibility.Visible;
                View.BuyButton.Visibility = System.Windows.Visibility.Collapsed;
                View.UpgradeButton.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void RefreshView()
        {
            View.PriceTB.Text = "Prix : " + SoldiersProducer.Price.ToString();
        }
    }
}
