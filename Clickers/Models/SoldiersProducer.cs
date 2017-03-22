using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clickers.Models
{
    public class SoldiersProducer<TEntity> where TEntity : class
    {
        private string name;
        private int price;
        private int level;
        private bool isActive;
        private TEntity[] allUnitsType;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public SoldiersProducer(string name, int price, int level, bool isActive, TEntity[] allUnitsType)
        {
            this.name = name;
            this.price = price;
            this.level = level;
            this.isActive = isActive;
            this.allUnitsType = allUnitsType;
        }

        public SoldiersProducer()
        {

        }
             


        #region Properties
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return isActive;
            }

            set
            {
                isActive = value;
            }
        }

        public TEntity[] AllUnitsType
        {
            get
            {
                return allUnitsType;
            }

            set
            {
                allUnitsType = value;
            }
        }
        #endregion
    }
}
