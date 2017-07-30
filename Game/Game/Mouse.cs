using Game.GUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game {
    static class Mouse {

        internal enum Button {
            Left, Right, Middle
        }

        internal static int X {
            get { return newState.X; }
            set { Microsoft.Xna.Framework.Input.Mouse.SetPosition(value, Y); }
        }

        internal static int Y {
            get { return newState.Y; }
            set { Microsoft.Xna.Framework.Input.Mouse.SetPosition(X, value); }
        }

        internal static ButtonState LeftButton {
            get { return newState.LeftButton; }
        }

        internal static ButtonState RightButton {
            get { return newState.RightButton; }
        }

        internal static ButtonState MiddleButton {
            get { return newState.MiddleButton; }
        }

        static MouseState oldState, newState;
        static Texture2D textureNormal, texturePressed;

        internal static void Init() {
            oldState = newState = Microsoft.Xna.Framework.Input.Mouse.GetState();
            textureNormal = texturePressed = new Texture2D(Program.Game.GraphicsDevice, 1, 1);
        }

        internal static void SetTextures(Texture2D normal, Texture2D pressed) {
            textureNormal = normal;
            texturePressed = pressed;
            Program.Game.IsMouseVisible = false;
        }

        internal static bool JustPressed(Button button) {
            switch (button) {
                case Button.Left: return newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released;
                case Button.Right: return newState.RightButton == ButtonState.Pressed && oldState.RightButton == ButtonState.Released;
                case Button.Middle: return newState.MiddleButton == ButtonState.Pressed && oldState.MiddleButton == ButtonState.Released;
                default: return false;
            }
        }

        internal static bool JustPressedAny() {
            return JustPressed(Button.Left) || JustPressed(Button.Right) || JustPressed(Button.Middle);
        }

        internal static bool JustReleased(Button button) {
            switch (button) {
                case Button.Left: return oldState.LeftButton == ButtonState.Pressed && newState.LeftButton == ButtonState.Released;
                case Button.Right: return oldState.RightButton == ButtonState.Pressed && newState.RightButton == ButtonState.Released;
                case Button.Middle: return oldState.MiddleButton == ButtonState.Pressed && newState.MiddleButton == ButtonState.Released;
                default: return false;
            }
        }

        internal static bool JustReleasedAny() {
            return JustReleased(Button.Left) || JustReleased(Button.Right) || JustReleased(Button.Middle);
        }

        internal static bool JustMoved() {
            return newState.X != oldState.X || newState.Y != oldState.Y;
        }

        internal static void Update() {
            oldState = newState;
            newState = Microsoft.Xna.Framework.Input.Mouse.GetState();

            MouseEventArgs args = new MouseEventArgs(X, Y, LeftButton, RightButton, MiddleButton);
            IPressable[] pressables = Gui.GetAll<IPressable>();

            foreach (IPressable p in pressables) {
                if (JustPressedAny()) {
                    bool b = true;
                    b &= p.OnRawPress(p, args);
                    if (p.IsHovering())
                        b &= p.OnPress(p, args);
                    if (!b) break;
                }
                else if (JustReleasedAny()) {
                    bool b = true;
                    b &= p.OnRawRelease(p, args);
                    if (p.IsHovering()) {
                        b &= p.OnRelease(p, args);
                        if (!p.IsFocused())
                            b &= p.OnFocus(p, args);
                    }
                    else if (p.IsFocused())
                        b &= p.OnUnfocus(p, args);
                    if (!b) break;
                }
            }

            if (JustMoved())
                foreach (IPressable p in pressables) {
                    bool b = true;
                    b &= p.OnMove(p, args);
                    if (!p.IsHovering() && p.GetBounds().Intersects(new Rectangle(X, Y, 1, 1)))
                        b &= p.OnHover(p, args);
                    else if (p.IsHovering() && !p.GetBounds().Intersects(new Rectangle(X, Y, 1, 1)))
                        b &= p.OnUnhover(p, args);
                    if (!b) break;
                }
        }

        internal static void Draw(SpriteBatch spriteBatch) {
            if (newState.LeftButton == ButtonState.Pressed || newState.RightButton == ButtonState.Pressed)
                spriteBatch.Draw(texturePressed, new Vector2(X, Y), Color.White);
            else
                spriteBatch.Draw(textureNormal, new Vector2(X, Y), Color.White);
        }
    }
}
