using FCDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using DAL.Entity;



namespace DAL
{
    public class FactoryDB : BaseFCDal
    {

        public Tank GetTank(int ID)
        {
            return this._db.SingleById<Tank>(ID);
        }

        public List<Tank> GetList()
        {
            return this.GetInstance().Select<Tank>().ToList();
        }

        public long InsertTank(Tank tank)
        {
            try
            {
                return this.GetInstance().Insert<Tank>(tank, selectIdentity: true);
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public override bool DropAndCreateTables()
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    db.DropAndCreateTable<Factory>();
                    db.DropAndCreateTable<Tank>();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override bool CreateTableIfNotExists()
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    db.CreateTableIfNotExists<Factory>();
                    db.CreateTableIfNotExists<Tank>();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    } 
}
