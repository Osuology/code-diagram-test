using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_DiagramFlowchart_Test_Myl
{
    class Tilemap
    {
        public List<Tile> tiles;
        public Vector2 position;

        public Tilemap(string path, int screenX, int screenY)
        {
            position = new Vector2(1920 * screenX, 1080 * screenY);

            tiles = new List<Tile>();
            //for (int x = 0; x < 16 * 4; x++)
            //{
            //    for (int y = 0; y < 9 * 5; y++)
            //    {
            //        tiles.Add(new Tile((int)((120 * x)+position.X), (int)((120 * y) + position.Y), 1));
            //    }
            //}
        }

        public void Load(ContentHouse ch)
        {
            foreach (Tile tile in tiles)
            {
                tile.LoadTexture(ch);
            }
        }

        public void Update(GameTime gt)
        {
            foreach (Tile tile in tiles)
                tile.Update(gt);
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Tile tile in tiles)
                tile.Draw(sb);
        }
    }
}
