using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;


namespace WebKit
{
    internal class ActivationContextHelper
    {
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateActCtx(ref ActivationContextInfo info);

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern void ReleaseActCtx(IntPtr contextHandle);

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern bool ActivateActCtx(IntPtr contextHandle, out uint cookie);

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern bool DeactivateActCtx(uint flags, uint cookie);

        [StructLayout(LayoutKind.Sequential)]
        public struct ActivationContextInfo
        {
            public int     Size;
            public uint    Flags;
            public string  Source;
            public ushort  ProcessorArchitecture;
            public ushort  LanguageId;
            public string  AssemblyDirectory;
            public string  ResourceName;
            public string  ApplicationName;
            public IntPtr  ModuleHandle;
        }

        public ActivationContextHelper()
        {
            Activated = false;

            var assembly = Assembly.GetAssembly(typeof(ActivationContextHelper));

            _contextInfo         = new ActivationContextInfo();
            _contextInfo.Source  = assembly.Location + ".manifest";
            _contextInfo.Size    = Marshal.SizeOf(typeof(ActivationContextInfo));

            _contextHandle       = CreateActCtx(ref _contextInfo);
            _contextCookie       = 0;

            const int INVALID_POINTER = -1;

            if (_contextHandle == (IntPtr)INVALID_POINTER)
            {
                throw new Exception("Unable to create activation context");
            }
        }

        ~ActivationContextHelper()
        {
            ReleaseActCtx(_contextHandle);
        }

        public void Activate()
        {
            if (!Activated)
            {
                var result = ActivateActCtx(_contextHandle, out _contextCookie);

                if (!result)
                    throw new Exception("Unable to activate context");

                Activated = true;
            }
        }

        public void Deactivate()
        {
            if (Activated)
            {
                var result = DeactivateActCtx(0, _contextCookie);

                if (!result)
                    throw new Exception("Unable to deactivate context");

                Activated = false;
            }
        }

        private readonly IntPtr                 _contextHandle;
        private readonly ActivationContextInfo  _contextInfo;
        private uint                            _contextCookie;

        public bool Activated { get; private set; }
    }
}
