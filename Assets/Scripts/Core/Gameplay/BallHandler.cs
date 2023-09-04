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
        
        public void StartImpulse()
        {
            var randomDirection = GetRandomDirection();
            
            _ball.AddForce(randomDirection * 200);
        }

        private Vector2 GetRandomDirection()
        {
            return Vector2.up;
        }
    }
}