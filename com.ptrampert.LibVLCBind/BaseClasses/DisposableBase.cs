using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ptrampert.LibVLCBind.BaseClasses
{
    internal abstract class DisposableBase : IDisposable
    {
        public bool IsDisposed { get; protected set; }

        public IntPtr Handle { get; internal set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DisposableBase()
        {
            Dispose(false);
        }

        protected abstract void Dispose(bool disposing);
    }
}
