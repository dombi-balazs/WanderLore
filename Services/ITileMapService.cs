namespace WanderLore.Services
{
    public interface ITileMapService
    {
        void GenerateTileMap();
        void ChangeTileMap();
        void DrawTileMap();
        void DrawTileMapWithTreeTransparency();
    }
}