namespace WanderLore.Models
{
    public class TileMapModel
    {
        public int TileMapWidth { get; } = 1000;
        public int TileMapHeight { get; } = 1000;
        public int InitialArrayValue { get; } = 0;
        public int ForestNumber { get; } = 25;
        public int WaterNumber { get; } = 15;
    }
}