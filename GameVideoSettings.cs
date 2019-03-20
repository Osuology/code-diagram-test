using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_DiagramFlowchart_Test_Myl
{
    class GameVideoSettings
    {
        public Vector2 resolution = new Vector2(1920, 1080);
        public Vector2 windowSize = new Vector2(1280, 720);
        public Vector2 AspectRatio
        {
            get
            {

                float aspectRatio = resolution.X / resolution.Y;
                if (aspectRatio == 16 / 9f)
                {
                    return new Vector2(16, 9);
                }
                else if (aspectRatio == 4 / 3f)
                {
                    return new Vector2(4, 3);
                }
                else
                {
                    return new Vector2(resolution.X, resolution.Y);
                }

            }
            set { }
        }

        public TimeSpan frameRate = TimeSpan.FromSeconds(1 / 60f);
        public bool vSync = true;
        public bool fullscreen = false;

        public Color backColor = Color.TransparentBlack;
        public Color screenColor = Color.White;

        public SamplerState samplerState = SamplerState.PointClamp;
    }
}
