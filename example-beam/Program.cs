using System.Diagnostics;
using Love;
using BeamAnticheat;
namespace anticheat_love
{
    public class Game : Scene
    {
        BeamAnticheat.ZLab.Lib.Anticheat Lib = new BeamAnticheat.ZLab.Lib.Anticheat();
        BeamAnticheat.ZLab.Lib LibInfo = new BeamAnticheat.ZLab.Lib();
      

    static void Main(string[] args)
        {
            BeamAnticheat.ZLab.Lib LibInfo = new BeamAnticheat.ZLab.Lib();
            LibInfo.LogInfo();
            Boot.Init();
            Boot.Run(new Game());
        }

        public override void Draw()
        {
        
            Lib.LoadBeamLib(); /*/ For Attachments of Cheat Engine Debuggers / SpeedHack /*/
            Graphics.Print("Game Test", 400, 300);
        }
    }

}

