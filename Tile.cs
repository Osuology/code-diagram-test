﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_DiagramFlowchart_Test_Myl
{
    class Tile
    {
        uint ID = 0;

        TextureComponent texture;

        Vector2 position;
        Vector2 targetPosition;

        public Tile(int x, int y, uint id)
        {
            ID = id;
            position = new Vector2(x, y);
            texture = new TextureComponent();
        }

        public void LoadTexture(ContentHouse ch)
        {
            switch (ID)
            {
                case 0:
                    texture.Load(null);
                    break;
                case 1:
                    texture.Load(ch.Get("tile_1"));
                    break;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            texture.Draw(sb, position, 8f, Color.White);
        }
    }
}
