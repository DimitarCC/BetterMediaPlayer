using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace com.ptrampert.LibVLCBind.Util
{
    /// <summary>
    /// Static methods to help with marshaling.
    /// </summary>
    internal static class MarshalHelpers
    {
        /// <summary>
        /// Converts a managed byte array to a struct.
        /// </summary>
        /// <typeparam name="T">Struct type.</typeparam>
        /// <param name="bytes">Bytes to convert.</param>
        /// <param name="str">Struct to store conversion in.</param>
        /// <exception cref="ArgumentException">ArgumentException</exception>
        public static void BytesToStruct<T>(byte[] bytes, ref T str) where T : struct
        {
            int len = Marshal.SizeOf(str);
            if (bytes.Length < len)
                throw new ArgumentException(string.Format("Cannot convert byte array of size {0} to struct of size {1}", bytes.Length, len));
            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.AllocHGlobal(len);
                Marshal.Copy(bytes, 0, ptr, len);
                str = (T)Marshal.PtrToStructure(ptr, typeof(T));
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Converts a struct of type T to a managed byte array.
        /// </summary>
        /// <typeparam name="T">Struct type.</typeparam>
        /// <param name="str">Struct to convert.</param>
        /// <returns>Struct as a byte array.</returns>
        public static byte[] StructToBytes<T>(T str) where T : struct
        {
            int len = Marshal.SizeOf(str);
            byte[] arr = new byte[len];
            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.AllocHGlobal(len);
                Marshal.StructureToPtr(str, ptr, true);
                Marshal.Copy(ptr, arr, 0, len);
                return arr;
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Marshal.FreeHGlobal(ptr);
            }
        }
    }
}
