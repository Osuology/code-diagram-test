using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_DiagramFlowchart_Test_Myl
{
    interface IDrawableComponent
    {
        void Load(Texture2D texture);
        void Draw(SpriteBatch sb, Vector2 position, float scale, Color color);
    }
}
