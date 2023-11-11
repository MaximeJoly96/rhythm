using UnityEngine;
using UnityEngine.UI;

namespace Zenyth.UI.TitleScreen
{
    public class BackgroundManager
    {
        #region Enums
        public enum CardinalDirection { North, South, West, East, NorthWest, NorthEast, SouthWest, SouthEast }
        #endregion

        #region Constants
        private static Vector3 NORTH_EAST_CORNER
        {
            get { return new Vector2(Screen.width, Screen.height); }
        }
        private static Vector3 SOUTH_WEST_CORNER
        {
            get { return new Vector2(0.0f, 0.0f); }
        }

        private const float BACKGROUND_SPEED = 0.01f;
        #endregion

        #region Private members
        private Image _movingBackground;
        private Camera _camera;
        private CardinalDirection _backgroundDirection;
        #endregion

        #region ctor
        public BackgroundManager(Camera camera, Image movingBackground)
        {
            _camera = camera;
            _movingBackground = movingBackground;

            DefineRandomFactors();
        }
        #endregion

        #region Methods
        private void DefineRandomFactors()
        {
            System.Random rng = new System.Random();
            _camera.backgroundColor = new Color((float)rng.NextDouble(), (float)rng.NextDouble(), (float)rng.NextDouble());
            _backgroundDirection = rng.Next(0, 2) == 0 ? CardinalDirection.SouthWest : CardinalDirection.NorthEast;
        }

        public void MoveBackground()
        {
            if (_backgroundDirection == CardinalDirection.NorthEast)
                _movingBackground.transform.position += NORTH_EAST_CORNER * Time.deltaTime * BACKGROUND_SPEED;
            else
                _movingBackground.transform.position += SOUTH_WEST_CORNER * Time.deltaTime * BACKGROUND_SPEED;
        }
        #endregion
    }
}
