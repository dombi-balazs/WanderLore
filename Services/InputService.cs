using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using WanderLore.Models;

namespace WanderLore.Services;

class InputService : IInputService
{
    KeyboardState keyboardState = Keyboard.GetState();
    MouseState mouseState = Mouse.GetState();
    private const float MOVEMENT_SPEED = 5.0f;

    public Vector2 hedgehogPosition { get; set; }

    private TileMapModel _tileMapModel;

    public InputService(TileMapModel tileMapModel)
    {
        _tileMapModel = tileMapModel;
        hedgehogPosition = _tileMapModel.SpawnPoint;
    }


    public void CheckKeyboardInput()
    {
        KeyboardState keyboardState = Keyboard.GetState();

        Vector2 _hedgehogPosition = hedgehogPosition;
        Vector2 movement = Vector2.Zero;

        float speed = MOVEMENT_SPEED;
        if (keyboardState.IsKeyDown(Keys.Space))
        {
            speed *= 1.5f;
        }

        if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
            movement.Y -= 1;
        if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
            movement.Y += 1;
        if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
            movement.X -= 1;
        if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            movement.X += 1;

        if (movement != Vector2.Zero)
            movement = Vector2.Normalize(movement) * speed;

        _hedgehogPosition += movement;
        hedgehogPosition = _hedgehogPosition;
        hedgehogVelocity = movement;
    }

    public Vector2 hedgehogVelocity { get; private set; } = Vector2.Zero;
    public void ClickHandler()
    {
        if (mouseState.LeftButton == ButtonState.Pressed)
        { }
    }
    public void MovementHandler()
    {
    }

}