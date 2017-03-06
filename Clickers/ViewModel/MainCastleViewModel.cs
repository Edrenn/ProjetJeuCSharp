using Clickers.Views;
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
        }

        private void GoldFieldButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            GoldFieldView newGoldFieldView = new GoldFieldView();
            Switcher.Switch(newGoldFieldView);
        }
    }
}
