using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallsStart
{
    /// <summary>
    /// A wall that moving objects cannot pass through.
    /// </summary>
    public class Wall
    {
        // Same image for all walls.
        private static Texture2D texture;
        // The center of the wall.
        private Vector2 position;


        /// <summary>
        /// Create a wall object.
        /// </summary>
        /// <param name="position">The position of the wall, the postion of its center.</param>
        public Wall(Vector2 position)
        {
            this.position = position;
        }
        /// <summary>
        /// Read the position of the wall.
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return position;
            }
        }
        /// <summary>
        /// Read the width of the wall.
        /// </summary>
        public float Width
        {
            get
            {
                return texture.Width;
            }
        }
        /// <summary>
        /// Read the height of the wall.
        /// </summary>
        public float Height
        {
            get
            {
                return texture.Height;
            }
        }

        /// <summary>
        /// Call this method once to set the texture for all walls.
        /// </summary>
        /// <param name="texture"></param>
        public static void SetTexture2D(Texture2D texture)
        {
            Wall.texture = texture;
        }
        /// <summary>
        /// Call once per frame to update the wall's internal state.
        /// </summary>
        /// <param name="gameTime">A GameTime object that represents the time in the game.</param>
        public void Update(GameTime gameTime)
        {

        }
        /// <summary>
        /// Call once per frame to draw the wall to the screen.
        /// </summary>
        /// <param name="spriteBatch">The screen of the current frame.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the snake, centered on the position.
            spriteBatch.Draw(texture,
                position,
                null,
                Color.White,
                0f,
                new Vector2(texture.Width / 2, texture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f);
        }
    }
}

