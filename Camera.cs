using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_DiagramFlowchart_Test_Myl
{
    class Camera
    {
        Matrix matrix;
        Vector2 position;

        public Camera(int x, int y)
        {
            matrix = Matrix.CreateTranslation(-x, -y, 1);
            position = new Vector2(x, y);
        }

        public Matrix GetMatrix()
        {
            return matrix;
        }

        public void Update(GameTime gt, Vector2 _position)
        {
            position = _position;
            matrix.M41 = -(float)(Math.Floor(position.X / 1920f)) * 1920;
            matrix.M42 = -(float)(Math.Floor(position.Y / 1080f)) * 1080;
        }
    }
}
