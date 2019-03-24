using Code_DiagramFlowchart_Test_Myl.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_DiagramFlowchart_Test_Myl
{
    class SceneManager
    {
        //Scene that is being updated and drawn
        Scene currentScene;

        //Dictionary to return a scene based on its given name
        Dictionary<string, Scene> scenes;

        //Constructor to initialize all the scenes
        public SceneManager()
        {
            Overworld overworld_scene = new Overworld();
            MainMenu mainmenu_scene = new MainMenu();

            scenes = new Dictionary<string, Scene>();
            scenes.Add("overworld", overworld_scene);
            scenes.Add("main_menu", mainmenu_scene);
#if DEBUG
            Tilemap_Editor_Scene tilemap_editor = new Tilemap_Editor_Scene();
            scenes.Add("tilemap_editor", tilemap_editor);
#endif

            if (!scenes.TryGetValue("overworld", out currentScene))
                throw new Exception("Default scene does not exist.");
        }

        public void Load()
        {
            currentScene.Load();
        }

        //Switches the scene with the option to unload all the textures from the previous scene
        public void SwitchScene(string sceneName, bool unloadPrevious)
        {
            Scene switchScene;
            if (scenes.TryGetValue(sceneName, out switchScene))
            {
                if (switchScene != currentScene)
                {
                    if (unloadPrevious)
                        currentScene.Unload();
                    currentScene = switchScene;
                    currentScene.Load();
                }
            }
        }

        public void Update(GameTime gt)
        {
            if (Myl.Input.KeyReleased(Keys.F1) || GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
                SwitchScene("main_menu", true);
            else if (Myl.Input.KeyReleased(Keys.F2) || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
                SwitchScene("overworld", true);
            else if (Myl.Input.KeyReleased(Keys.F3) || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
                SwitchScene("tilemap_editor", true);

            currentScene.Update(gt);
        }

        public void Draw(SpriteBatch sb, GameVideoSettings vSettings)
        {
            currentScene.Draw(sb, vSettings);
        }
    }
}
