using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WanderLore;

public class WanderLoreGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _grass1;
    private Texture2D _hedgehog;
    private readonly IScreenService _screenService;

    public WanderLoreGame(IScreenService screenService)
    {
        _screenService = screenService;
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _screenService.SetFullScreen(_graphics);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _grass1 = Content.Load<Texture2D>("tiles/grass1");
        _hedgehog = Content.Load<Texture2D>("characters/hedgehog");

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
        _spriteBatch.Draw(
            _grass1,
            new Vector2(100,200),
            null,
            Color.White,
            MathHelper.ToRadians(0),
            new Vector2(_grass1.Width * 0.5f, _grass1.Height * 0.5f),
            3f, SpriteEffects.None, 0.0f);
        _spriteBatch.Draw(
            _hedgehog,
            new Vector2(Window.ClientBounds.Width*0.5f, Window.ClientBounds.Height*0.5f),
            null,
            Color.White,
            MathHelper.ToRadians(0),
            new Vector2(_hedgehog.Width * 0.5f, _hedgehog.Height * 0.5f),
            2f,
            SpriteEffects.FlipVertically,
            0.0f);
        

        // TODO: Add your drawing code here

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
