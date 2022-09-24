using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FCPlc.PlcEvents;
using System.Windows.Forms;
using System.IO;


namespace FCPlc
{

    public class EventArgs<T> : EventArgs
    {
        public T Value { get; private set; }

        public EventArgs(T val)
        {
            Value = val;
        }
    }


    /// <summary>
    /// PLC' den değişen degerleri yakalamak icin kullanılır.</summary>
    /// <remarks>
    /// Istenilen yenileme zamanina gore belirlenen degerdeki degisiklikleri
    /// OnValueChanged olayi ile yakalanabilir.</remarks>
    public class PlcValueNotification<T> where T : struct,IConvertible, IComparable
    {
        public event EventHandler<EventArgs<T>> OnValueChanged;
        public event EventHandler<EventArgs<String>> OnInternalException;

        public Control ValueOwner { get; set; }
        public Control ExceptionOwner { get; set; }
        public bool FirstRunRead { get; set; }

        private Control _Owner;
        private IPlcController _PlcController;

        private volatile bool Stopper;
        private Thread Worker;
        private T currentValue;
        private string _PlcValue;
        private int _interval;

        public PlcValueNotification(Control Owner)
        {
            _Owner = Owner;
            Stopper = true;
        }

        public void Stop()
        {
            Stopper = true;
        }

        public void Start()
        {
            if (!Stopper)
                return;


            if (FirstRunRead)
            {
                try
                {
                    object eventlocker = new object();
                    object readValueObject;
                    if (_PlcController.ReadAny(_PlcValue, typeof(T), out readValueObject))
                    {
                        T readValue = (T)Convert.ChangeType(readValueObject, typeof(T));
                        if (readValue.CompareTo(currentValue) != 0)
                        {
                            currentValue = readValue;
                            ValueChanged(readValue);
                        }
                    }
                }
                catch (Exception InException)
                {
                    InternalException(InException.Message);
                }
            }

            Worker = new Thread(() => Work());
            Worker.IsBackground = true;
            Stopper = false;
            Worker.Start();

        }

        public void ValueChanged(T ChangedValue)
        {
            var tmpevent = OnValueChanged;
            if (ValueOwner == null && _Owner!=null )
            {
                // Invoke performed in the thread
                _Owner.Invoke((Action)(() =>
                {
                    if (tmpevent != null)
                        tmpevent(_Owner, new EventArgs<T>(ChangedValue));
                }));
            }
            else if (ValueOwner!=null)
            {
                // Invoke performed in the thread
                ValueOwner.Invoke((Action)(() =>
                {
                    if (tmpevent != null)
                        tmpevent(ValueOwner, new EventArgs<T>(ChangedValue));
                }));
            }
            else
            {                
                throw new InvalidDataException(@"notification'a owner tanımlamalısınız!!!");
            }
        }

        public void InternalException(String StrException)
        {
            var tmpevent = OnInternalException;
            if (ExceptionOwner == null && _Owner != null)
            {
                // Invoke performed in the thread
                _Owner.Invoke((Action)(() =>
                {
                    if (tmpevent != null)
                        tmpevent(_Owner, new EventArgs<string>(StrException));
                }));
            }
            else if (ExceptionOwner != null)
            {
                // Invoke performed in the thread
                ExceptionOwner.Invoke((Action)(() =>
                {
                    if (tmpevent != null)
                        tmpevent(ExceptionOwner, new EventArgs<string>(StrException));
                }));
            }
            else
            {
                throw new InvalidDataException(@"notification'a owner tanımlamalısınız!!!");
            }
        }

        public bool Init(IPlcController PlcController, string PlcValue, int interval)
        {
            try
            {
                _PlcController = PlcController;
                _PlcValue = PlcValue;
                _interval = interval;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Work()
        {
            object eventlocker = new object();
           
                while (!Stopper)
                {
                    try
                    {
                        object readValueObject;
                        if (_PlcController.ReadAny(_PlcValue, typeof(T), out readValueObject))
                        {
                            T readValue = (T)Convert.ChangeType(readValueObject, typeof(T));
                            if (readValue.CompareTo(currentValue) != 0)
                            {
                                lock (eventlocker)
                                    currentValue = readValue;

                                ValueChanged(readValue);
                            }
                        }
                    }
                    catch (Exception InException)
                    {
                        InternalException(InException.Message);
                    }
                  
                    Thread.Sleep(_interval);
                }
            }
            
           
        
    }
}
