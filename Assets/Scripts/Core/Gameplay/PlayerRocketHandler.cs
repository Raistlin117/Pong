using Core.Configs;
using Core.GameInput;
using UnityEngine;
using VContainer.Unity;

namespace Core.Gameplay
{
    public class PlayerRocketHandler : ITickable
    {
        // linear equation formula constants to calculate rocket move limit
        private const float M = -0.5f;
        private const float X = 1;
        private const float Y = 1.75f;
        
        private readonly IInputDirectionProvider _inputDirectionProvider;
        private readonly IPlayerRocket _playerRocket;
        private readonly PlayerConfigs _playerConfigs;

        public PlayerRocketHandler(IInputDirectionProvider inputDirectionProvider, IPlayerRocket playerRocket, PlayerConfigs playerConfigs)
        {
            _inputDirectionProvider = inputDirectionProvider;
            _playerRocket = playerRocket;
            _playerConfigs = playerConfigs;
        }

        public void Tick()
        {
            if (_inputDirectionProvider.GetInputDirection() == InputDirection.Left)
            {
                MoveLeft();
            }
            else if (_inputDirectionProvider.GetInputDirection() == InputDirection.Right)
            {
                MoveRight();
            }
        }

        private void MoveRight()
        {
            MoveRocket(1f);
        }

        private void MoveLeft()
        {
            MoveRocket(-1f);
        }

        private void MoveRocket(float direction)
        {
            var rocketPosition = _playerRocket.GetRocketTransform().position;
            float moveLimit = GetRocketMoveLimit();

            float movedPositionX = rocketPosition.x + direction * _playerConfigs.RocketMoveSpeed * Time.deltaTime;
            
            float fixedPositionX = Mathf.Clamp(movedPositionX, -moveLimit, moveLimit);
            
            rocketPosition = new Vector3(fixedPositionX, rocketPosition.y, rocketPosition.z);
            
            _playerRocket.GetRocketTransform().position = rocketPosition;
        }

        private float GetRocketMoveLimit()
        {
            var rocketSize = _playerRocket.GetRocketTransform().localScale.x;

            var moveLimit = M * (rocketSize - X) + Y;

            return moveLimit;
        }
    }
}