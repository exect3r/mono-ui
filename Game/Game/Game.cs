using Game.GUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Game {
    public class Game : Microsoft.Xna.Framework.Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize() {
            IsMouseVisible = true;

            // Initializes the components.
            // P.S: Although my implementations of Keyboard and Mouse aren't required, you would have to
            // make some changes in the GUI code to replace them with your implementations.
            Keyboard.Init();
            Mouse.Init(); // Uses Program.Game.GraphicsDevice and Program.Game.IsMouseVisible fields.
            Gui.Init();

            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Optional: Sets custom Mouse cursor. (Software)
            // Mouse.SetTextures(Content.Load<Texture2D>("NORMAL"), Content.Load<Texture2D>("PRESSED"));

            // Loads resources used by the GUI elements. Uses Program.Game.Content field.
            Gui.Load();

            // Adds elements to the GUI. This adds an element that showcases all IPressable events and another that deletes it.
            Gui.Add(
                new Pressable("test")
                .SetOnFocusListener     ((s, e) => { Console.WriteLine("Focus");        return true; })
                .SetOnHoverListener     ((s, e) => { Console.WriteLine("Hover");        return true; })
                .SetOnMoveListener      ((s, e) => { Console.WriteLine("Move");         return true; })
                .SetOnPressListener     ((s, e) => { Console.WriteLine("Press");        return true; })
                .SetOnRawPressListener  ((s, e) => { Console.WriteLine("RawPress");     return true; })
                .SetOnRawReleaseListener((s, e) => { Console.WriteLine("RawRelease");   return true; })
                .SetOnReleaseListener   ((s, e) => { Console.WriteLine("Release");      return true; })
                .SetOnUnfocusListener   ((s, e) => { Console.WriteLine("Unfocus");      return true; })
                .SetOnUnhoverListener   ((s, e) => { Console.WriteLine("Unhover");      return true; })
                .SetBounds(0, 0, 100, 100),

                new Pressable("deleter")
                .SetOnPressListener((s, e) => {
                    Gui.Get<IElement>("test").Delete();
                    // Or: Gui.Remove("test", "test2", "test3", ...);
                    // Or: Gui.RemoveAll(el => el.GetId() == "test");
                    // Or: Gui.Clear(); to delete every element.
                    return true;
                })
                .SetBounds(0, 100, 100, 100)
            );

            // GUI is by default hidden. Use Gui.Show() and Gui.Hide() to manipulate it's visibility.
            // P.S: GUI's visibility does not affect elements' visibilities. Simply nothing is drawn when GUI is hidden.
            Gui.Show();
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.IsKeyDown(Keys.Escape))
                Exit();

            // Updates the components.
            Keyboard.Update();
            Mouse.Update();
            Gui.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // Draws the components. The order might affect which is on top of which depending on your
            // settings.
            Gui.Draw(spriteBatch, gameTime);
            Mouse.Draw(spriteBatch); // This is useless if you don't plan on using a custom Mouse cursor.

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
