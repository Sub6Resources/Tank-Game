﻿using Microsoft.Xna.Framework;
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
            keyReverse = _keyReverse;
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
            //Declare the variables used to determine the direction and speed of the tank.
            bool RIGHT_down = state.IsKeyDown(keyRight);
            bool DOWN_down = state.IsKeyDown(keyDown);
            bool LEFT_down = state.IsKeyDown(keyLeft);
            bool UP_down = state.IsKeyDown(keyUp);
            bool BOOST_down = state.IsKeyDown(keyBoost);
            bool REVERSE_down = state.IsKeyDown(keyReverse);


            if (UP_down)
            {
                Rotate(UP);
                MoveUp(BOOST_down, REVERSE_down);
                if (RIGHT_down && !BOOST_down)
                {
                    Rotate(UP_RIGHT);
                    MoveRight(BOOST_down, REVERSE_down);
                }
                if (LEFT_down && !BOOST_down)
                {
                    Rotate(UP_LEFT);
                    MoveLeft(BOOST_down, REVERSE_down);
                }
            }
            else if (DOWN_down)
            {
                Rotate(DOWN);
                MoveDown(BOOST_down, REVERSE_down);
                if (RIGHT_down && !BOOST_down)
                {
                    Rotate(DOWN_RIGHT);
                    MoveRight(BOOST_down, REVERSE_down);
                }
                if (LEFT_down && !BOOST_down)
                {
                    Rotate(DOWN_LEFT);
                    MoveLeft(BOOST_down, REVERSE_down);
                }
            }
            else if (RIGHT_down)
            {
                Rotate(RIGHT);
                MoveRight(BOOST_down, REVERSE_down);
            }
            else if (LEFT_down)
            {
                Rotate(LEFT);
                MoveLeft(BOOST_down, REVERSE_down);
            }
            
        }
        public void MoveLeft(bool isBoostPressed, bool isReversedPressed)
        {
            if (isBoostPressed)
            {
                this.location.X -= (2) + this.speed.X;
            }
            else if (isReversedPressed)
            {
                this.location.X += this.speed.Y;
            } 
            else
            {
                this.location.X -= this.speed.X;
            }
        }
        public void MoveRight(bool isBoostPressed, bool isReversedPressed)
        {
            if (isBoostPressed)
            {
                this.location.X += (2) + this.speed.X;
            }
            else if (isReversedPressed)
            {
                this.location.X -= this.speed.X;
            }
            else
            {
                this.location.X += this.speed.X;
            }
        }
        public void MoveUp(bool isBoostPressed, bool isReversedPressed)
        {
            if (isBoostPressed)
            {
                this.location.Y -= (2) + this.speed.Y;
            }
            else if (isReversedPressed)
            {
                this.location.Y += this.speed.Y;
            }
            else
            {
                this.location.Y -= this.speed.Y;
            }
        }
        public void MoveDown(bool isBoostPressed, bool isReversedPressed)
        {
            if (isBoostPressed)
            {
                this.location.Y += (2) + this.speed.Y;
            }
            else if (isReversedPressed)
            {
                this.location.Y -= this.speed.Y;
            }
            else
            {
                this.location.Y += this.speed.Y;
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
                return new Bullet(game, new Rectangle((int)location.X, (int)location.Y, 5, 5), new Vector2(0, -20), Color.Black, player, UP, whiteRectangle);
            } else if(rotation== UP_RIGHT)
            {
                return new Bullet(game, new Rectangle((int)location.X, (int)location.Y, 5, 5), new Vector2(10, -10), Color.Black, player, UP_RIGHT, whiteRectangle);
            } else if(rotation == RIGHT)
            {
                return new Bullet(game, new Rectangle((int)location.X, (int)location.Y, 5, 5), new Vector2(20, 0), Color.Black, player, RIGHT, whiteRectangle);
            } else if(rotation ==DOWN_RIGHT)
            {
                return new Bullet(game, new Rectangle((int)location.X, (int)location.Y, 5, 5), new Vector2(10, 10), Color.Black, player, DOWN_RIGHT, whiteRectangle);
            } else if(rotation == DOWN)
            {
                return new Bullet(game, new Rectangle((int)location.X, (int)location.Y, 5, 5), new Vector2(0, 20), Color.Black, player, DOWN, whiteRectangle);
            } else if(rotation == DOWN_LEFT)
            {
                return new Bullet(game, new Rectangle((int)location.X, (int)location.Y, 5, 5), new Vector2(-10, 10), Color.Black, player, DOWN_LEFT, whiteRectangle);
            } else if(rotation == LEFT)
            {
                return new Bullet(game, new Rectangle((int)location.X, (int)location.Y, 5, 5), new Vector2(-20, 0), Color.Black, player, LEFT, whiteRectangle);
            } else if(rotation == UP_LEFT)
            {
                return new Bullet(game, new Rectangle((int)location.X, (int)location.Y, 5, 5), new Vector2(-10, -10), Color.Black, player, UP, whiteRectangle);
            } else
            {
                return null;
            }
            
        }
        public void Die()
        {
            //TODO: Die method
            Respawn(Vector2.Zero);
        }
        public void Respawn(Vector2 location)
        {
            //TODO: Respawn method
        }
    }
}
