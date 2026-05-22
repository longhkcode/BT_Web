
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Graphics;

namespace RanSanMoi;

public class Snake
{
    // Danh sách các đốt của rắn (Mỗi đốt là một Vector2 lưu tọa độ pixel)
    // Đốt đầu tiên Body[0] luôn luôn là ĐẦU RẮN
    public List<Vector2> Body { get; private set; }
    
    // Hướng di chuyển (Tốc độ) hiện tại và hướng di chuyển dự định ở bước tiếp theo
    public Vector2 Velocity { get; private set; }
    private Vector2 _nextVelocity;
    
    private Texture2D _headTexture;
    private Texture2D _bodyTexture;
    private int _tileSize;
    
    private float _moveTimer = 0f;
    private float _moveDelay = 0.15f; // Tốc độ rắn bò (Thời gian chờ giữa các ô tính bằng giây)

    public Snake(Texture2D headTexture, Texture2D bodyTexture, Vector2 startPosition, int tileSize)
    {
        _headTexture = headTexture;
        _bodyTexture = bodyTexture;
        _tileSize = tileSize;

        // Khởi tạo rắn ban đầu có 3 đốt tại vị trí ngẫu nhiên được truyền vào
        Body = new List<Vector2>
        {
            startPosition
        };

        // Mặc định lúc vừa vào game, rắn tự động bò sang phải
        Velocity = new Vector2(_tileSize, 0);
        _nextVelocity = Velocity;
    }

    public void HandleInput()
    {
        var keyCode = Keyboard.GetState();
        if ((keyCode.IsKeyDown(Keys.W) || keyCode.IsKeyDown(Keys.Up)) && Velocity.Y == 0)
        {
            _nextVelocity = new Vector2(0, -_tileSize);
        }
        if ((keyCode.IsKeyDown(Keys.S) || keyCode.IsKeyDown(Keys.Down)) && Velocity.Y == 0)
        {
            _nextVelocity = new Vector2(0, _tileSize);
        }
        if ((keyCode.IsKeyDown(Keys.A) || keyCode.IsKeyDown(Keys.Left)) && Velocity.X == 0)
        {
            _nextVelocity = new Vector2(-_tileSize, 0);
        }
        if ((keyCode.IsKeyDown(Keys.D) || keyCode.IsKeyDown(Keys.Right)) && Velocity.X == 0)
        {
            _nextVelocity = new Vector2(_tileSize, 0);
        }
    }

    public Vector2 getNextHeadPossition()
    {
        Velocity = _nextVelocity;
        return Body[0] +  Velocity;
    }

    public void MoveTo(Vector2 headPosition, bool hasEaten)
    {
        Body.Insert(0,headPosition);
        if (!hasEaten)
        {
            Body.RemoveAt(Body.Count - 1);
        }
    }
    // kiểm tra va chạm đầu vs thân
    public bool checkCollisionHeadBody(Vector2 headPosition)
    {
        for (int i = 1; i < Body.Count; i++)
        {
            if(Body[i] == headPosition) return true;
        }
        return false;
    }
    
    // bộ ếm thời gian đồng booj với di chuyển của rắn
    public bool ShouldMove(GameTime gameTime)
    {
        _moveTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (_moveTimer >= _moveDelay)
        {
            _moveTimer = 0;
            return true;
        }
        return false;
    }
    
    // vẽ
    public void Draw(SpriteBatch spriteBatch)
    {
        for (int i = 0; i < Body.Count; i++)
        {
            if (i == 0)
            {
                spriteBatch.Draw(_headTexture, Body[i], Color.White);
            }
            else
            {
                spriteBatch.Draw(_bodyTexture, Body[i], Color.White);
            }
        }
    }
}