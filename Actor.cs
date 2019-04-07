using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myl.Hitboxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_DiagramFlowchart_Test_Myl
{
    class Actor
    {
        #region CONSTANTS

        protected const float speedCap = 5f;

        #endregion

        protected Vector2 position;
        protected Vector2 velocity;
        protected Vector2 acceleration;

        public RectangleHitbox hitbox;

        protected IDrawableComponent texture;
        protected float textureScale = 1;

        public Actor(int x, int y, int width, int height)
        {
            position = new Vector2(x, y);
            hitbox = new RectangleHitbox(x, y, width, height);
        }

        public virtual void LoadTexture(Texture2D texture)
        {
            
        }

        public virtual void Update(GameTime gt)
        {
            velocity += acceleration;

            if (velocity.X > speedCap)
                velocity.X = speedCap;
            else if (velocity.X < -speedCap)
                velocity.X = -speedCap;
            if (velocity.Y > speedCap)
                velocity.Y = speedCap;
            else if (velocity.Y < -speedCap)
                velocity.Y = -speedCap;

            position += velocity;
            hitbox.SetPosition(position);
        }

        public virtual void Draw(SpriteBatch sb)
        {
            texture.Draw(sb, position, textureScale, Color.White);
        }
    }
}
