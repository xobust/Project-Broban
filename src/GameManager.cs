﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public CollisionController collisionController;
        RoomController roomController;
        UIController uiController;
        public TimeSpan playTime;          // used to display formatted time
        private float elapsedPlayTime = 0; // float representation of the playtime
        public SpriteFont font;

        String Name;
        KeyboardState OldState;

        public enum GameState { START, PLAY, FAIL, WIN }

        // NOT SUPPOSED TO BE PUBLIC STATIC, CHANGE ASAP
        public static GameState gameState = GameState.START;

        Texture2D startScreen;
        Texture2D gameOverScreen;
        Texture2D winScreen;
        bool submittedScore = false;    // Has the player submitted their score
        float submitTimer = 0;          // How long to wait before closing the game

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

            GameWorld = new World(10, 5, 5);

            player = new Player(new Vector2(10,10 ));
            monsterController = new MonsterController(this);
            playerController = new PlayerController(this);
            collisionController = new CollisionController(this);
            roomController = new RoomController(this);
            uiController = new UIController(this);
            roomController = new RoomController(this);

            playTime = new TimeSpan(0);
            Name = ""; 
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

            startScreen = Content.Load<Texture2D>("startScreen");
            gameOverScreen = Content.Load<Texture2D>("gameOver");
            winScreen = Content.Load<Texture2D>("winScreen");

            player.LoadContent(GraphicsDevice, Content);
            GameWorld.LoadContent(GraphicsDevice, Content);
            uiController.LoadContent(GraphicsDevice, Content);
            font = Content.Load<SpriteFont>("font");
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

            

            switch (gameState)
            {
                case GameState.START:
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    {
                        gameState = GameState.PLAY;
                    }
                    break;

                case GameState.PLAY:
                    GameWorld.Update(gameTime);
                    playerController.Update(gameTime);
                    player.Update(gameTime);
                    monsterController.Update(gameTime);
                    collisionController.Update(gameTime);
                    roomController.Update(gameTime);
                    uiController.Update(gameTime);

                    elapsedPlayTime += (float)gameTime.ElapsedGameTime.Milliseconds;
                    playTime = TimeSpan.FromMilliseconds(elapsedPlayTime);

                    if (player.hp <= 0)
                    {
                        gameState = GameState.FAIL;
                    }
                    break;
                case GameState.FAIL:
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    {
                        // TODO: reset the game
                    }
                    break;
                case GameState.WIN:
                    KeyboardState keyState = Keyboard.GetState();
                    if (!submittedScore)
                    {
                        foreach (Keys key in keyState.GetPressedKeys())
                        {
                            if (OldState.IsKeyUp(key))
                                if (key == Keys.Back)
                                {
                                    Name = Name.Remove(Name.Length - 1, 1);
                                }
                                else if (key == Keys.Enter)
                                {
                                    new Publish().PostTime(Name, playTime.Seconds + 60 * playTime.Minutes);
                                    submittedScore = true;
                                }
                                else if (key == Keys.Space)
                                {
                                    Name = Name + " ";
                                }
                                else
                                {
                                    Name += key.ToString();
                                }
                        }
                        OldState = keyState;
                    }
                    else
                    {
                        submitTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                        Name = "Submitting..."; // Change this later to its own variable
                        if (submitTimer >= 500) 
                        {
                            Exit();
                        }
                    }
                    break;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.FrontToBack);

            switch (gameState)
            {
                case GameState.START:
                    spriteBatch.Draw(startScreen, 
                        new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    break;

                case GameState.PLAY:
                    GameWorld.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    uiController.Draw(spriteBatch);

                    
                    break;

                case GameState.FAIL:
                    spriteBatch.Draw(gameOverScreen, new Rectangle(0, 0, screenWidth, screenHeight),
                        Color.White);
                    break;
                case GameState.WIN:
                    spriteBatch.Draw(winScreen, new Rectangle(0, 0, screenWidth, screenHeight),
                        Color.White);
                    Vector2 textSize = font.MeasureString(Name);

                    // Display formatted time
                    Vector2 Origin = new Vector2(textSize.X, 0);
                    spriteBatch.DrawString(font, Name, new Vector2(GameManager.screenWidth/2, GameManager.screenHeight/2),
                        Color.White, 0, Origin, 1, SpriteEffects.None, 1);
                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}