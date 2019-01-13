using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MihirBreakBricker
{
    class Bricks
    {
        //Variables
        public Texture2D image;
        public Vector2 position;
        public Color tint;

        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);
            }
        }


        //Construct
        public Bricks(Texture2D image, Vector2 position, Color tint)
        {
            this.image = image;
            this.position = position;
            this.tint = tint;
        }

        //Update
        public void Update(GraphicsDevice graphicsDevice)
        {

        }

        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, tint);
        }
    }
}
