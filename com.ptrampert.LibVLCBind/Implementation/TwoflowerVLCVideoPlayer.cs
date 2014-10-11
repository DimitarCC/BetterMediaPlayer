using com.ptrampert.LibVLCBind.Hooks;
using com.ptrampert.LibVLCBind.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace com.ptrampert.LibVLCBind.Implementation
{
    internal class TwoflowerVLCVideoPlayer : TwoflowerVLCAudioPlayer, IVideoPlayer
    {
        /// <summary>
        /// Called when <code>Title</code> changes. The new title is passed in the event args.
        /// </summary>
        public event EventHandler<IntEventArgs> TitleChanged;

        /// <summary>
        /// Called when a snapshot is taken. The location the snapshot was saved to is passed in the event args.
        /// </summary>
        public event EventHandler<StringEventArgs> SnapshotTaken;

        /// <summary>
        /// Called when the number of video outputs changes. The new count is passed in the event args.
        /// </summary>
        public event EventHandler<IntEventArgs> Vout;

        /// <summary>
        /// Gets/Sets the windows drawable handle on which to render video content.
        /// </summary>
        public IntPtr Drawable
        {
            get
            {
                return NativeMethods.libvlc_media_player_get_hwnd(Handle);
            }
            set
            {
                NativeMethods.libvlc_media_player_set_hwnd(Handle, value);
            }
        }

        /// <summary>
        /// Gets/Sets the current chapter (if applicable).
        /// </summary>
        public int Chapter
        {
            get
            {
                int ch = NativeMethods.libvlc_media_player_get_chapter(Handle);
                if (ch == -1)
                    throw new VLCException();
                return ch;
            }
            set
            {
                NativeMethods.libvlc_media_player_set_chapter(Handle, value);
            }
        }

        /// <summary>
        /// Gets the number of chapters in the current media (if applicable).
        /// </summary>
        public int ChapterCount
        {
            get
            {
                int count = NativeMethods.libvlc_media_player_get_chapter_count(Handle);
                if (count == -1)
                    throw new VLCException();
                return count;
            }
        }

        /// <summary>
        /// Gets/Sets the current title (if applicable).
        /// </summary>
        public int Title
        {
            get
            {
                int title = NativeMethods.libvlc_media_player_get_title(Handle);
                if (title == -1)
                    throw new VLCException();
                return title;
            }
            set
            {
                NativeMethods.libvlc_media_player_set_title(Handle, value);
            }
        }

        /// <summary>
        /// Gets the number of titles in the current media (if applicable).
        /// </summary>
        public int TitleCount
        {
            get
            {
                int count = NativeMethods.libvlc_media_player_get_title_count(Handle);
                if (count == -1)
                    throw new VLCException();
                return count;
            }
        }

        /// <summary>
        /// Gets the current FPS.
        /// </summary>
        public float FPS { get { return NativeMethods.libvlc_media_player_get_fps(Handle); } }

        /// <summary>
        /// Gets the current number of Video Outputs for the player.
        /// </summary>
        public uint VoutCount { get { return NativeMethods.libvlc_media_player_has_vout(Handle); } }

        /// <summary>
        /// Gets/Sets Fullscreen mode.
        /// </summary>
        public bool IsFullscreen
        {
            get
            {
                return NativeMethods.libvlc_get_fullscreen(Handle) == 0 ? false : true;
            }
            set
            {
                NativeMethods.libvlc_set_fullscreen(Handle, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Gets/Sets the current video scale.
        /// </summary>
        public float VideoScale
        {
            get
            {
                return NativeMethods.libvlc_video_get_scale(Handle);
            }
            set
            {
                NativeMethods.libvlc_video_set_scale(Handle, value);
            }
        }

        /// <summary>
        /// Gets/Sets the current aspect ratio.
        /// </summary>
        public string AspectRatio
        {
            get
            {
                IntPtr ptr = NativeMethods.libvlc_video_get_aspect_ratio(Handle);
                if (ptr == IntPtr.Zero)
                    return null;
                string result = Marshal.PtrToStringAnsi(ptr);
                NativeMethods.libvlc_free(ptr);
                return result;
            }
            set
            {
                NativeMethods.libvlc_video_set_aspect_ratio(Handle, value);
            }
        }

        /// <summary>
        /// Gets the available subtitle tracks.
        /// </summary>
        public IEnumerable<TrackDescription> SubtitleTracks
        {
            get
            {
                int count = NativeMethods.libvlc_video_get_spu_count(Handle);
                IntPtr ptr = NativeMethods.libvlc_video_get_spu_description(Handle);
                return GetTracks(count, ptr);
            }
        }

        /// <summary>
        /// Gets/Sets the current subtitle track.
        /// </summary>
        public TrackDescription Subtitles
        {
            get
            {
                int id = NativeMethods.libvlc_video_get_spu(Handle);
                return SubtitleTracks.Where(t => t.ID == id).SingleOrDefault();
            }
            set
            {
                int status = NativeMethods.libvlc_video_set_spu(Handle, (uint)value.ID);
                if (status == -1)
                    throw new VLCException();
                subtitleFile = null;
            }
        }

        private string subtitleFile = null;

        /// <summary>
        /// Gets/Sets the current subtitle file.
        /// </summary>
        public string SubtitleFile
        {
            get
            {
                return subtitleFile;
            }
            set
            {
                int status = NativeMethods.libvlc_video_set_subtitle_file(Handle, value);
                if (status == -1)
                    throw new VLCException();
            }
        }

        /// <summary>
        /// Gets/Sets the current subtitle delay (in milliseconds).
        /// </summary>
        public long SubtitleDelay
        {
            get
            {
                return NativeMethods.libvlc_video_get_spu_delay(Handle);
            }
            set
            {
                int status = NativeMethods.libvlc_video_set_spu_delay(Handle, value);
                if (status == -1)
                    throw new VLCException();
            }
        }

        /// <summary>
        /// Gets the available video titles.
        /// </summary>
        public IEnumerable<TrackDescription> VideoTitles
        {
            get
            {
                int count = NativeMethods.libvlc_media_player_get_title_count(Handle);
                IntPtr ptr = NativeMethods.libvlc_video_get_title_description(Handle);
                IEnumerable<TrackDescription> titles = GetTracks(count, ptr);
                foreach (TrackDescription title in titles)
                {
                    count = NativeMethods.libvlc_media_player_get_chapter_count_for_title(Handle, title.ID);
                    ptr = NativeMethods.libvlc_video_get_chapter_description(Handle, title.ID);
                    title.Children = GetTracks(count, ptr);
                }
                return titles;
            }
        }

        /// <summary>
        /// Gets/Sets the currently playing title.
        /// </summary>
        public TrackDescription VideoTitle
        {
            get
            {
                int id = NativeMethods.libvlc_media_player_get_title(Handle);
                if (id == -1)
                    return null;
                return VideoTitles.Where(t => t.ID == id).SingleOrDefault();
            }
            set
            {
                NativeMethods.libvlc_media_player_set_title(Handle, value.ID);
            }
        }

        /// <summary>
        /// Gets/Sets the currently playing chapter.
        /// </summary>
        public TrackDescription VideoChapter
        {
            get
            {
                int id = NativeMethods.libvlc_media_player_get_chapter(Handle);
                if (id == -1)
                    return null;
                return VideoTitles.SelectMany(t => t.Children).Where(t => t.ID == id).SingleOrDefault();
            }
            set
            {
                NativeMethods.libvlc_media_player_set_chapter(Handle, value.ID);
            }
        }

        /// <summary>
        /// Gets/Sets the current crop geometry.
        /// </summary>
        public string CropGeometry
        {
            get
            {
                IntPtr ptr = NativeMethods.libvlc_video_get_crop_geometry(Handle);
                if (ptr == IntPtr.Zero)
                    return null;
                string result = Marshal.PtrToStringAnsi(ptr);
                NativeMethods.libvlc_free(ptr);
                return result;
            }
            set
            {
                NativeMethods.libvlc_video_set_crop_geometry(Handle, value);
            }
        }

        /// <summary>
        /// Gets/Sets the current teletext page.
        /// </summary>
        public int TeletextPage
        {
            get
            {
                return NativeMethods.libvlc_video_get_teletext(Handle);
            }
            set
            {
                NativeMethods.libvlc_video_set_teletext(Handle, value);
            }
        }

        /// <summary>
        /// Gets the available video tracks.
        /// </summary>
        public IEnumerable<TrackDescription> VideoTracks
        {
            get
            {
                int count = NativeMethods.libvlc_video_get_track_count(Handle);
                IntPtr ptr = NativeMethods.libvlc_video_get_track_description(Handle);
                return GetTracks(count, ptr);
            }
        }

        /// <summary>
        /// Gets/Sets the current video track.
        /// </summary>
        public TrackDescription VideoTrack
        {
            get
            {
                int id = NativeMethods.libvlc_video_get_track(Handle);
                if (id == -1)
                    return null;
                return VideoTracks.Where(t => t.ID == id).SingleOrDefault();
            }
            set
            {
                int status = NativeMethods.libvlc_video_set_track(Handle, value.ID);
                if (status == -1)
                    throw new VLCException();
            }
        }

        internal TwoflowerVLCVideoPlayer(TwoflowerVLCInstance instance) : base(instance) { }

        internal TwoflowerVLCVideoPlayer(IMedia media) : base(media) { }

        protected override void HandleEvent(libvlc_event_t e)
        {
            switch (e.type)
            {
                case LIBVLC_EVENT.MEDIA_PLAYER_TITLE_CHANGED:
                    media_player_title_changed titleChanged = new media_player_title_changed();
                    MarshalHelpers.BytesToStruct(e.data, ref titleChanged);
                    EventHelpers.SafeEventInvoke(this, TitleChanged, new IntEventArgs(titleChanged.new_title));
                    break;
                case LIBVLC_EVENT.MEDIA_PLAYER_SNAPSHOT_TAKEN:
                    media_player_snapshot_taken snapshotTaken = new media_player_snapshot_taken();
                    MarshalHelpers.BytesToStruct(e.data, ref snapshotTaken);
                    EventHelpers.SafeEventInvoke(this, SnapshotTaken, new StringEventArgs(snapshotTaken.psz_filename));
                    break;
                case LIBVLC_EVENT.MEDIA_PLAYER_VOUT:
                    media_player_vout vout = new media_player_vout();
                    MarshalHelpers.BytesToStruct(e.data, ref vout);
                    EventHelpers.SafeEventInvoke(this, Vout, new IntEventArgs(vout.new_count));
                    break;
                default:
                    base.HandleEvent(e);
                    break;
            }
        }
    }
}
