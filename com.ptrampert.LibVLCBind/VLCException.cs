using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using com.ptrampert.LibVLCBind.Hooks;

namespace com.ptrampert.LibVLCBind
{
    /// <summary>
    /// Managed exception for encapsulating LibVLC errors.
    /// </summary>
    public class VLCException : Exception
    {
        /// <summary>
        /// Error message.
        /// </summary>
        protected string _err;

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public override string Message { get { return _err; } }

        /// <summary>
        /// Creates a new VLCException.
        /// </summary>
        internal VLCException()
            : base()
        {
            IntPtr errorPtr = NativeMethods.libvlc_errmsg();
            _err = errorPtr == IntPtr.Zero ? "VLC Exception" : Marshal.PtrToStringAnsi(errorPtr);
            NativeMethods.libvlc_free(errorPtr);
        }

        /// <summary>
        /// Creates a new VLCException with the given message.
        /// </summary>
        /// <param name="msg">The message</param>
        public VLCException(string msg)
            : base()
        {
            _err = msg;
        }
    }
}
