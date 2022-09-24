using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwinCAT.Ads;
using FCPlc.PlcEvents;
using System.Threading;

namespace FCPlc
{
    public class BeckhoffController : PlcController
    {

        private TcAdsClient AdsClient;
        public override string PLCConnectionString { get; set; }
             

        public BeckhoffController()
        {
            try
            {
                AdsClient = new TcAdsClient();
                OnNotification(new PlcBasicEventArgs("Ads Client Created"));
            }
            catch (Exception e)
            {
                OnException(new PlcExceptionEventArgs(e, "Ads Client Init Error"));
            }
        }

        public override bool Connect()
        {
            try
            {
                AdsClient.Connect(PLCConnectionString, 801);
                OnNotification(new PlcBasicEventArgs("Ads Client Connected to the PLC"));
                return ConnectionState();
            }
            catch (Exception e)
            {
                OnException(new PlcExceptionEventArgs(e, "Error Ads Client Not Connected"));
                return false;
            }
        }

        public override bool DisConnect()
        {
            try
            {
                AdsClient.Dispose();
                return true;
            }
            catch (Exception e)
            {
                OnException(new PlcExceptionEventArgs(e, "Error Ads Client Not DisConnected"));
                return false;
            }
        }

        public override bool ConnectionState()
        {
            return AdsClient.IsConnected;
        }

        private void PLCError(Exception PlcException, string PlcValueKey)
        {
            OnException(new PlcExceptionEventArgs(PlcException, PlcValueKey));
        }

        #region Beckhoff Control System Read-Write Functions

        private int CreateVariableHandle(string PlcValueKey)
        {
            try
            {
                return AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception ExPlc)
            {
                PLCError(ExPlc, PlcValueKey);
                return 0;
            }
        }

        public override bool Read(string PlcValueKey, int ArrayLen, int Length, out string[] Value)
        {
            int hVar;
            int istr = Length + 1;

            AdsStream stream = new AdsStream(ArrayLen * istr);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = null;
                return false;
            }
            //Bağlantı Üzerinden Okuma İşlemi(Dizi olduğunda biraz farklı)
            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;
                    string[] tmpValue = new string[ArrayLen];

                    for (int i = 0; i < ArrayLen; i++)
                        tmpValue[i] = binaryReader.ReadPlcString(istr);

                    Value = tmpValue;
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, int Length, string[] Value)
        {
            int hVar;
            int istr = Length + 1;

            AdsStream stream = new AdsStream(ArrayLen * istr);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    for (int i = 0; i < ArrayLen; i++)
                        binWrite.WritePlcString(Value[i].PadRight(Length), istr);

                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }


        public override bool Read(string PlcValueKey, int ArrayLen, out double[] Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(ArrayLen * 8);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = null;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;
                    double[] tmpValue = new double[ArrayLen];

                    for (int i = 0; i < ArrayLen; i++)
                        tmpValue[i] = binaryReader.ReadDouble();

                    Value = tmpValue;
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, double[] Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(ArrayLen * 8);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    for (int i = 0; i < ArrayLen; i++)
                        binWrite.Write(Value[i]);

                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Read(string PlcValueKey, int ArrayLen, out float[] Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(ArrayLen * 4);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = null;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;
                    float[] tmpValue = new float[ArrayLen];

                    for (int i = 0; i < ArrayLen; i++)
                        tmpValue[i] = binaryReader.ReadSingle();

                    Value = tmpValue;
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, float[] Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(ArrayLen * 4);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    for (int i = 0; i < ArrayLen; i++)
                        binWrite.Write(Value[i]);

                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }


        public override bool Read(string PlcValueKey, int ArrayLen, out ulong[] Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(ArrayLen * 8);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = null;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;
                    ulong[] tmpValue = new ulong[ArrayLen];

                    for (int i = 0; i < ArrayLen; i++)
                        tmpValue[i] = binaryReader.ReadUInt64();

                    Value = tmpValue;
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, ulong[] Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(ArrayLen * 8);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    for (int i = 0; i < ArrayLen; i++)
                        binWrite.Write(Value[i]);

                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Read(string PlcValueKey, int ArrayLen, out uint[] Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(ArrayLen * 4);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = null;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;
                    uint[] tmpValue = new uint[ArrayLen];

                    for (int i = 0; i < ArrayLen; i++)
                        tmpValue[i] = binaryReader.ReadUInt32();

                    Value = tmpValue;
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, uint[] Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(ArrayLen * 4);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    for (int i = 0; i < ArrayLen; i++)
                        binWrite.Write(Value[i]);

                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Read(string PlcValueKey, int ArrayLen, out ushort[] Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(ArrayLen * 2);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = null;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;
                    ushort[] tmpValue = new ushort[ArrayLen];

                    for (int i = 0; i < ArrayLen; i++)
                        tmpValue[i] = binaryReader.ReadUInt16();

                    Value = tmpValue;
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, ushort[] Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(ArrayLen * 2);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    for (int i = 0; i < ArrayLen; i++)
                        binWrite.Write(Value[i]);

                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Read(string PlcValueKey, int ArrayLen, out long[] Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(ArrayLen * 8);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = null;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;
                    long[] tmpValue = new long[ArrayLen];

                    for (int i = 0; i < ArrayLen; i++)
                        tmpValue[i] = binaryReader.ReadInt64();

                    Value = tmpValue;
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, long[] Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(ArrayLen * 8);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    for (int i = 0; i < ArrayLen; i++)
                        binWrite.Write(Value[i]);

                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Read(string PlcValueKey, int ArrayLen, out int[] Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(ArrayLen * 4);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = null;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;
                    int[] tmpValue = new int[ArrayLen];

                    for (int i = 0; i < ArrayLen; i++)
                        tmpValue[i] = binaryReader.ReadInt32();

                    Value = tmpValue;
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, int[] Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(ArrayLen * 4);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    for (int i = 0; i < ArrayLen; i++)
                        binWrite.Write(Value[i]);

                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }


        public override bool Read(string PlcValueKey, int ArrayLen, out short[] Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(ArrayLen * 2);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = null;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;
                    short[] tmpValue = new short[ArrayLen];

                    for (int i = 0; i < ArrayLen; i++)
                        tmpValue[i] = binaryReader.ReadInt16();

                    Value = tmpValue;
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, short[] Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(ArrayLen * 2);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    for (int i = 0; i < ArrayLen; i++)
                        binWrite.Write(Value[i]);

                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Read(string PlcValueKey, int ArrayLen, out byte[] Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(ArrayLen * 1);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = null;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;
                    byte[] tmpValue = new byte[ArrayLen];

                    for (int i = 0; i < ArrayLen; i++)
                        tmpValue[i] = binaryReader.ReadByte();

                    Value = tmpValue;
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, byte[] Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(ArrayLen * 1);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    for (int i = 0; i < ArrayLen; i++)
                        binWrite.Write(Value[i]);

                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Read(string PlcValueKey, int ArrayLen, out bool[] Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(ArrayLen);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = null;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;
                    bool[] tmpValue = new bool[ArrayLen];

                    for (int i = 0; i < ArrayLen; i++)
                        tmpValue[i] = binaryReader.ReadBoolean();

                    Value = tmpValue;
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, int ArrayLen, bool[] Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(ArrayLen);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    for (int i = 0; i < ArrayLen; i++)
                        binWrite.Write(Value[i]);

                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Read(string PlcValueKey, int Length, out string Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(Length + 1);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = null;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;

                    Value = binaryReader.ReadPlcString(Length + 1);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }

        }

        public override bool Write(string PlcValueKey, int Length, string Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(Length);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    binWrite.WritePlcString(Value.PadRight(Length), Length);
                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Read(string PlcValueKey, out double Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(8);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = 0;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;

                    Value = binaryReader.ReadDouble();
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = 0;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, double Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(8);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    binWrite.Write(Value);
                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Read(string PlcValueKey, out float Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(4);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = 0;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;
                    Value = binaryReader.ReadSingle();
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = 0;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, float Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(4);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    binWrite.Write(Value);
                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Read(string PlcValueKey, out ulong Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(8);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = 0;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;
                    Value = binaryReader.ReadUInt64();
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = 0;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, ulong Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(8);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    binWrite.Write(Value);
                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }


        public override bool Read(string PlcValueKey, out uint Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(4);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = 0;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;
                    Value = binaryReader.ReadUInt32();
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = 0;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, uint Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(4);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    binWrite.Write(Value);
                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Read(string PlcValueKey, out ushort Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(2);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = 0;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;
                    Value = binaryReader.ReadUInt16();
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = 0;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, ushort Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(2);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    binWrite.Write(Value);
                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }


        public override bool Read(string PlcValueKey, out long Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(8);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = 0;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;
                    Value = binaryReader.ReadInt64();
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = 0;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, long Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(8);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    binWrite.Write(Value);
                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Read(string PlcValueKey, out int Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(4);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = 0;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;
                    Value = binaryReader.ReadInt32();
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = 0;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, int Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(4);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    binWrite.Write(Value);
                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Read(string PlcValueKey, out short Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(2);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = 0;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;
                    Value = binaryReader.ReadInt16();
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = 0;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, short Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(2);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    binWrite.Write(Value);
                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Read(string PlcValueKey, out byte Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(1);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = 0;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;
                    Value = binaryReader.ReadByte();
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = 0;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, byte Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(1);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    binWrite.Write(Value);
                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }


        public override bool Read(string PlcValueKey, out bool Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(1);
            AdsBinaryReader binaryReader = new AdsBinaryReader(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = false;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.Read(hVar, stream);
                    stream.Position = 0;
                    Value = binaryReader.ReadBoolean();
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = false;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool Write(string PlcValueKey, bool Value)
        {
            int hVar;

            AdsStream stream = new AdsStream(1);
            AdsBinaryWriter binWrite = new AdsBinaryWriter(stream);

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                return false;
            }

            try
            {
                try
                {
                    binWrite.Write(Value);
                    stream.Position = 0;
                    AdsClient.Write(hVar, stream);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }


        public override bool ReadAny(string PlcValueKey, Type type, out object Value)
        {
            int hVar;

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = null;
                return false;
            }

            try
            {
                try
                {
                    Value = AdsClient.ReadAny(hVar, type);
                    return Value != null ? true : false;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    Value = null;
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }
        }

        public override bool WriteAny(string PlcValueKey, object Value)
        {
            int hVar;

            try
            {
                hVar = AdsClient.CreateVariableHandle(PlcValueKey);
            }
            catch (Exception exp)
            {
                PLCError(exp, PlcValueKey);
                Value = null;
                return false;
            }

            try
            {
                try
                {
                    AdsClient.WriteAny(hVar, Value);
                    return true;
                }
                catch (Exception exp)
                {
                    PLCError(exp, PlcValueKey);
                    return false;
                }
            }
            finally
            {
                AdsClient.DeleteVariableHandle(hVar);
            }

        }

        #endregion

        public override bool ReadAny(string PlcValueKey, out object[] Value)
        {
            throw new NotImplementedException();
        }

        public override bool WriteAny(string PlcValueKey, object[] Value)
        {
            throw new NotImplementedException();
        }
    }
}
