namespace ChickenEgg;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Input;
public class Egg
{
    public Texture2D egg;
    public Texture2D egg_break;
    public Vector2 position;
    public float speed = 200f;
    public bool active = true;
    public bool isBroken = false;
    public float breakTimer = 0f;

    public Rectangle Bounds
    {
        get
        {
            return new Rectangle(
                (int)position.X,
                (int)position.Y,
                90,
                90);
        }
    }

    public Egg(Texture2D egg, Texture2D eggBreak, Vector2 position)
    {
        this.egg = egg;
        egg_break = eggBreak;
        this.position = position;
    }

    public void Update(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (!isBroken)
        {
            position.Y += speed * deltaTime;
        }
        else
        {
            breakTimer += deltaTime;
            if (breakTimer >= 2f)
            {
                active = false;
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Rectangle destRect = new Rectangle((int)position.X, (int)position.Y, 90, 90);
        if(!isBroken)
            spriteBatch.Draw(egg, destRect, Color.White);
        else
            spriteBatch.Draw(egg_break, destRect, Color.White);
    }
}