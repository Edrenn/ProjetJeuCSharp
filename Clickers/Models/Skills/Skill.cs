using Clickers.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clickers.Models.Skills
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

        private int useCounter;
        public int UseCounter
        {
            get { return useCounter; }
            set { useCounter = value; }
        }

        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }


        public Skill() { }

        public Skill(string name, string description,int useCounter)
        {
            this.Name = name;
            this.Description = description;
            this.UseCounter = useCounter;
        }




    }
}
