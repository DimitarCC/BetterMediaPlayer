using System;
namespace com.ptrampert.LibVLCBind
{
    /// <summary>
    /// Generic media player interface.
    /// </summary>
    public interface IMediaPlayer : IDisposable
    {
        /// <summary>
        /// Called when state changes to <value>LIBVLC_STATE.BUFFERING</value>.
        /// The percentage complete is passed in the event args.
        /// </summary>
        event EventHandler<FloatEventArgs> Buffering;

        /// <summary>
        /// Called when the media player encounters an error. The exception is passed in the event args.
        /// </summary>
        event EventHandler<EncounteredErrorEventArgs> EncounteredError;

        /// <summary>
        /// Called when state changes to <value>LIBVLC_STATE.END_REACHED</value>
        /// </summary>
        event EventHandler EndReached;

        /// <summary>
        /// Called when the media player's length is changed. The new length is passed in the event args.
        /// </summary>
        event EventHandler<LongEventArgs> LengthChanged;

        /// <summary>
        /// Called when the media is changed. The new media is passed in the event args.
        /// </summary>
        event EventHandler<MediaChangedEventArgs> MediaChanged;

        /// <summary>
        /// Called when state changes to <value>LIBVLC_STATE.NOTHING_SPECIAL</value>
        /// </summary>
        event EventHandler NothingSpecial;

        /// <summary>
        /// Called when state changes to <value>LIBVLC_STATE.OPENING</value>
        /// </summary>
        event EventHandler Opening;

        /// <summary>
        /// Called when <code>IsPausable</code> changes. The new state is passed in the event args.
        /// </summary>
        event EventHandler<BoolEventArgs> IsPausableChanged;

        /// <summary>
        /// Called when the media player's position changes. The new position is passed in the event args.
        /// </summary>
        event EventHandler<FloatEventArgs> PositionChanged;
        
        /// <summary>
        /// Called when state changes to <value>LIBVLC_STATE.PLAYING</value>
        /// </summary>
        event EventHandler Playing;

        /// <summary>
        /// Called when state changes to <value>LIBVLC_STATE.PAUSED</value>
        /// </summary>
        event EventHandler Paused;

        /// <summary>
        /// Called when <code>IsSeekable</code> changes. The new state is passed in the event args.
        /// </summary>
        event EventHandler<BoolEventArgs> IsSeekableChanged;

        /// <summary>
        /// Called when state changes to <value>LIBVLC_STATE.STOPPED</value>
        /// </summary>
        event EventHandler Stopped;

        /// <summary>
        /// Called when the media player's Time changes. The new time is passed in the event args.
        /// </summary>
        event EventHandler<LongEventArgs> TimeChanged;

        /// <summary>
        /// Called when state changes to <value>LIBVLC_STATE.FORWARD</value>
        /// </summary>
        event EventHandler Forward;

        /// <summary>
        /// Called when state changes to <value>LIBVLC_STATE.BACKWARD</value>
        /// </summary>
        event EventHandler Backward;

        /// <summary>
        /// Can the player be paused?
        /// </summary>
        bool IsPausable { get; }
        
        /// <summary>
        /// Is the player playing?
        /// </summary>
        bool IsPlaying { get; }

        /// <summary>
        /// Is the player seekable?
        /// </summary>
        bool IsSeekable { get; }

        /// <summary>
        /// Gets the length of the current media.
        /// </summary>
        long Length { get; }

        /// <summary>
        /// Gets/Sets the current media.
        /// </summary>
        IMedia Media { get; set; }

        /// <summary>
        /// Gets/Sets the current position of the current media (percentage between 0.0 and 1.0).
        /// </summary>
        float Position { get; set; }

        /// <summary>
        /// Gets/Sets the requested playback rate.
        /// </summary>
        float Rate { get; set; }

        /// <summary>
        /// Gets the current player state.
        /// </summary>
        LIBVLC_STATE State { get; }

        /// <summary>
        /// Gets/Sets the current time of the current media (in milliseconds).
        /// </summary>
        long Time { get; set; }

        /// <summary>
        /// Will the player play if <code>Play()</code> is called?
        /// </summary>
        bool WillPlay { get; }

        /// <summary>
        /// Toggles pause on the player.
        /// </summary>
        void Pause();

        /// <summary>
        /// Plays the player.
        /// </summary>
        void Play();

        /// <summary>
        /// Stops the player.
        /// </summary>
        void Stop();
    }
}
