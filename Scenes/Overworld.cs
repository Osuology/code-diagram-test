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

        World world;

        public Overworld()
        {
            player = new Player((1920/2)-60, (1080/2)-60, 120, 120);

            Random rand = new Random();
            
            world = new World(0, 0);
        }

        public override void Load()
        {
            player = new Player((1920 / 2) - 60, (1080 / 2) - 60, 120, 120);

            Random rand = new Random();

            ch = new ContentHouse();
            ch.LoadTexture("test", "test");
            ch.LoadTexture("Textures/black", "tile_0");
            ch.LoadTexture("grass", "tile_1");
            ch.LoadTexture("sand", "tile_2");
            ch.LoadTexture("Textures/green_cobble", "tile_3");
            ch.LoadTexture("Textures/stone", "tile_4");
            ch.LoadTexture("Textures/bush", "tile_5");
            ch.LoadTexture("Textures/water", "tile_6");
            ch.LoadTexture("Textures/orange_cobble", "tile_7");
            ch.LoadTexture("Textures/bones_1", "tile_8");
            ch.LoadTexture("Textures/skull_1", "tile_9");

            player.LoadTexture(ch.Get("test"));

            world.Load("tilemap", ch);
        }

        public override void Unload()
        {
            player.LoadTexture(null);
            base.Unload();
        }

        public override void Update(GameTime gt)
        {
            world.Update(gt, ref player);
            player.Update(gt);
            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb, GameVideoSettings vSettings)
        {
            sb.Begin(SpriteSortMode.Deferred, null, vSettings.samplerState, null, null, null, player.cam.GetMatrix());

            world.Draw(sb);
            player.Draw(sb);

            base.Draw(sb, vSettings);
        }
    }
}
