using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tank_Game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D whiteRectangle;
        public Tank tank1;
        public Tank tank2;
        Explosion tank1Explosion;
        Explosion tank2Explosion;
        Bullet[] bullets = new Bullet[2];



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            whiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
            whiteRectangle.SetData(new[] { Color.White });
            tank1 = new Tank(this, "GreenTank", Vector2.Zero, new Vector2(2, 2), 0, 1, 1f, whiteRectangle, Keys.W, Keys.A, Keys.S, Keys.D);
            tank2 = new Tank(this, "RedTank", new Vector2(100, 0), new Vector2(2, 2), MathHelper.Pi, 2, 1f, whiteRectangle, Keys.Up, Keys.Left, Keys.Down, Keys.Right);
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState state = Keyboard.GetState();

            tank1.Update(state);
            tank2.Update(state);
            if(state.IsKeyDown(Keys.Space))
            {
                bullets[0] = tank1.Fire();
            }
            if(state.IsKeyDown(Keys.RightControl))
            {
                bullets[1] = tank2.Fire();
            }
            if (state.IsKeyDown(Keys.E))
            {
                tank1Explosion = new Explosion(tank1.location, this, 1, whiteRectangle, Color.Green);
            }
            if (state.IsKeyDown(Keys.RightShift))
            {
                tank2Explosion = new Explosion(tank2.location, this, 2, whiteRectangle, Color.Red);
            }
            foreach (Bullet bullet in bullets)
            {
                if (bullet != null)
                {
                    bullet.Update();
                }
            }
            if(tank1Explosion != null)
            {
                tank1Explosion.Update();
            }
            if(tank2Explosion != null)
            {
                tank2Explosion.Update();
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            tank1.Draw(spriteBatch);
            tank2.Draw(spriteBatch);
            foreach(Bullet bullet in bullets)
            {
                if (bullet != null)
                {
                    bullet.Draw(spriteBatch);
                }
            }
            if (tank1Explosion != null)
            {
                tank1Explosion.Draw(spriteBatch);
            }
            if (tank2Explosion != null)
            {
                tank2Explosion.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
    
