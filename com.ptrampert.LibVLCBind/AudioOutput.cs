using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ptrampert.LibVLCBind
{
    /// <summary>
    /// Describes an audio output and its associated devices.
    /// </summary>
    public class AudioOutput
    {
        /// <summary>
        /// Gets the name of the output.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the description of the output.
        /// </summary>
        public string Description { get; internal set; }
    }
}
