using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

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
        List<Bullet> bullets = new List<Bullet>();
        public Score scoreManager;
        public List<Landmine> landmines = new List<Landmine>();
        Rectangle debugRect;
        Rectangle tank2DebugRect;
        private float tank1FireDelay = 0f;
        private float tank2FireDelay = 0f;
        private const float FIRE_DELAY = 0.5f;
        private float tank1ExplosionDelay = 0f;
        private float tank2ExplosionDelay = 0f;
        private const float EXPLOSION_DELAY = 5f;
        private float tank1TimeToBackAlive = 2f;
        private float tank2TimeToBackAlive = 2f;
        private const float BACK_ALIVE_DELAY = 2f;
        private float tank1MineDelay = 0f;
        private float tank2MineDelay = 0f;
        private const float MINE_DELAY = 20f;



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
            tank1 = new Tank(this, "GreenTank", new Vector2(100,100), new Vector2(3, 3), 0, 1, 1f, whiteRectangle, Keys.W, Keys.A, Keys.S, Keys.D, Keys.Tab, Keys.LeftShift);
            tank2 = new Tank(this, "RedTank", new Vector2(600, 100), new Vector2(3, 3), MathHelper.Pi, 2, 1f, whiteRectangle, Keys.Up, Keys.Left, Keys.Down, Keys.Right, Keys.Enter, Keys.RightShift);
            scoreManager = new Score(this, 2);
            debugRect = new Rectangle();
            tank2DebugRect = new Rectangle();
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

            //Update delays
            float timer = (float) gameTime.ElapsedGameTime.TotalMilliseconds / 1000;
            tank1FireDelay -= timer;
            tank2FireDelay -= timer;
            tank1ExplosionDelay -= timer;
            tank2ExplosionDelay -= timer;
            tank1MineDelay -= timer;
            tank2MineDelay -= timer;

            //if tanks are dead, decrease their time until they respawn
            if (!tank1.alive)
            {
                tank1TimeToBackAlive -= timer;
                if (tank1TimeToBackAlive < 0)
                {
                    tank1.Respawn(tank1.startingLocation);
                    tank1TimeToBackAlive = BACK_ALIVE_DELAY;
                }
            }
            if (!tank2.alive)
            {
                tank2TimeToBackAlive -= timer;
                if (tank2TimeToBackAlive < 0)
                {
                    tank2.Respawn(tank2.startingLocation);
                    tank2TimeToBackAlive = BACK_ALIVE_DELAY;
                }
            }

            // TODO: Add your update logic here
            KeyboardState state = Keyboard.GetState();

            tank1.Update(state, gameTime);
            tank2.Update(state, gameTime);
            debugRect = new Rectangle((int)tank1.location.X-(tank1.tankTexture.Width/2), (int)tank1.location.Y-(tank1.tankTexture.Height/2), tank1.tankTexture.Width, tank1.tankTexture.Height);
            tank2DebugRect = new Rectangle((int)tank2.location.X - (tank2.tankTexture.Width / 2), (int)tank2.location.Y - (tank2.tankTexture.Height / 2), tank2.tankTexture.Width, tank2.tankTexture.Height);
            foreach (Landmine lm in landmines)
            {
                lm.Update();
            }
            if(state.IsKeyDown(Keys.Space) && tank1FireDelay <= 0)
            {
                tank1FireDelay = FIRE_DELAY;
                bullets.Add(tank1.Fire());
            }
            if(state.IsKeyDown(Keys.RightControl) && tank2FireDelay <= 0)
            {
                tank2FireDelay = FIRE_DELAY;
                bullets.Add(tank2.Fire());
            }
            if (state.IsKeyDown(Keys.E) && tank1ExplosionDelay <= 0)
            {
                tank1ExplosionDelay = EXPLOSION_DELAY;
                tank1Explosion = new Explosion(tank1.location, this, 1, whiteRectangle, Color.Green);
                tank1.Die();
            }
            if (state.IsKeyDown(Keys.Back) && tank2ExplosionDelay <= 0)
            {
                tank2ExplosionDelay = EXPLOSION_DELAY;
                tank2Explosion = new Explosion(tank2.location, this, 2, whiteRectangle, Color.Red);
                tank2.Die();
            }
            if(state.IsKeyDown(Keys.V) && tank1MineDelay <= 0)
            {
                tank1MineDelay = MINE_DELAY;
                landmines.Add(new Landmine(this, new Rectangle((int)tank1.location.X, (int)tank1.location.Y, 20, 20), Vector2.Zero, Color.Orange, 1, 0, whiteRectangle));
            }
            if(state.IsKeyDown(Keys.M) && tank2MineDelay <= 0)
            {
                tank2MineDelay = MINE_DELAY;
                landmines.Add(new Landmine(this, new Rectangle((int)tank2.location.X, (int)tank2.location.Y, 20, 20), Vector2.Zero, Color.Orange, 2, 0, whiteRectangle));
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
            GraphicsDevice.Clear(Color.WhiteSmoke);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //DEBUG DRAWS (COMMENT OUT TO TURN OFF DEBUG MODE)
                //spriteBatch.Draw(whiteRectangle, debugRect, Color.Pink); //Tank1 DebugRect
                //spriteBatch.Draw(whiteRectangle, tank2DebugRect, Color.Pink); //Tank2 DebugRect
            tank1.Draw(spriteBatch);
            tank2.Draw(spriteBatch);
            
            scoreManager.Draw(spriteBatch);
            foreach (Landmine lm in landmines)
            {
                lm.Draw(spriteBatch);
            }
            foreach (Bullet bullet in bullets)
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
    
