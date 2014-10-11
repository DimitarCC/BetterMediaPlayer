using System;
namespace com.ptrampert.LibVLCBind
{
    /// <summary>
    /// Exposes methods, events, and properties associated with media.
    /// </summary>
    public interface IMedia : IDisposable, ICloneable
    {
        /// <summary>
        /// Called when Album changes.
        /// </summary>
        event EventHandler AlbumChanged;

        /// <summary>
        /// Called when Artist changes.
        /// </summary>
        event EventHandler ArtistChanged;

        /// <summary>
        /// Called when ArtworkURL changes.
        /// </summary>
        event EventHandler ArtworkUrlChanged;

        /// <summary>
        /// Called when Copyright changes.
        /// </summary>
        event EventHandler CopyrightChanged;

        /// <summary>
        /// Called when Date changes.
        /// </summary>
        event EventHandler DateChanged;

        /// <summary>
        /// Called when Description changes.
        /// </summary>
        event EventHandler DescriptionChanged;

        /// <summary>
        /// Called when Duration changes.
        /// </summary>
        event EventHandler<LongEventArgs> DurationChanged;

        /// <summary>
        /// Called when EncodedBy changes.
        /// </summary>
        event EventHandler EncodedByChanged;

        /// <summary>
        /// Called when Genre changes.
        /// </summary>
        event EventHandler GenreChanged;

        /// <summary>
        /// Called when IsParsed changes.
        /// </summary>
        event EventHandler<BoolEventArgs> IsParsedChanged;

        /// <summary>
        /// Called when Language changes.
        /// </summary>
        event EventHandler LanguageChanged;

        /// <summary>
        /// Called when the underlying Media is freed.
        /// </summary>
        event EventHandler MediaFreed;

        /// <summary>
        /// Called when NowPlaying changes.
        /// </summary>
        event EventHandler NowPlayingChanged;

        /// <summary>
        /// Called when Publisher changes.
        /// </summary>
        event EventHandler PublisherChanged;

        /// <summary>
        /// Called when Rating changes.
        /// </summary>
        event EventHandler RatingChanged;

        /// <summary>
        /// Called when Setting changes.
        /// </summary>
        event EventHandler SettingChanged;

        /// <summary>
        /// Called when State changes.
        /// </summary>
        event EventHandler<StateChangedEventArgs> StateChanged;

        /// <summary>
        /// Called when Title changes.
        /// </summary>
        event EventHandler TitleChanged;

        /// <summary>
        /// Called when TrackId changes.
        /// </summary>
        event EventHandler TrackIdChanged;

        /// <summary>
        /// Called when TrackNumber changes.
        /// </summary>
        event EventHandler TrackNumberChanged;

        /// <summary>
        /// The media's handle.
        /// </summary>
        IntPtr Handle { get; }

        /// <summary>
        /// Called when URL changes.
        /// </summary>
        event EventHandler UrlChanged;

        /// <summary>
        /// Gets/Sets album.
        /// </summary>
        string Album { get; set; }
        
        /// <summary>
        /// Gets/Sets media artist.
        /// </summary>
        string Artist { get; set; }

        /// <summary>
        /// Gets/Sets artwork url.
        /// </summary>
        string ArtworkURL { get; set; }

        /// <summary>
        /// Gets/Sets copyright
        /// </summary>
        string Copyright { get; set; }

        /// <summary>
        /// Gets/Sets date.
        /// </summary>
        string Date { get; set; }

        /// <summary>
        /// Gets/Sets description
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets the duration (in ms) of the media.
        /// </summary>
        long Duration { get; }

        /// <summary>
        /// Gets/Sets encoded by.
        /// </summary>
        string EncodedBy { get; set; }

        /// <summary>
        /// Gets/Sets media genre.
        /// </summary>
        string Genre { get; set; }

        /// <summary>
        /// Gets whether or not the media has been parsed yet.
        /// </summary>
        bool IsParsed { get; }

        /// <summary>
        /// Gets/Sets language.
        /// </summary>
        string Language { get; set; }

        /// <summary>
        /// Gets the Media Resource Locator (MRL) string for this media.
        /// </summary>
        string MRL { get; }

        /// <summary>
        /// Gets/Sets now playing.
        /// </summary>
        string NowPlaying { get; set; }

        /// <summary>
        /// Gets/Sets publisher.
        /// </summary>
        string Publisher { get; set; }

        /// <summary>
        /// Gets/Sets rating.
        /// </summary>
        string Rating { get; set; }

        /// <summary>
        /// Gets/Sets setting.
        /// </summary>
        string Setting { get; set; }

        /// <summary>
        /// Gets the media's state. Does not require calling of Parse().
        /// </summary>
        LIBVLC_STATE State { get; }

        /// <summary>
        /// Gets the media's statistics. Will return null if media is not playing or if stats are otherwise unavailable.
        /// </summary>
        MediaStats Stats { get; }

        /// <summary>
        /// Gets/Sets media title.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets/Sets track id.
        /// </summary>
        string TrackId { get; set; }

        /// <summary>
        /// Gets/Sets track number.
        /// </summary>
        string TrackNumber { get; set; }

        /// <summary>
        /// Gets/Sets url.
        /// </summary>
        string URL { get; set; }

        /// <summary>
        /// Adds an option to the VLCMedia.
        /// </summary>
        /// <param name="options">Option to add.</param>
        void AddOption(string options);

        /// <summary>
        /// Adds an option flag to the VLCMedia.
        /// </summary>
        /// <param name="options">Option to add.</param>
        /// <param name="flags">Flag value (0 or 1)</param>
        void AddOptionFlag(string options, uint flags);

        /// <summary>
        /// Parses the media's local metadata and tracks information. 
        /// Needs to be called before much of the media's metadata can be accessed.
        /// The ParsedChanged event is called when parsing is complete.
        /// </summary>
        void Parse();

        /// <summary>
        /// Asynchronously parses the media's local metadata and tracks information.
        /// Needs to be called before much of the media's metadata can be accessed.
        /// The ParsedChanged event is called when parsing is complete.
        /// </summary>
        void ParseAsync();

        /// <summary>
        /// Saves changes made to the media's local metadata.
        /// </summary>
        void SaveChanges();
    }
}
