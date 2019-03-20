using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Code_DiagramFlowchart_Test_Myl
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch sb;
        RenderTarget2D rt;
        GameVideoSettings vSettings;

        SceneManager sm;

        public Game1()
        {
            vSettings = new GameVideoSettings();
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = (int)vSettings.windowSize.X;
            graphics.PreferredBackBufferHeight = (int)vSettings.windowSize.Y;

            IsFixedTimeStep = false;
            graphics.SynchronizeWithVerticalRetrace = vSettings.vSync;
            TargetElapsedTime = vSettings.frameRate;

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            rt = new RenderTarget2D(GraphicsDevice, (int)vSettings.resolution.X, (int)vSettings.resolution.Y);

            sm = new SceneManager();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Myl.Game.Content = Content;
            // Create a new SpriteBatch, which can be used to draw textures.
            sb = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Myl.Debug.Load(Content);

            sm.Load();

            Myl.Debug.WriteLine("Game1.cs loaded content.");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Myl.Input.Update();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Myl.Input.KeyReleased(Keys.Escape))
                Exit();

#if DEBUG
            Myl.Debug.Update(gameTime);
#endif
            // TODO: Add your update logic here
            sm.Update(gameTime);

            base.Update(gameTime);
            Myl.Input.OldUpdate();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(rt);
            GraphicsDevice.Clear(vSettings.backColor);

            sb.Begin(SpriteSortMode.Deferred, null, vSettings.samplerState, null, null, null, null);
            // TODO: Add your drawing code here
            sm.Draw(sb);


#if DEBUG
            Myl.Debug.Draw(sb);
#endif

            sb.End();

            GraphicsDevice.SetRenderTarget(null);
            sb.Begin(SpriteSortMode.Deferred, null, vSettings.samplerState, null, null, null, null);
            sb.Draw(rt, new Rectangle(0, 0, (int)vSettings.windowSize.X, (int)vSettings.windowSize.Y), vSettings.screenColor);
            sb.End();

            base.Draw(gameTime);
        }
    }
}
