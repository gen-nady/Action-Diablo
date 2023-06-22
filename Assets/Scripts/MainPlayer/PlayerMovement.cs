using UnityEngine;

namespace MainPlayer
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Moving")]
        [SerializeField] private FloatingJoystick _joystick;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _transform;
        [SerializeField] private float _speed;
        [Header("Moving animation")]
        [SerializeField] private Animator _animator;
        private readonly int _speedPlayerHash = Animator.StringToHash("Speed");
        
        private InputController _inputController;

        #region MONO
        private void Awake()
        {
            _inputController = new InputController(_joystick);
        }

        private void Update()
        {
            Move();
            AnimationMove();
        }
        #endregion
        
        private void Move()
        {
            if (_inputController.GetAxis() != Vector3.zero)
            {
                var angle = Mathf.Atan2(_inputController.GetAxis().x, _inputController.GetAxis().z) * Mathf.Rad2Deg;
                _transform.rotation = Quaternion.Euler(0, angle, 0);
                _characterController.Move(_inputController.GetAxis() * _speed * Time.deltaTime);
            }
        }

        private void AnimationMove()
        {
            _animator.SetFloat(_speedPlayerHash, Mathf.Max(Mathf.Abs(_inputController.GetAxis().x),Mathf.Abs(_inputController.GetAxis().z)));
        }
    }
}