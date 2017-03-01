using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tank_Game
{



    class Bullet
    {
        private Game1 game;
        public Rectangle bulletRect;
        public Vector2 speed;
        public Color color { get; set; }
        public int player { get; set; }
        public float rotation { get; set; }
        public Texture2D rectangleTexture;
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
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(rectangleTexture, bulletRect, color);
        }
        public void Update()
        {
            bulletRect.X += (int) speed.X;
            bulletRect.Y += (int) speed.Y;
        }
        public bool Collision()
        {
            return false;
        }
        public void Die()
        {

        }
    }
}
