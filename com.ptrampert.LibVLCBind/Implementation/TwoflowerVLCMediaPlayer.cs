using com.ptrampert.LibVLCBind.BaseClasses;
using com.ptrampert.LibVLCBind.Hooks;
using com.ptrampert.LibVLCBind.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace com.ptrampert.LibVLCBind.Implementation
{
    /// <summary>
    /// Wrapper around libvlc_media_player_t.
    /// </summary>
    internal class TwoflowerVLCMediaPlayer : DisposableBase, IMediaPlayer
    {
        #region Private Fields

        /// <summary>
        /// Delegate used by the event manager to signal callbacks.
        /// </summary>
        private libvlc_callback_t handler;

        /// <summary>
        /// Pointer to this media player's event manager.
        /// </summary>
        private IntPtr eventManager;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets/Sets the current media.
        /// </summary>
        public IMedia Media
        {
            get
            {
                IntPtr ptr = NativeMethods.libvlc_media_player_get_media(Handle);
                if (ptr == IntPtr.Zero)
                    return null;
                return new TwoflowerVLCMediaFromPlayer(ptr);
            }
            set
            {
                if (value == null)
                    NativeMethods.libvlc_media_player_set_media(Handle, IntPtr.Zero);
                else if (value is TwoflowerVLCMedia)
                    NativeMethods.libvlc_media_player_set_media(Handle, value.Handle);
            }
        }

        /// <summary>
        /// Is the player playing?
        /// </summary>
        public bool IsPlaying { get { return NativeMethods.libvlc_media_player_is_playing(Handle) == 1 ? true : false; } }

        /// <summary>
        /// Gets the length of the current media.
        /// </summary>
        public long Length { get { return NativeMethods.libvlc_media_player_get_length(Handle); } }

        /// <summary>
        /// Gets/Sets the current time of the current media (in milliseconds).
        /// </summary>
        public long Time
        {
            get
            {
                return NativeMethods.libvlc_media_player_get_time(Handle);
            }
            set
            {
                NativeMethods.libvlc_media_player_set_time(Handle, value);
            }
        }

        /// <summary>
        /// Gets/Sets the current position of the current media (percentage between 0.0 and 1.0).
        /// </summary>
        public float Position
        {
            get
            {
                float pos = NativeMethods.libvlc_media_player_get_position(Handle);
                if (pos == -1)
                    throw new VLCException();
                return pos;
            }
            set
            {
                NativeMethods.libvlc_media_player_set_position(Handle, value);
            }
        }

        /// <summary>
        /// Gets/Sets the requested playback rate.
        /// </summary>
        public float Rate
        {
            get
            {
                return NativeMethods.libvlc_media_player_get_rate(Handle);
            }
            set
            {
                NativeMethods.libvlc_media_player_set_rate(Handle, value);
            }
        }

        /// <summary>
        /// Gets the current player state.
        /// </summary>
        public LIBVLC_STATE State { get { return (LIBVLC_STATE)NativeMethods.libvlc_media_player_get_state(Handle); } }

        /// <summary>
        /// Is the player seekable?
        /// </summary>
        public bool IsSeekable { get { return NativeMethods.libvlc_media_player_is_seekable(Handle) == 0 ? false : true; } }

        /// <summary>
        /// Can the player be paused?
        /// </summary>
        public bool IsPausable { get { return NativeMethods.libvlc_media_player_can_pause(Handle) == 0 ? false : true; } }

        /// <summary>
        /// Will the player play if <code>Play()</code> is called?
        /// </summary>
        public bool WillPlay { get { return NativeMethods.libvlc_media_player_will_play(Handle) == 0 ? false : true; } }
        #endregion

        #region Events
        /// <summary>
        /// Called when the media is changed. The new media is passed in the event args.
        /// </summary>
        public event EventHandler<MediaChangedEventArgs> MediaChanged;

        /// <summary>
        /// Called when state changes to <value>LIBVLC_STATE.NOTHING_SPECIAL</value>
        /// </summary>
        public event EventHandler NothingSpecial;

        /// <summary>
        /// Called when state changes to <value>LIBVLC_STATE.OPENING</value>
        /// </summary>
        public event EventHandler Opening;

        /// <summary>
        /// Called when state changes to <value>LIBVLC_STATE.BUFFERING</value>.
        /// The percentage complete is passed in the event args.
        /// </summary>
        public event EventHandler<FloatEventArgs> Buffering;

        /// <summary>
        /// Called when state changes to <value>LIBVLC_STATE.PLAYING</value>
        /// </summary>
        public event EventHandler Playing;

        /// <summary>
        /// Called when state changes to <value>LIBVLC_STATE.PAUSED</value>
        /// </summary>
        public event EventHandler Paused;

        /// <summary>
        /// Called when state changes to <value>LIBVLC_STATE.STOPPED</value>
        /// </summary>
        public event EventHandler Stopped;

        /// <summary>
        /// Called when state changes to <value>LIBVLC_STATE.FORWARD</value>
        /// </summary>
        public event EventHandler Forward;

        /// <summary>
        /// Called when state changes to <value>LIBVLC_STATE.BACKWARD</value>
        /// </summary>
        public event EventHandler Backward;

        /// <summary>
        /// Called when state changes to <value>LIBVLC_STATE.END_REACHED</value>
        /// </summary>
        public event EventHandler EndReached;

        /// <summary>
        /// Called when the media player encounters an error. The exception is passed in the event args.
        /// </summary>
        public event EventHandler<EncounteredErrorEventArgs> EncounteredError;

        /// <summary>
        /// Called when the media player's Time changes. The new time is passed in the event args.
        /// </summary>
        public event EventHandler<LongEventArgs> TimeChanged;

        /// <summary>
        /// Called when the media player's position changes. The new position is passed in the event args.
        /// </summary>
        public event EventHandler<FloatEventArgs> PositionChanged;

        /// <summary>
        /// Called when <code>IsSeekable</code> changes. The new state is passed in the event args.
        /// </summary>
        public event EventHandler<BoolEventArgs> IsSeekableChanged;

        /// <summary>
        /// Called when <code>IsPausable</code> changes. The new state is passed in the event args.
        /// </summary>
        public event EventHandler<BoolEventArgs> IsPausableChanged;

        /// <summary>
        /// Called when the media player's length is changed. The new length is passed in the event args.
        /// </summary>
        public event EventHandler<LongEventArgs> LengthChanged;
        #endregion

        #region Constructors
        internal TwoflowerVLCMediaPlayer(TwoflowerVLCInstance instance)
        {
            Handle = NativeMethods.libvlc_media_player_new(instance.Handle);
            if (Handle == IntPtr.Zero) throw new VLCException();
            eventManager = NativeMethods.libvlc_media_player_event_manager(Handle);
            handler = MarshalEvent;
            EventHelpers.RegisterEvents(eventManager, LIBVLC_EVENT.MEDIA_PLAYER_MEDIA_CHANGED, LIBVLC_EVENT.MEDIA_PLAYER_VOUT, handler);
        }

        internal TwoflowerVLCMediaPlayer(IMedia media)
        {
            Handle = NativeMethods.libvlc_media_player_new_from_media(media.Handle);
            if (Handle == IntPtr.Zero) throw new VLCException();
            eventManager = NativeMethods.libvlc_media_player_event_manager(Handle);
            handler = MarshalEvent;
            EventHelpers.RegisterEvents(eventManager, LIBVLC_EVENT.MEDIA_PLAYER_MEDIA_CHANGED, LIBVLC_EVENT.MEDIA_PLAYER_VOUT, handler);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Plays the player.
        /// </summary>
        public void Play()
        {
            if (NativeMethods.libvlc_media_player_play(Handle) == -1)
                throw new VLCException();
        }

        /// <summary>
        /// Toggles pause on the player.
        /// </summary>
        public void Pause()
        {
            NativeMethods.libvlc_media_player_pause(Handle);
        }

        /// <summary>
        /// Stops the player.
        /// </summary>
        public void Stop()
        {
            NativeMethods.libvlc_media_player_stop(Handle);
        }

        /// <summary>
        /// Toggles teletext on the player.
        /// </summary>
        public void ToggleTeletext()
        {
            NativeMethods.libvlc_toggle_teletext(Handle);
        }

        /// <summary>
        /// Jump to previous chapter.
        /// </summary>
        public void PreviousChapter()
        {
            NativeMethods.libvlc_media_player_previous_chapter(Handle);
        }

        /// <summary>
        /// Jump to next chapter.
        /// </summary>
        public void NextChapter()
        {
            NativeMethods.libvlc_media_player_next_chapter(Handle);
        }

        /// <summary>
        /// Get an integer valued logo option.
        /// </summary>
        /// <param name="option">Option to get the value for.</param>
        /// <returns>Value of the option.</returns>
        public int GetLogoInt(LIBVLC_LOGO_OPTIONS option)
        {
            return NativeMethods.libvlc_video_get_logo_int(Handle, (uint)option);
        }

        /// <summary>
        /// Get a string valued logo option.
        /// </summary>
        /// <param name="option">Option to get the value for.</param>
        /// <returns>Value of the option.</returns>
        public string GetLogoString(LIBVLC_LOGO_OPTIONS option)
        {
            IntPtr ptr = NativeMethods.libvlc_video_get_logo_string(Handle, (uint)option);
            if (ptr == IntPtr.Zero)
                return null;
            string result = Marshal.PtrToStringAnsi(ptr);
            NativeMethods.libvlc_free(ptr);
            return result;
        }

        /// <summary>
        /// Set a logo option.
        /// </summary>
        /// <param name="option">Option to set.</param>
        /// <param name="value">String to set as the value.</param>
        public void SetLogoOption(LIBVLC_LOGO_OPTIONS option, string value)
        {
            NativeMethods.libvlc_video_set_logo_string(Handle, (uint)option, value);
        }

        /// <summary>
        /// Set a logo option.
        /// </summary>
        /// <param name="option">Option to set.</param>
        /// <param name="value">Integer to set as the value.</param>
        public void SetLogoOption(LIBVLC_LOGO_OPTIONS option, int value)
        {
            NativeMethods.libvlc_video_set_logo_int(Handle, (uint)option, value);
        }

        /// <summary>
        /// Get an integer valued adjust option.
        /// </summary>
        /// <param name="option">Option to get the value for.</param>
        /// <returns>Value of the option.</returns>
        public int GetAdjustOptionInt(LIBVLC_ADJUST_OPTIONS option)
        {
            return NativeMethods.libvlc_video_get_adjust_int(Handle, (uint)option);
        }

        /// <summary>
        /// Get a float valued adjust option.
        /// </summary>
        /// <param name="option">Option to get the value for.</param>
        /// <returns>Value of the option.</returns>
        public float GetAdjustOptionFloat(LIBVLC_ADJUST_OPTIONS option)
        {
            return NativeMethods.libvlc_video_get_adjust_float(Handle, (uint)option);
        }

        /// <summary>
        /// Set the value of an adjust option.
        /// </summary>
        /// <param name="option">Option to set.</param>
        /// <param name="value">Integer value to set the option to.</param>
        public void SetAdjustOption(LIBVLC_ADJUST_OPTIONS option, int value)
        {
            NativeMethods.libvlc_video_set_adjust_int(Handle, (uint)option, value);
        }

        /// <summary>
        /// Set the value of an adjust option.
        /// </summary>
        /// <param name="option">Option to set.</param>
        /// <param name="value">Float value to set the option to.</param>
        public void SetAdjustOption(LIBVLC_ADJUST_OPTIONS option, float value)
        {
            NativeMethods.libvlc_video_set_adjust_float(Handle, (uint)option, value);
        }
        #endregion

        #region Protected Methods
        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (IsPlaying)
                    Stop();
                while (IsPlaying)
                    Thread.Sleep(100);
                NativeMethods.libvlc_media_player_release(Handle);
                IsDisposed = true;
            }
        }

        /// <summary>
        /// Handles an event callback from this object's event manager.
        /// </summary>
        /// <param name="e">The event data</param>
        protected virtual void HandleEvent(libvlc_event_t e)
        {
            switch (e.type)
            {
                case LIBVLC_EVENT.MEDIA_PLAYER_MEDIA_CHANGED:
                    media_player_media_changed mediaChanged = new media_player_media_changed();
                    MarshalHelpers.BytesToStruct(e.data, ref mediaChanged);
                    try
                    {
                        EventHelpers.SafeEventInvoke(this, MediaChanged, new MediaChangedEventArgs(new TwoflowerVLCMedia(mediaChanged.new_media)));
                    }
                    catch (VLCException)
                    {
                        EventHelpers.SafeEventInvoke(this, MediaChanged, new MediaChangedEventArgs(null));
                    }
                    break;
                case LIBVLC_EVENT.MEDIA_PLAYER_NOTHING_SPECIAL:
                    EventHelpers.SafeEventInvoke(this, NothingSpecial, new EventArgs());
                    break;
                case LIBVLC_EVENT.MEDIA_PLAYER_OPENING:
                    EventHelpers.SafeEventInvoke(this, Opening, new EventArgs());
                    break;
                case LIBVLC_EVENT.MEDIA_PLAYER_BUFFERING:
                    media_player_buffering buffering = new media_player_buffering();
                    MarshalHelpers.BytesToStruct(e.data, ref buffering);
                    EventHelpers.SafeEventInvoke(this, Buffering, new FloatEventArgs(buffering.new_cache));
                    break;
                case LIBVLC_EVENT.MEDIA_PLAYER_PLAYING:
                    EventHelpers.SafeEventInvoke(this, Playing, new EventArgs());
                    break;
                case LIBVLC_EVENT.MEDIA_PLAYER_PAUSED:
                    EventHelpers.SafeEventInvoke(this, Paused, new EventArgs());
                    break;
                case LIBVLC_EVENT.MEDIA_LIST_PLAYER_STOPPED:
                    EventHelpers.SafeEventInvoke(this, Stopped, new EventArgs());
                    break;
                case LIBVLC_EVENT.MEDIA_PLAYER_FORWARD:
                    EventHelpers.SafeEventInvoke(this, Forward, new EventArgs());
                    break;
                case LIBVLC_EVENT.MEDIA_PLAYER_BACKWARD:
                    EventHelpers.SafeEventInvoke(this, Backward, new EventArgs());
                    break;
                case LIBVLC_EVENT.MEDIA_PLAYER_END_REACHED:
                    EventHelpers.SafeEventInvoke(this, EndReached, new EventArgs());
                    break;
                case LIBVLC_EVENT.MEDIA_PLAYER_ENCOUNTERED_ERROR:
                    VLCException ex = new VLCException();
                    EventHelpers.SafeEventInvoke(this, EncounteredError, new EncounteredErrorEventArgs(ex));
                    break;
                case LIBVLC_EVENT.MEDIA_PLAYER_TIME_CHANGED:
                    media_player_time_changed timeChanged = new media_player_time_changed();
                    MarshalHelpers.BytesToStruct(e.data, ref timeChanged);
                    EventHelpers.SafeEventInvoke(this, TimeChanged, new LongEventArgs(timeChanged.new_time));
                    break;
                case LIBVLC_EVENT.MEDIA_PLAYER_POSITION_CHANGED:
                    media_player_position_changed posChanged = new media_player_position_changed();
                    MarshalHelpers.BytesToStruct(e.data, ref posChanged);
                    EventHelpers.SafeEventInvoke(this, PositionChanged, new FloatEventArgs(posChanged.new_position));
                    break;
                case LIBVLC_EVENT.MEDIA_PLAYER_SEEKABLE_CHANGED:
                    media_player_seekable_changed seekableChanged = new media_player_seekable_changed();
                    MarshalHelpers.BytesToStruct(e.data, ref seekableChanged);
                    EventHelpers.SafeEventInvoke(this, IsSeekableChanged, new BoolEventArgs(seekableChanged.new_seekable == 0 ? false : true));
                    break;
                case LIBVLC_EVENT.MEDIA_PLAYER_PAUSABLE_CHANGED:
                    media_player_pausable_changed pausableChanged = new media_player_pausable_changed();
                    MarshalHelpers.BytesToStruct(e.data, ref pausableChanged);
                    EventHelpers.SafeEventInvoke(this, IsPausableChanged, new BoolEventArgs(pausableChanged.new_pausable == 0 ? false : true));
                    break;
                case LIBVLC_EVENT.MEDIA_PLAYER_LENGTH_CHANGED:
                    media_player_length_changed lengthChanged = new media_player_length_changed();
                    MarshalHelpers.BytesToStruct(e.data, ref lengthChanged);
                    EventHelpers.SafeEventInvoke(this, LengthChanged, new LongEventArgs(lengthChanged.new_length));
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Gets an <code>IEnumerable&lt;VLCTrackDescription&gt;</code> with the given number of elements for a pointer.
        /// </summary>
        /// <param name="count">Expected number of elements.</param>
        /// <param name="ptr">Pointer to the first element.</param>
        /// <returns><code>IEnumerable&lt;VLCTrackDescription&gt;</code> for the pointer.</returns>
        protected IEnumerable<TrackDescription> GetTracks(int count, IntPtr ptr)
        {
            libvlc_track_description_t tmp = new libvlc_track_description_t
            {
                i_id = 0,
                p_next = ptr,
                psz_name = null
            };
            for (int i = 0; i < count && tmp.p_next != IntPtr.Zero; i++)
            {
                tmp = (libvlc_track_description_t)Marshal.PtrToStructure(tmp.p_next, typeof(libvlc_track_description_t));
                yield return new TrackDescription { ID = tmp.i_id, Name = tmp.psz_name };
            }
            NativeMethods.libvlc_track_description_list_release(ptr);
        }
        #endregion

        #region Private Methods
        private void MarshalEvent(IntPtr eventData, IntPtr userData)
        {
            libvlc_event_t e = (libvlc_event_t)Marshal.PtrToStructure(eventData, typeof(libvlc_event_t));
            if (e.p_obj == Handle)
                HandleEvent(e);
        }

        ~TwoflowerVLCMediaPlayer()
        {
            Dispose(false);
        }
        #endregion
    }
}
