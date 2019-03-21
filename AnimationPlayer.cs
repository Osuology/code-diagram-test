using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Code_DiagramFlowchart_Test_Myl
{
    class AnimationPlayer : IDrawableComponent
    {
        //Current animation that is playing
        Animation animation;

        public void Update(GameTime gt)
        {
            animation.Update(gt);
        }

        public void Draw(SpriteBatch sb, Vector2 position, float scale, Color color)
        {
            animation.Draw(sb, position, scale, color);
        }

        public void Load(Texture2D texture)
        {
            animation.Load(texture);
        }

        public void LoadAnim(Animation anim)
        {
            animation = anim;
        }
    }
}
