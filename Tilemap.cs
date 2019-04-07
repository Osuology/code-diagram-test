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
        public List<List<Tile>> layers;
        public int currentLayer = 0;
        Vector2 position;

        public Tilemap(int screenX, int screenY)
        {
            position = new Vector2(1920 * screenX, 1080 * screenY);

            layers = new List<List<Tile>>();
            layers.Add(new List<Tile>());
            //for (int x = 0; x < 16 * 4; x++)
            //{
            //    for (int y = 0; y < 9 * 5; y++)
            //    {
            //        tiles.Add(new Tile((int)((120 * x)+position.X), (int)((120 * y) + position.Y), 1));
            //    }
            //}
        }

        public void Load(ContentHouse ch, string path)
        {
            List<List<Tile>> tileS;
            using (StreamReader sr = File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                tileS = (List<List<Tile>>)serializer.Deserialize(sr, typeof(List<List<Tile>>));
            }

            layers = new List<List<Tile>>();
            for (int i = 0; i < tileS.Count; i++)
            {
                layers.Add(new List<Tile>());
                for (int h = 0; h < tileS[i].Count; h++)
                {
                    Tile tile = tileS[i][h];
                    layers[i].Add(new Tile((int)(position.X + tile.position.X), (int)(position.Y + tile.position.Y), tile.ID));
                    layers[i][h].LoadTexture(ch);
                }
            }
        }

        public void LayerUp()
        {
            if (currentLayer + 1 > layers.Count - 1)
            {
                layers.Add(new List<Tile>());
            }
            currentLayer++;
        }

        public void LayerDown()
        {
            if (currentLayer - 1 < 0)
            {
                return;
            }
            currentLayer++;
        }

        public void Update(GameTime gt, ref Player player)
        {
            foreach (List<Tile> layer in layers)
            {
                foreach (Tile tile in layer)
                {
                    tile.Update(gt);
                    if (player.hitbox.Intersects(tile.hitbox))
                    {
                        if (tile.targetedScene != null)
                        {

                        }
                    }
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (List<Tile> layer in layers)
            {
                foreach (Tile tile in layer)
                {
                    tile.Draw(sb);
                }
            }
        }
    }
}
