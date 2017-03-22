using Clickers.Json;
using Clickers.Models;
using Clickers.Models.Generators;
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
        public DbSet<RessourceProducer> RessourceProducerTable { get; set; }
        public MySQLFullDB()
            :base(JsonManager.Instance.ReadFile<ConnectionString>(@"D:\Workspaces\Clickers\Clickers\JsonConfig\",@"MysqlConfig.json").ToString())
        {
            InitLocalMySQL();
        }

        private void InitLocalMySQL()
        {
            if (this.Database.CreateIfNotExists())
            {

               List<RessourceProducer> allProducer = JsonManager.Instance.ReadFileToList<List<RessourceProducer>>("D:\\Workspaces\\Clickers\\Clickers\\JsonConfig\\", "GoldProducer.Json");
                foreach (RessourceProducer item in allProducer)
                {
                    RessourceProducerTable.Add(item);
                }
            }

                this.SaveChangesAsync();
        }
    }
}
