using UnityEngine;

namespace Core.GameInput
{
    public class InputDirectionProvider : MonoBehaviour, IInputDirectionProvider
    {
        private int _screenWidth;
        private InputDirection _inputDirection;

        private void Start()
        {
            _screenWidth = Screen.width;
        }

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);

                var halfScreenWidth = _screenWidth * 0.5f;

                _inputDirection = touch.position.x < halfScreenWidth ? InputDirection.Left : InputDirection.Right;
                
                return;
            }

            _inputDirection = InputDirection.None;
        }

        public InputDirection GetInputDirection()
        {
            return _inputDirection;
        }
    }
}