using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_DiagramFlowchart_Test_Myl
{
    class ContentHouse
    {
        //Dictionaries to hold the content, and the name of that content
        Dictionary<string, Texture2D> textures;
        Dictionary<string, SoundEffect> sounds;
        Dictionary<string, Song> songs;
        Dictionary<string, SpriteFont> fonts;

        //Constructor, initializes the dictionaries 
        public ContentHouse()
        {
            textures = new Dictionary<string, Texture2D>();
            sounds = new Dictionary<string, SoundEffect>();
            songs = new Dictionary<string, Song>();
            fonts = new Dictionary<string, SpriteFont>();
        }

        //Load methods to load a content file into its respective dictionary
        public void LoadTexture(string path, string name)
        {
            var content = Myl.Game.Content.Load<Texture2D>(path);

            textures.Add(name, content);
        }

        public void LoadSound(string path)
        {
            var content = Myl.Game.Content.Load<SoundEffect>(path);

            sounds.Add(path, content);
        }

        public void LoadSong(string path)
        {
            var content = Myl.Game.Content.Load<Song>(path);

            songs.Add(path, content);
        }

        public void LoadFont(string path)
        {
            var content = Myl.Game.Content.Load<SpriteFont>(path);

            fonts.Add(path, content);
        }

        //Get methods to return a content file, fetched by a given key, of its respective type
        public Texture2D Get(string key)
        {
            Texture2D texture;
            if (textures.TryGetValue(key, out texture))
                return texture;
            else
                return null;
        }

        public SoundEffect GetS(string key)
        {
            SoundEffect sound;
            if (sounds.TryGetValue(key, out sound))
                return sound;
            else
                return null;
        }

        public Song GetSong(string key)
        {
            Song song;
            if (songs.TryGetValue(key, out song))
                return song;
            else
                return null;
        }

        public SpriteFont GetFont(string key)
        {
            SpriteFont font;
            if (fonts.TryGetValue(key, out font))
                return font;
            else
                return null;
        }
    }
}
