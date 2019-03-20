using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_DiagramFlowchart_Test_Myl.Scenes
{
    class MainMenu : Scene
    {
        Actor actor;

        public MainMenu()
        {
            actor = new Player(0, 0);
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
