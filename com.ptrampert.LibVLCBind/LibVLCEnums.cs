using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ptrampert.LibVLCBind
{
    /// <summary>
    /// Enum representing the state of a VLCMediaPlayer.
    /// </summary>
    public enum LIBVLC_STATE 
    { 
        /// <summary>
        /// Player is Idle.
        /// </summary>
        NOTHING_SPECIAL,
        
        /// <summary>
        /// Player is opening.
        /// </summary>
        OPENING,
        
        /// <summary>
        /// Player is buffering.
        /// </summary>
        BUFFERING,

        /// <summary>
        /// Player is playing.
        /// </summary>
        PLAYING,

        /// <summary>
        /// Player is paused.
        /// </summary>
        PAUSED,

        /// <summary>
        /// Player is stopped.
        /// </summary>
        STOPPED,

        /// <summary>
        /// Player has ended.
        /// </summary>
        ENDED,

        /// <summary>
        /// Player has encountered an error.
        /// </summary>
        ERROR
    }

    /// <summary>
    /// Used to specify the requested logo option to get/set.
    /// </summary>
    public enum LIBVLC_LOGO_OPTIONS : uint
    {
        /// <summary>
        /// Enable the logo.
        /// </summary>
        ENABLE,

        /// <summary>
        /// Logo file.
        /// </summary>
        FILE,

        /// <summary>
        /// Logo x position.
        /// </summary>
        POS_X,

        /// <summary>
        /// Logo y position.
        /// </summary>
        POX_Y,

        /// <summary>
        /// Logo display delay.
        /// </summary>
        DELAY,

        /// <summary>
        /// Repeat the logo?
        /// </summary>
        REPEAT,

        /// <summary>
        /// Logo opacity.
        /// </summary>
        OPACITY,

        /// <summary>
        /// Logo position.
        /// </summary>
        POSITION
    }

    /// <summary>
    /// Used to specify the requested adjust option to get/set.
    /// </summary>
    public enum LIBVLC_ADJUST_OPTIONS : uint
    {
        /// <summary>
        /// Enable video adjusting.
        /// </summary>
        ENABLE,
        /// <summary>
        /// Contrast value.
        /// </summary>
        CONTRAST,

        /// <summary>
        /// Brightness value.
        /// </summary>
        BRIGHTNESS,

        /// <summary>
        /// Hue value.
        /// </summary>
        HUE,

        /// <summary>
        /// Saturation value.
        /// </summary>
        SATURATION,

        /// <summary>
        /// Gamma value.
        /// </summary>
        GAMMA
    }

    internal enum LIBVLC_META
    {
        TITLE,
        ARTIST,
        GENRE,
        COPYRIGHT,
        ALBUM,
        TRACK_NUMBER,
        DESCRIPTION,
        RATING,
        DATE,
        SETTING,
        URL,
        LANGUAGE,
        NOW_PLAYING,
        PUBLISHER,
        ENCODED_BY,
        ARTWORK_URL,
        TRACK_ID
    }

    internal enum LIBVLC_EVENT
    {
        MEDIA_META_CHANGED = 0,
        MEDIA_SUBITEM_ADDED,
        MEDIA_DURATION_CHANGED,
        MEDIA_PARSED_CHANGED,
        MEDIA_FREED,
        MEDIA_STATE_CHANGED,
        MEDIA_PLAYER_MEDIA_CHANGED = 0x100,
        MEDIA_PLAYER_NOTHING_SPECIAL,
        MEDIA_PLAYER_OPENING,
        MEDIA_PLAYER_BUFFERING,
        MEDIA_PLAYER_PLAYING,
        MEDIA_PLAYER_PAUSED,
        MEDIA_PLAYER_STOPPED,
        MEDIA_PLAYER_FORWARD,
        MEDIA_PLAYER_BACKWARD,
        MEDIA_PLAYER_END_REACHED,
        MEDIA_PLAYER_ENCOUNTERED_ERROR,
        MEDIA_PLAYER_TIME_CHANGED,
        MEDIA_PLAYER_POSITION_CHANGED,
        MEDIA_PLAYER_SEEKABLE_CHANGED,
        MEDIA_PLAYER_PAUSABLE_CHANGED,
        MEDIA_PLAYER_TITLE_CHANGED,
        MEDIA_PLAYER_SNAPSHOT_TAKEN,
        MEDIA_PLAYER_LENGTH_CHANGED,
        MEDIA_PLAYER_VOUT,
        MEDIA_LIST_ITEM_ADDED = 0x200,
        MEDIA_LIST_WILL_ADD_ITEM,
        MEDIA_LIST_ITEM_DELETED,
        MEDIA_LIST_WILL_DELETE_ITEM,
        MEDIA_LIST_PLAYER_PLAYED,
        MEDIA_LIST_PLAYER_NEXT_ITEM_SET,
        MEDIA_LIST_PLAYER_STOPPED,
        MEDIA_DISCOVERER_STARTED = 0x500,
        MEDIA_DISCOVERER_ENDED,
        VLM_MEDIA_ADDED = 0x600,
        VLM_MEDIA_REMOVED,
        VLM_MEDIA_CHANGED,
        VLM_MEDIA_INSTANCE_STARTED,
        VLM_MEDIA_INSTANCE_STOPPED,
        VLM_MEDIA_INSTANCE_STATUS_INIT,
        VLM_MEDIA_INSTANCE_STATUS_OPENING,
        VLM_MEDIA_INSTANCE_STATUS_PLAYING,
        VLM_MEDIA_INSTANCE_STATUS_PAUSE,
        VLM_MEDIA_INSTANCE_STATUS_END,
        VLM_MEDIA_INSTANCE_STATUS_ERROR
    }
}
