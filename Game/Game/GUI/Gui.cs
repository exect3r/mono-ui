using Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI {
    static class Gui {
        static List<IElement> buffer;
        static bool visible;

        internal static void Init() {
            buffer = new List<IElement>();
            visible = false;
        }

        // TODO: Add draw and update orders.
        internal static void Load() {
            // Load default resources here using Program.Game.Content
        }

        internal static void Update(GameTime gameTime) {
            if (buffer.Count == 0) return;

            for (int i = 0; i < buffer.Count; i++)
                if (buffer[i].IsMarkedForDelete())
                    buffer.RemoveAt(i);
                else
                    buffer[i].Update(gameTime);

        }

        internal static void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            if (!visible) return;

            foreach (IElement e in buffer)
                if (e.IsVisible())
                    e.Draw(spriteBatch, gameTime);
        }

        internal static void Add(params IElement[] elements) {
            buffer.AddRange(elements);
        }

        internal static void Remove(params string[] Ids) {
            foreach(string Id in Ids) {
                int index = buffer.FindIndex(e => e.GetId() == Id);
                if (index > -1)
                    buffer.RemoveAt(index);
            }
        }

        internal static void RemoveAll(Predicate<IElement> match) {
            buffer.RemoveAll(match);
        }

        internal static void Clear() {
            buffer.Clear();
        }

        internal static void Show() {
            visible = true;
        }

        internal static void Hide() {
            visible = false;
        }

        internal static T Get<T>(string Id) where T: IElement {
            return (T)buffer.Find(e => e.GetId() == Id);
        }

        internal static T[] GetAll<T>() where T: IElement {
            List<T> t = new List<T>();
            foreach (IElement e in buffer)
                if (e is T)
                    t.Add((T)e);

            return t.ToArray();
        }
    }
}
