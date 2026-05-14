using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChickenEgg;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    
    private Texture2D _background;
    private Texture2D _eggTexture;
    private  Texture2D _egg_breakTexture;
    private Texture2D _basketTexture;
    private Texture2D _chickenTexture;
    private Basket _basket;
    private List<Egg> _eggs = new();
    private  List<Chicken> _chickens = new();
    private Random _rd = new Random();
    
    private float spamEgg; 
    private int score = 0;
    private int egg_broken = 0;
    
    private int totalEggs = 20;
    private int spawnedEggs = 0;
    
    private SpriteFont gameFont;
    
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

        // TODO: use this.Content to load your game content here
        _background = Content.Load<Texture2D>("background");
        _eggTexture = Content.Load<Texture2D>("egg");

        _egg_breakTexture = Content.Load<Texture2D>("egg_break");

        _basketTexture = Content.Load<Texture2D>("basket");

        _chickenTexture = Content.Load<Texture2D>("chicken");
        _basket = new Basket(
            _basketTexture,
            new Vector2(
                600,
                _graphics.PreferredBackBufferHeight - 180
            )
        );
        
        int soLuongGa = 5;
        float chieuRongConGa = 80; 
        float tongChieuRongGa = soLuongGa * chieuRongConGa;
        float khoangTrong = _graphics.PreferredBackBufferWidth - tongChieuRongGa;
        float khoangCach = khoangTrong / (soLuongGa + 1);
        
        for (int i = 0; i < soLuongGa; i++)
        {
            float x = khoangCach + (i * (chieuRongConGa + khoangCach));
            _chickens.Add(new Chicken(_chickenTexture, new Vector2(x, 100)));
        }
        gameFont = Content.Load<SpriteFont>("myFont");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _basket.Update(gameTime, _graphics.PreferredBackBufferWidth);
        spamEgg += dt;
        if (spamEgg >= 1.5f && spawnedEggs < totalEggs)
        {
            spamEgg = 0;
            int randomChicken = _rd.Next(_chickens.Count);
            Chicken chicken = _chickens[randomChicken];
            Vector2 eggPos = new Vector2(
                chicken.position.X + chicken.Width / 2 - 30,
                chicken.position.Y + chicken.Height - 20
            );
            _eggs.Add(
                new Egg(
                    _eggTexture,
                    _egg_breakTexture,
                    eggPos
                )
            );
            spawnedEggs++;
        }

        for (int i = 0; i < _eggs.Count; i++)
        {
            Egg egg = _eggs[i];
            egg.Update(gameTime);
            if (egg.Bounds.Intersects(_basket.Bounds) && !egg.isBroken)
            {
                score += 1;
                egg.active = false;
            }

            if (egg.position.Y >= _graphics.PreferredBackBufferHeight - 180 && !egg.isBroken)
            {
                egg_broken++;
                egg.isBroken = true;
            }
        }
        _eggs.RemoveAll(egg => !egg.active);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(_background,Vector2.Zero, Color.White);
        foreach (var chicken in _chickens)
        {
            chicken.Draw(_spriteBatch);
        }

        foreach (var egg in _eggs)
        {
            egg.Draw(_spriteBatch);
        }

        _basket.Draw(_spriteBatch);
        _spriteBatch.DrawString(gameFont,"Score :  " + score,new Vector2(300,20),Color.White);
        _spriteBatch.DrawString(gameFont,"Broken_egg : " + egg_broken,new Vector2(800, 20),Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
