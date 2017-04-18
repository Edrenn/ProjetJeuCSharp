﻿using Clickers.Models.Base;
using Clickers.Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clickers.Models
{
    public class Hero : BaseDBEntity
    {
        string name;
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

        int life;
        public int Life
        {
            get
            {
                return life;
            }

            set
            {
                life = value;
            }
        }

        int armor;
        public int Armor
        {
            get
            {
                return armor;
            }

            set
            {
                armor = value;
            }
        }

        int attackValue;
        public int AttackValue
        {
            get
            {
                return attackValue;
            }

            set
            {
                attackValue = value;
            }
        }

        int level;
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

        int price;
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

        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private List<Item> inventory;
        public List<Item> Inventory
        {
            get
            {
                return inventory;
            }

            set
            {
                inventory = value;
            }
        }

        private List<Skill> skills;
        public List<Skill> Skills
        {
            get { return skills; }
            set { skills = value; }
        }

        private string imagePath;
        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }

        private bool isParing;
        public bool IsParing
        {
            get { return isParing; }
            set { isParing = value; }
        }

        public Hero() { }

        public Hero(string name, int life, int armor, int attackValue, int level, string type, string imagePath)
        {
            this.Name = name;
            this.Life = life;
            this.Armor = armor;
            this.AttackValue = attackValue;
            this.Level = level;
            this.Inventory = new List<Item>();
            this.Type = type;
            this.ImagePath = imagePath;
            this.Skills = new List<Skill>();
        }
    }
}
