using Microsoft.Xna.Framework.Graphics;
using static WanderLore.Models.RegionModel;
using Microsoft.Xna.Framework;

namespace WanderLore.Services;

class DrawService : IDrawService
{
    private readonly IAtlasService _atlasService;

    public DrawService(IAtlasService atlasService)
    {
        _atlasService = atlasService;
    }
    public void DrawAtlasItems(SpriteBatch spriteBatch, Texture2D textureAtlas, Viewport viewport)
    {
        var grass1 = _atlasService[Grass1];
        var hedgehog = _atlasService[Hedgehog];

        // Fű kirajzolása
        spriteBatch.Draw(
            textureAtlas,
            new Vector2(100, 200),
            grass1,
            Color.White,
            0f,
            new Vector2(grass1.Width * 0.5f, grass1.Height * 0.5f),
            3f,
            SpriteEffects.None,
            0f);

        spriteBatch.Draw(
        textureAtlas,
        new Vector2(viewport.Width * 0.5f, viewport.Height * 0.5f),
        hedgehog,
        Color.White,
        0f,
        new Vector2(hedgehog.Width * 0.5f, hedgehog.Height * 0.5f),
        2f,
        SpriteEffects.FlipVertically,
        0f);
    }

}