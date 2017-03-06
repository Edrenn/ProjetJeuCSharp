using Clickers.DataBaseManager;
using Clickers.Models.RepetitingItems;
using Clickers.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clickers
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private int goldCounter = 0;
        public event PropertyChangedEventHandler PropertyChanged;
        private static GameViewModel instance;

        private GameViewModel() { }

        public static GameViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameViewModel();
                }
                return instance;
            }
        }

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

        public void UsineProduction(int productSpeed, int quantityProduct)
        {
            Thread.Sleep(productSpeed);
            GoldCounter = GoldCounter + quantityProduct;
            UsineProduction(productSpeed, quantityProduct);
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
