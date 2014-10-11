using com.ptrampert.LibVLCBind.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ptrampert.LibVLCBind.Util
{
    internal static class EventHelpers
    {
        /// <summary>
        /// Safely invokes an <code>EventHandler</code>.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">Event handler to invoke.</param>
        /// <param name="args">EventArgs.</param>
        public static void SafeEventInvoke(object sender, EventHandler e, EventArgs args)
        {
            EventHandler eCopy = e;
            if (eCopy != null)
                eCopy(sender, args);
        }

        /// <summary>
        /// Safely invokes an <code>EventHandler&lt;T&gt;</code>.
        /// </summary>
        /// <typeparam name="T">EventArgs type.</typeparam>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">Event handler to invoke.</param>
        /// <param name="args">EventArgs.</param>
        public static void SafeEventInvoke<T>(object sender, EventHandler<T> e, T args) where T : EventArgs
        {
            EventHandler<T> eCopy = e;
            if (eCopy != null)
                eCopy(sender, args);
        }

        /// <summary>
        /// Registers <code>callback</code> for all events between <code>min</code> and <code>max</code> (inclusive) with <code>eventManager</code>.
        /// </summary>
        /// <param name="eventManager">Event manager to register with.</param>
        /// <param name="min">Min event.</param>
        /// <param name="max">Max event.</param>
        /// <param name="callback">Callback on event.</param>
        public static void RegisterEvents(IntPtr eventManager, LIBVLC_EVENT min, LIBVLC_EVENT max, libvlc_callback_t callback)
        {
            for (LIBVLC_EVENT e = min; e <= max; e++)
            {
                int result = NativeMethods.libvlc_event_attach(eventManager, e, callback, IntPtr.Zero);
                if (result != 0)
                    throw new VLCException();
            }
        }

        /// <summary>
        /// Unregisters <code>callback</code> for all events between <code>min</code> and <code>max</code> (inclusive) with <code>eventManager</code>.
        /// </summary>
        /// <param name="eventManager">Event manger to unregister with.</param>
        /// <param name="min">Min event.</param>
        /// <param name="max">Max event.</param>
        /// <param name="callback">Callback on event.</param>
        public static void UnregisterEvents(IntPtr eventManager, LIBVLC_EVENT min, LIBVLC_EVENT max, libvlc_callback_t callback)
        {
            for (LIBVLC_EVENT e = min; e <= max; e++)
                NativeMethods.libvlc_event_detach(eventManager, e, callback, IntPtr.Zero);
        }
    }
}
