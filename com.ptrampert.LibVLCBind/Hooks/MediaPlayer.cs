using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace com.ptrampert.LibVLCBind.Hooks
{
    internal static partial class NativeMethods
    {
        /// <summary>
        /// Create an empty Media Player object.
        /// </summary>
        /// <param name="p_libvlc_instance">the libvlc instance in which the Media Player should be created.</param>
        /// <returns>a new media player object, or NULL on error.</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_player_new(IntPtr p_libvlc_instance);

        /// <summary>
        /// Create a Media Player object from a Media.
        /// </summary>
        /// <param name="p_md">the media. Afterwards the p_md can be safely destroyed.</param>
        /// <returns>a new media player object, or NULL on error.</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_player_new_from_media(IntPtr p_md);

        /// <summary>
        /// Get the Windows API window handle (HWND) previously set with libvlc_media_player_set_hwnd().
        /// The handle will be returned even if LibVLC is not currently outputting any video to it.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <returns>a window handle or NULL if there are none.</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_player_get_hwnd(IntPtr p_mi);

        /// <summary>
        /// Set a Win32/Win64 API window handle (HWND) where the media player should render its video output.
        /// If LibVLC was built without Win32/Win64 API output support, then this has no effect.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <param name="drawable">windows handle of the drawable</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_player_set_hwnd(IntPtr p_mi, IntPtr drawable);

        /// <summary>
        /// Release a media_player after use Decrement the reference count of a media player object.
        /// If the reference count is 0, then libvlc_media_player_release() will release the media player object. If the media player object has been released, then it should not be used again.
        /// </summary>
        /// <param name="p_mi">the Media Player to free</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_player_release(IntPtr p_mi);

        /// <summary>
        /// Set the media that will be used by the media player.
        /// If any, previous md will be released.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <param name="p_md">the Media. Afterwards the p_md can be safely destroyed.</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_player_set_media(IntPtr p_mi, IntPtr p_md);

        /// <summary>
        /// Get the media used by the media_player.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <returns>the media associated with p_mi, or NULL if no media is associated</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_player_get_media(IntPtr p_mi);

        /// <summary>
        /// Get the event manager from which the media player sends events.
        /// </summary>
        /// <param name="p_mi">the media player</param>
        /// <returns>the event manager</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_player_event_manager(IntPtr p_mi);

        /// <summary>
        /// Play
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <returns>0 if playback started (or was already started), or -1 on error.</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_media_player_play(IntPtr p_mi);

        /// <summary>
        /// Toggle pause (no effect if there is no media).
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_player_pause(IntPtr p_mi);

        /// <summary>
        /// Pause or resume (no effect if there is no media).
        /// </summary>
        /// <param name="p_mp">the Media Player</param>
        /// <param name="do_pause">play/resume if zero, pause if non-zero</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_player_set_pause(IntPtr p_mp, int do_pause);

        /// <summary>
        /// Stop (no effect if there is no media).
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_player_stop(IntPtr p_mi);

        /// <summary>
        /// Is the player able to play.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <returns>boolean</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_media_player_will_play(IntPtr p_mi);

        /// <summary>
        /// Is this media player seekable?
        /// </summary>
        /// <param name="p_mi">the media player</param>
        /// <returns>true if the media player can seek</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_media_player_is_seekable(IntPtr p_mi);

        /// <summary>
        /// Can this media player be paused?
        /// </summary>
        /// <param name="p_mi">the media player</param>
        /// <returns>true if the media player can pause</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_media_player_can_pause(IntPtr p_mi);

        /// <summary>
        /// Is this media player playing?
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <returns>1 if the media player is playing, 0 otherwise.</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_media_player_is_playing(IntPtr p_mi);

        /// <summary>
        /// Get the current movie length (in ms).
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <returns>the movie length (in ms), or -1 if there is no media.</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern long libvlc_media_player_get_length(IntPtr p_mi);

        /// <summary>
        /// Get the current movie time (in ms).
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <returns>the movie time (in ms), or -1 if there is no media.</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern long libvlc_media_player_get_time(IntPtr p_mi);

        /// <summary>
        /// Set the movie time (in ms).
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <param name="i_time">the movie time (in ms)</param>
        /// <returns>the movie time (in ms), or -1 if there is no media.</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_player_set_time(IntPtr p_mi, long i_time);

        /// <summary>
        /// Get movie position as percentage between 0.0 and 1.0.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <returns>movie position, or -1. in case of error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern float libvlc_media_player_get_position(IntPtr p_mi);

        /// <summary>
        /// Set movie position as percentage between 0.0 and 1.0.
        /// This has no effect if playback is not enabled. This might not work depending on the underlying input format and protocol.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <param name="f_pos">the position</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_player_set_position(IntPtr p_mi, float f_pos);

        /// <summary>
        /// Set the movie chapter (if applicable).
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <param name="i_chapter">chapter number to play</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_player_set_chapter(IntPtr p_mi, int i_chapter);

        /// <summary>
        /// Get movie chapter
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <returns>chapter number currently playing, or -1 if there is no media.</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_media_player_get_chapter(IntPtr p_mi);

        /// <summary>
        /// Get movie chapter count.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <returns>number of chapters in movie, or -1</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_media_player_get_chapter_count(IntPtr p_mi);

        /// <summary>
        /// Get title chapter count.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <param name="i_title">title</param>
        /// <returns>number of chapters in title, or -1</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_media_player_get_chapter_count_for_title(IntPtr p_mi, int i_title);

        /// <summary>
        /// Set the movie title.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <param name="i_title">title number to play</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_player_set_title(IntPtr p_mi, int i_title);

        /// <summary>
        /// Get the movie title.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <returns>title number currently playing, or -1</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_media_player_get_title(IntPtr p_mi);

        /// <summary>
        /// Get movie title count
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <returns>title number count, or -1</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_media_player_get_title_count(IntPtr p_mi);

        /// <summary>
        /// Set previous chapter (if applicable).
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_player_previous_chapter(IntPtr p_mi);

        /// <summary>
        /// Set next chapter (if applicable).
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_player_next_chapter(IntPtr p_mi);

        /// <summary>
        /// Get the requested movie play rate.
        /// Warning: Depending on the underlying media, the requested rate may be different from the real playback rate.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <returns>movie play rate</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern float libvlc_media_player_get_rate(IntPtr p_mi);

        /// <summary>
        /// Set movie play rate.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <param name="rate">-1 if an error was detected, 0 otherwise (but even then, it might not actually work depending on the underlying media protocol).</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_player_set_rate(IntPtr p_mi, float rate);

        /// <summary>
        /// Get current movie state.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <returns>the current state of the media player (playing, paused, ...)</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_media_player_get_state(IntPtr p_mi);

        /// <summary>
        /// Get movie fps rate.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <returns>frames per second (fps) for this playing movie, or 0 if unspecified.</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern float libvlc_media_player_get_fps(IntPtr p_mi);

        /// <summary>
        /// How many video outputs does this media player have?
        /// </summary>
        /// <param name="p_mi">the media player</param>
        /// <returns>the number of video outputs</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint libvlc_media_player_has_vout(IntPtr p_mi);

        /// <summary>
        /// Release (free) libvlc_track_description_t.
        /// </summary>
        /// <param name="p_track_description">the structure to release</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_track_description_list_release(IntPtr p_track_description);

        #region Audio Controls
        /// <summary>
        /// Gets the list of available audio outputs.
        /// </summary>
        /// <param name="p_instance">libvlc instance</param>
        /// <returns>list of available audio outputs, or NULL in case of error.</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_audio_output_list_get(IntPtr p_instance);

        /// <summary>
        /// Sets the audio output.
        /// Note:
        /// Any change will take effect only after playback is stopped and restarted. Audio output cannot be changed while playing.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="psz_name">name of audio output, use psz_name</param>
        /// <returns>0 if function succeded, -1 if error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_audio_output_set(IntPtr p_mi, [MarshalAs(UnmanagedType.LPStr)] string psz_name);

        /// <summary>
        /// Frees the list of available audio outputs.
        /// </summary>
        /// <param name="p_list">list with audio outputs for release</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_audio_output_list_release(IntPtr p_list);

        /// <summary>
        /// Gets a list of audio output devices for a given audio output.
        /// Note:
        /// Not all audio outputs support this. In particular, an empty (NULL) list of devices does not imply that the specified audio output does not work.
        /// The list might not be exhaustive
        /// Warning:
        /// Some audio output devices in the list might not actually work in some circumstances. By default, it is recommended to not specify any explicit audio device.
        /// </summary>
        /// <param name="p_instance">libvlc instance</param>
        /// <param name="aout">audio output name (as returned by libvlc_audio_output_list_get())</param>
        /// <returns>A NULL-terminated linked list of potential audio output devices. It must be freed with libvlc_audio_output_device_list_release().</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_audio_output_device_list_get(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string aout);

        /// <summary>
        /// Frees a list of available audio output devices.
        /// </summary>
        /// <param name="p_list">list with audio output devices for release</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_audio_output_device_list_release(IntPtr p_list);

        /// <summary>
        /// Configures an explicit audio output device for a given audio output plugin.
        /// A list of possible devices can be obtained with libvlc_audio_output_device_list_get().
        /// Note:
        /// This function does not select the specified audio output plugin. libvlc_audio_output_set() is used for that purpose.
        /// Warning:
        /// The syntax for the device parameter depends on the audio output. This is not portable. Only use this function if you know what you are doing. Some audio outputs do not support this function (e.g. PulseAudio, WASAPI). Some audio outputs require further parameters (e.g. ALSA: channels map).
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="psz_audio_output">name of audio output</param>
        /// <param name="psz_device_id">device</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_audio_output_device_set(IntPtr p_mi, [MarshalAs(UnmanagedType.LPStr)] string psz_audio_output, [MarshalAs(UnmanagedType.LPStr)] string psz_device_id);

        /// <summary>
        /// Toggle mute status.
        /// </summary>
        /// <param name="p_mi">media player</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_audio_toggle_mute(IntPtr p_mi);

        /// <summary>
        /// Get current mute status.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <returns>the mute status (boolean) if defined, -1 if undefined/unapplicable</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_audio_get_mute(IntPtr p_mi);

        /// <summary>
        /// Set mute status.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <param name="status">If status is true then mute, otherwise unmute.</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_audio_set_mute(IntPtr p_mi, int status);

        /// <summary>
        /// Get current software audio volume.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <returns>the software volume in percents (0 = mute, 100 = nominal / 0dB)</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_audio_get_volume(IntPtr p_mi);

        /// <summary>
        /// Set current software audio volume.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="i_volume">the volume in percents (0 = mute, 100 = 0dB)</param>
        /// <returns>0 if the volume was set, -1 if it was out of range.</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_audio_set_volume(IntPtr p_mi, int i_volume);

        /// <summary>
        /// Get number of available audio tracks.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <returns>the number of available audio tracks (int), or -1 if unavailable</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_audio_get_track_count(IntPtr p_mi);

        /// <summary>
        /// Get the description of available audio tracks.
        /// Note: This IntPtr points to the first in a list of libvlc_track_description_t structs.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <returns>list with description of available audio tracks, or NULL</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_audio_get_track_description(IntPtr p_mi);

        /// <summary>
        /// Get the current audio track.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <returns>the number of available audio tracks (int), or -1 if unavailable</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_audio_get_track(IntPtr p_mi);

        /// <summary>
        /// Set current audio track.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="i_track">the track ID (i_id field from track description)</param>
        /// <returns>0 on success, -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_audio_set_track(IntPtr p_mi, int i_track);

        /// <summary>
        /// Get current audio channel.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <returns>the audio channel</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_audio_get_channel(IntPtr p_mi);

        /// <summary>
        /// Set current audio channel.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="channel">the audio channel</param>
        /// <returns>0 on success, -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_audio_set_channel(IntPtr p_mi, int channel);

        /// <summary>
        /// Get current audio delay.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <returns>the audio delay (microseconds)</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern long libvlc_audio_get_delay(IntPtr p_mi);

        /// <summary>
        /// Set current audio delay.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="i_delay">the audio delay (microseconds)</param>
        /// <returns>0 on success, -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_audio_set_delay(IntPtr p_mi, long i_delay);

        #endregion

        #region Video Controls
        /// <summary>
        /// Toggle fullscreen status on non-embedded video outputs.
        /// </summary>
        /// <param name="p_mi">the media player</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_toggle_fullscreen(IntPtr p_mi);

        /// <summary>
        /// Enable or disable fullscreen.
        /// Warning:
        /// With most window managers, only a top-level window can be in full-screen mode. Hence, this function will not operate properly if if libvlc_media_player_set_xwindow() was
        /// used to embed the video in a non-top-level window. In that case, the embedding window must be reparented to the root window *before* fullscreen mode is enabled. You will want
        /// to reparent it back to its normal parent when disabling fullscreen.
        /// </summary>
        /// <param name="p_mi">the media player</param>
        /// <param name="b_fullscreen">boolean for fullscreen status</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_set_fullscreen(IntPtr p_mi, int b_fullscreen);

        /// <summary>
        /// Get current fullscreen status.
        /// </summary>
        /// <param name="p_mi">the media player</param>
        /// <returns>the fullscreen status (boolean)</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_get_fullscreen(IntPtr p_mi);

        /// <summary>
        /// Enable or disable key press events handling, according to the LibVLC hotkeys configuration.
        /// By default and for historical reasons, keyboard events are handled by the LibVLC video widget.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="on">true to handle key press events, false to ignore them.</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_video_set_key_input(IntPtr p_mi, uint on);

        /// <summary>
        /// Enable or disable mouse click events handling.
        /// By default, those events are handled. This is needed for DVD menus to work, as well as a few video filters such as "puzzle".
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="on">true to handle mouse click events, false to ignore them.</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_video_set_mouse_input(IntPtr p_mi, uint on);

        /// <summary>
        /// Get the pixel dimensions of a video.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="num">number of the video (starting from and most commonly 0)</param>
        /// <param name="px">pointer to get the pixel width</param>
        /// <param name="py">pointer to get the pixel height</param>
        /// <returns>0 on success, -1 if the specified video does not exist</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_video_get_size(IntPtr p_mi, uint num, out uint px, out uint py);

        /// <summary>
        /// Get the mouse pointer coordinates over a video.
        /// Coordinates are expressed in terms of the decoded video resolution, not in terms of pixels on the screen/viewport (to get the latter, you can query your windowing system directly).
        /// Either of the coordinates may be negative or larger than the corresponding dimension of the video, if the cursor is outside the rendering area.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="num">number of the video (starting from, and most commonly 0)</param>
        /// <param name="px">pointer to get the abscissa (x-coordinate)</param>
        /// <param name="py">pointer to get the ordinate (y-coordinate)</param>
        /// <returns>0 on success, -1 if the specified video does not exist</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_video_get_cursor(IntPtr p_mi, uint num, out int px, out int py);

        /// <summary>
        /// Get the current video scaling factor.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <returns>the currently configured zoom factor, or 0. if the video is set to fit to the output window/drawable automatically</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern float libvlc_video_get_scale(IntPtr p_mi);

        /// <summary>
        /// Set the video scaling factor.
        /// That is the ratio of the number of pixels on screen to the number of pixels in the original decoded video in each dimension. Zero is a special value; it will adjust the video to the output window/drawable (in windowed mode) or the entire screen.
        /// Note that not all video outputs support scaling.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="f_factor">the scaling factor, or zero</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_video_set_scale(IntPtr p_mi, float f_factor);

        /// <summary>
        /// Get current video aspect ratio.
        /// </summary>
        /// <param name="p_mi">the media player</param>
        /// <returns>the video aspect ratio or NULL if unspecified</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_video_get_aspect_ratio(IntPtr p_mi);

        /// <summary>
        /// Set new video aspect ratio
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="psz_aspect">new video aspect-ratio or NULL to reset to default</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_video_set_aspect_ratio(IntPtr p_mi, [MarshalAs(UnmanagedType.LPStr)] string psz_aspect);

        /// <summary>
        /// Get current video subtitle.
        /// </summary>
        /// <param name="p_mi">the media player</param>
        /// <returns>the video subtitle selected, or -1 if none</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_video_get_spu(IntPtr p_mi);

        /// <summary>
        /// Get the number of available video subtitles
        /// </summary>
        /// <param name="p_mi">the media player</param>
        /// <returns>the number of available video subtitles</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_video_get_spu_count(IntPtr p_mi);

        /// <summary>
        /// Get the description of available video subtitles
        /// </summary>
        /// <param name="p_mi">the media player</param>
        /// <returns>list containing description of available video subtitles</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_video_get_spu_description(IntPtr p_mi);

        /// <summary>
        /// Set the new video subtitle
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="i_spu">new video subtitle to select</param>
        /// <returns>0 on success, -1 if out of range</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_video_set_spu(IntPtr p_mi, uint i_spu);

        /// <summary>
        /// Set new video subtitle file.
        /// </summary>
        /// <param name="p_mi">the media player</param>
        /// <param name="psz_subtitle">new video subtitle file</param>
        /// <returns>the success status (boolean)</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_video_set_subtitle_file(IntPtr p_mi, [MarshalAs(UnmanagedType.LPStr)] string psz_subtitle);

        /// <summary>
        /// Get the current subtitle delay.
        /// Positive values means subtitles are being displayed later, negative values earlier.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <returns>time (in milliseconds) the display of subtitles is being delayed</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern long libvlc_video_get_spu_delay(IntPtr p_mi);

        /// <summary>
        /// Set the subtitle delay.
        /// This affects the timing of when the subtitle will be displayed. Positive values result in subtitles being displayed later, while negative values will result in subtitles being displayed earlier.
        /// The subtitle delay will be reset to zero each time the media changes.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="i_delay">time (in microseconds) the display of subtitles should be delayed.</param>
        /// <returns>0 on success, -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_video_set_spu_delay(IntPtr p_mi, long i_delay);

        /// <summary>
        /// Get the description of available titles.
        /// </summary>
        /// <param name="p_mi">the media player</param>
        /// <returns>list containing descripton of available titles</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_video_get_title_description(IntPtr p_mi);

        /// <summary>
        /// Get the description of available chapters for specific title.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="i_title">selected title</param>
        /// <returns>list containing description of available chapter for title i_title</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_video_get_chapter_description(IntPtr p_mi, int i_title);

        /// <summary>
        /// Get current crop filter geometry.
        /// </summary>
        /// <param name="p_mi">the media player</param>
        /// <returns>the crop filter geometry or NULL if unset</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_video_get_crop_geometry(IntPtr p_mi);

        /// <summary>
        /// Set new crop filter geometry.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="psz_geometry">new crop filter geometry</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_video_set_crop_geometry(IntPtr p_mi, [MarshalAs(UnmanagedType.LPStr)] string psz_geometry);

        /// <summary>
        /// Get current teletext page requested.
        /// </summary>
        /// <param name="p_mi">the media player</param>
        /// <returns>the current teletext page requested.</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_video_get_teletext(IntPtr p_mi);

        /// <summary>
        /// Set new teletext page to retrieve.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="i_page">teletext page number requested</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_video_set_teletext(IntPtr p_mi, int i_page);

        /// <summary>
        /// Toggle teletext transparent status on video output.
        /// </summary>
        /// <param name="p_mi">the media player</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_toggle_teletext(IntPtr p_mi);

        /// <summary>
        /// Get number of available video tracks.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <returns>the number of available video tracks (int)</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_video_get_track_count(IntPtr p_mi);

        /// <summary>
        /// Get the description of available video tracks.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <returns>list with description of available video tracks, or NULL on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_video_get_track_description(IntPtr p_mi);

        /// <summary>
        /// Get current video track
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <returns>the video track ID (int) or -1 if no active input</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_video_get_track(IntPtr p_mi);

        /// <summary>
        /// Set video track.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="i_track">the track ID (i_id field from track description)</param>
        /// <returns>0 on success, -1 if out of range</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_video_set_track(IntPtr p_mi, int i_track);

        /// <summary>
        /// Take a snapshot of the current video window.
        /// If i_width AND i_height is 0, original size is used. If i_width XOR i_height is 0, original aspect-ratio is preserved.
        /// </summary>
        /// <param name="p_mi">media player instance</param>
        /// <param name="num">number of video output (typically 0 for the first/only one)</param>
        /// <param name="psz_filepath">the path where to save the screenshot to</param>
        /// <param name="i_width">the snapshot's width</param>
        /// <param name="i_height">the snapshot's height</param>
        /// <returns>0 on success, -1 if the video was not found</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_video_take_snapshot(IntPtr p_mi, uint num, [MarshalAs(UnmanagedType.LPStr)] string psz_filepath, uint i_width, uint i_height);

        /// <summary>
        /// Enable or disable deinterlace filter.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="psz_mode">type of deinterlace filter, NULL to disable</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_video_set_deinterlace(IntPtr p_mi, [MarshalAs(UnmanagedType.LPStr)] string psz_mode);

        /// <summary>
        /// Get an integer marquee option value.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="option">marq option to get</param>
        /// <returns></returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_video_get_marquee_int(IntPtr p_mi, uint option);

        /// <summary>
        /// Get a string marquee option value.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="option">marq option to get</param>
        /// <returns></returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_video_get_marquee_string(IntPtr p_mi, uint option);

        /// <summary>
        /// Enable, disable or set an integer marquee option.
        /// Setting libvlc_marquee_Enable has the side effect of enabling (arg !0) or disabling (arg 0) the marq filter.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="option">marq option to set. values of libvlc_video_marquee_int_option_t</param>
        /// <param name="i_val">marq option value</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_video_set_marquee_int(IntPtr p_mi, uint option, int i_val);

        /// <summary>
        /// Set a marquee string option.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="option">marq option to set. values of libvlc_video_marquee_string_option_t</param>
        /// <param name="psz_text">marq option value</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_video_set_marquee_string(IntPtr p_mi, uint option, [MarshalAs(UnmanagedType.LPStr)] string psz_text);

        /// <summary>
        /// Get integer logo option
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="option">logo option to get, values of libvlc_video_logo_option_t</param>
        /// <returns></returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_video_get_logo_int(IntPtr p_mi, uint option);

        /// <summary>
        /// Set logo option as integer.
        /// Options that take a different type value are ignored. Passing libvlc_logo_enable as option value has the side effect of starting (arg !0) or stopping (arg 0) the logo filter.
        /// </summary>
        /// <param name="p_mi">libvlc media player instance</param>
        /// <param name="option">logo option to set, values of libvlc_video_logo_option_t</param>
        /// <param name="value">logo option value</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_video_set_logo_int(IntPtr p_mi, uint option, int value);

        /// <summary>
        /// Set logo option as string.
        /// Options that take a different type value are ignored.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="option">logo option to set, values of libvlc_video_logo_option_t</param>
        /// <param name="psz_value">logo option value</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_video_set_logo_string(IntPtr p_mi, uint option, [MarshalAs(UnmanagedType.LPStr)] string psz_value);

        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_video_get_logo_string(IntPtr p_mi, uint option);

        /// <summary>
        /// Get integer adjust option
        /// </summary>
        /// <param name="p_mi">the media player</param>
        /// <param name="option">adjust option to get, values of libvlc_video_adjust_option_t</param>
        /// <returns></returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_video_get_adjust_int(IntPtr p_mi, uint option);

        /// <summary>
        /// Set adjust option as integer
        /// Options that take a different type value are ignored. Passing libvlc_adjust_enable as option value has the side effect of starting (arg !0) or stopping (arg 0) the adjust filter.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="option">adjust option to set, values of libvlc_video_adjust_option_t</param>
        /// <param name="value">adjust option value</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_video_set_adjust_int(IntPtr p_mi, uint option, int value);

        /// <summary>
        /// Get float adjust option.
        /// </summary>
        /// <param name="p_mi">the media player</param>
        /// <param name="option">adjust option to get, values of libvlc_video_adjust_option_t</param>
        /// <returns></returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern float libvlc_video_get_adjust_float(IntPtr p_mi, uint option);

        /// <summary>
        /// Set adjust option as float.
        /// </summary>
        /// <param name="p_mi">media player</param>
        /// <param name="option">adjust option to set, values of libvlc_video_adjust_option_t</param>
        /// <param name="value">adjust option value</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_video_set_adjust_float(IntPtr p_mi, uint option, float value);
        #endregion
    }
}
