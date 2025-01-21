using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WallsStart;


public class Cherry
{
	private static Texture2D texture;
	private Vector2 position;
	private static void SetTexture(Texture2D texture)
	{
		Cherry.texture = texture;
	}
	public Cherry(Vector2 position)
	{
		this.position = position;
	}
    /*
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
    */

}
