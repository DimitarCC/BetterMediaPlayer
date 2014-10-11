using com.ptrampert.LibVLCBind.BaseClasses;
using com.ptrampert.LibVLCBind.Hooks;
using com.ptrampert.LibVLCBind.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace com.ptrampert.LibVLCBind.Implementation
{
    /// <summary>
    /// Wrapper around libvlc_instance_t. This class must be created before any other VLC classes can be used.
    /// </summary>
    internal class TwoflowerVLCInstance : DisposableBase, IVLCInstance
    {
        /// <summary>
        /// Gets a list of the available AudioOutputs and their associated devices.
        /// </summary>
        public IEnumerable<AudioOutput> AudioOutputs
        {
            get
            {
                IntPtr ptr = NativeMethods.libvlc_audio_output_list_get(Handle);
                if (ptr == IntPtr.Zero)
                    throw new VLCException();
                libvlc_audio_output_t tmp = new libvlc_audio_output_t
                {
                    p_next = ptr,
                    psz_description = null,
                    psz_name = null
                };
                try
                {
                    while (tmp.p_next != IntPtr.Zero)
                    {
                        tmp = (libvlc_audio_output_t)Marshal.PtrToStructure(tmp.p_next, typeof(libvlc_audio_output_t));
                        yield return new AudioOutput
                        {
                            Name = tmp.psz_name,
                            Description = tmp.psz_description
                        };
                    }
                }
                finally
                {
                    if (ptr != IntPtr.Zero)
                        NativeMethods.libvlc_audio_output_list_release(ptr);
                }

            }
        }

        /// <summary>
        /// Instantiates a new instance of libvlc.
        /// </summary>
        public TwoflowerVLCInstance()
        {
            Handle = NativeMethods.libvlc_new(0, null);
            if (Handle == IntPtr.Zero)
                throw new VLCException();
        }

        /// <summary>
        /// Instantiates a new instance of libvlc.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public TwoflowerVLCInstance(string[] args)
        {
            int length = args == null ? 0 : args.Length;
            Handle = NativeMethods.libvlc_new(length, args);
            if (Handle == IntPtr.Zero)
                throw new VLCException();
        }

        /// <summary>
        /// Creates a new IMedia object.
        /// </summary>
        /// <param name="url">Resource location string for the media.</param>
        /// <param name="local">If url is a local filepath, use true. Otherwise, use false.</param>
        /// <returns>New IMedia object.</returns>
        public IMedia GetVLCMedia(string url, bool local)
        {
            return new TwoflowerVLCMedia(this, url, local);
        }

        /// <summary>
        /// Creates a new, empty TMediaPlayer, where TMediaPlayer implements IMediaPlayer
        /// </summary>
        /// <typeparam name="TMediaPlayer">Type of media player to create.</typeparam>
        /// <returns>New TMediaPlayer</returns>
        public TMediaPlayer CreateMediaPlayer<TMediaPlayer>() 
            where TMediaPlayer : class, IMediaPlayer
        {
            return CreateMediaPlayer() as TMediaPlayer;
        }

        /// <summary>
        /// Creates a new TMediaPlayer from an existing IMedia.
        /// </summary>
        /// <typeparam name="TMediaPlayer">Type of media player to create</typeparam>
        /// <param name="media">Media to load into the player.</param>
        /// <returns>New TMediaPlayer</returns>
        public TMediaPlayer CreateMediaPlayer<TMediaPlayer>(IMedia media)
            where TMediaPlayer : class, IMediaPlayer
        {
            return new TwoflowerVLCVideoPlayer(media) as TMediaPlayer;
        }

        /// <summary>
        /// Creates a new, empty IMediaPlayer
        /// </summary>
        /// <returns>New IMediaPlayer</returns>
        public IMediaPlayer CreateMediaPlayer()
        {
            return new TwoflowerVLCVideoPlayer(this);
        }

        internal static string EventTypeName(LIBVLC_EVENT e)
        {
            IntPtr result = NativeMethods.libvlc_event_type_name(e);
            if (result == IntPtr.Zero)
                return "Not an Event";
            string str = Marshal.PtrToStringAnsi(result);
            NativeMethods.libvlc_free(result);
            return str;
        }

        ~TwoflowerVLCInstance()
        {
            Dispose(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (Handle != IntPtr.Zero)
                {
                    NativeMethods.libvlc_release(Handle);
                }
                IsDisposed = true;
            }
        }
    }
}
