using UnityEngine;

namespace Infastructure
{
    public class GameSettings : MonoBehaviour
    {
        [SerializeField] private int _targetFrameRate;
        
        private void Awake()
        {
            Application.targetFrameRate = _targetFrameRate;
        }
    }
}