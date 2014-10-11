using System;
using System.Collections.Generic;
namespace com.ptrampert.LibVLCBind
{
    /// <summary>
    /// Exposes methods available to an instance of VLC.
    /// </summary>
    public interface IVLCInstance : IDisposable
    {
        /// <summary>
        /// Gets a list of the available AudioOutputs and their associated devices.
        /// </summary>
        IEnumerable<AudioOutput> AudioOutputs { get; }

        /// <summary>
        /// Creates a new, empty IMediaPlayer
        /// </summary>
        /// <returns>New IMediaPlayer</returns>
        IMediaPlayer CreateMediaPlayer();

        /// <summary>
        /// Creates a new, empty TMediaPlayer, where TMediaPlayer implements IMediaPlayer
        /// </summary>
        /// <typeparam name="TMediaPlayer">Type of media player to create.</typeparam>
        /// <returns>New TMediaPlayer</returns>
        TMediaPlayer CreateMediaPlayer<TMediaPlayer>() where TMediaPlayer : class, IMediaPlayer;

        /// <summary>
        /// Creates a new TMediaPlayer from an existing IMedia.
        /// </summary>
        /// <typeparam name="TMediaPlayer">Type of media player to create</typeparam>
        /// <param name="media">Media to load into the player.</param>
        /// <returns>New TMediaPlayer</returns>
        TMediaPlayer CreateMediaPlayer<TMediaPlayer>(IMedia media) where TMediaPlayer : class, IMediaPlayer;

        /// <summary>
        /// Creates a new IMedia object.
        /// </summary>
        /// <param name="url">Resource location string for the media.</param>
        /// <param name="local">If url is a local filepath, use true. Otherwise, use false.</param>
        /// <returns>New IMedia object.</returns>
        IMedia GetVLCMedia(string url, bool local);
    }
}
