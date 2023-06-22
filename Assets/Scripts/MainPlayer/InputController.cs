using UnityEngine;

public class InputController
{
    private readonly FloatingJoystick _joystick;
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    public InputController(FloatingJoystick joystick)
    {
        _joystick = joystick;
    }
    
    public Vector3 GetAxis()
    {
        return _joystick.Direction == Vector2.zero 
            ? new Vector3(Input.GetAxis(HORIZONTAL), 0f, Input.GetAxis(VERTICAL)) 
            : new Vector3(_joystick.Direction.x, 0f, _joystick.Direction.y);
    }
}
