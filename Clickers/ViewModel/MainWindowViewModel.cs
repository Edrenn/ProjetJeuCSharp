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
            MainCastleView newPage = new MainCastleView();
            Switcher.Switch(newPage);
        }
        #endregion
    }
}
