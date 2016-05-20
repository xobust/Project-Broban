using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project_Broban
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameManager : Game
    {
        GraphicsDeviceManager graphics;
        public static int screenHeight;
        public static int screenWidth;
        SpriteBatch spriteBatch;
        public World GameWorld;
        public Player player;
        MonsterController monsterController;
        PlayerController playerController;
        UIController uiController;
        

        public GameManager()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "content";
            graphics.PreferredBackBufferWidth = 1920;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 1080;   // set this value to the desired height of your window
            #if DEBUG
                graphics.IsFullScreen = false;
            #else
                graphics.IsFullScreen = true;
            #endif
            graphics.ApplyChanges();


            player = new Player();
            monsterController = new MonsterController(this);
            playerController = new PlayerController(this);
            uiController = new UIController(this);

            GameWorld = new World(10, 5, 5);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            screenHeight = GraphicsDevice.Viewport.Height;
            screenWidth = GraphicsDevice.Viewport.Width;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.LoadContent(GraphicsDevice, Content);
            GameWorld.LoadContent(GraphicsDevice, Content);
            uiController.LoadContent(GraphicsDevice, Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            player.UnloadContent();
            GameWorld.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
            GameWorld.Update(gameTime);
            playerController.Update(gameTime);
            player.Update(gameTime);
            monsterController.Update(gameTime);
            uiController.Update(gameTime);
           
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.FrontToBack);
            GameWorld.Draw(spriteBatch);
            player.Draw(spriteBatch);
            uiController.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}