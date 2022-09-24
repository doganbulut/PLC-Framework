using DAL.Entity;
using System;
using System.Collections.Generic;
using DAL;
using FCPlc;
using FCLog;

namespace BLL
{
    public class OperationTank
    {
        //Database
        private FactoryDB _dal = null;
        //PLC
        private static IPlcController _plc = null;
        //Log
        private static ILogger logPLC = null;

        //BLL Value
        public class FactTank : Tank
        {
            private string GetBarPLCId;

            public FactTank()
            {
                GetBarPLCId = ".stPlc.Tank[" + Id + "].Bar";
            }

           
            public double? GetBar 
            { 
                get
                {
                    double val;
                    if (_plc.Read(GetBarPLCId, out val))
                    {
                        logPLC.Info("Read : " + GetBarPLCId + " : " + val.ToString());
                        return val;
                    }
                    else
                    {
                        logPLC.Error("BLL GetBar Read Error : "+GetBarPLCId);
                        return null;
                    }
                } 
                set
                {
                    if(value.HasValue)
                        if (_plc.Write(GetBarPLCId,value.Value))
                            logPLC.Info("Write : " + GetBarPLCId + " : " + value.Value.ToString());
                        else
                            logPLC.Error("BLL GetBar Write Error : " + GetBarPLCId);
                } 
            }
 
        }
             


        public OperationTank()
        {
            //LogInit
            logPLC = new Logger("PLCTanks\\Log.txt");
            logPLC.initialize();

            try
            {
                //Database init
                _dal = new FactoryDB();      //Burası yeni database eklemek içindir
                _dal.CreateTableIfNotExists();  //Tablolar var ise kaldırılacak
            }
            catch (Exception e)
            {
                logPLC.Error("Tank DB Init Error", e);
            }

            try
            {
                //PLCInit
                _plc = new BeckhoffController();
                _plc.PLCConnectionString = "192.168.216.151.1.1";
                _plc.OnPlcException += _plc_OnPlcException;
                if (!_plc.Connect())
                    logPLC.Error("Tank PLC Connect Error");
            }
            catch (Exception e)
            {
                logPLC.Error("Tank PLC Init Error", e);
            }
        }


        public Tank GetTank(int ID)
        {
            return _dal.GetTank(ID);
        }

        public List<Tank> GetList()
        {
            return _dal.GetList();
        }

        public long InsertTank(Tank Tank)
        {
            return _dal.InsertTank(Tank);
        }

        void _plc_OnPlcException(object sender, FCPlc.PlcEvents.PlcExceptionEventArgs e)
        {
            logPLC.Error("Tank PLC Eception : ", e.EventException);
        }

       


    }
}
