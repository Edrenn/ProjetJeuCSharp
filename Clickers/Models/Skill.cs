using Clickers.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clickers.Models
{
    public class Skill : BaseDBEntity
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int cout;
        public int Cout
        {
            get { return cout; }
            set { cout = value; }
        }

        private int value;
        public int Value
        {
            get { return value; }
            set { value = value; }
        }
    }
}
