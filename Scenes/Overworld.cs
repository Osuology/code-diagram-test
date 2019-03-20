using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Code_DiagramFlowchart_Test_Myl.Scenes
{
    class Overworld : Scene
    {
        Actor actor;

        public Overworld()
        {
            actor = new Player(1920-128, 0);
        }

        public override void Load()
        {
            ch = new ContentHouse();
            ch.LoadTexture("test");

            actor.LoadTexture(ch.Get("test"));
        }

        public override void Unload()
        {
            actor.LoadTexture(null);
            base.Unload();
        }

        public override void Update(GameTime gt)
        {
            actor.Update(gt);
            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {
            actor.Draw(sb);
            base.Draw(sb);
        }
    }
}
