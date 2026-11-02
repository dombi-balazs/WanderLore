using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace WanderLore.Services;

class InputService : IInputService
{
    KeyboardState keyboardState = Keyboard.GetState();
    MouseState mouseState = Mouse.GetState();
    private const float MOVEMENT_SPEED = 5.0f;

    public Vector2 hedgehogPosition { get; set; } = new Vector2(400, 300);

    public void CheckKeyboardInput()
    {
         // Update the position based on input
        // Get the state of keyboard input
        KeyboardState keyboardState = Keyboard.GetState();

        Vector2 _hedgehogPosition = hedgehogPosition;

        // If the space key is held down, the movement speed increases by 1.5
        float speed = MOVEMENT_SPEED;
        if (keyboardState.IsKeyDown(Keys.Space))
        {
            speed *= 1.5f;
        }

        // If the W or Up keys are down, move the slime up on the screen.
        if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
        {
            _hedgehogPosition.Y -= speed;
        }

        // if the S or Down keys are down, move the slime down on the screen.
        if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
        {
            _hedgehogPosition.Y += speed;
        }

        // If the A or Left keys are down, move the slime left on the screen.
        if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
        {
            _hedgehogPosition.X -= speed;
        }

        // If the D or Right keys are down, move the slime right on the screen.
        if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
        {
            _hedgehogPosition.X += speed;
        }
        hedgehogPosition = _hedgehogPosition;
    }
    public void ClickHandler()
    {
        if (mouseState.LeftButton == ButtonState.Pressed)
        { }
    }
    public void MovementHandler()
    {
    }

}