using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Code_DiagramFlowchart_Test_Myl
{
    class Player : Actor
    {
        public Player(int x, int y) : base(x, y)
        {
            textureScale = 0.1f;
        }

        public override void LoadTexture(Texture2D texture)
        {
            this.texture = new TextureComponent();
            this.texture.Load(texture);
        }

        public override void Update(GameTime gt)
        {
            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }
    }
}
