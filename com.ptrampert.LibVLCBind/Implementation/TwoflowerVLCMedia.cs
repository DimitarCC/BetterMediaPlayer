using com.ptrampert.LibVLCBind.BaseClasses;
using com.ptrampert.LibVLCBind.Hooks;
using com.ptrampert.LibVLCBind.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;

namespace com.ptrampert.LibVLCBind.Implementation
{
    /// <summary>
    /// Wrapper arounda libvlc_media_t. Unless otherwise stated, all properties require Parse() to be called before reading/writing has any meaning.
    /// </summary>
    internal class TwoflowerVLCMedia : DisposableBase, IMedia
    {
        #region Internal Properties
        /// <summary>
        /// Pointer to the underlying libvlc_event_manager_t
        /// </summary>
        internal IntPtr EventManager { get; set; }
        #endregion

        #region Private Fields
        /// <summary>
        /// Handler that marshals the native libvlc callbacks for this media to managed events.
        /// </summary>
        private libvlc_callback_t handler;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets/Sets media title.
        /// </summary>
        public string Title
        {
            get
            {
                return GetMeta(LIBVLC_META.TITLE);
            }
            set
            {
                NativeMethods.libvlc_media_set_meta(Handle, (int)LIBVLC_META.TITLE, value);
            }
        }

        /// <summary>
        /// Gets/Sets media artist.
        /// </summary>
        public string Artist
        {
            get
            {
                return GetMeta(LIBVLC_META.ARTIST);
            }
            set
            {
                NativeMethods.libvlc_media_set_meta(Handle, (int)LIBVLC_META.ARTIST, value);
            }
        }

        /// <summary>
        /// Gets/Sets media genre.
        /// </summary>
        public string Genre
        {
            get
            {
                return GetMeta(LIBVLC_META.GENRE);
            }
            set
            {
                NativeMethods.libvlc_media_set_meta(Handle, (int)LIBVLC_META.GENRE, value);
            }
        }

        /// <summary>
        /// Gets/Sets copyright
        /// </summary>
        public string Copyright
        {
            get
            {
                return GetMeta(LIBVLC_META.COPYRIGHT);
            }
            set
            {
                NativeMethods.libvlc_media_set_meta(Handle, (int)LIBVLC_META.COPYRIGHT, value);
            }
        }

        /// <summary>
        /// Gets/Sets album.
        /// </summary>
        public string Album
        {
            get
            {
                return GetMeta(LIBVLC_META.ALBUM);
            }
            set
            {
                NativeMethods.libvlc_media_set_meta(Handle, (int)LIBVLC_META.ALBUM, value);
            }
        }

        /// <summary>
        /// Gets/Sets track number.
        /// </summary>
        public string TrackNumber
        {
            get
            {
                return GetMeta(LIBVLC_META.TRACK_NUMBER);
            }
            set
            {
                NativeMethods.libvlc_media_set_meta(Handle, (int)LIBVLC_META.TRACK_NUMBER, value);
            }
        }

        /// <summary>
        /// Gets/Sets description
        /// </summary>
        public string Description
        {
            get
            {
                return GetMeta(LIBVLC_META.DESCRIPTION);
            }
            set
            {
                NativeMethods.libvlc_media_set_meta(Handle, (int)LIBVLC_META.DESCRIPTION, value);
            }
        }

        /// <summary>
        /// Gets/Sets rating.
        /// </summary>
        public string Rating
        {
            get
            {
                return GetMeta(LIBVLC_META.RATING);
            }
            set
            {
                NativeMethods.libvlc_media_set_meta(Handle, (int)LIBVLC_META.RATING, value);
            }
        }

        /// <summary>
        /// Gets/Sets date.
        /// </summary>
        public string Date
        {
            get
            {
                return GetMeta(LIBVLC_META.DATE);
            }
            set
            {
                NativeMethods.libvlc_media_set_meta(Handle, (int)LIBVLC_META.DATE, value);
            }
        }

        /// <summary>
        /// Gets/Sets setting.
        /// </summary>
        public string Setting
        {
            get
            {
                return GetMeta(LIBVLC_META.SETTING);
            }
            set
            {
                NativeMethods.libvlc_media_set_meta(Handle, (int)LIBVLC_META.SETTING, value);
            }
        }

        /// <summary>
        /// Gets/Sets url.
        /// </summary>
        public string URL
        {
            get
            {
                return GetMeta(LIBVLC_META.URL);
            }
            set
            {
                NativeMethods.libvlc_media_set_meta(Handle, (int)LIBVLC_META.URL, value);
            }
        }

        /// <summary>
        /// Gets/Sets language.
        /// </summary>
        public string Language
        {
            get
            {
                return GetMeta(LIBVLC_META.LANGUAGE);
            }
            set
            {
                NativeMethods.libvlc_media_set_meta(Handle, (int)LIBVLC_META.LANGUAGE, value);
            }
        }

        /// <summary>
        /// Gets/Sets now playing.
        /// </summary>
        public string NowPlaying
        {
            get
            {
                return GetMeta(LIBVLC_META.NOW_PLAYING);
            }
            set
            {
                NativeMethods.libvlc_media_set_meta(Handle, (int)LIBVLC_META.NOW_PLAYING, value);
            }
        }

        /// <summary>
        /// Gets/Sets publisher.
        /// </summary>
        public string Publisher
        {
            get
            {
                return GetMeta(LIBVLC_META.PUBLISHER);
            }
            set
            {
                NativeMethods.libvlc_media_set_meta(Handle, (int)LIBVLC_META.PUBLISHER, value);
            }
        }

        /// <summary>
        /// Gets/Sets encoded by.
        /// </summary>
        public string EncodedBy
        {
            get
            {
                return GetMeta(LIBVLC_META.ENCODED_BY);
            }
            set
            {
                NativeMethods.libvlc_media_set_meta(Handle, (int)LIBVLC_META.ENCODED_BY, value);
            }
        }

        /// <summary>
        /// Gets/Sets artwork url.
        /// </summary>
        public string ArtworkURL
        {
            get
            {
                return GetMeta(LIBVLC_META.ARTWORK_URL);
            }
            set
            {
                NativeMethods.libvlc_media_set_meta(Handle, (int)LIBVLC_META.ARTWORK_URL, value);
            }
        }

        /// <summary>
        /// Gets/Sets track id.
        /// </summary>
        public string TrackId
        {
            get
            {
                return GetMeta(LIBVLC_META.TRACK_ID);
            }
            set
            {
                NativeMethods.libvlc_media_set_meta(Handle, (int)LIBVLC_META.TRACK_ID, value);
            }
        }

        /// <summary>
        /// Gets the Media Resource Locator (MRL) string for this media.
        /// </summary>
        public string MRL
        {
            get
            {
                IntPtr ptr = NativeMethods.libvlc_media_get_mrl(Handle);
                if (ptr == IntPtr.Zero) return null;
                string result = Marshal.PtrToStringAnsi(ptr);
                NativeMethods.libvlc_free(ptr);
                return result;
            }
        }
        
        /// <summary>
        /// Gets the media's state. Does not require calling of Parse().
        /// </summary>
        public LIBVLC_STATE State
        {
            get
            {
                return (LIBVLC_STATE)NativeMethods.libvlc_media_get_state(Handle);
            }
        }

        /// <summary>
        /// Gets the media's statistics. Will return null if media is not playing or if stats are otherwise unavailable.
        /// </summary>
        public virtual MediaStats Stats
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the duration (in ms) of the media.
        /// </summary>
        public long Duration
        {
            get
            {
                long result = NativeMethods.libvlc_media_get_duration(Handle);
                if (result == -1)
                    throw new VLCException();
                return result;
            }
        }

        /// <summary>
        /// Gets whether or not the media has been parsed yet.
        /// </summary>
        public bool IsParsed
        {
            get
            {
                return NativeMethods.libvlc_media_is_parsed(Handle) == 0 ? false : true;
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Called when Album changes.
        /// </summary>
        public event EventHandler AlbumChanged;

        /// <summary>
        /// Called when Artist changes.
        /// </summary>
        public event EventHandler ArtistChanged;

        /// <summary>
        /// Called when ArtworkURL changes.
        /// </summary>
        public event EventHandler ArtworkUrlChanged;

        /// <summary>
        /// Called when Copyright changes.
        /// </summary>
        public event EventHandler CopyrightChanged;

        /// <summary>
        /// Called when Date changes.
        /// </summary>
        public event EventHandler DateChanged;

        /// <summary>
        /// Called when Description changes.
        /// </summary>
        public event EventHandler DescriptionChanged;

        /// <summary>
        /// Called when EncodedBy changes.
        /// </summary>
        public event EventHandler EncodedByChanged;

        /// <summary>
        /// Called when Genre changes.
        /// </summary>
        public event EventHandler GenreChanged;

        /// <summary>
        /// Called when Language changes.
        /// </summary>
        public event EventHandler LanguageChanged;

        /// <summary>
        /// Called when NowPlaying changes.
        /// </summary>
        public event EventHandler NowPlayingChanged;

        /// <summary>
        /// Called when Publisher changes.
        /// </summary>
        public event EventHandler PublisherChanged;

        /// <summary>
        /// Called when Rating changes.
        /// </summary>
        public event EventHandler RatingChanged;

        /// <summary>
        /// Called when Setting changes.
        /// </summary>
        public event EventHandler SettingChanged;

        /// <summary>
        /// Called when Title changes.
        /// </summary>
        public event EventHandler TitleChanged;

        /// <summary>
        /// Called when TrackId changes.
        /// </summary>
        public event EventHandler TrackIdChanged;

        /// <summary>
        /// Called when TrackNumber changes.
        /// </summary>
        public event EventHandler TrackNumberChanged;
        
        /// <summary>
        /// Called when URL changes.
        /// </summary>
        public event EventHandler UrlChanged;

        /// <summary>
        /// Called when Duration changes.
        /// </summary>
        public event EventHandler<LongEventArgs> DurationChanged;

        /// <summary>
        /// Called when IsParsed changes.
        /// </summary>
        public event EventHandler<BoolEventArgs> IsParsedChanged;

        /// <summary>
        /// Called when the underlying Media is freed.
        /// </summary>
        public event EventHandler MediaFreed;

        /// <summary>
        /// Called when State changes.
        /// </summary>
        public event EventHandler<StateChangedEventArgs> StateChanged;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs a new VLCMedia.
        /// </summary>
        /// <param name="instance">VLCInstance responsible for creating the media.</param>
        /// <param name="url">Media path (either a url or a local path)</param>
        /// <param name="local">Should be true if url is a local path.</param>
        /// <exception cref="VLCException">VLCException</exception>
        internal TwoflowerVLCMedia(TwoflowerVLCInstance instance, string url, bool local)
        {
            handler = HandleMediaEvent;
            if (local)
                Handle = NativeMethods.libvlc_media_new_path(instance.Handle, url);
            else
                Handle = NativeMethods.libvlc_media_new_location(instance.Handle, url);
            if (Handle == IntPtr.Zero) throw new VLCException();
            EventManager = NativeMethods.libvlc_media_event_manager(Handle);
            EventHelpers.RegisterEvents(EventManager, LIBVLC_EVENT.MEDIA_META_CHANGED, LIBVLC_EVENT.MEDIA_STATE_CHANGED, handler);
        }

        /// <summary>
        /// Creates an empty VLCMedia with the given name.
        /// </summary>
        /// <param name="instance">VLCInstance responsible for creating the media.</param>
        /// <param name="name">Name for the media.</param>
        /// <exception cref="VLCException">VLCException</exception>
        internal TwoflowerVLCMedia(TwoflowerVLCInstance instance, string name)
        {
            handler = HandleMediaEvent;
            Handle = NativeMethods.libvlc_media_new_as_node(instance.Handle, name);
            if (Handle == IntPtr.Zero) throw new VLCException();
            EventManager = NativeMethods.libvlc_media_event_manager(Handle);
            EventHelpers.RegisterEvents(EventManager, LIBVLC_EVENT.MEDIA_META_CHANGED, LIBVLC_EVENT.MEDIA_STATE_CHANGED, handler);
        }

        /// <summary>
        /// Creates a new VLCMedia from a pointer to an existing libvlc_media_t.
        /// </summary>
        /// <param name="handle">Pointer to existing libvlc_media_t</param>
        /// <exception cref="VLCException">VLCException</exception>
        internal TwoflowerVLCMedia(IntPtr handle)
        {
            handler = HandleMediaEvent;
            Handle = handle;
            if (handle != IntPtr.Zero)
            {
                EventManager = NativeMethods.libvlc_media_event_manager(Handle);
                EventHelpers.RegisterEvents(EventManager, LIBVLC_EVENT.MEDIA_META_CHANGED, LIBVLC_EVENT.MEDIA_STATE_CHANGED, handler);
            }
            else
                throw new VLCException("Cannot instantiate VLCMedia from IntPtr.Zero");
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Adds an option to the VLCMedia.
        /// </summary>
        /// <param name="options">Option to add.</param>
        public void AddOption(string options)
        {
            NativeMethods.libvlc_media_add_option(Handle, options);
        }

        /// <summary>
        /// Adds an option flag to the VLCMedia.
        /// </summary>
        /// <param name="options">Option to add.</param>
        /// <param name="flags">Flag value (0 or 1)</param>
        public void AddOptionFlag(string options, uint flags)
        {
            NativeMethods.libvlc_media_add_option_flag(Handle, options, flags);
        }

        /// <summary>
        /// Saves changes made to the media's local metadata.
        /// </summary>
        /// <exception cref="VLCException">VLCException</exception>
        public void SaveChanges()
        {
            if (NativeMethods.libvlc_media_save_meta(Handle) == 0)
                throw new VLCException();
        }

        public object Clone()
        {
            IntPtr newHandle = NativeMethods.libvlc_media_duplicate(Handle);
            return new TwoflowerVLCMedia(newHandle);
        }

        /// <summary>
        /// Parses the media's local metadata and tracks information. 
        /// Needs to be called before much of the media's metadata can be accessed.
        /// The ParsedChanged event is called when parsing is complete.
        /// </summary>
        public void Parse()
        {
            NativeMethods.libvlc_media_parse(Handle);
        }

        /// <summary>
        /// Asynchronously parses the media's local metadata and tracks information.
        /// Needs to be called before much of the media's metadata can be accessed.
        /// The ParsedChanged event is called when parsing is complete.
        /// </summary>
        public void ParseAsync()
        {
            NativeMethods.libvlc_media_parse_async(Handle);
        }
        #endregion

        #region Protected Methods
        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                NativeMethods.libvlc_media_release(Handle);
                IsDisposed = true;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the specified meta value.
        /// </summary>
        /// <param name="meta">Which meta to get.</param>
        /// <returns>Value of the meta or null.</returns>
        private string GetMeta(LIBVLC_META meta)
        {
            IntPtr ptr = NativeMethods.libvlc_media_get_meta(Handle, (int)meta);
            if (ptr == IntPtr.Zero)
                return null;
            string result = Marshal.PtrToStringAnsi(ptr);
            NativeMethods.libvlc_free(ptr);
            return result;
        }

        /// <summary>
        /// Handles a callback from this media's event manager and dispatches the appropriate managed event.
        /// </summary>
        /// <param name="eventData">Pointer to libvlc_event_t</param>
        /// <param name="data">Custom user data (unused)</param>
        private void HandleMediaEvent(IntPtr eventData, IntPtr data)
        {
            if (eventData == IntPtr.Zero)
                return;
            libvlc_event_t e = (libvlc_event_t)Marshal.PtrToStructure(eventData, typeof(libvlc_event_t));
            if (e.p_obj == Handle)
            {
                switch (e.type)
                {
                    case LIBVLC_EVENT.MEDIA_META_CHANGED:
                        media_meta_changed metaChanged = new media_meta_changed();
                        MarshalHelpers.BytesToStruct(e.data, ref metaChanged);
                        MetaChangedEventInvoke(metaChanged.meta_type);
                        break;
                    case LIBVLC_EVENT.MEDIA_SUBITEM_ADDED:
                        break;
                    case LIBVLC_EVENT.MEDIA_DURATION_CHANGED:
                        media_duration_changed durationChanged = new media_duration_changed();
                        MarshalHelpers.BytesToStruct(e.data, ref durationChanged);
                        EventHelpers.SafeEventInvoke(this, DurationChanged, new LongEventArgs(durationChanged.new_duration));
                        break;
                    case LIBVLC_EVENT.MEDIA_PARSED_CHANGED:
                        media_parsed_changed parsedChanged = new media_parsed_changed();
                        MarshalHelpers.BytesToStruct(e.data, ref parsedChanged);
                        EventHelpers.SafeEventInvoke(this, IsParsedChanged, new BoolEventArgs(parsedChanged.new_status == 0 ? false : true));
                        break;
                    case LIBVLC_EVENT.MEDIA_FREED:
                        EventHelpers.SafeEventInvoke(this, MediaFreed, new EventArgs());
                        break;
                    case LIBVLC_EVENT.MEDIA_STATE_CHANGED:
                        media_state_changed stateChanged = new media_state_changed();
                        MarshalHelpers.BytesToStruct(e.data, ref stateChanged);
                        EventHelpers.SafeEventInvoke(this, StateChanged, new StateChangedEventArgs(stateChanged.new_state));
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Handles a meta changed callback from this media's event manager and dispatches the appropriate managed event.
        /// </summary>
        /// <param name="metaType">Which meta changed.</param>
        private void MetaChangedEventInvoke(LIBVLC_META metaType)
        {
            switch (metaType)
            {
                case LIBVLC_META.ALBUM:
                    EventHelpers.SafeEventInvoke(this, AlbumChanged, new EventArgs());
                    break;
                case LIBVLC_META.ARTIST:
                    EventHelpers.SafeEventInvoke(this, ArtistChanged, new EventArgs());
                    break;
                case LIBVLC_META.ARTWORK_URL:
                    EventHelpers.SafeEventInvoke(this, ArtworkUrlChanged, new EventArgs());
                    break;
                case LIBVLC_META.COPYRIGHT:
                    EventHelpers.SafeEventInvoke(this, CopyrightChanged, new EventArgs());
                    break;
                case LIBVLC_META.DATE:
                    EventHelpers.SafeEventInvoke(this, DateChanged, new EventArgs());
                    break;
                case LIBVLC_META.DESCRIPTION:
                    EventHelpers.SafeEventInvoke(this, DescriptionChanged, new EventArgs());
                    break;
                case LIBVLC_META.ENCODED_BY:
                    EventHelpers.SafeEventInvoke(this, EncodedByChanged, new EventArgs());
                    break;
                case LIBVLC_META.GENRE:
                    EventHelpers.SafeEventInvoke(this, GenreChanged, new EventArgs());
                    break;
                case LIBVLC_META.LANGUAGE:
                    EventHelpers.SafeEventInvoke(this, LanguageChanged, new EventArgs());
                    break;
                case LIBVLC_META.NOW_PLAYING:
                    EventHelpers.SafeEventInvoke(this, NowPlayingChanged, new EventArgs());
                    break;
                case LIBVLC_META.PUBLISHER:
                    EventHelpers.SafeEventInvoke(this, PublisherChanged, new EventArgs());
                    break;
                case LIBVLC_META.RATING:
                    EventHelpers.SafeEventInvoke(this, RatingChanged, new EventArgs());
                    break;
                case LIBVLC_META.SETTING:
                    EventHelpers.SafeEventInvoke(this, SettingChanged, new EventArgs());
                    break;
                case LIBVLC_META.TITLE:
                    EventHelpers.SafeEventInvoke(this, TitleChanged, new EventArgs());
                    break;
                case LIBVLC_META.TRACK_ID:
                    EventHelpers.SafeEventInvoke(this, TrackIdChanged, new EventArgs());
                    break;
                case LIBVLC_META.TRACK_NUMBER:
                    EventHelpers.SafeEventInvoke(this, TrackNumberChanged, new EventArgs());
                    break;
                case LIBVLC_META.URL:
                    EventHelpers.SafeEventInvoke(this, UrlChanged, new EventArgs());
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Destructor for VLCMedia.
        /// </summary>
        ~TwoflowerVLCMedia()
        {
            Dispose(false);
        }
        #endregion
    }
}
