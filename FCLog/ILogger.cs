using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCLog
{
    public interface ILogger
    {
        bool initialize();

        void Debug(object message);
        //
        // Summary:
        //     Logs a Debug message and exception.
        //
        // Parameters:
        //   message:
        //     The message.
        //
        //   exception:
        //     The exception.
        void Debug(object message, Exception exception);
        //
        // Summary:
        //     Logs a Debug format message.
        //
        // Parameters:
        //   format:
        //     The format.
        //
        //   args:
        //     The args.
        void DebugFormat(string format, params object[] args);
        //
        // Summary:
        //     Logs a Error message.
        //
        // Parameters:
        //   message:
        //     The message.
        void Error(object message);
        //
        // Summary:
        //     Logs a Error message and exception.
        //
        // Parameters:
        //   message:
        //     The message.
        //
        //   exception:
        //     The exception.
        void Error(object message, Exception exception);
        //
        // Summary:
        //     Logs a Error format message.
        //
        // Parameters:
        //   format:
        //     The format.
        //
        //   args:
        //     The args.
        void ErrorFormat(string format, params object[] args);
        //
        // Summary:
        //     Logs a Fatal message.
        //
        // Parameters:
        //   message:
        //     The message.
        void Fatal(object message);
        //
        // Summary:
        //     Logs a Fatal message and exception.
        //
        // Parameters:
        //   message:
        //     The message.
        //
        //   exception:
        //     The exception.
        void Fatal(object message, Exception exception);
        //
        // Summary:
        //     Logs a Error format message.
        //
        // Parameters:
        //   format:
        //     The format.
        //
        //   args:
        //     The args.
        void FatalFormat(string format, params object[] args);
        //
        // Summary:
        //     Logs an Info message and exception.
        //
        // Parameters:
        //   message:
        //     The message.
        void Info(object message);
        //
        // Summary:
        //     Logs an Info message and exception.
        //
        // Parameters:
        //   message:
        //     The message.
        //
        //   exception:
        //     The exception.
        void Info(object message, Exception exception);
        //
        // Summary:
        //     Logs an Info format message.
        //
        // Parameters:
        //   format:
        //     The format.
        //
        //   args:
        //     The args.
        void InfoFormat(string format, params object[] args);
        //
        // Summary:
        //     Logs a Warning message.
        //
        // Parameters:
        //   message:
        //     The message.
        void Warn(object message);
        //
        // Summary:
        //     Logs a Warning message and exception.
        //
        // Parameters:
        //   message:
        //     The message.
        //
        //   exception:
        //     The exception.
        void Warn(object message, Exception exception);
        //
        // Summary:
        //     Logs a Warning format message.
        //
        // Parameters:
        //   format:
        //     The format.
        //
        //   args:
        //     The args.
        void WarnFormat(string format, params object[] args);
    }
}
