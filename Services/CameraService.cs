using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WanderLore.Services
{
    public class CameraService : ICameraService
    {
        public Vector2 Position { get; private set; }
        
        private Vector2 _currentOffset = Vector2.Zero;
        private readonly float _maxLookAheadDistance = 80f;
        private readonly float _transitionSpeed = 5f;

        public void UpdateCameraView(GameTime gameTime, Vector2 playerPosition, Vector2 playerVelocity)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 targetOffset = Vector2.Zero;

            if (playerVelocity != Vector2.Zero)
            {
                Vector2 direction = Vector2.Normalize(playerVelocity);
                targetOffset = direction * _maxLookAheadDistance;
            }

            _currentOffset = Vector2.Lerp(_currentOffset, targetOffset, _transitionSpeed * deltaTime);

            Position = playerPosition + _currentOffset;
        }

        public Matrix GetViewMatrix(GraphicsDevice graphicsDevice)
        {
            var centerOffset = new Vector2(graphicsDevice.Viewport.Width / 2f, graphicsDevice.Viewport.Height / 2f);

            return Matrix.CreateTranslation(-Position.X, -Position.Y, 0) *
                   Matrix.CreateTranslation(centerOffset.X, centerOffset.Y, 0);
        }
    }
}