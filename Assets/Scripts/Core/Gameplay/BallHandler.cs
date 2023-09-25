using Core.Configs;
using UnityEngine;

namespace Core.Gameplay
{
    public class BallHandler : IBallHandler
    {
        private readonly GameConfigs _gameConfigs;
        private readonly IBall _ball;
        
        public BallHandler(GameConfigs gameConfigs, IBall ball)
        {
            _gameConfigs = gameConfigs;
            _ball = ball;
        }
        
        public void StartVelocity()
        {
            var randomDirection = GetRandomDirection();

            SetVelocity(randomDirection * _gameConfigs.BallStartSpeed);
        }
        

        public void SetVelocity(Vector2 velocityDirection)
        {
            _ball.SetVelocity(velocityDirection);
        }

        private Vector2 GetRandomDirection()
        {
            var randomX = Random.Range(-2f, 2f);
            var randomY = Random.Range(-2f, 2f);
            
            return new Vector2(randomX, randomY);
        }
    }
}