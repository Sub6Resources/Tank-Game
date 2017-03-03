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
        public Keys keyUp;
        public Keys keyLeft;
        public Keys keyDown;
        public Keys keyRight;
        public Keys keyBoost;
        public Keys keyReverse;
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
        public Tank(Game1 _game, string _tankSpriteName, Vector2 _location, Vector2 _speed, float _rotation, int _player, float _scale, Texture2D _whiteRectangle, Keys _keyUp, Keys _keyLeft, Keys _keyDown, Keys _keyRight, Keys _keyBoost, Keys _keyReverse)
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
            keyBoost = _keyBoost;
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
            bool boost = state.IsKeyDown(keyBoost);
            bool reverse = state.IsKeyDown(keyReverse);

            bool A_plus = state.IsKeyDown(keyLeft) && state.IsKeyDown(keyUp);
            bool A_plus2 = state.IsKeyDown(keyLeft) && state.IsKeyDown(keyDown);
            bool W_plus = state.IsKeyDown(keyUp) && state.IsKeyDown(keyLeft);
            bool S_plus = state.IsKeyDown(keyDown) && state.IsKeyDown(keyLeft);
            bool W_plus2 = state.IsKeyDown(keyUp) && state.IsKeyDown(keyRight);
            bool S_plus2 = state.IsKeyDown(keyDown) && state.IsKeyDown(keyRight);
            bool D_plus = state.IsKeyDown(keyRight) && state.IsKeyDown(keyUp);
            bool D_plus2 = state.IsKeyDown(keyRight) && state.IsKeyDown(keyDown);

            if (D_down)
            {
                MoveRight(boost, reverse, D_plus, D_plus2);
                Rotate(RIGHT);
            }
            if (A_down)
            {
                MoveLeft(boost, reverse, A_plus, A_plus2);
                Rotate(LEFT);
            }
            if (W_down)
            {
                MoveUp(boost, reverse, W_plus, W_plus2);
                Rotate(UP);
                if (D_down && !boost)
                {
                    Rotate(UP_RIGHT);
                }
                if (A_down && !boost)
                {
                    Rotate(UP_LEFT);
                }
            }
            if (S_down)
            {
                MoveDown(boost, reverse, S_plus, S_plus2);
                Rotate(DOWN);
                if (D_down && !boost)
                {
                    Rotate(DOWN_RIGHT);
                }
                if (A_down && !boost)
                {
                    Rotate(DOWN_LEFT);
                }
            }
        }
        public void MoveLeft(bool isBoostPressed, bool isReversedPressed, bool IsA_plusPressed, bool IsA_plus2Pressed)
        {
            if (isBoostPressed && !IsA_plusPressed && !IsA_plus2Pressed)
            {
                this.location.X -= (2) + this.speed.X;
            }
            else if (!isBoostPressed)
            {
                if (isReversedPressed)
                {
                    this.location.X += this.speed.Y;
                }
                else
                {
                    this.location.X -= this.speed.X;
                }
            }
        }
        public void MoveRight(bool isBoostPressed, bool isReversedPressed, bool IsD_plusPressed, bool IsD_plus2Pressed)
        {
            if (isBoostPressed && !IsD_plusPressed && !IsD_plus2Pressed)
            {
                this.location.X += (2) + this.speed.X;
            }
            else if (!isBoostPressed)
            {
                if (isReversedPressed)
                {
                    this.location.X -= this.speed.X;
                }
                else
                {
                    this.location.X += this.speed.X;
                }
            }
        }
        public void MoveUp(bool isBoostPressed, bool isReversedPressed, bool IsW_plusPressed, bool IsW_plus2Pressed)
        {
            if (isBoostPressed && !IsW_plusPressed && !IsW_plus2Pressed)
            {
                this.location.Y -= (2) + this.speed.Y;
            }
            else if (!isBoostPressed)
            {
                if (isReversedPressed)
                {
                    this.location.Y += this.speed.Y;
                }
                else
                {
                    this.location.Y -= this.speed.Y;
                }
            }
        }
        public void MoveDown(bool isBoostPressed, bool isReversedPressed, bool IsS_plusPressed, bool IsS_plus2Pressed)
        {
            if (isBoostPressed && !IsS_plusPressed && !IsS_plus2Pressed)
            {
                this.location.Y += (2) + this.speed.Y;
            }
            else if (!isBoostPressed)
            {
                if (isReversedPressed)
                {
                    this.location.Y -= this.speed.Y;
                }
                else
                {
                    this.location.Y += this.speed.Y;
                }
            }
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
