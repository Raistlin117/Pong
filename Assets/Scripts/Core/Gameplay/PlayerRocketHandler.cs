using Core.Configs;
using Core.GameInput;
using UnityEngine;
using VContainer.Unity;

namespace Core.Gameplay
{
    public class PlayerRocketHandler : ITickable
    {
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
            var rocketPosition = _playerRocket.GetRocketTransform().position;

            float newX = Mathf.Clamp(rocketPosition.x, -3.5f, 3.5f);

            rocketPosition = 
                new Vector3(newX + _playerConfigs.RocketMoveSpeed * Time.deltaTime,rocketPosition.y, rocketPosition.z);
            
            _playerRocket.GetRocketTransform().position = rocketPosition;
        }

        private void MoveLeft()
        {
            var rocketPosition = _playerRocket.GetRocketTransform().position;

            float newX = Mathf.Clamp(rocketPosition.x, -3.5f, 3.5f);

            rocketPosition = 
                new Vector3(newX - _playerConfigs.RocketMoveSpeed * Time.deltaTime,rocketPosition.y, rocketPosition.z);
            
            _playerRocket.GetRocketTransform().position = rocketPosition;
        }
    }
}