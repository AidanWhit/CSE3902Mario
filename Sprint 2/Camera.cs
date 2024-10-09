using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint_2.ScreenCamera
{
    public class Camera
    {
        public Matrix Transform { get; private set; }
        public Vector2 Position { get; private set; }
        public Viewport Viewport { get; private set; }
        public float SmoothFactor { get; set; } = 0.1f; // Adjust for desired smoothness

        private Vector2 _levelBounds; // The size of your level in pixels

        public Camera(Viewport viewport, Vector2 levelBounds)
        {
            Viewport = viewport;
            _levelBounds = levelBounds;
            Position = Vector2.Zero;
            UpdateTransform();
        }

        public void Update(GameTime gameTime, Vector2 targetPosition)
        {
            // Smoothly interpolate towards the target position
            Position = Vector2.Lerp(Position, targetPosition - new Vector2(Viewport.Width / 2, Viewport.Height / 2), SmoothFactor);

            // Clamp the camera position within the level bounds
            float cameraX = MathHelper.Clamp(Position.X, 0, _levelBounds.X - Viewport.Width);
            float cameraY = MathHelper.Clamp(Position.Y, 0, _levelBounds.Y - Viewport.Height);
            Position = new Vector2(cameraX, cameraY);

            UpdateTransform();
        }

        private void UpdateTransform()
        {
            Transform = Matrix.CreateTranslation(-Position.X, -Position.Y, 0);
        }

        public void Reset()
        {
            Position = Vector2.Zero;
            UpdateTransform();
        }
    }
}
