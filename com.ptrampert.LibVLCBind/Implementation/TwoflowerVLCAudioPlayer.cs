using com.ptrampert.LibVLCBind.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ptrampert.LibVLCBind.Implementation
{
    internal class TwoflowerVLCAudioPlayer : TwoflowerVLCMediaPlayer, IAudioPlayer
    {
        private AudioOutput audioOutput = null;

        /// <summary>
        /// Gets/Sets the current audio output.
        /// </summary>
        public AudioOutput AudioOutput
        {
            get
            {
                return audioOutput;
            }
            set
            {
                int status = NativeMethods.libvlc_audio_output_set(Handle, value.Name);
                if (status == -1)
                    throw new VLCException();
                audioOutput = value;
            }
        }

        /// <summary>
        /// Gets/Sets mute.
        /// </summary>
        public bool Mute
        {
            get
            {
                return NativeMethods.libvlc_audio_get_mute(Handle) == 0 ? false : true;
            }
            set
            {
                NativeMethods.libvlc_audio_set_mute(Handle, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Gets/Sets volume.
        /// </summary>
        public int Volume
        {
            get
            {
                return NativeMethods.libvlc_audio_get_volume(Handle);
            }
            set
            {
                int status = NativeMethods.libvlc_audio_set_volume(Handle, value);
                if (status == -1)
                    throw new VLCException("Volume out of range");
            }
        }

        /// <summary>
        /// Gets the available audio tracks.
        /// </summary>
        public IEnumerable<TrackDescription> AudioTracks
        {
            get
            {
                int count = NativeMethods.libvlc_audio_get_track_count(Handle);
                IntPtr ptr = NativeMethods.libvlc_audio_get_track_description(Handle);
                return GetTracks(count, ptr);
            }
        }

        /// <summary>
        /// Gets/Sets the current audio track.
        /// </summary>
        public TrackDescription AudioTrack
        {
            get
            {
                int id = NativeMethods.libvlc_audio_get_track(Handle);
                if (id == -1)
                    return null;
                return AudioTracks.Where(t => t.ID == id).SingleOrDefault();
            }
            set
            {
                int status = NativeMethods.libvlc_audio_set_track(Handle, value.ID);
                if (status == -1)
                    throw new VLCException();
            }
        }

        /// <summary>
        /// Gets/Sets the current audio channel.
        /// </summary>
        public int AudioChannel
        {
            get
            {
                return NativeMethods.libvlc_audio_get_channel(Handle);
            }
            set
            {
                int status = NativeMethods.libvlc_audio_set_channel(Handle, value);
                if (status == -1)
                    throw new VLCException();
            }
        }

        /// <summary>
        /// Gets/Sets the current audio delay (in milliseconds).
        /// </summary>
        public long AudioDelay
        {
            get
            {
                return NativeMethods.libvlc_audio_get_delay(Handle);
            }
            set
            {
                int status = NativeMethods.libvlc_audio_set_delay(Handle, value);
                if (status == -1)
                    throw new VLCException();
            }
        }

        internal TwoflowerVLCAudioPlayer(TwoflowerVLCInstance instance) : base(instance) { }

        internal TwoflowerVLCAudioPlayer(IMedia media) : base(media) { }
    }
}
