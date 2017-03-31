using Clickers.DataBaseManager.EntitiesLink;
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
        public DbSet<SoldiersProducer> SoldiersProducerTable { get; set; }
        public DbSet<Soldier> SoldiersTable { get; set; }
        public MySQLFullDB()
            : base(JsonManager.Instance.ReadFile<ConnectionString>(@"D:\Workspaces\Clickers\Clickers\JsonConfig\", @"MysqlConfig.json").ToString())
        {
            InitLocalMySQL();
        }

        private void InitLocalMySQL()
        {
            if (this.Database.CreateIfNotExists())
            {

                List<RessourceProducer> allGoldProducer = JsonManager.Instance.GetAllGoldProducersFromJSon();
                foreach (RessourceProducer item in allGoldProducer)
                {
                    RessourceProducerTable.Add(item);
                }
                List<Soldier> allSoldier = JsonManager.Instance.GetAllSoldiersFromJSon();
                foreach (Soldier item in allSoldier)
                {
                    SoldiersTable.Add(item);
                }
                List<SoldiersProducer> allSoldierProducer = JsonManager.Instance.GetAllSoldierProducersFromJSon();
                foreach (SoldiersProducer item in allSoldierProducer)
                {
                    SoldiersProducerTable.Add(item);
                }

                this.SaveChangesAsync();
            }
        }
    }
}
