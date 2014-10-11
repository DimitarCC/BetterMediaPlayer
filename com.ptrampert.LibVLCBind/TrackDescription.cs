using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ptrampert.LibVLCBind
{
    /// <summary>
    /// Describes a track in a VLCMediaPlayer. There are a variety of track types, and the type can be determined by the property name.
    /// </summary>
    public class TrackDescription
    {
        /// <summary>
        /// Gets the track ID.
        /// </summary>
        public int ID { get; internal set; }

        /// <summary>
        /// Gets the track Name.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets whether or not the track has children (e.g. Title tracks may have Chapter child tracks).
        /// </summary>
        public bool HasChildren { get { return Children != null && Children.Count() != 0; } }

        /// <summary>
        /// Gets the track's children.
        /// </summary>
        public IEnumerable<TrackDescription> Children { get; internal set; }
    }
}
