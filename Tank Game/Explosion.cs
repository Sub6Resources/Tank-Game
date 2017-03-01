using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Tank_Game
{
    class Explosion
    {
        public static int MAX_PROJECTILES = 25;
        private Color color;
        private Bullet[] shrapnel = new Bullet[MAX_PROJECTILES];
        public Explosion() { }
        public Explosion(Vector2 location, Game1 game, int player, Texture2D whiteRectangle, Color _color)
        {
            color = _color;
            Random randy = new Random();
            for(int i=0; i<MAX_PROJECTILES; ++i)
            {
                shrapnel[i] = new Bullet(game, new Rectangle(new Point((int) location.X, (int) location.Y), new Point(randy.Next(1,20),randy.Next(1,20))), new Vector2(randy.Next(-20,20),randy.Next(-20,20)), color, player, randy.Next(-((int)MathHelper.Pi), (int) MathHelper.Pi), whiteRectangle);
            }
        }
        public void Draw(SpriteBatch spriteBatch) {
            for (int i = 0; i < MAX_PROJECTILES; ++i)
            {
                shrapnel[i].Draw(spriteBatch);
            }
        }
        public void Update()
        {
            for (int i = 0; i < MAX_PROJECTILES; ++i)
            {
                shrapnel[i].Update();
            }
        }
    }
}
