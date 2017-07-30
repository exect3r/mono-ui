using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game;

namespace Game.GUI {
    class Element : IElement {
        protected string id;
        protected bool deleted, visible;
        protected Vector2 position;
        protected IElement parent;
        protected Texture2D texture;

        public Element(string Id) {
            id = Id;
            deleted = false;
            visible = true;
            position = Vector2.Zero;
            texture = new Texture2D(Program.Game.GraphicsDevice, 1, 1);
        }

        public virtual IElement Delete() {
            deleted = true;
            return this;
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            if (visible)
                spriteBatch.Draw(texture, position, Color.White);
        }

        public virtual string GetId() {
            return id;
        }

        public virtual IElement GetParent() {
            return parent;
        }

        public virtual Texture2D GetTexture() {
            return texture;
        }

        public virtual float GetX() {
            return position.X;
        }

        public virtual float GetY() {
            return position.Y;
        }

        public virtual bool IsMarkedForDelete() {
            return deleted;
        }

        public virtual bool IsVisible() {
            return visible;
        }

        public virtual IElement SetParent(IElement parent) {
            this.parent = parent;
            return this;
        }

        public virtual IElement SetTexture(Texture2D texture) {
            this.texture = texture;
            return this;
        }

        public virtual IElement SetVisible(bool visible) {
            this.visible = visible;
            return this;
        }

        public virtual IElement SetX(float x) {
            position.X = x;
            return this;
        }

        public virtual IElement SetY(float y) {
            position.Y = y;
            return this;
        }

        public virtual void Update(GameTime gameTime) {
            
        }
    }
}
