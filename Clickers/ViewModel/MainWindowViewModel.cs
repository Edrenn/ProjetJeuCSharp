using Clickers.DataBaseManager;
using Clickers.Models;
using Clickers.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Clickers.ViewModel
{
    public class MainWindowViewModel
    {
        MainWindow view;
        UsernameRegister popUp;

        public MainWindowViewModel(MainWindow view)
        {
            this.view = view;
            EventGenerator();
            Switcher.pageSwitcher = view;
        }

        public void Navigate(UserControl nextPage)
        {
            view.Content = nextPage;
        }
        #region PrivateMethods
        private void EventGenerator()
        {
            view.newGameButton.Click += NewGameButton_Click;
        }

        private void NewGameButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            popUp = new UsernameRegister();
            popUp.CancelButton.Click += CancelButton_Click;
            popUp.OkButton.Click += OkButton_Click;
            popUp.Visibility = Visibility.Visible;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            MainCastleView newPage = new MainCastleView();
            GameViewModel.Instance.CastleName = popUp.UsernameTB.Text;
            Switcher.Switch(newPage);
            popUp.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            popUp.Visibility = Visibility.Collapsed;
        }
        #endregion
    }
}
