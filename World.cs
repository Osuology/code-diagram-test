using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_DiagramFlowchart_Test_Myl
{
    class World
    {
        List<Tilemap> tilemaps;
        int currentTilemap;

        public World(int x, int y)
        {
            tilemaps = new List<Tilemap>();
            currentTilemap = 0;
        }

        public void Load(string prefix, ContentHouse ch)
        {
            DirectoryInfo taskDirectory = new DirectoryInfo("Tilemaps/");
            FileInfo[] taskFiles = taskDirectory.GetFiles(prefix+"*.txt");
            foreach (var file in taskFiles)
            {
                var x = 0;
                var y = 0;
                var position = file.Name.Substring(prefix.Length + 1);
                position = position.Replace(".txt", "");
                position = position.Replace("_", "");
                if (position[0] == '-')
                {
                    x = Int32.Parse(position.Substring(0, 2));
                    if (position[2] == '-')
                    {
                        y = Int32.Parse(position.Substring(2, 2));
                    }
                    else
                    {
                        y = Int32.Parse(position.Substring(2, 1));
                    }
                }
                else
                {
                    x = Int32.Parse(position.Substring(0, 1));

                    if (position[1] == '-')
                    {
                        y = Int32.Parse(position.Substring(1, 2));
                    }
                    else
                    {
                        y = Int32.Parse(position.Substring(1, 1));
                    }
                }
                Tilemap tilemap = new Tilemap(x, y);
                tilemap.Load(ch, file.DirectoryName + "/" + file.Name);
                tilemaps.Add(tilemap);
            }
        }

        public void Update(GameTime gt, ref Player player)
        {
            foreach (Tilemap tilemap in tilemaps)
            {
                tilemap.Update(gt, ref player);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Tilemap tilemap in tilemaps)
            {
                tilemap.Draw(sb);
            }
        }
    }
}
