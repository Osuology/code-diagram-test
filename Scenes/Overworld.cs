using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System.IO;

namespace Code_DiagramFlowchart_Test_Myl.Scenes
{
    class Overworld : Scene
    {
        Player player;

        List<Tile> tiles;
        Tilemap tilemap;

        public Overworld()
        {
            player = new Player(1920-128, 56);

            Random rand = new Random();
            tiles = new List<Tile>();

            tilemap = new Tilemap("tilemap_1.txt", 0, 0);
        }

        public override void Load()
        {
            using (StreamReader sr = File.OpenText("tilemap_1.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                tilemap = (Tilemap)serializer.Deserialize(sr, typeof(Tilemap));
            }

            ch = new ContentHouse();
            ch.LoadTexture("test", "test");
            ch.LoadTexture("grass", "tile_1");
            ch.LoadTexture("sand", "tile_2");

            player.LoadTexture(ch.Get("test"));

            tilemap.Load(ch);
        }

        public override void Unload()
        {
            player.LoadTexture(null);
            base.Unload();
            tilemap = null;
        }

        public override void Update(GameTime gt)
        {
            player.Update(gt);
            tilemap.Update(gt);
            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb, GameVideoSettings vSettings)
        {
            sb.Begin(SpriteSortMode.Deferred, null, vSettings.samplerState, null, null, null, player.cam.GetMatrix());
            tilemap.Draw(sb);

            player.Draw(sb);

            base.Draw(sb, vSettings);
        }
    }
}
