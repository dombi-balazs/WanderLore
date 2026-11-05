using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WanderLore.Services
{
    public interface ITileMapService
    {
        void GenerateTileMap();
        void ChangeTileMap();
        void DrawTileMap(SpriteBatch spriteBatch, Texture2D textureAtlas, Viewport viewport);
    }
}