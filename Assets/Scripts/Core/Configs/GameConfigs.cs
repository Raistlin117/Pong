using UnityEngine;
using UnityEngine.Serialization;

namespace Core.Configs
{
    [CreateAssetMenu(fileName = "GameConfigs", menuName = "Configs/GameConfigs", order = 0)]
    public class GameConfigs : ScriptableObject
    {
        [Header("Game Configs")]
        [SerializeField] private float _ballStartSpeed = 10f;
        [SerializeField] private float _rocketMaxSize = 2.6f;
        [SerializeField] private float _rocketSpeed = 4f;
        [SerializeField] private float _boosterRocketDeltaSize = 0.2f;
        [Range(1, 3)]
        [SerializeField] private float _rocketMaxAngle = 2;
        [Header("Player Configs")]
        [SerializeField] private PlayerConfigs _playerConfigs;

        public PlayerConfigs PlayerConfigs => _playerConfigs;
        public float BallStartSpeed => _ballStartSpeed;
        public float RocketMaxSize => _rocketMaxSize;
        public float RocketSpeed => _rocketSpeed;
        public float BoosterRocketDeltaSize => _boosterRocketDeltaSize;

        public float RocketMaxAngle => _rocketMaxAngle;
    }
}