using Microsoft.Xna.Framework;

namespace WanderLore.Services;

public interface IInputService
{
        public void ClickHandler();

    public void MovementHandler();

    public void CheckKeyboardInput();
    public Vector2 hedgehogPosition { get; set; }
}