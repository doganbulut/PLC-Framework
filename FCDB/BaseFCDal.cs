using System;
using System.Data;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;


namespace FCDB
{
    public abstract class BaseFCDal:IDisposable
    {
        bool disposed = false;

        protected IDbConnection _db;
        protected IDbConnectionFactory _dbFactory;
        public string SqliteMemoryDb { get; set; }
        public string SqliteFileDb { get; set; }

        public IDbConnection db 
        {
            get { return _db; } 
        }

        public IDbConnectionFactory dbFactory
        {
            get { return _dbFactory; }
            set { _dbFactory = value; }
        }

        
        public BaseFCDal()
        {
            this.SqliteMemoryDb = ":memory:";
            this.SqliteFileDb = "~/App_Data/db.sqlite".MapHostAbsolutePath();
            this._dbFactory = new OrmLiteConnectionFactory(SqliteFileDb, SqliteDialect.Provider, true);
        }

        public BaseFCDal(string SqliteMemoryDb, string SqliteFileDb)
        {
            this.SqliteMemoryDb = SqliteMemoryDb;
            this.SqliteFileDb = SqliteFileDb.MapHostAbsolutePath();
            this._dbFactory = new OrmLiteConnectionFactory(SqliteFileDb, SqliteDialect.Provider, true);
        }


        public IDbConnection GetInstance()
        {
            if (_db != null)
                return _db;

            return _db = _dbFactory.OpenDbConnection();
        }

        public abstract bool DropAndCreateTables();
        public abstract bool CreateTableIfNotExists();



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return; 

            if (disposing)
            {
                if (_db != null)
                {
                    _db = null;
                    _db.Dispose();
                }
            }

            disposed = true;
        }

        ~BaseFCDal()
        {
            Dispose(false);
        }

    }
}
