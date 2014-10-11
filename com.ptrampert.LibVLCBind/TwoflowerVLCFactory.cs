using com.ptrampert.LibVLCBind.Hooks;
using com.ptrampert.LibVLCBind.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace com.ptrampert.LibVLCBind
{
    /// <summary>
    /// IVLCFactory that instantiates a Twoflower (VLC v2.x.x) instance.
    /// </summary>
    public class TwoflowerVLCFactory : IVLCFactory
    {
        /// <summary>
        /// Gets the version of LibVLC.
        /// </summary>
        public string LibVLCVersion
        {
            get
            {
                return Marshal.PtrToStringAnsi(NativeMethods.libvlc_get_version());
            }
        }

        /// <summary>
        /// Gets the version of the compiler LibVLC was compiled with.
        /// </summary>
        public string LibVLCCompiler
        {
            get
            {
                return Marshal.PtrToStringAnsi(NativeMethods.libvlc_get_compiler());
            }
        }

        /// <summary>
        /// Gets the changeset of LibVLC
        /// </summary>
        public string LibVLCChangeset
        {
            get
            {
                return Marshal.PtrToStringAnsi(NativeMethods.libvlc_get_changeset());
            }
        }

        /// <summary>
        /// Initializes a new IVLCInstance
        /// </summary>
        /// <returns>A new IVLCInstance</returns>
        public IVLCInstance InitializeVLC()
        {
            return new TwoflowerVLCInstance();
        }

        /// <summary>
        /// Initializes a new IVLCInstance with the provided command line arguments.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        /// <returns>A new IVLCInstance</returns>
        public IVLCInstance InitializeVLC(string[] args)
        {
            return new TwoflowerVLCInstance(args);
        }
    }
}
