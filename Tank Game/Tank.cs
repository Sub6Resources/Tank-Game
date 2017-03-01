using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tank_Game
{
    class Tank
    {
        //data members
        public Vector2 location;
        public Vector2 speed { get; set; }
        public float rotation { get; set; }
        public Texture2D tankTexture { get; set; }
        public Vector2 origin { get; set; }
        private Game1 game { get; set; }
        public int player { get; set; }
        public int lives { get; set; }
        public float scale { get; set; }

        //generic constructor
        public Tank()
        {

        }

        //overloaded constructor(s)
        public Tank(Game1 _game, string _tankSpriteName, Vector2 _location, Vector2 _speed, float _rotation, int _player, float _scale)
        {
            tankTexture = _game.Content.Load<Texture2D>(_tankSpriteName);
            location = _location;
            speed = _speed;
            rotation = _rotation;
            origin = new Vector2(this.tankTexture.Width / 2f, this.tankTexture.Height / 2f);
            game = _game;
            player = _player;
            scale = _scale;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tankTexture, location, null, null, origin, rotation, null, null);
        }
        public void Update(KeyboardState state)
        {
            Move(state);
        }
        public void Move(KeyboardState state)
        {
            if (player == 1)
            {
                bool D_down = state.IsKeyDown(Keys.D);
                bool S_down = state.IsKeyDown(Keys.S);
                bool A_down = state.IsKeyDown(Keys.A);
                bool W_down = state.IsKeyDown(Keys.W);
                bool SPACE_down = state.IsKeyDown(Keys.Space);
                if (D_down)
                {
                    MoveRight();
                    Rotate(0);
                }
                if (A_down)
                {
                    MoveLeft();
                    Rotate(MathHelper.Pi);
                }
                if (W_down)
                {
                    MoveUp();
                    Rotate(-MathHelper.PiOver2);
                    if (D_down)
                    {
                        Rotate(-MathHelper.PiOver4);
                    }
                    if (A_down)
                    {
                        Rotate(-(MathHelper.Pi - MathHelper.PiOver4));
                    }
                }
                if (S_down)
                {
                    MoveDown();
                    Rotate(MathHelper.PiOver2);
                    if (D_down)
                    {
                        Rotate(MathHelper.PiOver4);
                    }
                    if (A_down)
                    {
                        Rotate(MathHelper.Pi - MathHelper.PiOver4);
                    }
                }
            } else if(player == 2)
            {
                bool UP_down = state.IsKeyDown(Keys.Up);
                bool LEFT_down = state.IsKeyDown(Keys.Left);
                bool DOWN_down = state.IsKeyDown(Keys.Down);
                bool RIGHT_down = state.IsKeyDown(Keys.Right);
                bool CTRL_down = state.IsKeyDown(Keys.RightControl);
                
                if (RIGHT_down)
                {
                    MoveRight();
                    Rotate(0);
                }
                if (LEFT_down)
                {
                    MoveLeft();
                    Rotate(MathHelper.Pi);
                }
                if (UP_down)
                {
                    MoveUp();
                    Rotate(-MathHelper.PiOver2);
                    if (RIGHT_down)
                    {
                        Rotate(-MathHelper.PiOver4);
                    }
                    if (LEFT_down)
                    {
                        Rotate(-(MathHelper.Pi - MathHelper.PiOver4));
                    }
                }
                if (DOWN_down)
                {
                    MoveDown();
                    Rotate(MathHelper.PiOver2);
                    if (RIGHT_down)
                    {
                        Rotate(MathHelper.PiOver4);
                    }
                    if (LEFT_down)
                    {
                        Rotate(MathHelper.Pi - MathHelper.PiOver4);
                    }
                }
            }
        }
        public void MoveLeft()
        {
            this.location.X -= this.speed.X;
        }
        public void MoveRight()
        {
            this.location.X += this.speed.X;
        }
        public void MoveUp()
        {
            this.location.Y -= this.speed.Y;
        }
        public void MoveDown()
        {
            this.location.Y += this.speed.Y;
        }
        public void Rotate(float angle)
        {
            this.rotation = angle;
        }
        public Bullet Fire()
        {
            //TODO: Fire method
            return new Bullet();
        }
        public void Die()
        {
            //TODO: Die method
            
        }
        public void Respawn(Vector2 location)
        {
            //TODO: Respawn method
        }
    }
}
