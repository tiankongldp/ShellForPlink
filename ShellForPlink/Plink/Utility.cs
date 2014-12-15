using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ShellForPlink
{
    public delegate void DataOutputHandler(int type, LogLevel level, string data);
    public delegate void ConnectionStateChangeHandler(ConnectionStatus lastState, ConnectionStatus curState);
    public delegate void PingFaildThreeHandler();

    public enum ConnectionStatus
    {
        idle,
        StartConnecting,
        ReConnecting,
        KeyConfirm,
        SendingUseName,
        SendingPassword,
        Authenticated,
        Connected,
        PingTunnelOpened,
        ConnectAborted,
        PingFailedStopd,
        ManualStoped
    }
    public enum LogLevel
    {
        Normal,
        Warning,
        Detail
    }

    public class Utility
    {
        private const string IP = @"(((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-4]|[01]?\d\d?))";
        private const string DoMain = @"(([a-zA-Z0-9]([a-zA-Z0-9\-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,6})";
        private const string Port = @"([0-9]|[1-9]\d|[1-9]\d{2}|[1-9]\d{3}|[1-5]\d{4}|6[0-4]\d{3}|65[0-4]\d{2}|655[0-2]\d|6553[0-5])";
        private const string IPOrDoMain = @"(" + IP + @"|" + DoMain + @")";
        private const string IPAndPort = @"((" + IP + @"\:)?" + Port + @")";

        private const string rgLookingup = @"^Looking up host """ + IPOrDoMain + @""".*$";
        private const string rgConnecting = @"^Connecting to " + IP + @" port \d{1,5}$";
        private const string rgUsername = @"^Using username "".+""\.$";
        private const string rgPassword = @"^.+\@" + IPOrDoMain + @"\'s password\:$";
        private const string rgStoreKey = @"^The server\'s host key is not cached in the registry\..*$";
        private const string rgAccessGranted = @"^Access granted$";
        private const string rgDynamicSocks = @"^Local port .+ SOCKS dynamic forwarding$";
        private const string rgLocalportForward = @"^Local port .+ forwarding to .+$";
        private static string rgRemoteportForward = @"^Remote port forwarding from .+ enabled$";

        private const string rgPortConnInfo1 = @"^Opening connection to .+ for forwarding$";
        private const string rgPortConnInfo2 = @"^Forwarded port closed$";
        private const string rgPortConnInfo3 = @"^Forwarded port opened successfully$";
        private const string rgPortConnInfo4 = @"^Received remote port .+ open request from .+$";
        private const string rgPortConnInfo5 = @"^Attempting to forward remote port to .+$";
        private const string rgPortConnInfo6 = @"^Forwarded port closed due to local error";

        public static bool IsLookingup(string input, RegexOptions ro = RegexOptions.IgnoreCase)
        {
            return Regex.IsMatch(input, rgLookingup, ro);
        }
        public static bool IsConnecting(string input, RegexOptions ro = RegexOptions.IgnoreCase)
        {
            return Regex.IsMatch(input, rgConnecting, ro);
        }
        public static bool IsUsername(string input, RegexOptions ro = RegexOptions.IgnoreCase)
        {
            return Regex.IsMatch(input, rgUsername, ro);
        }
        public static bool IsPassword(string input, RegexOptions ro = RegexOptions.IgnoreCase)
        {
            return Regex.IsMatch(input, rgPassword, ro);
        }
        public static bool IsStoreKey(string input, RegexOptions ro = RegexOptions.IgnoreCase)
        {
            return Regex.IsMatch(input, rgStoreKey, ro);
        }
        public static bool IsAccessGranted(string input, RegexOptions ro = RegexOptions.IgnoreCase)
        {
            return Regex.IsMatch(input, rgAccessGranted, ro);
        }
        public static bool IsDynamicSocks(string input, RegexOptions ro = RegexOptions.IgnoreCase)
        {
            return Regex.IsMatch(input, rgDynamicSocks, ro);
        }
        public static bool IsLocalportForward(string input, RegexOptions ro = RegexOptions.IgnoreCase)
        {
            return Regex.IsMatch(input, rgLocalportForward, ro);
        }
        public static bool IsRemoteportForward(string input, RegexOptions ro = RegexOptions.IgnoreCase)
        {
            return Regex.IsMatch(input, rgRemoteportForward, ro);
        }
        public static bool IsPingRemoteForward(string input, int Port, RegexOptions ro = RegexOptions.IgnoreCase)
        {
            string rgPingRemoteForward = @"^Remote port forwarding from " + Port + @" enabled$";
            return Regex.IsMatch(input, rgPingRemoteForward, ro);
        }
        public static bool IsPortConnInfo(string input, RegexOptions ro = RegexOptions.IgnoreCase)
        {
            return (Regex.IsMatch(input, rgPortConnInfo1, ro) || 
                Regex.IsMatch(input, rgPortConnInfo2, ro) || 
                Regex.IsMatch(input, rgPortConnInfo3, ro) || 
                Regex.IsMatch(input, rgPortConnInfo4, ro) ||
                Regex.IsMatch(input, rgPortConnInfo5, ro) ||
                Regex.IsMatch(input, rgPortConnInfo6, ro) );
        }

    }
}
