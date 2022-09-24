using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FCPlc.PlcEvents;

namespace FCPlc
{
    public interface IPlcController
    {
        string PLCConnectionString { get; set; }
        bool Connect();
        bool DisConnect();
        bool ConnectionState();

        event EventHandler<PlcBasicEventArgs> OnPlcState;
        event EventHandler<PlcBasicEventArgs> OnPlcNotification;
        event EventHandler<PlcExceptionEventArgs> OnPlcException;


        bool Read(string PlcValueKey, int ArrayLen, int Length, out string[] Value);
        bool Write(string PlcValueKey, int ArrayLen, int Length, string[] Value);

        bool Read(string PlcValueKey, int ArrayLen, out double[] Value);
        bool Write(string PlcValueKey, int ArrayLen, double[] Value);

        bool Read(string PlcValueKey, int ArrayLen, out float[] Value);
        bool Write(string PlcValueKey, int ArrayLen, float[] Value);

        bool Read(string PlcValueKey, int ArrayLen, out ulong[] Value);
        bool Write(string PlcValueKey, int ArrayLen, ulong[] Value);

        bool Read(string PlcValueKey, int ArrayLen, out uint[] Value);
        bool Write(string PlcValueKey, int ArrayLen, uint[] Value);

        bool Read(string PlcValueKey, int ArrayLen, out ushort[] Value);
        bool Write(string PlcValueKey, int ArrayLen, ushort[] Value);

        bool Read(string PlcValueKey, int ArrayLen, out long[] Value);
        bool Write(string PlcValueKey, int ArrayLen, long[] Value);

        bool Read(string PlcValueKey, int ArrayLen, out int[] Value);
        bool Write(string PlcValueKey, int ArrayLen, int[] Value);

        bool Read(string PlcValueKey, int ArrayLen, out short[] Value);
        bool Write(string PlcValueKey, int ArrayLen, short[] Value);

        bool Read(string PlcValueKey, int ArrayLen, out byte[] Value);
        bool Write(string PlcValueKey, int ArrayLen, byte[] Value);

        bool Read(string PlcValueKey, int ArrayLen, out bool[] Value);
        bool Write(string PlcValueKey, int ArrayLen, bool[] Value);

        bool Read(string PlcValueKey, int Length, out string Value);
        bool Write(string PlcValueKey, int Length, string Value);

        bool Read(string PlcValueKey, out double Value);
        bool Write(string PlcValueKey, double Value);

        bool Read(string PlcValueKey, out float Value);
        bool Write(string PlcValueKey, float Value);

        bool Read(string PlcValueKey, out ulong Value);
        bool Write(string PlcValueKey, ulong Value);

        bool Read(string PlcValueKey, out uint Value);
        bool Write(string PlcValueKey, uint Value);

        bool Read(string PlcValueKey, out ushort Value);
        bool Write(string PlcValueKey, ushort Value);

        bool Read(string PlcValueKey, out long Value);
        bool Write(string PlcValueKey, long Value);

        bool Read(string PlcValueKey, out int Value);
        bool Write(string PlcValueKey, int Value);

        bool Read(string PlcValueKey, out short Value);
        bool Write(string PlcValueKey, short Value);

        bool Read(string PlcValueKey, out byte Value);
        bool Write(string PlcValueKey, byte Value);

        bool Read(string PlcValueKey, out bool Value);
        bool Write(string PlcValueKey, bool Value);

        bool ReadAny(string PlcValueKey, Type type, out object Value);
        bool WriteAny(string PlcValueKey, object Value);

        bool ReadAny(string PlcValueKey, out object[] Value);
        bool WriteAny(string PlcValueKey, object[] Value);

    }
}
