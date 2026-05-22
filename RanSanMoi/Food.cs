using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RanSanMoi;

public class Food
{
    public Vector2 Position { get; set; }

    private Texture2D _foodTexture;

    public Food(Texture2D foodTexture)
    {
        _foodTexture = foodTexture;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_foodTexture, Position, Color.White);
    }
}