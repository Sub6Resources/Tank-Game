using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tank_Game
{
    public class Landmine : Bullet
    {
        public Explosion theExplosion;
        public Landmine() { }
        public Landmine(Game1 _game, Rectangle _bulletRect, Vector2 _speed, Color _color, int _player, float _rotation, Texture2D _rectangleTexture)
        {
            game = _game;
            bulletRect = _bulletRect;
            speed = _speed;
            color = _color;
            player = _player;
            rotation = _rotation;
            rectangleTexture = _rectangleTexture;
            alive = true;
            pointsOnHit = 50;
            pointsOnKill = 200;
        }
        public override void Die()
        {
            base.Die();
            if(player == 1)
            {
                theExplosion = new Explosion(new Vector2(this.bulletRect.X, this.bulletRect.Y), this.game, 2, this.rectangleTexture, Color.Orange);
                game.scoreManager.addScore(0, 1000);
            }
            if (player == 2)
            {
                theExplosion = new Explosion(new Vector2(this.bulletRect.X, this.bulletRect.Y), this.game, 1, this.rectangleTexture, Color.Orange);
                game.scoreManager.addScore(1, 1000);
            }
        }
        public override void Update()
        {
            base.Update();
            if (!alive)
            {
                theExplosion.Update();
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (!alive)
            {
                theExplosion.Draw(spriteBatch);
            }

        }
        public override void CheckCollision()
        {
			foreach (EnemyTank et in game.enemyTanks)
			{
				if ((Rectangle.Intersect(bulletRect, new Rectangle((int)et.location.X - (et.tankTexture.Width / 2), (int)et.location.Y - (et.tankTexture.Height / 2), et.tankTexture.Width, et.tankTexture.Height)).Width != 0) && et.alive)
				{
					this.Die();
				}
			}
			if (player == 2 && (Rectangle.Intersect(bulletRect, new Rectangle((int)game.tank1.location.X - (game.tank1.tankTexture.Width / 2), (int)game.tank1.location.Y - (game.tank1.tankTexture.Height / 2), game.tank1.tankTexture.Width, game.tank1.tankTexture.Height)).Width != 0) && game.tank1.alive)
            {
                this.Die();
            }
            if (player == 1 && (Rectangle.Intersect(bulletRect, new Rectangle((int)game.tank2.location.X - (game.tank2.tankTexture.Width / 2), (int)game.tank2.location.Y - (game.tank2.tankTexture.Height / 2), game.tank2.tankTexture.Width, game.tank2.tankTexture.Height)).Width != 0) && game.tank2.alive)
            {
                this.Die();
            }
        }
    }
}
