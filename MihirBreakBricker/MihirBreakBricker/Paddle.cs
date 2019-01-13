using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MihirBreakBricker
{
    class Paddle
    {
        //Variables
       public Texture2D image;
       public Vector2 position;
       public int speedx;
       public Color tint;

        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);
            }
        }

        //Construct
        public Paddle(Texture2D image, Vector2 position, int speedx, Color tint)
        {
            this.image = image;
            this.position = position;
            this.speedx = speedx;
            this.tint = tint;
        }

        //Update
        public void Update(GraphicsDevice graphicsDevice)
        {
            KeyboardState keys = Keyboard.GetState();
            if (keys.IsKeyDown(Keys.Left))
            {
                position.X -= speedx;
            }

            if (keys.IsKeyDown(Keys.Right))
            {
                position.X += speedx;
            }
            if(position.X < 0)
            {
                position.X = 0;
            }

            if (position.X > graphicsDevice.Viewport.Width - image.Width)
            {
                position.X = graphicsDevice.Viewport.Width - image.Width;
            }
        }

        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, tint);
        }

    }
}
