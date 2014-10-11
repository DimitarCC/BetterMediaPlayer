using System;
using System.Collections.Generic;
namespace com.ptrampert.LibVLCBind
{
    /// <summary>
    /// Exposes properties specific to audio players.
    /// </summary>
    public interface IAudioPlayer : IMediaPlayer
    {
        /// <summary>
        /// Gets/Sets the current audio channel.
        /// </summary>
        int AudioChannel { get; set; }

        /// <summary>
        /// Gets/Sets the current audio delay (in milliseconds).
        /// </summary>
        long AudioDelay { get; set; }

        /// <summary>
        /// Gets/Sets the current audio output.
        /// </summary>
        AudioOutput AudioOutput { get; set; }

        /// <summary>
        /// Gets the available audio tracks.
        /// </summary>
        IEnumerable<TrackDescription> AudioTracks { get; }

        /// <summary>
        /// Gets/Sets the current audio track.
        /// </summary>
        TrackDescription AudioTrack { get; set; }

        /// <summary>
        /// Gets/Sets mute.
        /// </summary>
        bool Mute { get; set; }

        /// <summary>
        /// Gets/Sets volume.
        /// </summary>
        int Volume { get; set; }
    }
}
