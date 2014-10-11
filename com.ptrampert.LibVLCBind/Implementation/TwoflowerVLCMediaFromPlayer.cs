using com.ptrampert.LibVLCBind.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace com.ptrampert.LibVLCBind.Implementation
{
    /// <summary>
    /// Represents a VLCMedia that was obtained from a MediaPlayer. Enables retreival of Stats property.
    /// </summary>
    internal class TwoflowerVLCMediaFromPlayer : TwoflowerVLCMedia
    {
        public TwoflowerVLCMediaFromPlayer(IntPtr ptr) : base(ptr)
        {
        }

        public override MediaStats Stats
        {
            get
            {
                libvlc_media_stats_t stats = new libvlc_media_stats_t();
                IntPtr ptr = IntPtr.Zero;
                try
                {
                    ptr = Marshal.AllocHGlobal(Marshal.SizeOf(stats));
                    Marshal.StructureToPtr(stats, ptr, false);
                    if (NativeMethods.libvlc_media_get_stats(Handle, ptr) == 0)
                        return null;
                    stats = (libvlc_media_stats_t)Marshal.PtrToStructure(Handle, typeof(libvlc_media_stats_t));
                    return new MediaStats(stats);
                }
                finally
                {
                    if (ptr != IntPtr.Zero)
                        Marshal.FreeHGlobal(ptr);
                }
            }
        }
    }
}
