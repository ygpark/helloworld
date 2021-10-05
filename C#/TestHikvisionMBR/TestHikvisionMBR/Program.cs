using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Recovery.FileSystem.Hikvision;
using GhostYak.IO.RawDiskDrive;

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
            //string path = Path.Combine(projectDirectory, "DS-7204HQHI-F1_MasterRecord.dd");
            //string path = Path.Combine(projectDirectory, @"D:\test\DS-7204HQHI-F1_중간부터(BlockInfo계산용).dd");
            //DS-7204HQHI-F1_중간부터(BlockInfo계산용).dd

            PhysicalStorage pe = new PhysicalStorage(7);
            
            
            HikvisionFileSystem fs = new HikvisionFileSystem(pe.OpenRead());

            if(fs.CanRead)
            {
                Console.WriteLine(fs.MasterSector.ToString(true));
                Console.WriteLine(fs.MasterSector.CanRead);
            }
            else
            {
                Console.WriteLine("Failure");
            }
        }
    }
}
