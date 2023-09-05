using UnityEngine;

namespace Core.Configs
{
    [CreateAssetMenu(fileName = "GameConfigs", menuName = "Configs/GameConfigs", order = 0)]
    public class GameConfigs : ScriptableObject
    {
        [SerializeField] private float _ballStartSpeed;
        [SerializeField] private float _maxRocketSize;
        [SerializeField] private float _boosterRocketDeltaSize;
        [SerializeField] private PlayerConfigs _playerConfigs;

        public PlayerConfigs PlayerConfigs => _playerConfigs;
    }
}