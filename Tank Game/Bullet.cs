using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tank_Game
{



    public class Bullet
    {
        public Game1 game;
        public Rectangle bulletRect;
        public Vector2 speed;
        public Color color { get; set; }
        public int player { get; set; }
        public float rotation { get; set; }
        public Texture2D rectangleTexture;
        public bool alive { get; set; }
        public int pointsOnHit { get; set; }
        public int pointsOnKill { get; set; }
        public Bullet() { }
        public Bullet(Game1 _game, Rectangle _bulletRect, Vector2 _speed, Color _color, int _player, float _rotation, Texture2D _rectangleTexture)
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
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (alive)
            {
                spriteBatch.Draw(rectangleTexture, bulletRect, color);
            }
        }
        public virtual void Update()
        {
            if (alive)
            {
                bulletRect.X += (int)speed.X;
                bulletRect.Y += (int)speed.Y;
                CheckCollision();
            }
        }
        public virtual void CheckCollision()
        {
            if (player == 2 && (Rectangle.Intersect(bulletRect, new Rectangle((int)game.tank1.location.X - (game.tank1.tankTexture.Width / 2), (int)game.tank1.location.Y - (game.tank1.tankTexture.Height / 2), game.tank1.tankTexture.Width, game.tank1.tankTexture.Height)).Width != 0) && game.tank1.alive)
            {
                game.tank1.Hit();
                game.scoreManager.addScore(1, pointsOnHit);
                if (!game.tank1.alive)
                {
                    game.scoreManager.addScore(1, pointsOnKill);
                }
                this.Die();
            }
            if (player == 1 && (Rectangle.Intersect(bulletRect, new Rectangle((int)game.tank2.location.X - (game.tank2.tankTexture.Width / 2), (int)game.tank2.location.Y - (game.tank2.tankTexture.Height / 2), game.tank2.tankTexture.Width, game.tank2.tankTexture.Height)).Width != 0) && game.tank2.alive)
            {
                game.tank2.Hit();
                game.scoreManager.addScore(0, pointsOnHit);
                if (!game.tank2.alive)
                {
                    game.scoreManager.addScore(0, pointsOnKill);
                }
                this.Die();
            }
            foreach (Tile[] tiles in game.map.map)
            {
                foreach (Tile tile in tiles)
                {
                    if((tile.isColliding(bulletRect).depth > 0)) //If collision is not an empty collision
                    {
                        Collision collision = tile.isColliding(bulletRect);
                        this.Die();
                    }
                }
            }
        }
        public virtual void Die()
        {
            alive = false;
            speed = Vector2.Zero;
            color = Color.Transparent;
    }
    }
}
