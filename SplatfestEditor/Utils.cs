using Syroot.BinaryData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplatfestEditor
{
    public static class Utils
    {
        public static int ReadInt24(this BinaryDataReader br)
        {
            byte[] b = br.ReadBytes(3);

            return (br.ByteOrder == ByteOrder.BigEndian || (!BitConverter.IsLittleEndian && br.ByteOrder == ByteOrder.System))
                ? (b[0] << 16) | (b[1] << 8) | b[2]
                : (b[2] << 16) | (b[1] << 8) | b[0];

        }
        public static void WriteInt24(this BinaryDataWriter bw, int value)
        {
            byte[] b = (bw.ByteOrder == ByteOrder.BigEndian || (!BitConverter.IsLittleEndian && bw.ByteOrder == ByteOrder.System))
            ? new byte[]
            {
                (byte)((value >> 16) & 0xFF),
                (byte)((value >> 8) & 0xFF),
                (byte)((value >> 0) & 0xFF),
            }
            : new byte[]
            {
                (byte)((value >> 0) & 0xFF),
                (byte)((value >> 8) & 0xFF),
                (byte)((value >> 16) & 0xFF),
            };
            bw.Write(b);

        }
    }
}
