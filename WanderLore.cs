using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using WanderLore.Services;

namespace WanderLore;

public class WanderLoreGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _textureAtlas;
    private Vector2 _hedgehogPosition;
    private readonly IScreenService _screenService;
    private readonly IAtlasService _atlasService;
    private readonly IDrawService _drawService;
    private readonly IInputService _inputService;
    private readonly ICameraService _cameraService;
    private readonly ITileMapService _tileMapService;
    private Song _backgroundMusic;

    public WanderLoreGame(
        IScreenService screenService,
    IAtlasService atlasService,
    IDrawService drawService,
    IInputService inputService,
    ICameraService cameraService,
    ITileMapService tileMapService)
    {
        _screenService = screenService;
        _atlasService = atlasService;
        _drawService = drawService;
        _graphics = new GraphicsDeviceManager(this);
        _inputService = inputService;
        _cameraService = cameraService;
        _tileMapService = tileMapService;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _screenService.SetFullScreen(_graphics);
        base.Initialize();
        _atlasService.LoadAtlasData();
        _tileMapService.GenerateTileMap();
        _tileMapService.ChangeTileMap();
        _tileMapService.GenerateTileMap();
        _tileMapService.ChangeTileMap();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _textureAtlas = Content.Load<Texture2D>("texture_atlas/texture_atlas");
        _backgroundMusic = Content.Load<Song>("music/background_music");
        MediaPlayer.Play(_backgroundMusic);
    }

    protected override void Update(GameTime gameTime)
{
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        Exit();

    _inputService.CheckKeyboardInput();

    Vector2 playerPosition = _inputService.hedgehogPosition;
    Vector2 playerVelocity = _inputService.hedgehogVelocity;
    _cameraService.UpdateCameraView(gameTime, playerPosition, playerVelocity);

    base.Update(gameTime);
}
    protected override void Draw(GameTime gameTime)
    {
        _hedgehogPosition = _inputService.hedgehogPosition;
        GraphicsDevice.Clear(Color.Black);
        var cameraMatrix = _cameraService.GetViewMatrix(GraphicsDevice);

        _spriteBatch.Begin(
            samplerState: SamplerState.PointClamp,
            transformMatrix: cameraMatrix
        );

        _tileMapService.DrawTileMap(_spriteBatch, _textureAtlas, GraphicsDevice.Viewport);
        _drawService.DrawAtlasItems(_spriteBatch, _textureAtlas, GraphicsDevice.Viewport, _hedgehogPosition);

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
