using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WanderLore.Services;

namespace WanderLore;

public class WanderLoreGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _textureAtlas;
    private readonly IScreenService _screenService;
    private readonly IAtlasService _atlasService;
    private readonly IDrawService _drawService;

    public WanderLoreGame(IScreenService screenService, IAtlasService atlasService, IDrawService drawService)
    {
        _screenService = screenService;
        _atlasService = atlasService;
        _drawService = drawService;
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _screenService.SetFullScreen(_graphics);
        base.Initialize();
        _atlasService.LoadAtlasData();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _textureAtlas = Content.Load<Texture2D>("texture_atlas/texture_atlas");


        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp); // This is important for pixel art games
        _drawService.DrawAtlasItems(_spriteBatch, _textureAtlas, GraphicsDevice.Viewport);

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
