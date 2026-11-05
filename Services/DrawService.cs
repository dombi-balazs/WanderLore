using Microsoft.Xna.Framework.Graphics;
using static WanderLore.Models.RegionModel;
using Microsoft.Xna.Framework;
using System;

namespace WanderLore.Services;

class DrawService : IDrawService
{
    private readonly IAtlasService _atlasService;

    public DrawService(IAtlasService atlasService)
    {
        _atlasService = atlasService;
    }
    public void DrawAtlasItems(SpriteBatch spriteBatch, Texture2D textureAtlas, Viewport viewport, Vector2 position)
    {
        var hedgehog = _atlasService[Hedgehog];

        spriteBatch.Draw(
            textureAtlas,
            new Vector2((int)MathF.Round(position.X), (int)MathF.Round(position.Y)),
            hedgehog,
            Color.White,
            0f,
            new Vector2(hedgehog.Width * 0.5f, hedgehog.Height * 0.5f),
            2f,
            SpriteEffects.FlipVertically,
            0f);
    }
}