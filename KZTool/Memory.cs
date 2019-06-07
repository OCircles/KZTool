using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace KZTool
{
    class Memory
    {

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

        const int PROCESS_WM_READ = 0x0010;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_OPERATION = 0x0008;
        const int PROCESS_ALL_ACCESS = 0x1F0FFF;


        public static int ReadInt(Process p, int address, bool ptr = false)
        {
            
            IntPtr processHandle = OpenProcess(PROCESS_WM_READ, false, p.Id);

            if (!ptr) address += p.MainModule.BaseAddress.ToInt32();

            int bytesRead = 0;
            byte[] buffer = new byte[8];
            
            ReadProcessMemory((int)processHandle, address, buffer, buffer.Length, ref bytesRead);

            return BitConverter.ToInt32(buffer, 0);
        }
        public static uint ReadIntPtr(Process p, int[] address)
        {

            uint value = (uint)ReadInt(p, address[0]);

            for ( int i = 1; i < address.Length; i++)
            {
                value += (uint)address[i];
                value = (uint)ReadInt(p, (int)value, true);
            }

            return value;
        }


        public static void WriteInt(Process p, int address, int value)
        {
            IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, p.Id);

            address += p.MainModule.BaseAddress.ToInt32();

            int bytesWritten = 0;
            byte[] buffer = BitConverter.GetBytes(value);
            
            WriteProcessMemory((int)processHandle, address, buffer, buffer.Length, ref bytesWritten);
        }


    }
}
