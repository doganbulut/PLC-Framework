using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FCPlc.PlcEvents;
using S7.Net;

namespace FCPlc
{
    public class S7300Controller:PlcController
    {
        private Plc S7Client;
        public override string PLCConnectionString { get; set; }


        public S7300Controller()
        {
            try
            {
                S7Client = new Plc();
                OnNotification(new PlcBasicEventArgs("S7300 Client Created"));
            }
            catch (Exception e)
            {
                OnException(new PlcExceptionEventArgs(e, "S7300 Client Init Error"));
            }
        }

        public override bool Connect()
        {
            try
            {
                //PLCConnectionString = ip;rackNumber;slotNumber 
                string[] conpar = PLCConnectionString.Split(';');
                S7Client.CPU = CpuType.S7300;
                S7Client.IP = conpar[0];

                short rackNumber;
                if (short.TryParse(conpar[1], out rackNumber))
                {
                    S7Client.Rack = rackNumber;
                }
                else 
                {
                    OnNotification(new PlcBasicEventArgs("S7300 Client Wrong RackNumber"));
                    return false;
                }

                short slotNumber;
                if (short.TryParse(conpar[2], out slotNumber))
                {
                    S7Client.Slot = slotNumber;
                }
                else
                {
                    OnNotification(new PlcBasicEventArgs("S7300 Client Wrong SlotNumber"));
                    return false;
                }

                if (S7Client.IsAvailable)
                {
                    ErrorCode connectionResult = S7Client.Open();

                    //Verify that connection was successful
                    if (connectionResult.Equals(ErrorCode.NoError))
                    {
                        OnNotification(new PlcBasicEventArgs("S7300 Client Connected to the PLC"));
                    }
                    else
                    {
                         OnNotification(new PlcBasicEventArgs("ERROR: Device is available but connection was unsuccessful! Code:" + connectionResult));
                    }
                }
                else
                {
                    OnNotification(new PlcBasicEventArgs("ERROR: Device is not available!"));
                }


                return ConnectionState();
            }
            catch (Exception e)
            {
                OnException(new PlcExceptionEventArgs(e, "Error S7300 Client Not Connected"));
                return false;
            }
        }

        public override bool DisConnect()
        {
            try
            {
                S7Client.Close();
                OnNotification(new PlcBasicEventArgs("S7300 Client DisConnected to the PLC"));
                return ConnectionState();
            }
            catch (Exception e)
            {
                OnException(new PlcExceptionEventArgs(e, "Error S7300 Client Not DisConnected"));
                return false;
            }
        }

        public override bool ConnectionState()
        {
            if (S7Client.IsConnected)
                return true;
            else
                return false;
        }

        private void PLCError(Exception PlcException, string PlcValueKey)
        {
            OnException(new PlcExceptionEventArgs(PlcException, PlcValueKey));
        }

        public override bool Read(string PlcValueKey, int ArrayLen, int Length, out string[] Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (string[])val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = null;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, int Length, string[] Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, int ArrayLen, out double[] Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (double[])val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = null;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, double[] Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, int ArrayLen, out float[] Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (float[])val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = null;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, float[] Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, int ArrayLen, out ulong[] Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (ulong[])val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = null;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, ulong[] Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, int ArrayLen, out uint[] Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (uint[])val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = null;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, uint[] Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, int ArrayLen, out ushort[] Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (ushort[])val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = null;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, ushort[] Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, int ArrayLen, out long[] Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (long[])val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = null;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, long[] Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, int ArrayLen, out int[] Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (int[])val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = null;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, int[] Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, int ArrayLen, out short[] Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (short[])val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = null;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, short[] Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, int ArrayLen, out byte[] Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (byte[])val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = null;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, byte[] Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, int ArrayLen, out bool[] Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (bool[])val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = null;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, bool[] Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, int Length, out string Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (string)val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = null;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, int Length, string Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, out double Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (double)val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = 0;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = 0;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, double Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, out float Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (float)val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = 0;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = 0;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, float Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, out ulong Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (ulong)val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = 0;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = 0;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, ulong Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, out uint Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (uint)val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = 0;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = 0;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, uint Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, out ushort Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (ushort)val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = 0;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = 0;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, ushort Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, out long Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (long)val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = 0;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = 0;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, long Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, out int Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (int)val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = 0;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = 0;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, int Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, out short Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (short)val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = 0;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = 0;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, short Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, out byte Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (byte)val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = 0;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = 0;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, byte Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool Read(string PlcValueKey, out bool Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (bool)val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = false;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = false;
                return false;
            }
        }

        public override bool Write(string PlcValueKey, bool Value)
        {
            return WriteAny(PlcValueKey, Value);
        }

        public override bool ReadAny(string PlcValueKey, Type type, out object Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = false;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = false;
                return false;
            }
        }

        public override bool WriteAny(string PlcValueKey, object Value)
        {
            if (string.IsNullOrEmpty(PlcValueKey))
            {
                try
                {
                    var result = (ErrorCode)S7Client.Write(PlcValueKey, Value);
                    if (result == ErrorCode.NoError)
                        return true;
                    else
                        return false;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = 0;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = 0;
                return false;
            }
        }

        public override bool ReadAny(string PlcValueKey, out object[] Value)
        {

            if (PlcValueKey != null)
            {
                try
                {
                    object val = S7Client.Read(PlcValueKey);
                    Value = (object[])val;
                    return true;
                }
                catch (Exception E)
                {
                    PLCError(E, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            else
            {
                PLCError(new NotImplementedException("PLC Degisken Ismi tanımsız"), PlcValueKey);
                Value = null;
                return false;
            }
        }

        public override bool WriteAny(string PlcValueKey, object[] Value)
        {
            return WriteAny(PlcValueKey, Value);
        }
    }
}
