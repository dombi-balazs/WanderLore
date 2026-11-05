

using Microsoft.Xna.Framework;

namespace WanderLore.Models
{
    public class TileMapModel
    {
        public int TileMapWidth { get; } = 1000;
        public int TileMapHeight { get; } = 1000;
        public int TileMapTileSize { get; } = 64;
        public int InitialArrayValue { get; } = 0;
        public int ForestNumber { get; } = 25;
        public int WaterNumber { get; } = 15;
        public Vector2 SpawnPoint => new Vector2(
            (TileMapWidth * TileMapTileSize) / 2f,
            (TileMapHeight * TileMapTileSize) / 2f
        );
    }
}