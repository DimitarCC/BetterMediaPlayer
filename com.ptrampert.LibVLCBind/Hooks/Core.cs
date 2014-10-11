using System;
using System.Runtime.InteropServices;

namespace com.ptrampert.LibVLCBind.Hooks
{
    /// <summary>
    /// Callback delegate for libvlc async api.
    /// </summary>
    /// <param name="e">Pointer to libvlc_event_t</param>
    /// <param name="data">User data pointer</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void libvlc_callback_t(IntPtr e, IntPtr data);

    /// <summary>
    /// Provides hooks into the native functions in libvlc.dll
    /// </summary>
    internal static partial class NativeMethods
    {
        /// <summary>
        /// Create and initialize a libvlc instance.
        /// This function accepts a list of "command line" arguments similar to the main(). These arguments affect the LibVLC instance default configuration.
        /// </summary>
        /// <param name="argc">the number of arguments (should be 0)</param>
        /// <param name="argv">list of arguments (should be NULL)</param>
        /// <returns>the libvlc instance or NULL in case of error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_new(int argc, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] argv);

        /// <summary>
        /// Decrement the reference count of a libvlc instance, and destroy it if it reaches zero.
        /// </summary>
        /// <param name="p_instance">the instance to destroy</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_release(IntPtr p_instance);

        /// <summary>
        /// Frees a heap allocation returned by a LibVLC function.
        /// </summary>
        /// <param name="ptr"></param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_free(IntPtr ptr);

        /// <summary>
        /// Sets the application name.
        /// LibVLC passes this as the user agent string when a protocol requires it.
        /// </summary>
        /// <param name="p_instance">LibVLC Instance</param>
        /// <param name="name">Human-Readable application name.</param>
        /// <param name="http">HTTP User Agent</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_set_user_agent(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string http);

        /// <summary>
        /// Retrieve libvlc version.
        /// </summary>
        /// <returns>libvlc version</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_get_version();

        /// <summary>
        /// Retrieve libvlc compiler version
        /// </summary>
        /// <returns>libvlc compiler version</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_get_compiler();

        /// <summary>
        /// Retrieve libvlc changeset
        /// </summary>
        /// <returns>libvlc changeset</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_get_changeset();

        #region Exception
        /// <summary>
        /// A human-readable error message for the last LibVLC error in the calling thread.
        /// The resulting string is valid until another error occurs (at least until the next LibVLC call).
        /// </summary>
        /// <returns>Human readable error message, or null if there is no error.</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_errmsg();

        /// <summary>
        /// Clears the LibVLC error status for the current thread.
        /// This is optional. By default, the error status is automatically overridden when a new error occurs, and destroyed when the thread exits.
        /// </summary>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_clearerr();
        #endregion

        #region Async

        /// <summary>
        /// Register an event for notification.
        /// </summary>
        /// <param name="p_event_manager">	the event manager to which you want to attach to. Generally it is obtained by 
        /// vlc_my_object_event_manager() where my_object is the object you want to listen to.</param>
        /// <param name="i_event_type">the desired event to which we want to listen</param>
        /// <param name="f_callback">the function to call when i_event_type occurs</param>
        /// <param name="user_data">user provided data to carry with the event</param>
        /// <returns>0 on success, ENOMEM on error</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_event_attach(
            IntPtr p_event_manager, 
            LIBVLC_EVENT i_event_type, 
            [MarshalAs(UnmanagedType.FunctionPtr)]libvlc_callback_t f_callback, 
            IntPtr user_data);

        /// <summary>
        /// Unregister an event notification.
        /// </summary>
        /// <param name="p_event_manager">the event manager</param>
        /// <param name="i_event_type">the desired event to which we want to unregister</param>
        /// <param name="f_callback">the function to call when i_event_type occurs</param>
        /// <param name="p_user_data">user provided data to carry with the event</param>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_event_detach(
            IntPtr p_event_manager,
            LIBVLC_EVENT i_event_type,
            [MarshalAs(UnmanagedType.FunctionPtr)]libvlc_callback_t f_callback,
            IntPtr p_user_data);

        /// <summary>
        /// Get an event type's name.
        /// </summary>
        /// <param name="event_type">the desired event</param>
        /// <returns>the event's name</returns>
        [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_event_type_name(LIBVLC_EVENT event_type);
        #endregion
    }
}
