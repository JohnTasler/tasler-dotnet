using System;
using System.Windows.Interop;

namespace Tasler.Windows.Input
{
    public static class KeyboardFilterService
    {
        #region KeyRepeatMinimumMilliseconds
        [ThreadStatic]
        private static uint? _keyRepeatMinimumMilliseconds;
        public static uint? KeyRepeatMinimumMilliseconds
        {
            get { return _keyRepeatMinimumMilliseconds; }
            set
            {
                if (_keyRepeatMinimumMilliseconds != value)
                {
                    if (_keyRepeatMinimumMilliseconds == null)
                        ComponentDispatcher.ThreadFilterMessage += ComponentDispatcher_ThreadFilterMessage;

                    _keyRepeatMinimumMilliseconds = value;

                    if (_keyRepeatMinimumMilliseconds == null)
                        ComponentDispatcher.ThreadFilterMessage -= ComponentDispatcher_ThreadFilterMessage;
                }
            }
        }

        private const int WM_KEYDOWN = 0x0100;
        private const int PreviousKeyStateMask = 1 << 30;

        [ThreadStatic]
        private static long _nextAllowedKeyTime;

        private static void ComponentDispatcher_ThreadFilterMessage(ref MSG msg, ref bool handled)
        {
            // This will prevent key repeats, which are annoying from a remote control
            if (msg.message == WM_KEYDOWN)
            {
                if ((msg.lParam.ToInt32() & PreviousKeyStateMask) != 0 && ((uint)msg.time) < _nextAllowedKeyTime)
                    handled = true;
                else
                    _nextAllowedKeyTime = (uint)msg.time + _keyRepeatMinimumMilliseconds.Value;
            }
        }

        #endregion KeyRepeatMinimumMilliseconds
    }
}
