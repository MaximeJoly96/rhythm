using UnityEngine.UI;
using UnityEngine;
using System;
using Zenyth.Utils;
using System.Collections;

namespace Zenyth.UI
{
    public class TitleScreenManager : MonoBehaviour
    {
        public enum State { Home, DifficultySelect }

        private const float BACKGROUND_SPEED = 0.01f;

        [SerializeField]
        private HomeScreenManager _homeScreenManager;
        [SerializeField]
        private DifficultySelectionScreenManager _difficultySelectionScreenManager;

        [SerializeField]
        private Text _title;
        [SerializeField]
        private Text _pressKeyText;

        [SerializeField]
        private Image _movingBackground;
        [SerializeField]
        private Image _songSelectWheel;
        [SerializeField]
        private Camera _camera;
        [SerializeField]
        private Text _difficultyLabel;

        private Utils.Utils.CardinalDirection _backgroundDirection;
        private State _state;

        private static Vector3 NORTH_EAST_CORNER
        {
            get { return new Vector2(Screen.width, Screen.height); }
        }
        private static Vector3 SOUTH_WEST_CORNER
        {
            get { return new Vector2(0.0f, 0.0f); }
        }

        private void Awake()
        {
            System.Random rng = new System.Random();
            _camera.backgroundColor = new Color((float)rng.NextDouble(), (float)rng.NextDouble(), (float)rng.NextDouble());
            _backgroundDirection = rng.Next(0, 2) == 0 ? Utils.Utils.CardinalDirection.SouthWest : Utils.Utils.CardinalDirection.NorthEast;
            _songSelectWheel.gameObject.SetActive(false);
            _state = State.Home;
        }

        private void Update()
        {
            if (_backgroundDirection == Utils.Utils.CardinalDirection.NorthEast)
                _movingBackground.transform.position += NORTH_EAST_CORNER * Time.deltaTime * BACKGROUND_SPEED;
            else
                _movingBackground.transform.position += SOUTH_WEST_CORNER * Time.deltaTime * BACKGROUND_SPEED;

            if(_state == State.Home)
            {
                if (Input.anyKeyDown)
                {
                    StartCoroutine(HideTitle());
                    StartCoroutine(DisplayWheel());
                }
            }
        }

        private IEnumerator DisplayWheel()
        {
            float alpha = 0.0f;
            Color newColor = _songSelectWheel.color;
            _songSelectWheel.color = Color.clear;
            _songSelectWheel.gameObject.SetActive(true);

            while(alpha <= 1.0f)
            {
                newColor.a = Mathf.Lerp(0.0f, 1.0f, alpha);
                alpha += Time.deltaTime;
                _songSelectWheel.color = newColor;
                yield return new WaitForEndOfFrame();
            }

            _state = State.DifficultySelect;
        }

        private IEnumerator HideTitle()
        {
            float alpha = 0.75f;
            Color newColor = _title.color;
            _pressKeyText.GetComponent<TextFader>().enabled = false;

            while(alpha >= 0.0f)
            {
                newColor.a = Mathf.Lerp(0.0f, 0.75f, alpha);
                alpha -= Time.deltaTime;
                _title.color = newColor;
                _pressKeyText.color = newColor;
                yield return new WaitForEndOfFrame();
            }

            _title.gameObject.SetActive(false);
            _pressKeyText.gameObject.SetActive(false);
        }

        public void UpdateDifficultyName(string label)
        {
            _difficultyLabel.text = label;
        }

        public void DifficultySelected(Utils.Utils.Difficulty difficulty)
        {
            _songSelectWheel.gameObject.SetActive(false);
        }
    }
}

