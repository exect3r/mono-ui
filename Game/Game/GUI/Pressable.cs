using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game.GUI {
    class Pressable : Element, IPressable {

        protected Rectangle bounds;
        protected bool hovering, focused;

        // P.S: Return false in any of the events to consume it, meaning it won't propagate to other elements.
        // P.P.S: Order your GUI elements carefully to avoid unwanted event consumption.
        // P.P.P.S: Events trigger order:
        //  1 - RawPress or RawRelease
        //  2 - Press or Release 
        //  3 - (If the event is Release: Focus or Unfocus)
        //  4 - Move
        //  5 - Hover or Unhover

        // Trigger when Mouse is just pressed or just released when in Bounds.
        public event MouseEventHandler Press;
        public event MouseEventHandler Release;
        public event MouseEventHandler Focus;
        // Triggers once when Mouse is just pressed or just released when out of Bounds. 
        public event MouseEventHandler Unfocus;
        // Trigger when Mouse just enters or just leaves the Bounds.
        public event MouseEventHandler Hover;
        public event MouseEventHandler Unhover;
        // Trigger when Mouse is just pressed or just released even out of Bounds.
        public event MouseEventHandler RawPress;
        public event MouseEventHandler RawRelease;
        // Triggers every time Mouse moves.
        public event MouseEventHandler Move;

        public Pressable(string Id) : base(Id) {
            bounds = new Rectangle(0, 0, 0, 0);
            hovering = focused = false;
        }

        public IPressable SetBounds(int x, int y, int width, int height) {
            bounds = new Rectangle(x, y, width, height);
            return this;
        }

        public Rectangle GetBounds() {
            return bounds;
        }

        public IPressable SetHovering(bool state) {
            hovering = state;
            return this;
        }

        public bool IsHovering() {
            return hovering;
        }
        
        public IPressable SetFocus(bool state) {
            focused = state;
            return this;
        }

        public bool IsFocused() {
            return focused;
        }

        public virtual bool OnPress(object sender, MouseEventArgs args) {
            if (Press != null)
                return Press.Invoke(sender, args);
            return true;
        }

        public virtual bool OnRelease(object sender, MouseEventArgs args) {
            if (Release != null)
                return Release.Invoke(sender, args);
            return true;
        }

        public virtual bool OnFocus(object sender, MouseEventArgs args) {
            focused = true;
            if (Focus != null)
                return Focus.Invoke(sender, args);
            return true;
        }

        public virtual bool OnUnfocus(object sender, MouseEventArgs args) {
            focused = false;
            if (Unfocus != null)
                return Unfocus.Invoke(sender, args);
            return true;
        }

        public virtual bool OnHover(object sender, MouseEventArgs args) {
            hovering = true;
            if (Hover != null)
                return Hover.Invoke(sender, args);
            return true;
        }

        public virtual bool OnUnhover(object sender, MouseEventArgs args) {
            hovering = false;
            if (Unhover != null)
                return Unhover.Invoke(sender, args);
            return true;
        }

        public virtual bool OnRawPress(object sender, MouseEventArgs args) {
            if (RawPress != null)
                return RawPress.Invoke(sender, args);
            return true;
        }

        public virtual bool OnRawRelease(object sender, MouseEventArgs args) {
            if (RawRelease != null)
                return RawRelease.Invoke(sender, args);
            return true;
        }

        public virtual bool OnMove(object sender, MouseEventArgs args) {
            if (Move != null)
                return Move.Invoke(sender, args);
            return true;
        }

        public IPressable SetOnPressListener(MouseEventHandler listener) {
            Press += listener;
            return this;
        }

        public IPressable SetOnReleaseListener(MouseEventHandler listener) {
            Release += listener;
            return this;
        }

        public IPressable SetOnFocusListener(MouseEventHandler listener) {
            Focus += listener;
            return this;
        }

        public IPressable SetOnUnfocusListener(MouseEventHandler listener) {
            Unfocus += listener;
            return this;
        }

        public IPressable SetOnHoverListener(MouseEventHandler listener) {
            Hover += listener;
            return this;
        }

        public IPressable SetOnUnhoverListener(MouseEventHandler listener) {
            Unhover += listener;
            return this;
        }

        public IPressable SetOnRawPressListener(MouseEventHandler listener) {
            RawPress += listener;
            return this;
        }

        public IPressable SetOnRawReleaseListener(MouseEventHandler listener) {
            RawRelease += listener;
            return this;
        }

        public IPressable SetOnMoveListener(MouseEventHandler listener) {
            Move += listener;
            return this;
        }
    }
}
