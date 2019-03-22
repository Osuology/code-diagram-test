using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System.IO;

namespace Code_DiagramFlowchart_Test_Myl.Scenes
{
    class Tilemap_Editor_Scene : Scene
    {
        Vector2 tilePos;

        uint currentTileID;

        Tilemap tilemap;
        string savePath = "Tilemaps/tilemap_1.txt";
        public Tilemap_Editor_Scene()
        {
        }

        public override void Load()
        {
            currentTileID = 1;
            ch = new ContentHouse();
            ch.LoadTexture("Textures/tile_select", "tile_select");
            ch.LoadTexture("grass", "tile_1");
            ch.LoadTexture("sand", "tile_2");
            ch.LoadTexture("Textures/green_cobble", "tile_3");

            tilemap = new Tilemap(savePath, 0, 0);

            base.Load();
        }

        public override void Update(GameTime gt)
        {
            var MousePos = Myl.Input.GetMousePos();
            var X = Math.Floor(MousePos.X / 120);
            var Y = Math.Floor(MousePos.Y / 120);
            tilePos = new Vector2((float)X*120, (float)Y*120);
            if (tilePos.X < 0)
                tilePos.X = 0;
            else if (tilePos.X > 1920 - 120)
                tilePos.X = 1920 - 120;

            if (tilePos.Y < 0)
                tilePos.Y = 0;
            else if (tilePos.Y > 1080 - 120)
                tilePos.Y = 1080 - 120;

            currentTileID = (uint)(Myl.Input.mouse.ScrollWheelValue / 120) + 1;

            if (Myl.Input.mouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                Tile tile = new Tile((int)tilePos.X, (int)tilePos.Y, currentTileID);
                tile.LoadTexture(ch);
                if (tilemap.tiles.Count > 0)
                {
                    bool canDo = true;
                    foreach (Tile tile2 in tilemap.tiles)
                    {
                        if (tile.ID == tile2.ID && tile.position == tile2.position)
                            canDo = false;
                        else
                            canDo = true;
                    }
                    if (canDo)
                        tilemap.tiles.Add(tile);
                }
                else
                {
                    tilemap.tiles.Add(tile);
                }
            }

            if (Myl.Input.KeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl) && Myl.Input.KeyReleased(Microsoft.Xna.Framework.Input.Keys.S))
            {
                var json = JsonConvert.SerializeObject(tilemap);

                using (StreamWriter sw = new StreamWriter(savePath))
                {
                    sw.WriteLine(json);
                }
            }
        }

        public override void Draw(SpriteBatch sb, GameVideoSettings vSettings)
        {
            sb.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, null);
            tilemap.Draw(sb);
            sb.Draw(ch.Get("tile_" + currentTileID), new Rectangle((int)tilePos.X, (int)tilePos.Y, (int)(7.5 * 16), (int)(7.5 * 16)), Color.White);
            sb.Draw(ch.Get("tile_select"), new Rectangle((int)tilePos.X, (int)tilePos.Y, (int)(7.5 * 16), (int)(7.5 * 16)), new Color(255, 255, 255, 100));
            base.Draw(sb, vSettings);
        }
    }
}
