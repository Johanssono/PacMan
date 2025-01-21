using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WallsStart
{

    // <summary>
    /// Create an object of the WallGame class.
    /// 
    /// Call the Run method to start the game. This method is inherited from the Microsoft.Xna.Framework.Game class.
    /// </summary>
    public class WallGame : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private World world;

        /// <summary>
        /// Create a WallGame object.
        /// </summary>
        public WallGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        //TODO make World a super class. Each level, or custom world, inherits from World.
        public void SetWorld(World world)
        {
            this.world = world;
            // TODO load content for the world.
        }
        /// <summary>
        /// Called by MonoGame after the game object is created. 
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();
            world = new World(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            world.Initialize();
            base.Initialize();
        }
        /// <summary>
        /// Called by MonoGame after Initialize. LoadContent will be called once per game and is the place to load all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            world.LoadContent(graphics, Content);
        }
        /// <summary>
        /// Called once per frame by MonoGame. Update your game logic here.
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            // Exit the game.
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            world.Update(gameTime);

            base.Update(gameTime);
        }
        /// <summary>
        /// Called once per frame by MonoGame to draw the game screen.
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            // TODO: Add your drawing code here
            world.Draw(gameTime, spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
    
}
