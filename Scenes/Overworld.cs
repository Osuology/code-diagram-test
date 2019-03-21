using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Code_DiagramFlowchart_Test_Myl.Scenes
{
    class Overworld : Scene
    {
        Actor actor;

        List<Tile> tiles;

        public Overworld()
        {
            actor = new Player(1920-128, 56);

            tiles = new List<Tile>();
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    tiles.Add(new Tile(128 * x, (128 * y)+56, 1));
                }
            }
        }

        public override void Load()
        {
            ch = new ContentHouse();
            ch.LoadTexture("test", "test");
            ch.LoadTexture("grass", "tile_1");

            actor.LoadTexture(ch.Get("test"));

            foreach (Tile tile in tiles)
            {
                tile.LoadTexture(ch);
            }
        }

        public override void Unload()
        {
            actor.LoadTexture(null);
            base.Unload();
        }

        public override void Update(GameTime gt)
        {
            actor.Update(gt);
            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {
            foreach (Tile tile in tiles)
            {
                tile.Draw(sb);
            }

            actor.Draw(sb);

            base.Draw(sb);
        }
    }
}
