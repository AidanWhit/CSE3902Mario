using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.GameObjects;
using Sprint_2.LevelManager;
using System.Diagnostics;


namespace Sprint_2.ScreenCamera
{
    public class Camera
    {
        public Matrix Transform { get; private set; }
        public Vector2 Position { get; private set; }
        public Viewport Viewport { get; private set; }
        public float SmoothFactor { get; set; } = 0.1f; // Adjust for desired smoothness

        private Vector2 _levelBounds; // The size of your level in pixels
        private Collider leftBorder;
        private float oldcameraX = 0;

        public Camera(Viewport viewport, Vector2 levelBounds)
        {
            Viewport = viewport;
            _levelBounds = levelBounds;
            Position = Vector2.Zero;
            leftBorder = new Collider(new Vector2(0, 240), new Vector2(16, 240), "Collider");
            Debug.WriteLine("Left border: " + leftBorder.GetHitBox().ToString());

            GameObjectManager.Instance.Static.Add(leftBorder);
            GameObjectManager.Instance.ForeDrawables.Add(leftBorder);
            UpdateTransform();
        }

        public void Update(GameTime gameTime)
        {
            // Smoothly interpolate towards the target x-position only
            float targetX = Game1.Instance.mario.XPos - (Viewport.Width / 8f);
            Position = new Vector2(
                MathHelper.Lerp(Position.X, targetX, SmoothFactor), 
                Position.Y //Keep Y Position Constant
            );

            // Clamp the camera position within the level bounds (only for X)
            float cameraX = MathHelper.Clamp(Position.X, 0, _levelBounds.X - Viewport.Width);
            if (cameraX >= oldcameraX)
            {
                Position = new Vector2(cameraX, 240);
                leftBorder.location = new Vector2(Position.X - CollisionConstants.blockWidth, Position.Y);
                UpdateTransform();

                oldcameraX = cameraX;
            }
        }


        private void UpdateTransform()
        {
            Transform = Matrix.CreateTranslation(-Position.X, -Position.Y, 0) * Matrix.CreateScale(2f, 2f, 1);
        }

        public void Reset()
        {
            Position = Vector2.Zero;
            UpdateTransform();
        }

        public void SetLevelBounds(Vector2 levelBounds)
        {
            _levelBounds = levelBounds;
        }
    }
}
