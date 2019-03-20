using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_DiagramFlowchart_Test_Myl
{
    class TextureComponent : IDrawableComponent
    {
        Texture2D texture;

        public TextureComponent()
        {

        }

        public void Load(Texture2D text)
        {
            texture = text;
        }

        public void Draw(SpriteBatch sb, Vector2 position, float scale, Color color) 
        {
            sb.Draw(texture, new Rectangle((int)position.X, (int)position.Y, (int)(texture.Width * scale), (int)(texture.Height * scale)), color);
        }
    }
}
