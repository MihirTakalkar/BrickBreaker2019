using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace MihirBreakBricker
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Ball ball;
        Paddle paddle;
        bool gameWon = false;
        int lossnumber = 0;

        List<Bricks> bricks;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1210;
            graphics.PreferredBackBufferHeight = 780;
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
          
            base.Initialize();    
        }

        void Reset()
        {
            bricks = new List<Bricks>();

            float positiony = 0;
            for (int row = 0; row < 1; row++)
            {
                float positionx = 0;
                for (int col = 0; col < 1; col++)
                {
                    bricks.Add(new Bricks(Content.Load<Texture2D>("Rewind"), new Vector2(positionx, positiony), Color.White));
                    positionx += 135;
                }
                positiony += 60;
            }
            
            ball = new Ball(Content.Load<Texture2D>("Dislike"), new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height/2 - 70), new Vector2(5, 5), Color.White);
            paddle = new Paddle(Content.Load<Texture2D>("Paddle"), new Vector2(GraphicsDevice.Viewport.Width / 2 - 124, GraphicsDevice.Viewport.Height - 70), 7, Color.White);

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Reset();
        }
            // TODO: use this.Content to load your game content here
        

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState keys = Keyboard.GetState();
            ball.Update(GraphicsDevice);
            paddle.Update(GraphicsDevice);

            if (ball.Hitbox.Intersects(paddle.Hitbox))
            {
                ball.speed.Y = -Math.Abs(ball.speed.Y);
            }

            if(ball.position.Y >= GraphicsDevice.Viewport.Bounds.Bottom - 50)
            {
                lossnumber++;
                ball = new Ball(Content.Load<Texture2D>("Dislike"), new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height/2 - 70), new Vector2(5, 5), Color.White);
            }

            for (int i = 0; i < bricks.Count; i++)
            {
                if(bricks[i].Hitbox.Intersects(ball.Hitbox))
                {
                    ball.speed.Y *= -1;
                    bricks.Remove(bricks[i]);
                    
                    //ball.speed.X *= -1;
                    //ball.speed.Y *= -1;
                }
            }
            
            if (bricks.Count == 0)
            {
                gameWon = true;
            }
           
            if (keys.IsKeyDown(Keys.R))
            {
                lossnumber = 0;
                Reset();
                gameWon = false;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.TransparentBlack);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            ball.Draw(spriteBatch);
            paddle.Draw(spriteBatch);
            for(int i = 0; i < bricks.Count; i++)
            {
                bricks[i].Draw(spriteBatch);
            }

            if (gameWon == true)
            {
                spriteBatch.DrawString(Content.Load<SpriteFont>("Cool"), ($"You Won. Press R to Restart"), new Vector2(0, 750), Color.Blue);
            }
            else if (lossnumber >= 10)
            {
                spriteBatch.DrawString(Content.Load<SpriteFont>("Cool"), ($"You Lost. Press R to Restart"), new Vector2(0, 750), Color.Green);
            }
            else if (lossnumber < 10)
            {
                spriteBatch.DrawString(Content.Load<SpriteFont>("Cool"), ($"Losses: {lossnumber}"), new Vector2(0, 750), Color.Red);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
