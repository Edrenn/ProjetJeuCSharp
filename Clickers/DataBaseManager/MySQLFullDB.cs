using Clickers.Json;
using Clickers.Models;
using Clickers.Models.Generators;
using Clickers.Models.RepetitingItems;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clickers.DataBaseManager
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    class MySQLFullDB : DbContext
    {

        public DbSet<Baguette> BaguetteTable { get; set; }
        public MySQLFullDB()
            :base(JsonManager.Instance.ReadFile<ConnectionString>(@"D:\Workspaces\Clickers\Clickers\JsonConfig\",@"MysqlConfig.json").ToString())
        {
            InitLocalMySQL();
        }

        private void InitLocalMySQL()
        {
            if (this.Database.CreateIfNotExists())
            {
            }

                this.SaveChangesAsync();
        }
    }
}
