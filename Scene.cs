using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_DiagramFlowchart_Test_Myl
{
    class Scene
    {
        //Each scene has its own unique content, this allows us to unload unused textures in other scenes
        protected ContentHouse ch;

        //Constructor
        public Scene()
        {
            ch = new ContentHouse();
        }

        public virtual void Load()
        {

        }

        public virtual void Unload()
        {
            ch = null;
        }

        public virtual void Update(GameTime gt)
        {

        }

        public virtual void Draw(SpriteBatch sb, GameVideoSettings vSettings)
        {

        }
    }
}
