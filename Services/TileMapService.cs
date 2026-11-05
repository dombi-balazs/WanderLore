using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WanderLore.Models;

namespace WanderLore.Services
{
    public class TileMapService : ITileMapService
    {
        private TileMapModel _tileMapModel;
        private int[,] _TileMap;
        private readonly IInputService _inputService;
        private readonly IAtlasService _atlasService;

        public TileMapService(TileMapModel tileMapModel, IInputService inputService, IAtlasService atlasService)
        {
            _tileMapModel = tileMapModel;
            _inputService = inputService;
            _atlasService = atlasService;
        }

        public void GenerateTileMap()
        {
            Random _random = new();
            _TileMap = new int[_tileMapModel.TileMapWidth, _tileMapModel.TileMapHeight];
            for (int i = 0; i < _tileMapModel.TileMapWidth; i++)
            {
                for (int j = 0; j < _tileMapModel.TileMapHeight; j++)
                {
                    int randomZ = _random.Next(0, 10);
                    _TileMap[i, j] = randomZ;
                }
            }
        }

        public void ChangeTileMap()
        {
            int _forestNumber = _tileMapModel.ForestNumber;
            int _waterNumber = _tileMapModel.WaterNumber;
            Random _random = new();

            for (int i = 0; i < _forestNumber; i++)
            {
                int randomX = _random.Next(0, _tileMapModel.TileMapWidth);
                int randomY = _random.Next(0, _tileMapModel.TileMapHeight);
                int randomZ = _random.Next(12, 14); // Trees1 (12) vagy Trees2 (13)

                int _forestWidth = _random.Next(1, 20);
                int _forestHeight = _random.Next(1, 20);
                int _forestFillPercentage = _random.Next(1, 100);

                for (int j = 0; j < _forestWidth; j++)
                {
                    for (int k = 0; k < _forestHeight; k++)
                    {
                        if (_random.Next(1, 100) <= _forestFillPercentage)
                        {
                            int x = randomX + j;
                            int y = randomY + k;

                            if (x < _tileMapModel.TileMapWidth && y < _tileMapModel.TileMapHeight)
                            {
                                _TileMap[x, y] = randomZ;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < _waterNumber; i++)
            {
                int randomX = _random.Next(0, _tileMapModel.TileMapWidth);
                int randomY = _random.Next(0, _tileMapModel.TileMapHeight);

                int _waterWidth = _random.Next(1, 20);
                int _waterHeight = _random.Next(1, 20);
                int _waterFillPercentage = _random.Next(1, 100);

                for (int j = 0; j < _waterWidth; j++)
                {
                    for (int k = 0; k < _waterHeight; k++)
                    {
                        if (_random.Next(1, 100) <= _waterFillPercentage)
                        {
                            int x = randomX + j;
                            int y = randomY + k;

                            if (x < _tileMapModel.TileMapWidth && y < _tileMapModel.TileMapHeight)
                            {
                                _TileMap[x, y] = 14;
                            }
                        }
                    }
                }
            }
        }

        public void DrawTileMap(SpriteBatch spriteBatch, Texture2D textureAtlas, Viewport viewport)
        {
            if (_TileMap == null) return;

            int tileSize = _tileMapModel.TileMapTileSize; // 128
            Vector2 hedgehogPos = _inputService.hedgehogPosition;

            int hedgehogTileX = (int)MathF.Floor(hedgehogPos.X / tileSize);
            int hedgehogTileY = (int)MathF.Floor(hedgehogPos.Y / tileSize);

            int visibleCols = (int)MathF.Ceiling(viewport.Width / (float)tileSize) + 20;
            int visibleRows = (int)MathF.Ceiling(viewport.Height / (float)tileSize) + 20;

            int startX = Math.Max(0, hedgehogTileX - (visibleCols / 2) - 10);
            int endX = Math.Min(_tileMapModel.TileMapWidth - 1, hedgehogTileX + (visibleCols / 2) + 10);
            int startY = Math.Max(0, hedgehogTileY - (visibleRows / 2) - 10);
            int endY = Math.Min(_tileMapModel.TileMapHeight - 1, hedgehogTileY + (visibleRows / 2) + 10);

            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    int tileId = _TileMap[x, y];
                    Vector2 position = new Vector2(x * tileSize, y * tileSize);

                    if (tileId == 12 || tileId == 13)
                    {
                        int grassIndex = ((x * 73 + y * 37) % 10) + 1;
                        RegionModel grassRegion = (RegionModel)Enum.Parse(typeof(RegionModel), $"Grass{grassIndex}");

                        spriteBatch.Draw(textureAtlas, position, _atlasService[grassRegion], Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);

                        RegionModel treeRegion = (tileId == 12) ? RegionModel.Trees1 : RegionModel.Trees2;
                        spriteBatch.Draw(textureAtlas, position, _atlasService[treeRegion], Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
                    }
                    else
                    {
                        RegionModel region = tileId switch
                        {
                            >= 0 and <= 9 => (RegionModel)Enum.Parse(typeof(RegionModel), $"Grass{tileId + 1}"),
                            10 => RegionModel.Trees1,
                            11 => RegionModel.Trees2,
                            12 => RegionModel.Water1,
                            _ => RegionModel.Grass1
                        };

                        spriteBatch.Draw(textureAtlas, position, _atlasService[region], Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
                    }
                }
            }
        }
    }
}