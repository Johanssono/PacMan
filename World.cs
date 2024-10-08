using Microsoft.Xna.Framework.Content;
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
    /// This class represents the game window and its contents.
    /// </summary>
    public class World : IWorld
    {

        private Turtle turtle;
        private System.Random random;
        private List<Wall> walls;
        private int width;
        private int height;

        /// <summary>
        /// Construct a game world.
        /// </summary>
        /// 
        /// <param name="width">The width of the game window.</param>
        /// <param name="height">The height of the game window.</param>
        public World(int width, int height)
        {
            random = new System.Random();
            walls = new List<Wall>();
            this.width = width;
            this.height = height;
        }
        /// <summary>
        /// Read the width of the game window.
        /// </summary>
        public int Width
        {
            get
            {
                return width;
            }
        }
        /// <summary>
        /// Read the height of the game window.
        /// </summary>
        public int Height
        {
            get
            {
                return height;
            }
        }
        /// <summary>
        /// Called by the WallGame instance when the game is initialized.
        /// </summary>

        public void Initialize()
        {
            // Place the turtle in the center of the screen.
            turtle = new Turtle(new Vector2(width / 2, height / 2), this);

            // Add some walls.
            walls.Add(new Wall(new Vector2(200, height / 2)));
            walls.Add(new Wall(new Vector2(600, height / 2)));
        }

        /// <summary>
        /// Called by the WallGame instance when the game is loaded.
        /// </summary>
        /// 
        /// <param name="graphics">A GraphicsDeviceManager object that represents the graphics device.</param>
        /// <param name="content">A ContentManager object that represents the content manager.</param>
        public void LoadContent(GraphicsDeviceManager graphics, ContentManager content)
        {
            // TODO: use content to load your game content here
            Turtle.SetTexture2D(content.Load<Texture2D>("turtle2"));
            Wall.SetTexture2D(content.Load<Texture2D>("Wall"));

        }
        /// <summary>
        /// Called by the WallGame object once per frame to update the game.
        /// 
        /// Update your game objects here.
        /// </summary>
        /// <param name="gameTime"> A GameTime object is passed when this method is called.</param>
        public void Update(GameTime gameTime)
        {
            // Call Update on all game objects.
            turtle.Update(gameTime);

        }




        /// <summary>
        /// This method is called by the WallGame object once per frame to draw the game.
        /// 
        /// Call Draw on all game objects here.
        /// </summary>
        /// <param name="gameTime">A GameTime object is passed when this method is called.</param>
        /// <param name="spriteBatch">A SpriteBatch object is passed by when this method is called. 
        /// It represents the screen.</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            turtle.Draw(spriteBatch);
            foreach (Wall wall in walls)
            {
                wall.Draw(spriteBatch);
            }

        }
        /// <summary>
        /// Return a list of walls in the game.
        /// </summary>
        /// <returns></returns>
        public List<Wall> GetWalls()
        {
            return walls;
        }
    }
}
