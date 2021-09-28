using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestHikvisionMBR
{
    class Program
    {
        /*
         * 채널 역할의 블록번호 구하는 공식
         * (stream.Position - HikvisionMasterSector.OffsetToVideoDataArea) / HikvisionMasterSector.DatablockSize
         * 
         * 
         * 
         */
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string solutionDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string path = Path.Combine(projectDirectory, "DS-7204HQHI-F1_MasterRecord.dd");
            byte[] array = new byte[512];
            FileStream s = File.OpenRead(path);

            s.Position = 512;
            s.Read(array, 0, 512);

            var masterSector = ByteArrayToStructure<FileSystem.Hikvision.MasterSector>(array);
            Console.WriteLine(masterSector.ToString(true));

            Console.WriteLine(masterSector.isValid()); 
        }

        static T ByteArrayToStructure<T>(byte[] bytes)
        {
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T stuff = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return stuff;
        }
    }
}
