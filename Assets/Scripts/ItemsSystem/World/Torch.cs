using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ItemsSystem.World
{
    public class Torch : MonoBehaviour
    {
        [SerializeField] private Light _light;
        [SerializeField] private int _minValue = 10;
        [SerializeField] private int _maxValue = 20;
        private const float TIME_FOR_REPEAT = 0.2f;
        private float _currentTime;

        private void OnEnable()
        {
            _currentTime = TIME_FOR_REPEAT;
        }

        private void Update()
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime < 0)
            {
                _light.intensity = Random.Range(_minValue, _maxValue);
                _currentTime = TIME_FOR_REPEAT;
            }
        }
    }
}