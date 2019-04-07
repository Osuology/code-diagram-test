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
        string savePath = "Tilemaps/";
        bool saveActive = false;
        public Tilemap_Editor_Scene()
        {
        }

        public override void Load()
        {
            currentTileID = 1;
            ch = new ContentHouse();
            ch.LoadTexture("Textures/tile_select", "tile_select");
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

            ch.LoadFont("Fonts/tile_editor");

            tilemap = new Tilemap(0, 0);

            base.Load();
        }

        public override void Update(GameTime gt)
        {
            if (!saveActive)
            {
                var MousePos = Myl.Input.GetMousePos();
                var X = Math.Floor(MousePos.X / 120);
                var Y = Math.Floor(MousePos.Y / 120);
                tilePos = new Vector2((float)X * 120, (float)Y * 120);
                if (tilePos.X < 0)
                    tilePos.X = 0;
                else if (tilePos.X > 1920 - 120)
                    tilePos.X = 1920 - 120;

                if (tilePos.Y < 0)
                    tilePos.Y = 0;
                else if (tilePos.Y > 1080 - 120)
                    tilePos.Y = 1080 - 120;
                
                currentTileID = (uint)(Myl.Input.mouse.ScrollWheelValue / 120) + 1;

                if (Myl.Input.mouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && !Myl.Input.KeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl))
                {
                    Tile tile = new Tile((int)tilePos.X, (int)tilePos.Y, currentTileID);
                    tile.LoadTexture(ch);
                    if (tilemap.layers[tilemap.currentLayer].Count > 0)
                    {
                        bool canDo = true;
                        for (int i = 0; i < tilemap.layers[tilemap.currentLayer].Count; i++)
                        {
                            Tile tile2 = tilemap.layers[tilemap.currentLayer][i];
                            if (tile.ID == tile2.ID && tile.position == tile2.position)
                                canDo = false;
                            else if (tile.ID != tile2.ID && tile.position == tile2.position)
                            {
                                canDo = false;
                                tilemap.layers[tilemap.currentLayer][i] = tile;
                            }
                            else
                                canDo = true;
                        }
                        if (canDo)
                            tilemap.layers[tilemap.currentLayer].Add(tile);
                    }
                    else
                    {
                        tilemap.layers[tilemap.currentLayer].Add(tile);
                    }
                }
                else if (Myl.Input.mouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && Myl.Input.KeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl))
                {

                }

                if (Myl.Input.KeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl) && Myl.Input.KeyPressed(Microsoft.Xna.Framework.Input.Keys.S))
                {
                    saveActive = true;
                    savePath = "Tilemaps/";
                    //var json = JsonConvert.SerializeObject(tilemap);

                    //using (StreamWriter sw = new StreamWriter(savePath))
                    //{
                    //    sw.WriteLine(json);
                    //}
                }

                if (Myl.Input.KeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl) && Myl.Input.KeyPressed(Microsoft.Xna.Framework.Input.Keys.Z))
                {
                    tilemap.layers[tilemap.currentLayer].RemoveAt(tilemap.layers[tilemap.currentLayer].Count - 1);
                }

                if (Myl.Input.KeyReleased(Microsoft.Xna.Framework.Input.Keys.Delete) && Myl.Input.KeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl) && Myl.Input.KeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift))
                {
                    tilemap.layers[tilemap.currentLayer] = new List<Tile>();
                }

                if (Myl.Input.KeyPressed(Microsoft.Xna.Framework.Input.Keys.OemPlus))
                {
                    tilemap.LayerUp();
                }
                else if (Myl.Input.KeyPressed(Microsoft.Xna.Framework.Input.Keys.OemMinus))
                {
                    tilemap.LayerDown();
                }
            }
            else
            {
                savePath += Myl.Input.PressedKey();

                if (Myl.Input.KeyPressed(Microsoft.Xna.Framework.Input.Keys.Delete))
                    savePath = savePath.Remove(savePath.Length - 1);

                if (Myl.Input.KeyPressed(Microsoft.Xna.Framework.Input.Keys.Enter))
                {
                    savePath += ".txt";
                    Save();
                }
            }
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(tilemap.layers);

            using (StreamWriter sw = new StreamWriter(savePath))
            {
                sw.WriteLine(json);
            }
            saveActive = false;
        }

        public override void Draw(SpriteBatch sb, GameVideoSettings vSettings)
        {
            sb.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, null);
            tilemap.Draw(sb);
            sb.Draw(ch.Get("tile_" + currentTileID), new Rectangle((int)tilePos.X, (int)tilePos.Y, (int)(7.5 * 16), (int)(7.5 * 16)), Color.White);
            sb.Draw(ch.Get("tile_select"), new Rectangle((int)tilePos.X, (int)tilePos.Y, (int)(7.5 * 16), (int)(7.5 * 16)), new Color(255, 255, 255, 100));

            if (saveActive)
                sb.DrawString(ch.GetFont("Fonts/tile_editor"), savePath + ".txt", new Vector2(0, 0), Color.White);

            base.Draw(sb, vSettings);
        }
    }
}
