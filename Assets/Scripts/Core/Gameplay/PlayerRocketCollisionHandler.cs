using Core.Configs;
using UnityEngine;
using VContainer.Unity;

namespace Core.Gameplay
{
    public class PlayerRocketCollisionHandler : IStartable
    {
        private const float MiddleAnglePoint = 90f;
        
        private readonly IPlayerRocket _playerRocket;
        private readonly GameConfigs _gameConfigs;
        private readonly IBallHandler _ballHandler;

        public PlayerRocketCollisionHandler(IPlayerRocket playerRocket, GameConfigs gameConfigs, IBallHandler ballHandler)
        {
            _playerRocket = playerRocket;
            _gameConfigs = gameConfigs;
            _ballHandler = ballHandler;
        }
        public void Start()
        {
            Subscribes();
        }

        private void Subscribes()
        {
            _playerRocket.CollisionEntered += OnCollisionEntered;
        }

        private void OnCollisionEntered(Collision2D other)
        {
            var contact = other.GetContact(0);
            Debug.Log(contact.point);
            
            var contactPosition = contact.point;
            var rocketTransform = _playerRocket.GetRocketTransform();
            var rocketPosition = rocketTransform.position;
            var maxHalfLocalScaleX = rocketTransform.localScale.x *  -0.5f;
            
            var contactDeltaPositionX = rocketPosition.x - contactPosition.x;
            
            var angle = GetAngle(_gameConfigs.RocketMaxAngle, contactDeltaPositionX, maxHalfLocalScaleX);
            var ballVelocity = new Vector2(angle, 1);
            
            // _ballHandler.SetVelocity(ballVelocity);
            Demo();
        }

        private void Demo()
        {
            float randomAngle = Random.Range(20f, 160f);

            var velocity = Quaternion.Euler(0, 0, randomAngle) * Vector2.right * _gameConfigs.BallStartSpeed;

            _ballHandler.SetVelocity(velocity);
        }

        private float GetAngle(float maxAngleSize, float contactDeltaPositionX, float rocketSize)
        {
            // linear interpolation formula: y = y1 + (x−x1) ∗ ((y2-y1) / (x2-x1))
            
            var angle = maxAngleSize + (contactDeltaPositionX - rocketSize) *
                ((MiddleAnglePoint - maxAngleSize) / (MiddleAnglePoint - rocketSize));

            return angle;
        }
    }
}