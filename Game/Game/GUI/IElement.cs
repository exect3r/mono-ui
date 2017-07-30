using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GUI {
    interface IElement {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        IElement Delete();
        bool IsMarkedForDelete();
        IElement SetVisible(bool visible);
        bool IsVisible();
        string GetId();
        IElement SetX(float x);
        float GetX();
        IElement SetY(float y);
        float GetY();
        IElement SetTexture(Texture2D texture);
        Texture2D GetTexture();
        IElement SetParent(IElement parent);
        IElement GetParent();
    }
}
