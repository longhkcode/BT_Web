using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace RanSanMoi;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private TiledMap _tiledMap;
    private TiledMapRenderer _tiledMapRenderer;
    
    private Snake _snake;
    private Food _food;
    
    private bool isGameOver = false;
    public Random _random = new Random();
    
    // Kích thước ô (Tile) dựa trên ảnh Terrain 32.png của bạn là 32x32 pixel
    private int _tileSize = 32;
    private Texture2D foodTexture;
    private Texture2D headSnakeTexture;
    private Texture2D bodySnakeTexture;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferHeight = 768;
        _graphics.PreferredBackBufferWidth = 1376;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _tiledMap = Content.Load<TiledMap>("map1");
        _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);
        
        foodTexture = Content.Load<Texture2D>("food");
        headSnakeTexture = Content.Load<Texture2D>("head_snake");
        bodySnakeTexture = Content.Load<Texture2D>("body_snake");
        ResetGame();
    }
    private void ResetGame()
    {
        // Tạo snake ở vị trí random hợp lệ
        Vector2 snakeSpawnPosition = GetRandomEmptyTile();

        _snake = new Snake(
            headSnakeTexture,
            bodySnakeTexture,
            snakeSpawnPosition,
            _tileSize
        );

        // Tạo food
        _food = new Food(foodTexture);

        // Spawn food
        generateFood();

        isGameOver = false;
    }
    

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // Nếu trạng thái là GameOver thì ngừng cập nhật logic game
        if (isGameOver)
        {
            // Nhấn phím Enter để chơi lại màn mới khi thua
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                isGameOver = false;
                LoadContent(); // Gọi lại LoadContent để reset rắn và mồi về ban đầu
            }
            return;
        }
        
        _tiledMapRenderer.Update(gameTime);
        _snake.HandleInput();

        if (_snake.ShouldMove(gameTime))
        {
            Vector2 headSnakePosition = _snake.getNextHeadPossition();
            if (CheckWallCollision(headSnakePosition))
            {
                isGameOver = true;
                return;
            }

            if (_snake.checkCollisionHeadBody(headSnakePosition))
            {
                isGameOver = true;
                return;
            }
            
            bool hasEaten = (headSnakePosition == _food.Position);
            _snake.MoveTo(headSnakePosition,hasEaten);

            if (hasEaten)
            {
                generateFood();    
            }
            
        }
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _tiledMapRenderer.Draw();

        _spriteBatch.Begin();

        _food.Draw(_spriteBatch);

        _snake.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
    

    private void generateFood()
    {
        _food.Position = GetRandomEmptyTile();
    }

    private Vector2 GetRandomEmptyTile()
    {
        List<Vector2> emptyTiles =
            new List<Vector2>();

        TiledMapTileLayer tileLayer =
            _tiledMap.GetLayer<TiledMapTileLayer>(
                "Tile Layer 1"
            );

        if (tileLayer == null)
            return Vector2.Zero;

        // GIỚI HẠN VÙNG SPAWN
        int minX = 3;
        int maxX = _tiledMap.Width - 4;

        int minY = 2;
        int maxY = _tiledMap.Height - 4;

        for (int x = minX; x <= maxX; x++)
        {
            for (int y = minY; y <= maxY; y++)
            {
                TiledMapTile? tile =
                    tileLayer.GetTile(
                        (ushort)x,
                        (ushort)y
                    );

                bool isWall =
                    tile.HasValue &&
                    tile.Value.GlobalIdentifier != 0;

                Vector2 tilePosition =
                    new Vector2(
                        x * _tileSize,
                        y * _tileSize
                    );

                bool isSnakeBody = false;

                if (_snake != null)
                {
                    foreach (Vector2 bodyPart in _snake.Body)
                    {
                        if (bodyPart == tilePosition)
                        {
                            isSnakeBody = true;
                            break;
                        }
                    }
                }

                if (!isWall && !isSnakeBody)
                {
                    emptyTiles.Add(tilePosition);
                }
            }
        }

        if (emptyTiles.Count == 0)
            return Vector2.Zero;

        int randomIndex =
            _random.Next(emptyTiles.Count);

        return emptyTiles[randomIndex];
    }
    
    private bool CheckWallCollision(Vector2 position)
    {
        TiledMapTileLayer tileLayer =
            _tiledMap.GetLayer<TiledMapTileLayer>(
                "Tile Layer 1"
            );

        if (tileLayer == null)
            return false;

        ushort tileX =
            (ushort)(position.X / _tileSize);

        ushort tileY =
            (ushort)(position.Y / _tileSize);

        // Ra ngoài map
        if (tileX >= _tiledMap.Width ||
            tileY >= _tiledMap.Height)
        {
            return true;
        }

        TiledMapTile? tile =
            tileLayer.GetTile(tileX, tileY);

        return tile.HasValue &&
               tile.Value.GlobalIdentifier != 0;
    }
}
