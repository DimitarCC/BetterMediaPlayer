using com.ptrampert.LibVLCBind.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ptrampert.LibVLCBind
{
    /// <summary>
    /// Represents stats that are collected on a media as a media player is playing.
    /// </summary>
    public class MediaStats
    {
        /// <summary>
        /// Number of bytes read.
        /// </summary>
        public int ReadBytes { get; internal set; }

        /// <summary>
        /// The input bitrate.
        /// </summary>
        public float InputBitrate { get; internal set; }

        /// <summary>
        /// Demux bytes read.
        /// </summary>
        public int DemuxReadBytes { get; internal set; }

        /// <summary>
        /// Demux bitrate.
        /// </summary>
        public float DemuxBitrate { get; internal set; }

        /// <summary>
        /// Amount of demux corrupted.
        /// </summary>
        public int DemuxCorrupted { get; internal set; }

        /// <summary>
        /// Amount of demux discontinuity.
        /// </summary>
        public int DemuxDiscontinuity { get; internal set; }

        /// <summary>
        /// Amount of decoded video.
        /// </summary>
        public int DecodedVideo { get; internal set; }

        /// <summary>
        /// Amount of decoded audio.
        /// </summary>
        public int DecodedAudio { get; internal set; }

        /// <summary>
        /// Number of displayed pictures.
        /// </summary>
        public int DisplayedPictures { get; internal set; }

        /// <summary>
        /// Number of lost pictures.
        /// </summary>
        public int LostPictures { get; internal set; }

        /// <summary>
        /// Number of played audio buffers.
        /// </summary>
        public int PlayedAudioBuffers { get; internal set; }

        /// <summary>
        /// Number of lost audio buffers.
        /// </summary>
        public int LostAudioBuffers { get; internal set; }

        /// <summary>
        /// Number of sent packets.
        /// </summary>
        public int SentPackets { get; internal set; }

        /// <summary>
        /// Number of sent bytes.
        /// </summary>
        public int SentBytes { get; internal set; }

        /// <summary>
        /// The send bitrate.
        /// </summary>
        public float SendBitrate { get; internal set; }

        internal MediaStats(libvlc_media_stats_t stats)
        {
            ReadBytes = stats.i_read_bytes;
            InputBitrate = stats.f_input_bitrate;
            DemuxReadBytes = stats.i_demux_read_bytes;
            DemuxBitrate = stats.f_demux_bitrate;
            DemuxCorrupted = stats.i_demux_corrupted;
            DemuxDiscontinuity = stats.i_demux_discontinuity;
            DecodedVideo = stats.i_decoded_video;
            DecodedAudio = stats.i_decoded_audio;
            DisplayedPictures = stats.i_displayed_pictures;
            LostPictures = stats.i_lost_pictures;
            PlayedAudioBuffers = stats.i_played_abuffers;
            LostAudioBuffers = stats.i_lost_abuffers;
            SentPackets = stats.i_sent_packets;
            SentBytes = stats.i_sent_bytes;
            SendBitrate = stats.f_send_bitrate;
        }
    }
}
