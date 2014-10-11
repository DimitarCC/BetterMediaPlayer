using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ptrampert.LibVLCBind
{
    /// <summary>
    /// Interface that exposes the underlying vlc version, compiler version, and changeset, and allows for the creation of new vlc instances.
    /// A concrete instance of this interface is the main entry point into LibVLCBind.
    /// </summary>
    public interface IVLCFactory
    {
        /// <summary>
        /// Gets the version of LibVLC.
        /// </summary>
        string LibVLCVersion { get; }

        /// <summary>
        /// Gets the version of the compiler LibVLC was compiled with.
        /// </summary>
        string LibVLCCompiler { get; }

        /// <summary>
        /// Gets the changeset of LibVLC
        /// </summary>
        string LibVLCChangeset { get; }

        /// <summary>
        /// Initializes a new IVLCInstance
        /// </summary>
        /// <returns>A new IVLCInstance</returns>
        IVLCInstance InitializeVLC();

        /// <summary>
        /// Initialize a new IVLCInstance with the given command line arguments. This generally should not be used,
        /// since the command line arguments are subject to change.
        /// </summary>
        /// <param name="args">The command line arguments to initialize with.</param>
        /// <returns>A new IVLCInstance</returns>
        IVLCInstance InitializeVLC(string[] args);
    }
}
