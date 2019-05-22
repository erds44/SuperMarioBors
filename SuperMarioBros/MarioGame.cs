using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace SuperMarioBros
{
    class MarioGame : Game
    {
    private IController player;
    private ISprite sprite;
    private SpriteBatch spriteBatch;
    private Vector2 location;
    public MarioGame()
    {
        var graphicsDeviceManager = new GraphicsDeviceManager(this);
        graphicsDeviceManager.DeviceCreated += (o, e) =>
        {
            spriteBatch = new SpriteBatch((o as GraphicsDeviceManager).GraphicsDevice);
        };
        Content.RootDirectory = "Content";
    }
    protected override void Initialize()
    {
        location = new Vector2(400, 200);
        TextureStorage.LoadAllTextures(Content);
        if (GamePad.GetState(PlayerIndex.One).IsConnected)
        {
            player = new GamePadController(this);
        }
        else
        {
            player = new KeyboardController(this);
        }
        base.Initialize();
    }
    protected override void LoadContent()
    {
        TextureStorage.LoadAllTextures(Content);
    }
    protected override void Update(GameTime gameTime)
    {
        player.Update();
        sprite.Update(ref location);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        sprite.Draw(spriteBatch);
        base.Draw(gameTime);
    }
    public void SetMotionAnimatedSprite(Texture2D texture, bool left)
    {

        sprite = new MotionAnimatedSprite(texture, left);
    }
    public void SetStillSprite(Texture2D texture)
    {
        sprite = new MotionlessFixedSprite(texture);
    }
    }
}
