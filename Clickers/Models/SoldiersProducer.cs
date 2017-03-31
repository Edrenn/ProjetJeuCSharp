using Clickers.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clickers.Models
{
    public class SoldiersProducer : BaseDBEntity
    {
        private string name;
        private int price;
        private int level;
        private bool isActive;
        private Soldier allUnitsType;
        private string imagePath;

        public SoldiersProducer(string name, int price, int level, bool isActive, Soldier allUnitsType, string imagePath)
        {
            this.name = name;
            this.price = price;
            this.level = level;
            this.isActive = isActive;
            this.allUnitsType = allUnitsType;
            this.imagePath = imagePath;
        }

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
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

        public Soldier AllUnitsType
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
