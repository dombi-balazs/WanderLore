using Microsoft.Extensions.DependencyInjection;
using WanderLore;

var services = new ServiceCollection();
services.AddSingleton<IScreenService, ScreenService>();
services.AddSingleton<WanderLoreGame>();
var serviceProvider = services.BuildServiceProvider();

using var game = serviceProvider.GetRequiredService<WanderLoreGame>();
game.Run();