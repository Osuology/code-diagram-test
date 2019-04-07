using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myl.Hitboxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_DiagramFlowchart_Test_Myl
{
    class Tile
    {
        public uint ID = 0;

        TextureComponent texture;

        public Vector2 position;
        Vector2 targetPosition;

        public RectangleHitbox hitbox;

        public string targetedScene = null;

        public Tile(int x, int y, uint id)
        {
            ID = id;
            position = new Vector2(x, y);
            hitbox = new RectangleHitbox(x, y, 120, 120);
            texture = new TextureComponent();
        }

        public void LoadTexture(ContentHouse ch)
        {
            switch (ID)
            {
                default:
                    texture.Load(ch.Get("tile_" + ID));
                    break;
            }
        }

        public void Update(GameTime gt)
        {
        }

        public void Draw(SpriteBatch sb)
        {
            texture.Draw(sb, position, 7.5f, Color.White);
        }
    }
}
