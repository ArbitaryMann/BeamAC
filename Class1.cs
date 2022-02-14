using System.Diagnostics;

namespace BeamAnticheat
{
    public class ZLab
    {

       

        public class Metadata
        {
            public string speedhack64 = "Gd9"; // Probably the same on all cheat engine builds

        }
        public class Lib
        {
            public string buildNumber = "1.0.0";
       
            long returnMemorySize()
            {
                return Process.GetCurrentProcess().MainModule.ModuleMemorySize;
            }
            public void LogInfo()
            {

                Console.WriteLine("BeamAnticheat" + Environment.NewLine + "Build: " + buildNumber);
                Console.WriteLine("Start Module Size (useless) -> " + returnMemorySize());

            }
            
            public class Anticheat
            {
                [System.Runtime.InteropServices.DllImport("kernel32.dll")]
                private static extern void ReadProcessMemory(IntPtr handle, long where, byte[] data, int size, out int a);
                [System.Runtime.InteropServices.DllImport("kernel32.dll")]
                private static extern IntPtr OpenProcess(int han, bool bInheritHandle, int id);
                bool veh = false;
                bool saidOnce = false;
                void Loginfo()
                {
                    if (veh == false)
                    {
                        if (saidOnce == false)
                        {
                            Console.WriteLine("VEHDebugger [Loaded]");
                            saidOnce = true;
                        }
                    }
                }
                ZLab RequiredStuff = new ZLab();
                public void MaximumSecurityCheck(long Modbase)
                {
                    
                }   
                public void LoadBeamLib()
                {
                    
                    checkVEHDebug();
                }
                public void checkD3DHook()
                {
                    /*/
                     * ImGui / or any graphical hook (Exception)
                    /*/
                }
                public void checkVEHDebug()
                {
                   
                    veh = true;
                    
                        checkD3DHook();
                       
                        ProcessModuleCollection internalModules = Process.GetCurrentProcess().Modules;

                       
                        foreach (ProcessModule selfMod in internalModules)
                        {
                            IntPtr handle = OpenProcess(0x0FFFF, false, Process.GetCurrentProcess().Id);
                            byte[] modData = new byte[5];
                            int aa = 0;
                            ReadProcessMemory(handle, selfMod.BaseAddress.ToInt64() + 0x2DEB4, modData, 5, out aa);
                            var modDump = System.Text.ASCIIEncoding.ASCII.GetString(modData);
                            if (modDump.Contains(new Metadata().speedhack64))
                            {
                                Console.WriteLine("[Max-Security] SpeedHack-Injection Exception");
                                System.Threading.Thread.Sleep(2500);
                                Environment.Exit(1);
                            }
                            if (modDump.Contains(new Metadata().speedhack64))
                            {
                                Console.WriteLine("[Max-Security] SpeedHack-Injection Exception");
                                System.Threading.Thread.Sleep(1000);
                                Environment.Exit(1);
                            }
                            if (selfMod.ModuleName.Contains("speedhack"))
                            {
                                Debug.WriteLine("{speedhack} Exception");
                                System.Threading.Thread.Sleep(1000);
                                System.Environment.Exit(0);

                            }
                            if (selfMod.ModuleName.Contains("vehdebug"))
                            {
                                Debug.WriteLine("{Debugger} Exception");
                                System.Threading.Thread.Sleep(1000);
                                System.Environment.Exit(0);
                            }
                        

                    }


                }
            }
        }
       
    }
}