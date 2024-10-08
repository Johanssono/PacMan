using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallsStart
{
    /// <summary>
    /// A turtle that can move around the screen.
    /// </summary>
    public class Turtle
    {
        // Same image for all turtles.
        private static Texture2D texture;
        // Containts thes direction the turtle is facing.
        private SpriteEffects spriteEffect;
        // The center of the turtel.
        private Vector2 position;
        private float speed;
        private const int RIGHT = 1;
        private const int LEFT = 2;
        private int lastDirection = RIGHT;
        private IWorld world;



        /// <summary>
        /// Create a turtle object.
        /// </summary>
        /// <param name="position">The position of the turtle, the postion of its center.</param>
        /// <param name="world">The world the turtle is in. 
        /// Dependency injection used to give the turtle access to the World object, 
        /// but only to the parts that are reveled by the IWorld interface.</param>
        public Turtle(Vector2 position, IWorld world)
        {
            this.world = world;
            // Look right by default.
            spriteEffect = SpriteEffects.None;

            this.position = position;
            speed = 200f;
        }
        /// <summary>
        /// Read or set the position of the turtle.
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        /// <summary>
        /// Call this method once to set the texture for all turtles.
        /// </summary>
        /// <param name="texture"></param>
        public static void SetTexture2D(Texture2D texture)
        {
            Turtle.texture = texture;
        }
        /// <summary>
        /// Call once per frame to update the turtle's internal state.
        /// </summary>
        /// <param name="gameTime">A GameTime object that represents the time in the game.</param>
        public void Update(GameTime gameTime)
        {
            // Move the turtle based on input.
            var keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Left))
            {
                // If the turtle face a new direction, flip it.
                if (lastDirection == RIGHT)
                {
                    spriteEffect = SpriteEffects.FlipHorizontally;
                    lastDirection = LEFT;
                }
                position.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (keyState.IsKeyDown(Keys.Right))
            {
                // If the turtle face a new direction, flip it.
                if (lastDirection == LEFT)
                {
                    spriteEffect = SpriteEffects.None;
                    lastDirection = RIGHT;
                }
                position.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            // Check for collision with walls.
            foreach (Wall wall in world.GetWalls())
            {
                if (CollidesWith(wall))
                {
                    // Reset the position of the turtle.
                    Position = new Vector2(world.Width / 2, world.Height / 2);
                }
            }
        }
        /// <summary>
        /// Call once per frame to draw the turtle to the screen.
        /// </summary>
        /// <param name="spriteBatch">The screen of the current frame.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the turtle, centered on the position.
            spriteBatch.Draw(texture,
                position,
                null,
                Color.White,
                0f,
                new Vector2(texture.Width / 2, texture.Height / 2),
                Vector2.One,
                spriteEffect,
                0f);
        }
        /// <summary>
        /// Returns true if the turtle rectangle overlaps with the walls rectangle.
        /// </summary>
        /// <param name="wall"></param>
        /// <returns></returns>
        public bool CollidesWith(Wall wall)
        {
            // check rectangle overlap
            // Turtle left x or right x is inside wall x
            // and turtle top x or bottom x is inside wall y
            // then collision
            float turtleLeft = position.X - texture.Width / 2;
            float turtleRight = position.X + texture.Width / 2;
            float turtleTop = position.Y - texture.Height / 2;
            float turtleBottom = position.Y + texture.Height / 2;
            float wallLeft = wall.Position.X - wall.Width / 2;
            float wallRight = wall.Position.X + wall.Width / 2;
            float wallTop = wall.Position.Y - wall.Height / 2;
            float wallBottom = wall.Position.Y + wall.Height / 2;
            if (IsBetween(turtleLeft, wallLeft, wallRight) || IsBetween(turtleRight, wallLeft, wallRight))
            {
                if (IsBetween(turtleTop, wallTop, wallBottom) || IsBetween(turtleBottom, wallTop, wallBottom))
                {
                    return true;
                }
            }
            return false;

        }
        private bool IsBetween(float value, float min, float max)
        {
            // check if value is between min and max
            return value >= min && value <= max;
        }
    }
}
