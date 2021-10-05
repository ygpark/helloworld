using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Recovery.FileSystem.Hikvision
{
    class HikvisionFileSystem
    {
        

        private bool _canRead = false;
        public bool CanRead { get { return _canRead; } }

        private MasterSector _masterSector = new MasterSector();
        public MasterSector MasterSector { get { return _masterSector; } }

        public List<ChannelInfo> ChannelInfoMap = new List<ChannelInfo>();




        public HikvisionFileSystem(Stream stream)
        {
            bool success = ParseMasterSector(stream);
            if (!success)
                return;

            success = ParseDataBlockInfo(stream);
            if (!success)
                return;

            // Done
            _canRead = true;
        }

        public bool ParseMasterSector(Stream stream)
        {
            byte[] array = new byte[512];

            // check error
            if (!(stream != null && stream.CanRead && 1024 <= stream.Length))
            {
                return false;
            }

            //Parse Master Sector
            stream.Position = 512;
            stream.Read(array, 0, 512);
            _masterSector = ByteArrayToStructure<MasterSector>(array);

            return true;
        }

        // MasterSector를 참조해서 list<BlockInfo>()를 생성한다.
        public bool ParseDataBlockInfo(Stream stream)
        {
            BlockInfo blockInfo_0 = new BlockInfo();
            BlockInfo blockInfo_N = new BlockInfo();

            // check error
            if (!(stream != null && stream.CanRead ))
            {
                return false;
            }

            try
            {
                long OffsetToVideoDataArea = _masterSector.OffsetToVideoDataArea;
                long DatablockSize = _masterSector.DatablockSize;
                long end = _masterSector.DatablockCount;
                long block_N_StartOffset;//DataBlock 시작 위치
                long block_N_InfoOffset;//DataBlockInfo는 DataBlock 끝에서 1MB 앞에 있다.
                byte[] buffer = new byte[512];
                int readLen;

                for (long i = 0; i < end; i++)
                {
                    block_N_StartOffset = OffsetToVideoDataArea + (i * DatablockSize);
                    //Console.WriteLine(block_N_StartOffset);
                    block_N_InfoOffset = block_N_StartOffset + DatablockSize - 1024 * 1024;/*1MB=1024*1024*/

                    stream.Position = block_N_InfoOffset;
                    //Console.WriteLine("{0:X}", block_N_InfoOffset);
                    //Raad BlockInfoHeader
                    readLen = stream.Read(buffer, 0, 512);
                    if (readLen == 0 || readLen != 512)
                        break;


                    var blockInfoHeader = ByteArrayToStructure<BlockInfoHeader>(buffer);

                    if (!blockInfoHeader.CanRead)
                    {
                        //Console.WriteLine("Can not read a header.");
                        continue;
                    } 

                    DumpIt(block_N_InfoOffset, buffer, readLen);

                    //Raad BlockInfo #0
                    readLen = stream.Read(buffer, 0, 512);
                    if (readLen != 512)
                        break;
                    blockInfo_0 = ByteArrayToStructure<BlockInfo>(buffer);

                    if (1 < blockInfoHeader.InfoCount)
                    {
                        //Skip BlockInfo #1...N-1
                        for (int j = 1; j < blockInfoHeader.InfoCount - 1; j++)
                        {
                            readLen = stream.Read(buffer, 0, 512);
                            if (readLen != 512)
                                break;
                            // <for DEBUG>
                            //var blockInfo = ByteArrayToStructure<BlockInfo>(buffer);
                            //Console.WriteLine($"[{j}] StartOffset: {blockInfo.StartOffset:X}, EndOffset: 0x{blockInfo.StartOffset:X} ");
                        }

                        //Raad BlockInfo #N
                        readLen = stream.Read(buffer, 0, 512);
                        if (readLen != 512)
                            break;
                        blockInfo_N = ByteArrayToStructure<BlockInfo>(buffer);
                        //Console.WriteLine($"[N] StartOffset: {blockInfo_N.StartOffset:X}, EndOffset: 0x{blockInfo_N.StartOffset:X} ");
                    }



                    //TODO: 채널 지도를 만들자. List{ 채널, 시작주소, 끝주소 }
                    long endOffset = blockInfoHeader.DataBlockStartOffset + blockInfo_0.EndOffset;


                    var channelInfo = new ChannelInfo()
                    {
                        Channel = blockInfoHeader.Channel,
                        StreamStartOffset = blockInfoHeader.DataBlockStartOffset + blockInfo_0.StartOffset,
                        LastStreamStartOffset = (blockInfo_N.EndOffset != 0) ? blockInfoHeader.DataBlockStartOffset + blockInfo_N.EndOffset : blockInfoHeader.DataBlockStartOffset + blockInfo_0.EndOffset
                    };

                    this.ChannelInfoMap.Add(channelInfo);

                    //Console.WriteLine($"CH: {blockInfoHeader.Channel}," +
                    //    $" StartBlockOffset: 0x{blockInfoHeader.DataBlockStartOffset:X}," +
                    //    $" InfoCount: {blockInfoHeader.InfoCount}," +
                    //    $" StartOffset: 0x{(blockInfoHeader.DataBlockStartOffset + blockInfo_0.StartOffset):X}, " +
                    //    $"EndOffset: 0x{(blockInfoHeader.DataBlockStartOffset + blockInfo_N.EndOffset):X} ");

                    //var blockInfo = new BlockInfoHeader();
                }
                foreach (ChannelInfo item in ChannelInfoMap)
                {
                    Console.WriteLine(item);
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


            return true;
        }

        private static void DumpIt(long block_N_InfoOffset, byte[] buffer, int readLen)
        {
            Console.Write($"[offset: {block_N_InfoOffset}] ");
            for (int j = 0; j < readLen; j++)
            {
                Console.Write($"{buffer[j]:X} ");
            }
            Console.WriteLine();
        }

        private T ByteArrayToStructure<T>(byte[] bytes)
        {
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T stuff = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return stuff;
        }
    }
}
