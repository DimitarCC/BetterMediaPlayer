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
        /// Release the vlm instance releated to the given libvlc_instance_t.
        /// </summary>
        /// <param name="p_instance">the instance</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_vlm_release(IntPtr p_instance);

        /// <summary>
        /// Add a broadcast, with one input.
        /// </summary>
        /// <param name="p_instance">the instance</param>
        /// <param name="psz_name">the name of the new broadcast</param>
        /// <param name="psz_input">the input MRL</param>
        /// <param name="psz_output">the output MRL (the parameter to the "sout" variable)</param>
        /// <param name="i_options">number of additional options</param>
        /// <param name="ppsz_options">additional options</param>
        /// <param name="b_enabled">boolean for enabling the new broadcast</param>
        /// <param name="b_loop">Should this broadcast be played in a loop?</param>
        /// <returns>0 on success, -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_vlm_add_broadcast(
            IntPtr p_instance,
            [MarshalAs(UnmanagedType.LPStr)] string psz_name,
            [MarshalAs(UnmanagedType.LPStr)] string psz_input,
            [MarshalAs(UnmanagedType.LPStr)] string psz_output,
            int i_options,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] ppsz_options,
            int b_enabled,
            int b_loop);

        /// <summary>
        /// Add a VOD, with one input.
        /// </summary>
        /// <param name="p_instance">the instance</param>
        /// <param name="psz_name">the name of the new broadcast</param>
        /// <param name="psz_input">the input MRL</param>
        /// <param name="psz_output">the output MRL (the parameter to the "sout" variable)</param>
        /// <param name="i_options">number of additional options</param>
        /// <param name="ppsz_options">additional options</param>
        /// <param name="b_enabled">boolean for enabling the new VOD</param>
        /// <param name="psz_mux">the muxer of the vod media</param>
        /// <returns>0 on success, -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_vlm_add_vod(
            IntPtr p_instance,
            [MarshalAs(UnmanagedType.LPStr)] string psz_name,
            [MarshalAs(UnmanagedType.LPStr)] string psz_input,
            [MarshalAs(UnmanagedType.LPStr)] string psz_output,
            int i_options,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] ppsz_options,
            int b_enabled,
            [MarshalAs(UnmanagedType.LPStr)] string psz_mux);

        /// <summary>
        /// Delete a media (VOD or broadcast).
        /// </summary>
        /// <param name="p_instance">the instance</param>
        /// <param name="psz_name">the media to delete</param>
        /// <returns>0 on success, -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_vlm_del_media(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string psz_name);

        /// <summary>
        /// Enable or disable a media (VOD or broadcast)
        /// </summary>
        /// <param name="p_instance">the instance</param>
        /// <param name="psz_name">the media to work on</param>
        /// <param name="b_enabled">the new status</param>
        /// <returns>0 on success, -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_vlm_set_enabled(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string psz_name, int b_enabled);

        /// <summary>
        /// Set the output for a media.
        /// </summary>
        /// <param name="p_instance">the instance</param>
        /// <param name="psz_name">the media to work on</param>
        /// <param name="psz_output">the output MRL (the parameter to the "sout" variable)</param>
        /// <returns>0 on success, -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_vlm_set_output(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string psz_name, [MarshalAs(UnmanagedType.LPStr)] string psz_output);

        /// <summary>
        /// Set a media's input MRL.
        /// This will delete all existing inputs and add the specified one.
        /// </summary>
        /// <param name="p_instance">the instance</param>
        /// <param name="psz_name">the media to work on</param>
        /// <param name="psz_input">the input MRL</param>
        /// <returns>0 on success, -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_vlm_set_input(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string psz_name, [MarshalAs(UnmanagedType.LPStr)] string psz_input);

        /// <summary>
        /// Add a media's input MRL.
        /// This will add the specified one.
        /// </summary>
        /// <param name="p_instance">the instance</param>
        /// <param name="psz_name">the media to work on</param>
        /// <param name="psz_input">the input MRL</param>
        /// <returns>0 on success, -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_vlm_add_input(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string psz_name, [MarshalAs(UnmanagedType.LPStr)] string psz_input);

        /// <summary>
        /// Set a media's loop status
        /// </summary>
        /// <param name="p_instance">the instance</param>
        /// <param name="psz_name">the media to work on</param>
        /// <param name="b_loop">the input MRL</param>
        /// <returns>0 on success, -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_vlm_set_loop(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string psz_name, int b_loop);

        /// <summary>
        /// Set a media's vod muxer.
        /// </summary>
        /// <param name="p_instance">the instance</param>
        /// <param name="psz_name">the media to work on</param>
        /// <param name="psz_mux">the new muxer</param>
        /// <returns>0 on success, -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_vlm_set_mux(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string psz_name, [MarshalAs(UnmanagedType.LPStr)] string psz_mux);

        /// <summary>
        /// Edit the parameters of a media.
        /// This will delete all existing inputs and add the specified one.
        /// </summary>
        /// <param name="p_instance">the instance</param>
        /// <param name="psz_name">the name of the new broadcast</param>
        /// <param name="psz_input">the input MRL</param>
        /// <param name="psz_output">the output MRL (the parameter to the "sout" variable)</param>
        /// <param name="i_options">number of additional options</param>
        /// <param name="ppsz_options">additional options</param>
        /// <param name="b_enabled">boolean for enabling the new broadcast</param>
        /// <param name="b_loop">should this broadcast be played in a loop?</param>
        /// <returns>0 on success, -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_vlm_change_media(
            IntPtr p_instance,
            [MarshalAs(UnmanagedType.LPStr)] string psz_name,
            [MarshalAs(UnmanagedType.LPStr)] string psz_input,
            [MarshalAs(UnmanagedType.LPStr)] string psz_output,
            int i_options,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] ppsz_options,
            int b_enabled,
            int b_loop);

        /// <summary>
        /// Play the named broadcast.
        /// </summary>
        /// <param name="p_instance">the instance</param>
        /// <param name="psz_name">the name of the broadcast</param>
        /// <returns>0 on success, -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_vlm_play_media(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string psz_name);

        /// <summary>
        /// Stop the named broadcast.
        /// </summary>
        /// <param name="p_instance">the instance</param>
        /// <param name="psz_name">the name of the broadcast</param>
        /// <returns>0 on success, -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_vlm_stop_media(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string psz_name);

        /// <summary>
        /// Pause the named broadcast.
        /// </summary>
        /// <param name="p_instance">the instance</param>
        /// <param name="psz_name">the name of the broadcast</param>
        /// <returns>0 on success, -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_vlm_pause_media(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string psz_name);

        /// <summary>
        /// Seek in the named broadcast.
        /// </summary>
        /// <param name="p_instance">the instance</param>
        /// <param name="psz_name">the name of the broadcast</param>
        /// <param name="f_percentage">the percentage to seek to</param>
        /// <returns>0 on success, -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_vlm_seek_media(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string psz_name, float f_percentage);

        /// <summary>
        /// Return information about the named media as a JSON string representation.
        /// This function is mainly intended for debugging use, if you want programmatic access to the state of a vlm_media_instance_t, 
        /// please use the corresponding libvlc_vlm_get_media_instance_xxx functions. Currently there are no such functions available for vlm_media_t though.
        /// </summary>
        /// <param name="p_instance">the instance</param>
        /// <param name="psz_name">the name of the media, if the name is an empty string, all media is described</param>
        /// <returns>string with information about named media, or NULL on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_vlm_show_media(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string psz_name);

        /// <summary>
        /// Get vlm_media instance position by name or instance id.
        /// </summary>
        /// <param name="p_instance">a libvlc instance</param>
        /// <param name="psz_name">name of vlm media instance</param>
        /// <param name="i_instance">instance id</param>
        /// <returns>position as float or -1. on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern float libvlc_vlm_get_media_instance_position(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string psz_name, int i_instance);

        /// <summary>
        /// Get vlm_media instance time by name or instance id.
        /// </summary>
        /// <param name="p_instance">a libvlc instance</param>
        /// <param name="psz_name">instance id</param>
        /// <param name="i_instance">time as integer or -1 on error</param>
        /// <returns>0 on success, -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_vlm_get_media_instance_time(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string psz_name, int i_instance);

        /// <summary>
        /// Get vlm_media instance length by name or instance id.
        /// </summary>
        /// <param name="p_instance">a libvlc instance</param>
        /// <param name="psz_name">name of vlm media instance</param>
        /// <param name="i_instance">instance id</param>
        /// <returns>length of media item or -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_vlm_get_media_instance_length(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string psz_name, int i_instance);

        /// <summary>
        /// Get vlm_media instance playback rate by name or instance id.
        /// </summary>
        /// <param name="p_instance">a libvlc instance</param>
        /// <param name="psz_name">name of vlm media instance</param>
        /// <param name="i_instance">instance id</param>
        /// <returns>playback rate or -1 on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_vlm_get_media_instance_rate(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string psz_name, int i_instance);
    }
}
