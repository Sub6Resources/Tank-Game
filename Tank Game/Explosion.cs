using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Tank_Game
{
    class Explosion
    {
        public static int MAX_PROJECTILES = 200;
        private Color color;
        private Bullet[] shrapnel = new Bullet[MAX_PROJECTILES];
        public Explosion() { }
        public Explosion(Vector2 location, Game1 game, int player, Texture2D whiteRectangle, Color _color)
        {
            color = _color;
            Random randy = new Random();
            for(int i=0; i<MAX_PROJECTILES; ++i)
            {
                var speed = new Vector2();
                var a = randy.Next(-20, 20);
                var b = randy.Next(-20, 20);

                if (a == 0 || a ==1 || a == 2)
                {
                    a = 3;
                }
                if (b == 0 || b == 1 || b== 2)
                {
                    b = 3;
                }
                speed = new Vector2(a, b);

                var r = randy.Next(0, 456);
                //Thread.Sleep(0.01);
                var g = randy.Next(0, 456);
                // Thread.Sleep(1);
                var c = randy.Next(0, 456);
                color = Color.FromNonPremultiplied(255, r, g, c);

                shrapnel[i] = new Bullet(game, new Rectangle(new Point((int)location.X, (int)location.Y), new Point(randy.Next(1, 20), randy.Next(1, 20))), speed, color, player, randy.Next(-((int)MathHelper.Pi), (int)MathHelper.Pi), whiteRectangle);


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
