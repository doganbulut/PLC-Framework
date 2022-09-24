
using ServiceStack.Logging;
using ServiceStack.Logging.Log4Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCLog
{
    public class Logger: ILogger
    {
        
        protected string DefaultConfig 
        {
            get { return _DefaultConfig; }
            set { _DefaultConfig = value; } 
        }

        protected string _LogDirectory;
        private string _DefaultConfig;

        protected Log4NetFactory factory;
        protected ILog log;


        public Logger(string LogDirectory)
        {

            _LogDirectory = LogDirectory;
            _DefaultConfig = "<log4net>" +
                                "<appender name=\"FileAppender\" type=\"log4net.Appender.FileAppender\">" + "\n" +
                                "<file value=\"" + _LogDirectory + "\" />" + "\n" +
                                "<appendToFile value=\"true\" />" + "\n" +
                                "<lockingModel type=\"log4net.Appender.FileAppender+MinimalLock\" />" + "\n" +
                                "<layout type=\"log4net.Layout.PatternLayout\">" + "\n" +
                                "<conversionpattern value=\"%date [%thread] %-5level  – %message%newline\" />" + "\n" +
                                "</layout>" + "\n" +
                                "<filter type=\"log4net.Filter.LevelRangeFilter\">" + "\n" +
                                "<levelMin value=\"INFO\" />" + "\n" +
                                "<levelMax value=\"FATAL\" />" + "\n" +
                                "</filter>" + "\n" +
                                "</appender>" + "\n" +
                                "<root>" + "\n" +
                                "<level value=\"DEBUG\"/>" + "\n" +
                                "<appender-ref ref=\"FileAppender\"/>" + "\n" +
                                "</root>" + "\n" +
                                "</log4net>";

        }


        public bool initialize()
        {
            string conffile = Path.GetFileName(_LogDirectory);

            string logfile = Path.GetDirectoryName(_LogDirectory) + Path.ChangeExtension(conffile, ".config");

            string apppath = new Uri(Path.GetDirectoryName(
                                System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath;

            try
            {

                if (!File.Exists(apppath + "\\" + logfile))
                {
                    using (FileStream f = new FileStream(logfile, FileMode.CreateNew, FileAccess.Write))
                    using (StreamWriter s = new StreamWriter(f))
                        s.WriteLine(_DefaultConfig);
                }

            }
            catch
            {
                return false;
            }


            try
            {
                factory = new Log4NetFactory(logfile);
                log = new Log4NetLogger(GetType());
                return true;
            }
            catch
            {
                return false;
            }

        }
        

        public void Debug(object message)
        {
            log.Debug(message);
        }

        public void Debug(object message, Exception exception)
        {
            log.Debug(message,exception);
        }

        public void DebugFormat(string format, params object[] args)
        {
            log.DebugFormat(format,args);
        }

        public void Error(object message)
        {
            log.Error(message);
        }

        public void Error(object message, Exception exception)
        {
            log.Error(message, exception);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            log.ErrorFormat(format, args);
        }

        public void Fatal(object message)
        {
            log.Fatal(message);
        }

        public void Fatal(object message, Exception exception)
        {
            log.Fatal(message, exception);
        }

        public void FatalFormat(string format, params object[] args)
        {
            log.FatalFormat(format, args);
        }

        public void Info(object message)
        {
            log.Info(message);
        }

        public void Info(object message, Exception exception)
        {
            log.Info(message, exception);
        }

        public void InfoFormat(string format, params object[] args)
        {
            log.InfoFormat(format, args);
        }

        public void Warn(object message)
        {
            log.Warn(message);
        }

        public void Warn(object message, Exception exception)
        {
            log.Warn(message, exception);
        }

        public void WarnFormat(string format, params object[] args)
        {
            log.WarnFormat(format, args);
        }
    }
}
