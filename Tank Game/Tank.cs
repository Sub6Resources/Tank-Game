using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tank_Game
{
    public class Tank
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
        public Keys keyUp;
        public Keys keyLeft;
        public Keys keyDown;
        public Keys keyRight;
        private static float UP = -MathHelper.PiOver2;
        private static float UP_RIGHT = -MathHelper.PiOver4;
        private static float RIGHT = 0;
        private static float DOWN_RIGHT = MathHelper.PiOver4;
        private static float DOWN = MathHelper.PiOver2;
        private static float DOWN_LEFT = MathHelper.Pi - MathHelper.PiOver4;
        private static float LEFT = MathHelper.Pi;
        private static float UP_LEFT = -(MathHelper.Pi - MathHelper.PiOver4);
        Texture2D whiteRectangle;

        //generic constructor
        public Tank()
        {

        }

        //overloaded constructor(s)
        public Tank(Game1 _game, string _tankSpriteName, Vector2 _location, Vector2 _speed, float _rotation, int _player, float _scale, Texture2D _whiteRectangle, Keys _keyUp, Keys _keyLeft, Keys _keyDown, Keys _keyRight)
        {
            tankTexture = _game.Content.Load<Texture2D>(_tankSpriteName);
            location = _location;
            speed = _speed;
            rotation = _rotation;
            origin = new Vector2(this.tankTexture.Width / 2f, this.tankTexture.Height / 2f);
            game = _game;
            player = _player;
            scale = _scale;
            whiteRectangle = _whiteRectangle;
            keyUp = _keyUp;
            keyLeft = _keyLeft;
            keyDown = _keyDown;
            keyRight = _keyRight;
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
                bool D_down = state.IsKeyDown(keyRight);
                bool S_down = state.IsKeyDown(keyDown);
                bool A_down = state.IsKeyDown(keyLeft);
                bool W_down = state.IsKeyDown(keyUp);
                if (D_down)
                {
                    MoveRight();
                    Rotate(RIGHT);
                }
                if (A_down)
                {
                    MoveLeft();
                    Rotate(LEFT);
                }
                if (W_down)
                {
                    MoveUp();
                    Rotate(UP);
                    if (D_down)
                    {
                        Rotate(UP_RIGHT);
                    }
                    if (A_down)
                    {
                        Rotate(UP_LEFT);
                    }
                }
                if (S_down)
                {
                    MoveDown();
                    Rotate(DOWN);
                    if (D_down)
                    {
                        Rotate(DOWN_RIGHT);
                    }
                    if (A_down)
                    {
                        Rotate(DOWN_LEFT);
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
            if(rotation == UP)
            {
                return new Bullet(game, new Rectangle((int)location.X, (int)location.Y, 5, 5), new Vector2(0, -20), Color.White, player, UP, whiteRectangle);
            } else if(rotation== UP_RIGHT)
            {
                return new Bullet(game, new Rectangle((int)location.X, (int)location.Y, 5, 5), new Vector2(10, -10), Color.White, player, UP_RIGHT, whiteRectangle);
            } else if(rotation == RIGHT)
            {
                return new Bullet(game, new Rectangle((int)location.X, (int)location.Y, 5, 5), new Vector2(20, 0), Color.White, player, RIGHT, whiteRectangle);
            } else if(rotation ==DOWN_RIGHT)
            {
                return new Bullet(game, new Rectangle((int)location.X, (int)location.Y, 5, 5), new Vector2(10, 10), Color.White, player, DOWN_RIGHT, whiteRectangle);
            } else if(rotation == DOWN)
            {
                return new Bullet(game, new Rectangle((int)location.X, (int)location.Y, 5, 5), new Vector2(0, 20), Color.White, player, DOWN, whiteRectangle);
            } else if(rotation == DOWN_LEFT)
            {
                return new Bullet(game, new Rectangle((int)location.X, (int)location.Y, 5, 5), new Vector2(-10, 10), Color.White, player, DOWN_LEFT, whiteRectangle);
            } else if(rotation == LEFT)
            {
                return new Bullet(game, new Rectangle((int)location.X, (int)location.Y, 5, 5), new Vector2(-20, 0), Color.White, player, LEFT, whiteRectangle);
            } else if(rotation == UP_LEFT)
            {
                return new Bullet(game, new Rectangle((int)location.X, (int)location.Y, 5, 5), new Vector2(-10, -10), Color.White, player, UP, whiteRectangle);
            } else
            {
                return null;
            }
            
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
