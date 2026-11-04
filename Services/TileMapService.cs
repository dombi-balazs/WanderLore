using System;
using WanderLore.Models;

namespace WanderLore.Services
{
    public class TileMapService : ITileMapService
    {
        private TileMapModel _tileMapModel;
        private int[,] _TileMap;

        public TileMapService(TileMapModel tileMapModel)
        {
            _tileMapModel = tileMapModel;
        }

        public void GenerateTileMap()
        {
            Random _random = new();
            _TileMap = new int[_tileMapModel.TileMapWidth, _tileMapModel.TileMapHeight];
            for (int i = 0; i < _tileMapModel.TileMapWidth; i++)
            {
                for (int j = 0; j < _tileMapModel.TileMapHeight; j++)
                {
                    int randomZ = _random.Next(0,9);   
                    _TileMap[i, j] = _random.Next();
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
                int randomZ = _random.Next(10,11);
                
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
                                _TileMap[x, y] = 12;
                            }
                        }
                    }
                }
            }
        }

        public void DrawTileMap()
        {
            
        }
    }
}