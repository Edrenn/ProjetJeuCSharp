using Clickers.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clickers.ViewModel
{
    public class GoldFieldViewModel : INotifyPropertyChanged
    {
        #region Fields
        GoldFieldView view;
        private int goldCounter = 0;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public int GoldCounter
        {
            get
            {
                return goldCounter;
            }
            set
            {
                goldCounter = value;
                RaisePropertyChanged("GoldCounter");
            }
        }
        #endregion

        public GoldFieldViewModel(GoldFieldView view)
        {
            this.view = view;
            EventGenerator();
            view.DataContext = GameViewModel.Instance;
            
        }

        private void EventGenerator()
        {
            view.GoldButton.Click += GoldButton_Click1;
            view.UsineOneButton.Click += UsineOneButton_Click;
            view.UsineTwoButton.Click += UsineTwoButton_Click;
            view.UsineThreeButton.Click += UsineThreeButton_Click;
            view.UsineFourButton.Click += UsineFourButton_Click;
            view.MapButton.Click += MapButton_Click;
        }

        private void MapButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new MainCastleView());
        }

        private void GoldButton_Click1(object sender, System.Windows.RoutedEventArgs e)
        {
            GameViewModel.Instance.GoldCounter++;
        }

        private void UsineFourButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            {
                if (GameViewModel.Instance.GoldCounter < 40)
                {
                    int rest = 40 - GameViewModel.Instance.GoldCounter;
                    view.UsineFourButton.Content = "Reste : " + rest.ToString();
                }
                else
                {
                    GameViewModel.Instance.GoldCounter = GameViewModel.Instance.GoldCounter - 30;
                    view.UsineFourButton.IsEnabled = false;
                    view.labelFour.Content = "Activé : 1000g/60s";
                    view.labelFour.Visibility = System.Windows.Visibility.Collapsed;
                    ThreadStart childref = new ThreadStart(UsineProductionFour);
                    Thread childThread = new Thread(childref);
                    childThread.Start();
                }
            }
        }

        private void UsineThreeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            {
                if (GameViewModel.Instance.GoldCounter < 30)
                {
                    int rest = 30 - GameViewModel.Instance.GoldCounter;
                    view.UsineThreeButton.Content = "Reste : " + rest.ToString();
                }
                else
                {
                    GameViewModel.Instance.GoldCounter = GameViewModel.Instance.GoldCounter -30;
                    view.UsineThreeButton.IsEnabled = false;
                    view.labelThree.Content = "Activé : 50g/10s";
                    view.labelThree.Visibility = System.Windows.Visibility.Collapsed;
                    ThreadStart childref = new ThreadStart(UsineProductionThree);
                    Thread childThread = new Thread(childref);
                    childThread.Start();
                }
            }
        }

        private void UsineTwoButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            {
                if (GameViewModel.Instance.GoldCounter < 20)
                {
                    int rest = 20 - GameViewModel.Instance.GoldCounter;
                    view.UsineTwoButton.Content = "Reste : " + rest.ToString();
                }
                else
                {
                    GameViewModel.Instance.GoldCounter = GameViewModel.Instance.GoldCounter - 20;
                    view.UsineTwoButton.IsEnabled = false;
                    view.labelTwo.Content = "Activé : 20g/5s";
                    view.labelTwo.Visibility = System.Windows.Visibility.Collapsed;
                    ThreadStart childref = new ThreadStart(UsineProductionTwo);
                    Thread childThread = new Thread(childref);
                    childThread.Start();
                }
            }
        }

        private void UsineOneButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            {
                if (GameViewModel.Instance.GoldCounter < 10)
                {
                    int rest = 10 - GameViewModel.Instance.GoldCounter;
                    view.UsineOneButton.Content = "Reste : " + rest.ToString();
                }
                else
                {
                    GameViewModel.Instance.GoldCounter = GameViewModel.Instance.GoldCounter - 10;
                    view.UsineOneButton.IsEnabled = false;
                    view.labelOne.Content = "Activé : 10g/2s";
                    view.labelOne.Visibility = System.Windows.Visibility.Collapsed;
                    ThreadStart childref = new ThreadStart(UsineProductionOne);
                    Thread childThread = new Thread(childref);
                    childThread.Start();
                }
            }
        }
        private void UsineProductionOne()
        {
            GameViewModel.Instance.UsineProduction(2000,10);
        }

        private void UsineProductionTwo()
        {
            GameViewModel.Instance.UsineProduction(5000, 50);
        }

        private void UsineProductionThree()
        {
            GameViewModel.Instance.UsineProduction(10000, 100);
        }

        private void UsineProductionFour()
        {
            GameViewModel.Instance.UsineProduction(60000, 1000);
        }

        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
