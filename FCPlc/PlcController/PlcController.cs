using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FCPlc.PlcEvents;

namespace FCPlc
{
    public abstract class PlcController : IPlcController
    {
        public event EventHandler<PlcBasicEventArgs> OnPlcState;
        public event EventHandler<PlcExceptionEventArgs> OnPlcException;
        public event EventHandler<PlcBasicEventArgs> OnPlcNotification;

        public abstract bool Connect();
        public abstract bool DisConnect();
        public abstract bool ConnectionState();

        public abstract string PLCConnectionString { get; set; }

        protected virtual void OnException(PlcExceptionEventArgs e)
        {
            if (OnPlcException != null)
                OnPlcException(this, e);
        }

        protected virtual void OnState(PlcBasicEventArgs e)
        {
            if (OnPlcState != null)
                OnPlcState(this, e);
        }

        public void OnNotification(PlcBasicEventArgs e)
        {
            if (OnPlcNotification != null)
                OnPlcNotification(this, e);
        }

        public abstract bool Read(string PlcValueKey, int ArrayLen, int Length, out string[] Value);
        public abstract bool Write(string PlcValueKey, int ArrayLen, int Length, string[] Value);
        public abstract bool Read(string PlcValueKey, int ArrayLen, out double[] Value);
        public abstract bool Write(string PlcValueKey, int ArrayLen, double[] Value);
        public abstract bool Read(string PlcValueKey, int ArrayLen, out float[] Value);
        public abstract bool Write(string PlcValueKey, int ArrayLen, float[] Value);
        public abstract bool Read(string PlcValueKey, int ArrayLen, out ulong[] Value);
        public abstract bool Write(string PlcValueKey, int ArrayLen, ulong[] Value);
        public abstract bool Read(string PlcValueKey, int ArrayLen, out uint[] Value);
        public abstract bool Write(string PlcValueKey, int ArrayLen, uint[] Value);
        public abstract bool Read(string PlcValueKey, int ArrayLen, out ushort[] Value);
        public abstract bool Write(string PlcValueKey, int ArrayLen, ushort[] Value);
        public abstract bool Read(string PlcValueKey, int ArrayLen, out long[] Value);
        public abstract bool Write(string PlcValueKey, int ArrayLen, long[] Value);
        public abstract bool Read(string PlcValueKey, int ArrayLen, out int[] Value);
        public abstract bool Write(string PlcValueKey, int ArrayLen, int[] Value);
        public abstract bool Read(string PlcValueKey, int ArrayLen, out short[] Value);
        public abstract bool Write(string PlcValueKey, int ArrayLen, short[] Value);
        public abstract bool Read(string PlcValueKey, int ArrayLen, out byte[] Value);
        public abstract bool Write(string PlcValueKey, int ArrayLen, byte[] Value);
        public abstract bool Read(string PlcValueKey, int ArrayLen, out bool[] Value);
        public abstract bool Write(string PlcValueKey, int ArrayLen, bool[] Value);
        public abstract bool Read(string PlcValueKey, int Length, out string Value);
        public abstract bool Write(string PlcValueKey, int Length, string Value);
        public abstract bool Read(string PlcValueKey, out double Value);
        public abstract bool Write(string PlcValueKey, double Value);
        public abstract bool Read(string PlcValueKey, out float Value);
        public abstract bool Write(string PlcValueKey, float Value);
        public abstract bool Read(string PlcValueKey, out ulong Value);
        public abstract bool Write(string PlcValueKey, ulong Value);
        public abstract bool Read(string PlcValueKey, out uint Value);
        public abstract bool Write(string PlcValueKey, uint Value);
        public abstract bool Read(string PlcValueKey, out ushort Value);
        public abstract bool Write(string PlcValueKey, ushort Value);
        public abstract bool Read(string PlcValueKey, out long Value);
        public abstract bool Write(string PlcValueKey, long Value);
        public abstract bool Read(string PlcValueKey, out int Value);
        public abstract bool Write(string PlcValueKey, int Value);
        public abstract bool Read(string PlcValueKey, out short Value);
        public abstract bool Write(string PlcValueKey, short Value);
        public abstract bool Read(string PlcValueKey, out byte Value);
        public abstract bool Write(string PlcValueKey, byte Value);
        public abstract bool Read(string PlcValueKey, out bool Value);
        public abstract bool Write(string PlcValueKey, bool Value);
        public abstract bool ReadAny(string PlcValueKey, Type type, out object Value);
        public abstract bool WriteAny(string PlcValueKey, object Value);
        public abstract bool ReadAny(string PlcValueKey, out object[] Value);
        public abstract bool WriteAny(string PlcValueKey, object[] Value);

    }
}
