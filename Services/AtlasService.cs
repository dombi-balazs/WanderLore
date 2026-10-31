#nullable enable

using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace WanderLore.Services;

class AtlasService : IAtlasService
{
    private List<AtlasModel>? _atlasList;
    public void LoadAtlasData()
    {
        string _atlasPath = "Content/texture_atlas/texture_atlas.json";
        string _atlasData = File.ReadAllText(_atlasPath);
        _atlasList = JsonSerializer.Deserialize<List<AtlasModel>>(_atlasData);
    }
    public void LoadContent()
    {
        /* using the loaded atlas data called atlasList, create sprites for each tile from the atlas.
        */
    }
}