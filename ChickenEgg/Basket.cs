using System.Collections.Generic;
namespace ChickenEgg;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Input;
public class Basket
{
    public Texture2D _basket;
    public Vector2 position;
    public float _basketSpeed = 300f;
    // Khai báo kích thước hiển thị cố định
    public int Width = 180;
    public int Height = 120;

    public Rectangle DrawRect => new Rectangle(
        (int)position.X,
        (int)position.Y,
        Width,
        Height
    );

    // RECTANGLE ĐỂ VA CHẠM
    public Rectangle Bounds => new Rectangle(
        (int)position.X + 45,
        (int)position.Y + 35,
        90,
        55
    );

    public Basket(Texture2D basket, Vector2 basketPosition)
    {
        _basket = basket;
        position = basketPosition;
    }

    public void Update(GameTime gameTime, int screenWidth)
    {
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        KeyboardState kb = Keyboard.GetState();
        if (kb.IsKeyDown(Keys.Left)) position.X -= _basketSpeed * dt;
        if (kb.IsKeyDown(Keys.Right)) position.X += _basketSpeed * dt;

        // Chặn biên dựa trên Width cố định thay vì _basket.Width
        if (position.X < 0) position.X = 0;
        if (position.X > screenWidth - Width) position.X = screenWidth - Width;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Vẽ rổ với kích thước cố định
        spriteBatch.Draw(_basket, DrawRect, Color.White);
    }
}