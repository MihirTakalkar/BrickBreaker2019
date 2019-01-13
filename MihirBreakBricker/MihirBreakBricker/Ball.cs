using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MihirBreakBricker
{
    class Ball
    {
        //Variables
        public Texture2D image;
        public Vector2 position;
        public Vector2 speed;
        public Color tint;


        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);
            }
        }

        //Construct
        public Ball(Texture2D image, Vector2 position, Vector2 speed, Color tint)
        {
            this.image = image;
            this.position = position;
            this.speed = speed;
            this.tint = tint;
        }

        //Update
        public void Update(GraphicsDevice graphicsDevice)
        {


            if (position.Y < 0)
            {
                speed.Y = Math.Abs(speed.Y);
            }

            if (position.X > graphicsDevice.Viewport.Width - image.Width)
            {
                speed.X = -Math.Abs(speed.X);
            }

            if (position.X < 0)
            {
                speed.X = Math.Abs(speed.X);
            }

            position.X += speed.X;
            position.Y += speed.Y;


        }

        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, tint);
        }


    }
}
