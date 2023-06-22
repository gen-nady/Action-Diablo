using UnityEngine;

namespace MainPlayer
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick _joystick;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _transform;
        [SerializeField] private Animator _animator;
        private readonly int _speedPlayer = Animator.StringToHash("Speed");
        [SerializeField] private float _speed;
        
        private InputController _inputController;
        
        private void Awake()
        {
            _inputController = new InputController(_joystick);
        }

        private void Update()
        {
            if (_inputController.GetAxis() != Vector3.zero)
            {
                var angle = Mathf.Atan2(_inputController.GetAxis().x, _inputController.GetAxis().z) * Mathf.Rad2Deg;
                _transform.rotation = Quaternion.Euler(0, angle, 0);
                _characterController.Move(_inputController.GetAxis() * _speed * Time.deltaTime);
            }
            _animator.SetFloat(_speedPlayer, Mathf.Max(Mathf.Abs(_inputController.GetAxis().x),Mathf.Abs(_inputController.GetAxis().z)));
        }
    }
}