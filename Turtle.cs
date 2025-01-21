using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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
        // The center of the turtle.
        private Vector2 position;
        private float speed;
        // rotation in degrees
        // 0 = right, 90 = down, 180 = left, 270 = up
        private static int RIGHT = 0;
        private static int DOWN = 90;
        private static int LEFT = 180;
        private static int UP = 270;
        // TODO lock rotation to 0 - 359.999... degrees
        private float rotation = 0f;
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
            speed = 800f;
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
            // Move the turtle based on input
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                rotation = LEFT;
                position.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                rotation = RIGHT;
                position.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                rotation = DOWN;
                position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            }
            else if (keyboardState.IsKeyDown(Keys.Up))
            {
                rotation = UP;
                position.Y -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            }
            // TODO
            // Write your code here.



            // Check for collision with walls.
            foreach (Wall wall in world.GetWalls())
            {
                if (CollidesWith(wall))
                {
                    // If turtle is colliding with a wall. Move back.
                    if (HasRotation(RIGHT))
                    {
                        // move back
                        position.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                    else if (HasRotation(LEFT))
                    {
                        // move back
                        position.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                    else if (HasRotation(DOWN))
                    {
                        // move back
                        position.Y -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                    else if (HasRotation(UP))
                    {
                        // move back
                        position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                    
                    // TODO
                    // Write your code here.



                }
            }
        }
        /// <summary>
        /// Check if the turtle has a rotation.
        /// </summary>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public bool HasRotation(float rotation)
        {
            float deltaRotation = 0.1f;
            return rotation - deltaRotation < this.rotation && this.rotation < rotation + deltaRotation;
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
               rotation * MathF.PI / 180f, // Convert to radians
               new Vector2(texture.Width / 2, texture.Height / 2), // Center image on position
               Vector2.One,
               SpriteEffects.None,
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
            if (HasRotation(UP) || HasRotation(DOWN))
            {
                // When turtle rotated 90 degrees
                // swap width and height.
                turtleLeft = position.X - texture.Height / 2;
                turtleRight = position.X + texture.Height / 2;
                turtleTop = position.Y - texture.Width / 2;
                turtleBottom = position.Y + texture.Width / 2;
            }
            float wallLeft = wall.Position.X - wall.Width / 2;
            float wallRight = wall.Position.X + wall.Width / 2;
            float wallTop = wall.Position.Y - wall.Height / 2;
            float wallBottom = wall.Position.Y + wall.Height / 2;
            // a corner of turtle is inside of wall
            if (IsBetween(turtleLeft, wallLeft, wallRight) || IsBetween(turtleRight, wallLeft, wallRight))
            {
                if (IsBetween(turtleTop, wallTop, wallBottom) || IsBetween(turtleBottom, wallTop, wallBottom))
                {
                    return true;
                }
            }
            // a corner of wall is inside of turtle
            if (IsBetween(wallLeft, turtleLeft, turtleRight) || IsBetween(wallRight, turtleLeft, turtleRight))
            {
                if (IsBetween(wallTop, turtleTop, turtleBottom) || IsBetween(wallBottom, turtleTop, turtleBottom))
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
