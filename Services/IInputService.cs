using Microsoft.Xna.Framework;

public interface IInputService
{
    void ClickHandler();
    void MovementHandler();
    void CheckKeyboardInput();
    Vector2 hedgehogPosition { get; set; }
    Vector2 hedgehogVelocity { get; }
}