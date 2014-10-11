using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace com.ptrampert.LibVLCBind.Hooks
{
    internal static partial class NativeMethods
    {
        /// <summary>
        /// Create a media with a certain given media resource location, for instance a valid URL.
        /// </summary>
        /// <param name="p_instance">the instance</param>
        /// <param name="psz_mrl">the media location</param>
        /// <returns>the newly created media or NULL on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_new_location(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string psz_mrl);

        /// <summary>
        /// Create a media for a certain file path.
        /// </summary>
        /// <param name="p_instance">the instance</param>
        /// <param name="path">local filesystem path</param>
        /// <returns>the newly created media or NULL on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_new_path(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string path);

        /// <summary>
        /// Create a media for an already open file descriptor.
        /// The file descriptor shall be open for reading (or reading and writing).
        /// Regular file descriptors, pipe read descriptors and character device descriptors (including TTYs) are 
        /// supported on all platforms. Block device descriptors are supported where available. Directory 
        /// descriptors are supported on systems that provide fdopendir(). Sockets are supported on all platforms 
        /// where they are file descriptors, i.e. all except Windows.
        /// </summary>
        /// <param name="p_instance">the instance</param>
        /// <param name="fd">open file descriptor</param>
        /// <returns>the newly created media or NULL on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_new_fd(IntPtr p_instance, int fd);

        /// <summary>
        /// Create a media as an empty node with a given name.
        /// </summary>
        /// <param name="p_instance">the instance</param>
        /// <param name="psz_name">the name of the node</param>
        /// <returns>the new empty media or NULL on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_new_as_node(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string psz_name);

        /// <summary>
        /// Decrement the reference count of a media descriptor object.
        /// If the reference count is 0, then libvlc_media_release() will release the media descriptor object. 
        /// It will send out a libvlc_MediaFreed event to all listeners. If the media descriptor object has been released it should not be used again.
        /// </summary>
        /// <param name="p_md">the media descriptor</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_release(IntPtr p_md);

        /// <summary>
        /// Add an option to the media.
        /// This option will be used to determine how the media_player will read the media. This allows to use VLC's advanced reading/streaming options on a per-media basis.
        /// </summary>
        /// <param name="p_md">the media descriptor</param>
        /// <param name="ppsz_options">the options (as a string)</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_add_option(IntPtr p_md, [MarshalAs(UnmanagedType.LPStr)] string ppsz_options);

        /// <summary>
        /// Add an option to the media with configurable flags.
        /// This option will be used to determine how the media_player will read the media. This allows the use of VLC's advanced reading/streaming options on a per-media basis.
        /// </summary>
        /// <param name="p_md">the media descriptor</param>
        /// <param name="ppsz_options">the options (as a string)</param>
        /// <param name="i_flags">the flags for this option</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_add_option_flag(IntPtr p_md, [MarshalAs(UnmanagedType.LPStr)] string ppsz_options, uint i_flags);

        /// <summary>
        /// Get the media resource locator (mrl) from a media descriptor object.
        /// </summary>
        /// <param name="p_md">a media descriptor object</param>
        /// <returns>string with mrl of media descriptor object</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_get_mrl(IntPtr p_md);

        /// <summary>
        /// Duplicate a media descriptor object.
        /// </summary>
        /// <param name="p_md">a media descriptor object.</param>
        /// <returns>a new identical media descriptor object.</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_duplicate(IntPtr p_md);

        /// <summary>
        /// Read the meta of the media.
        /// If the media has not yet been parsed this will return NULL.
        /// This methods automatically calls libvlc_media_parse_async(), so after calling it you may receive a libvlc_MediaMetaChanged event. 
        /// If you prefer a synchronous version ensure that you call libvlc_media_parse() before get_meta().
        /// </summary>
        /// <param name="p_md">the media descriptor</param>
        /// <param name="e_meta">the meta to read</param>
        /// <returns>the media's meta</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_get_meta(IntPtr p_md, int e_meta);

        /// <summary>
        /// Set the meta of the media (this function will not save the meta, call libvlc_media_save_meta in order to save the meta).
        /// </summary>
        /// <param name="p_md">the media descriptor</param>
        /// <param name="e_meta">the meta to write</param>
        /// <param name="psz_value">the media's meta</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_set_meta(IntPtr p_md, int e_meta, [MarshalAs(UnmanagedType.LPStr)] string psz_value);

        /// <summary>
        /// Save the meta previously set.
        /// </summary>
        /// <param name="p_md">the media descriptor</param>
        /// <returns>true if the write operation was successful</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_media_save_meta(IntPtr p_md);

        /// <summary>
        /// Get current state of media descriptor object.
        /// Possible media states are defined in libvlc_structures.c ( libvlc_NothingSpecial=0, libvlc_Opening, libvlc_Buffering, libvlc_Playing, libvlc_Paused, libvlc_Stopped, libvlc_Ended, libvlc_Error).
        /// </summary>
        /// <param name="p_md">a media descriptor object</param>
        /// <returns>state of media descriptor object</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_media_get_state(IntPtr p_md);

        /// <summary>
        /// Get the current statistics about the media.
        /// </summary>
        /// <param name="p_md">media descriptor object</param>
        /// <param name="p_stats">structure that contains the statistics about the media (this structure must be allocated by the caller)</param>
        /// <returns>true if the statistics are available, false otherwise.</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_media_get_stats(IntPtr p_md, IntPtr p_stats);

        /// <summary>
        /// Get subitems of media descriptor object.
        /// This will increment the reference count of supplied media descriptor object. Use libvlc_media_list_release() to decrement the reference counting.
        /// </summary>
        /// <param name="p_md">the media descriptor</param>
        /// <returns>list of media descriptor subitems or NULL.</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_subitems(IntPtr p_md);

        /// <summary>
        /// Get event manager from media descriptor object.
        /// </summary>
        /// <param name="p_md">a media descriptor object.</param>
        /// <returns>event manager object.</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_event_manager(IntPtr p_md);

        /// <summary>
        /// Get duration (in ms) of media descriptor object item.
        /// </summary>
        /// <param name="p_md">media descriptor object.</param>
        /// <returns>duration of media item or -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern long libvlc_media_get_duration(IntPtr p_md);

        /// <summary>
        /// Parse a media.
        /// This fetches (local) meta data and tracks information. The method is synchronous.
        /// </summary>
        /// <param name="p_md">media descriptor object</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_parse(IntPtr p_md);

        /// <summary>
        /// Parse a media.
        /// This fetches (local) meta data and tracks information. The method is the asynchronous of libvlc_media_parse().
        /// To track when this is over you can listen to libvlc_MediaParsedChanged event. However if the media was already parsed you will not receive this event.
        /// </summary>
        /// <param name="p_md">media descriptor object</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_parse_async(IntPtr p_md);

        /// <summary>
        /// Get Parsed status for media descriptor object.
        /// </summary>
        /// <param name="p_md">media descriptor object</param>
        /// <returns>true if media object has been parsed otherwise it returns false</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_media_is_parsed(IntPtr p_md);

        /// <summary>
        /// Get media descriptor's elementary streams description.
        /// Note, you need to call libvlc_media_parse() or play the media at least once before calling this function. Not doing this will result in an empty array.
        /// </summary>
        /// <param name="p_md">media descriptor object</param>
        /// <param name="tracks">address to store an allocated array of Elementary Streams descriptions (must be freed by the caller) [OUT]</param>
        /// <returns>the number of Elementary Streams</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_media_get_tracks_info(IntPtr p_md, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] tracks);
    }
}
