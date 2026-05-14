namespace ChickenEgg;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Input;
public class Chicken
{
    public Texture2D chicken;
    public Vector2 position;
    public int Width = 240;
    public int Height = 180;

    public Chicken(Texture2D chicken, Vector2 position)
    {
        this.chicken = chicken;
        this.position = position;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Width, Height);
        spriteBatch.Draw(chicken, destinationRectangle, Color.White);
    }
}