using System;
using System.Collections.Generic;
namespace com.ptrampert.LibVLCBind
{
    /// <summary>
    /// Exposes properties, events, and methods specific to video players.
    /// </summary>
    public interface IVideoPlayer : IAudioPlayer
    {
        /// <summary>
        /// Called when a snapshot is taken. The location the snapshot was saved to is passed in the event args.
        /// </summary>
        event EventHandler<StringEventArgs> SnapshotTaken;
        
        /// <summary>
        /// Called when <code>Title</code> changes. The new title is passed in the event args.
        /// </summary>
        event EventHandler<IntEventArgs> TitleChanged;

        /// <summary>
        /// Called when the number of video outputs changes. The new count is passed in the event args.
        /// </summary>
        event EventHandler<IntEventArgs> Vout;

        /// <summary>
        /// Gets/Sets the current aspect ratio.
        /// </summary>
        string AspectRatio { get; set; }

        /// <summary>
        /// The currently playing chapter.
        /// </summary>
        int Chapter { get; set; }

        /// <summary>
        /// The number of chapters.
        /// </summary>
        int ChapterCount { get; }

        /// <summary>
        /// Gets/Sets the current crop geometry.
        /// </summary>
        string CropGeometry { get; set; }

        /// <summary>
        /// Gets/Sets the windows drawable handle on which to render video content.
        /// </summary>
        IntPtr Drawable { get; set; }

        /// <summary>
        /// Gets the current FPS.
        /// </summary>
        float FPS { get; }

        /// <summary>
        /// Gets/Sets Fullscreen mode.
        /// </summary>
        bool IsFullscreen { get; set; }

        /// <summary>
        /// Gets/Sets the current subtitle delay (in milliseconds).
        /// </summary>
        long SubtitleDelay { get; set; }

        /// <summary>
        /// Gets/Sets the current subtitle file.
        /// </summary>
        string SubtitleFile { get; set; }
        
        /// <summary>
        /// Gets/Sets the current subtitle track.
        /// </summary>
        TrackDescription Subtitles { get; set; }

        /// <summary>
        /// Gets the available subtitle tracks.
        /// </summary>
        IEnumerable<TrackDescription> SubtitleTracks { get; }

        /// <summary>
        /// Gets/Sets the current teletext page.
        /// </summary>
        int TeletextPage { get; set; }

        /// <summary>
        /// Gets/Sets the current title (if applicable).
        /// </summary>
        int Title { get; set; }

        /// <summary>
        /// Gets the number of titles in the current media (if applicable).
        /// </summary>
        int TitleCount { get; }

        /// <summary>
        /// Gets/Sets the currently playing chapter.
        /// </summary>
        TrackDescription VideoChapter { get; set; }

        /// <summary>
        /// Gets/Sets the current video scale.
        /// </summary>
        float VideoScale { get; set; }

        /// <summary>
        /// Gets/Sets the currently playing title.
        /// </summary>
        TrackDescription VideoTitle { get; set; }

        /// <summary>
        /// Gets the available video titles.
        /// </summary>
        IEnumerable<TrackDescription> VideoTitles { get; }

        /// <summary>
        /// Gets/Sets the current video track.
        /// </summary>
        TrackDescription VideoTrack { get; set; }

        /// <summary>
        /// Gets the available video tracks.
        /// </summary>
        IEnumerable<TrackDescription> VideoTracks { get; }

        /// <summary>
        /// Gets the current number of Video Outputs for the player.
        /// </summary>
        uint VoutCount { get; }

        /// <summary>
        /// Get a float valued adjust option.
        /// </summary>
        /// <param name="option">Option to get the value for.</param>
        /// <returns>Value of the option.</returns>
        float GetAdjustOptionFloat(LIBVLC_ADJUST_OPTIONS option);

        /// <summary>
        /// Get an integer valued adjust option.
        /// </summary>
        /// <param name="option">Option to get the value for.</param>
        /// <returns>Value of the option.</returns>
        int GetAdjustOptionInt(LIBVLC_ADJUST_OPTIONS option);

        /// <summary>
        /// Get an integer valued logo option.
        /// </summary>
        /// <param name="option">Option to get the value for.</param>
        /// <returns>Value of the option.</returns>
        int GetLogoInt(LIBVLC_LOGO_OPTIONS option);

        /// <summary>
        /// Get a string valued logo option.
        /// </summary>
        /// <param name="option">Option to get the value for.</param>
        /// <returns>Value of the option.</returns>
        string GetLogoString(LIBVLC_LOGO_OPTIONS option);

        /// <summary>
        /// Jump to next chapter.
        /// </summary>
        void NextChapter();

        /// <summary>
        /// Jump to previous chapter.
        /// </summary>
        void PreviousChapter();

        /// <summary>
        /// Set the value of an adjust option.
        /// </summary>
        /// <param name="option">Option to set.</param>
        /// <param name="value">Integer value to set the option to.</param>
        void SetAdjustOption(LIBVLC_ADJUST_OPTIONS option, int value);

        /// <summary>
        /// Set the value of an adjust option.
        /// </summary>
        /// <param name="option">Option to set.</param>
        /// <param name="value">Float value to set the option to.</param>
        void SetAdjustOption(LIBVLC_ADJUST_OPTIONS option, float value);

        /// <summary>
        /// Set a logo option.
        /// </summary>
        /// <param name="option">Option to set.</param>
        /// <param name="value">String to set as the value.</param>
        void SetLogoOption(LIBVLC_LOGO_OPTIONS option, int value);

        /// <summary>
        /// Set a logo option.
        /// </summary>
        /// <param name="option">Option to set.</param>
        /// <param name="value">Integer to set as the value.</param>
        void SetLogoOption(LIBVLC_LOGO_OPTIONS option, string value);

        /// <summary>
        /// Toggles teletext on the player.
        /// </summary>
        void ToggleTeletext();
    }
}
