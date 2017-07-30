using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI {
    class MouseEventArgs {
        int X, Y;
        ButtonState LeftButton, RightButton, MiddleButton;
        internal MouseEventArgs(int x, int y, 
            ButtonState lb = ButtonState.Released, ButtonState rb = ButtonState.Released, ButtonState mb = ButtonState.Released) {

            X = x; Y = y;
            LeftButton = lb; RightButton = rb; MiddleButton = mb;
        }
    }

    delegate bool MouseEventHandler(object sender, MouseEventArgs args);
}
