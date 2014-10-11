using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace com.ptrampert.LibVLCBind.Hooks
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct libvlc_track_description_t
    {
        public int i_id;
        [MarshalAs(UnmanagedType.LPStr)]
        public string psz_name;
        public IntPtr p_next;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct libvlc_audio_output_t
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string psz_name;
        [MarshalAs(UnmanagedType.LPStr)]
        public string psz_description;
        public IntPtr p_next;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct libvlc_audio_output_device_t
    {
        public IntPtr p_next;
        [MarshalAs(UnmanagedType.LPStr)]
        public string psz_device;
        [MarshalAs(UnmanagedType.LPStr)]
        public string psz_description;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct libvlc_media_stats_t
    {
        public int i_read_bytes;
        public float f_input_bitrate;
        public int i_demux_read_bytes;
        public float f_demux_bitrate;
        public int i_demux_corrupted;
        public int i_demux_discontinuity;
        public int i_decoded_video;
        public int i_decoded_audio;
        public int i_displayed_pictures;
        public int i_lost_pictures;
        public int i_played_abuffers;
        public int i_lost_abuffers;
        public int i_sent_packets;
        public int i_sent_bytes;
        public float f_send_bitrate;
    }

    #region Async
    [StructLayout(LayoutKind.Explicit)]
    internal struct libvlc_event_t
    {
        [FieldOffset(0)]
        public LIBVLC_EVENT type;

        [FieldOffset(4)]
        public IntPtr p_obj;

        [FieldOffset(8)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] data;
    }
    #region Union Structs
    [StructLayout(LayoutKind.Sequential)]
    internal struct media_meta_changed
    {
        public LIBVLC_META meta_type;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_subitem_added
    {
        public IntPtr new_child;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_duration_changed
    {
        public long new_duration;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_parsed_changed
    {
        public int new_status;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_freed
    {
        public IntPtr handle;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_state_changed
    {
        public LIBVLC_STATE new_state;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_buffering
    {
        public float new_cache;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_position_changed
    {
        public float new_position;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_time_changed
    {
        public long new_time;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_title_changed
    {
        public int new_title;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_seekable_changed
    {
        public int new_seekable;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_pausable_changed
    {
        public int new_pausable;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_vout
    {
        public int new_count;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_list_item_added
    {
        public IntPtr item;
        public int index;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_list_will_add_item
    {
        public IntPtr item;
        public int index;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_list_item_deleted
    {
        public IntPtr item;
        public int index;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_list_will_delete_item
    {
        public IntPtr item;
        public int index;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_list_player_next_item_set
    {
        public IntPtr item;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_snapshot_taken
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string psz_filename;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_length_changed
    {
        public long new_length;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct vlm_media_event
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string psz_media_name;
        [MarshalAs(UnmanagedType.LPStr)]
        public string psz_instance_name;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_media_changed
    {
        public IntPtr new_media;
    }
    #endregion
    #endregion
}
