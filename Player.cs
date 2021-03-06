﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Code_DiagramFlowchart_Test_Myl
{
    class Player : Actor
    {
        //Player state machine
        enum PlayerState
        {
            Idle,
            Walking,
            Rolling,
            Attacking
        }
        PlayerState state = PlayerState.Idle;

        //Texture/Animation components
        Animation idle;

        public Camera cam;

        //Constructor
        public Player(int x, int y, int width, int height) : base(x, y, width, height)
        {
            textureScale = 7.5f;
            cam = new Camera(x, y);
        }

        //Base method to load texture component
        public override void LoadTexture(Texture2D texture)
        {
            idle = new Animation();

            this.texture = new TextureComponent();
            this.texture.Load(texture);
        }

        //Update physics and animations
        public override void Update(GameTime gt)
        {
            if (Myl.Input.KeyDown(Binds.d))
            {
                acceleration.X = 0.4f;
            }
            else if (Myl.Input.KeyDown(Binds.a))
            {
                acceleration.X = -0.4f;
            }
            else
            {
                acceleration.X = 0;
                velocity.X = 0;
            }

            if (Myl.Input.KeyDown(Binds.w))
            {
                acceleration.Y = -0.4f;
            }
            else if (Myl.Input.KeyDown(Binds.s))
            {
                acceleration.Y = 0.4f;
            }
            else
            {
                acceleration.Y = 0;
                velocity.Y = 0;
            }

            base.Update(gt);
            cam.Update(gt, this.position);
        }

        //Draw texture and animations
        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }
    }
}
