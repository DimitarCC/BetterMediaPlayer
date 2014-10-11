using System;
namespace com.ptrampert.LibVLCBind
{
    /// <summary>
    /// Event args containing a long value.
    /// </summary>
    public class LongEventArgs : EventArgs
    {
        /// <summary>
        /// The value.
        /// </summary>
        public long Value { get; private set; }
        internal LongEventArgs(long value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// Event args containing a float value.
    /// </summary>
    public class FloatEventArgs : EventArgs
    {
        /// <summary>
        /// The value.
        /// </summary>
        public float Value { get; private set; }
        internal FloatEventArgs(float value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// Event args containing an int value.
    /// </summary>
    public class IntEventArgs : EventArgs
    {
        /// <summary>
        /// The value.
        /// </summary>
        public int Value { get; private set; }
        internal IntEventArgs(int value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// Event args containing a bool value.
    /// </summary>
    public class BoolEventArgs : EventArgs
    {
        /// <summary>
        /// The value.
        /// </summary>
        public bool Value { get; private set; }
        internal BoolEventArgs(bool value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// Event args containing a string value.
    /// </summary>
    public class StringEventArgs : EventArgs
    {
        /// <summary>
        /// The value.
        /// </summary>
        public string Value { get; private set; }
        internal StringEventArgs(string value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// Event args for a MediaChanged event.
    /// </summary>
    public class MediaChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The new media.
        /// </summary>
        public IMedia Media { get; private set; }
        internal MediaChangedEventArgs(IMedia media)
        {
            Media = media;
        }
    }

    /// <summary>
    /// Event args for an EncounteredError event.
    /// </summary>
    public class EncounteredErrorEventArgs : EventArgs
    {
        /// <summary>
        /// The exception that occurred.
        /// </summary>
        public Exception E { get; private set; }
        internal EncounteredErrorEventArgs(Exception e)
        {
            E = e;
        }
    }

    /// <summary>
    /// Event args for StateChanged event.
    /// </summary>
    public class StateChangedEventArgs : EventArgs
    {
        private LIBVLC_STATE newState;
        /// <summary>
        /// New State.
        /// </summary>
        public LIBVLC_STATE NewState { get { return newState; } }
        internal StateChangedEventArgs(LIBVLC_STATE newState)
        {
            this.newState = newState;
        }
    }
}