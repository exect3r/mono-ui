using System;

namespace Game {
    public static class Program {

        // This is used to access important fields like Content and GraphicsDevice.
        static internal Game Game;

        [STAThread]
        static void Main() {
            Game = new Game();
            Game.Run();
        }
    }
}
