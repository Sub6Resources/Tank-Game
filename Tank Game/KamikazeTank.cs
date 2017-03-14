﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tank_Game
{
	public class KamikazeTank : EnemyTank
	{
		private const int AI_TOLERANCE = 3;
        Vector2 initSpeed = new Vector2();
        bool charging;

		public KamikazeTank() { }
		public KamikazeTank(Game1 _game, string _tankSpriteName, Vector2 _location, Vector2 _speed, float _rotation, int _player, float _scale, Texture2D _whiteRectangle)
		{
			tankTexture = _game.Content.Load<Texture2D>(_tankSpriteName);
			location = _location;
			startingLocation = _location;
			speed = _speed;
            initSpeed = speed;
			rotation = _rotation;
			origin = new Vector2(this.tankTexture.Width / 2f, this.tankTexture.Height / 2f);
			game = _game;
			player = _player;
			scale = _scale;
			whiteRectangle = _whiteRectangle;
			alive = true;
			lives = 3;
			respawnParticles = new ParticleSpray(location, game, player, whiteRectangle, Color.Green, 0);
			deathParticles = new ParticleSpray(location, game, player, whiteRectangle, Color.Red, 0);
			tankRect = new Rectangle((int)location.X - (tankTexture.Width / 2), (int)location.Y - (tankTexture.Height / 2), tankTexture.Width, tankTexture.Height);
			targetDirection = DOWN;
		}
		public override void Move(KeyboardState state)
		{
			base.Move(state);
            speed = initSpeed;
            //If very close to enemy tank, explode 
            if ((location.X >= game.tank1.location.X - AI_TOLERANCE && location.X <= game.tank1.location.X + AI_TOLERANCE) && (location.Y >= game.tank1.location.Y - AI_TOLERANCE && location.Y <= game.tank1.location.Y + AI_TOLERANCE))
			{
                if (lives <= 1)
                {
                    Explode();
                }
                charging = true;
			}
			//If X = X of enemy tank and Y > Y of enemy tank, go up.
			if ((location.X >= game.tank1.location.X - AI_TOLERANCE && location.X <= game.tank1.location.X + AI_TOLERANCE) && location.Y > game.tank1.location.Y)
			{
                if (lives <= 1)
                {
                    speed += new Vector2(2, 2);
                }
				targetDirection = UP;
                charging = true;
			}
			//If X = X of enemy tank and Y < Y of enemy tank, go down.
			if ((location.X >= game.tank1.location.X - AI_TOLERANCE && location.X <= game.tank1.location.X + AI_TOLERANCE) && location.Y < game.tank1.location.Y)
			{
                if (lives <= 1)
                {
                    speed += new Vector2(2, 2);
                }
                targetDirection = DOWN;
                charging = true;
			}
			//If Y = Y of enemy tank and X > X of enemy tank, go left.
			if((location.Y >= game.tank1.location.Y - AI_TOLERANCE && location.Y <= game.tank1.location.Y + AI_TOLERANCE) && location.X > game.tank1.location.X)
			{
                if (lives <= 1)
                {
                    speed += new Vector2(2, 2);
                }
                targetDirection = LEFT;
                charging = true;
			}
			//If Y = Y of enemy tank and X < X of enemy tank, go right.
			if ((location.Y >= game.tank1.location.Y - AI_TOLERANCE && location.Y <= game.tank1.location.Y + AI_TOLERANCE) && location.X < game.tank1.location.X)
			{
                if (lives <= 1)
                {
                    speed += new Vector2(2, 2);
                }
                targetDirection = RIGHT;
                charging = true;
			}
		}
	}
}
