using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI {
    interface IPressable : IElement {
        // Trigger when Mouse is just pressed or just released when in Bounds.
        event MouseEventHandler Press;
        event MouseEventHandler Release;
        // Triggers once when Mouse is just pressed or just released when in Bounds. 
        event MouseEventHandler Focus;
        // Triggers once when Mouse is just pressed or just released when out of Bounds. 
        event MouseEventHandler Unfocus;
        // Trigger when Mouse just enters or just leaves the Bounds.
        event MouseEventHandler Hover;
        event MouseEventHandler Unhover;
        // Trigger when Mouse is just pressed or just released even out of Bounds.
        event MouseEventHandler RawPress;
        event MouseEventHandler RawRelease;
        // Triggers every time Mouse moves.
        event MouseEventHandler Move;

        IPressable SetBounds(int x, int y, int width, int height);
        Rectangle GetBounds();

        IPressable SetHovering(bool state);
        bool IsHovering();

        IPressable SetFocus(bool state);
        bool IsFocused();

        bool OnPress(object sender, MouseEventArgs args);
        bool OnRelease(object sender, MouseEventArgs args);
        bool OnFocus(object sender, MouseEventArgs args);
        bool OnUnfocus(object sender, MouseEventArgs args);
        bool OnHover(object sender, MouseEventArgs args);
        bool OnUnhover(object sender, MouseEventArgs args);
        bool OnRawPress(object sender, MouseEventArgs args);
        bool OnRawRelease(object sender, MouseEventArgs args);
        bool OnMove(object sender, MouseEventArgs args);

        // Listeners, just for the sake of method chaining.
        IPressable SetOnPressListener(MouseEventHandler listener);
        IPressable SetOnReleaseListener(MouseEventHandler listener);
        IPressable SetOnFocusListener(MouseEventHandler listener);
        IPressable SetOnUnfocusListener(MouseEventHandler listener);
        IPressable SetOnHoverListener(MouseEventHandler listener);
        IPressable SetOnUnhoverListener(MouseEventHandler listener);
        IPressable SetOnRawPressListener(MouseEventHandler listener);
        IPressable SetOnRawReleaseListener(MouseEventHandler listener);
        IPressable SetOnMoveListener(MouseEventHandler listener);
    }
}
