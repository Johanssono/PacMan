using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

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
        private List<Cherry> Cherries;

        private int width;
        private int height;
        private float cherryamountmax = 6f;

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
            turtle = new Turtle(new Vector2(25, 340), this);


            /*
            // Add some walls.
            for (int y = 25; y < height + 50; y += 50)
            {
                walls.Add(new Wall(new Vector2(25, y)));
                if (y == 225)
                    y = 345;
            }
            for (int y = 25; y < height + 50; y += 50)
            {
                walls.Add(new Wall(new Vector2(1725, y)));
                if (y == 225)
                    y = 345;
            }
            for (int x = 25; x < width + 50; x += 50)
            {
                walls.Add(new Wall(new Vector2(x, 25)));
            }
            for (int x = 25; x < width + 50; x += 50)
            {
                walls.Add(new Wall(new Vector2(x, 825)));
            }


            for (int y = 75; y < height - 150; y += 50)
            {
                for (int x = 180; x < width - 50; x = x + 340)
                {
                    walls.Add(new Wall(new Vector2(x, y)));

                }
            }

            
            for (int y = 175; y < height - 50; y += 50)
            {
                for (int x = 360; x < width - 50; x = x + 340)
                {
                    walls.Add(new Wall(new Vector2(x, y)));

                }
            }


            
            for (int y = 150; y < height - 75; y += 50)
            {
                for (int x = 340; x < width - 50; x = x + 350)
                {
                    walls.Add(new Wall(new Vector2(x, y)));

                }
            }
            */
            LoadLevel();





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
            Turtle.SetTexture2D(content.Load<Texture2D>("turtle2_half"));
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


        private void PlaceCherry()
        {
            if (cherryamountmax > 0)
            {
                float x = (float)random.NextDouble() * width;
                float y = (float)random.NextDouble() * height;
                Cherries.Add(new Cherry(new Vector2(x, y)));
                /*
                if ()
                */
            }
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

        private void LoadLevel()
        {
            char[][] maze = new char[16][16];
            FileReader fileReader = new FileReader();
            String level = fileReader.ReadFile();
            int x = 25;
            int col = 0;
            int y = 25;
            int row = 0;
            foreach (char token in level)
            {
                if (token == 'x')
                {
                    walls.Add(new Wall(new Vector2(x, y)));
                    maze[col][row] = token;
                }
                else if (token == 't')
                {
                    // only one turtle
                    turtle = new Turtle(new Vector2(x, y), this);
                    maze[col][row] = token;
                }
                if (token == '\n')
                {
                    x = 25;
                    col = 0;
                    y += 50;
                    row += 1;
                }
                else
                {
                    x += 50;
                    col += 1;
                    maze[col][row] = 'e';
                }
            }

            // uprepa tills 20 plums lagts till
            Random random = new Random();
            col = random.Next(0, 16);
            row = random.Next(0, 16);
            if (maze[col][row] == 'e')
            {
                maze[col][row] = 'p';
                // add plum to world
            }
            


        }
    }
}
