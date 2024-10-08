using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallsStart
{
    /// <summary>
    /// An interfaced used to hide som of the methods and properties of the World class for game objects like the Turtle.
    /// </summary>
    public interface IWorld
    {
        /// <summary>
        /// Read the width of the world.
        /// </summary>
        public int Width { get; }
        /// <summary>
        /// Read the height of the world.
        /// </summary>
        public int Height { get; }
        /// <summary>
        /// Get a list of all walls in the world.
        /// </summary>
        /// <returns></returns>
        public List<Wall> GetWalls();
    }
}
