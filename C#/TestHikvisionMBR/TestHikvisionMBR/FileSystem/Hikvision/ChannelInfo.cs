using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recovery.FileSystem.Hikvision
{
    public class ChannelInfo
    {
        public int Channel { get; set; }
        public long StreamStartOffset { get; set; }
        public long LastStreamStartOffset { get; set; }

        public override string ToString()
        {
            return $"{{{Channel}, {StreamStartOffset}, {LastStreamStartOffset}}}";
        }
    }
}
