using UnityEngine;
using System.Collections;

public class test_easytouch_01 : MonoBehaviour 
{

    void Start()
    {
        EasyJoystick.On_JoystickMoveStart += OnJoystickMoveStart;
        EasyJoystick.On_JoystickMove += OnJoystickMove;
        EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;
    }

    void OnJoystickMoveStart(MovingJoystick value)
    {
        Debug.Log("OnJoystickMoveStart");
    }

    void OnJoystickMove(MovingJoystick value)
    {

        Debug.Log("OnJoystickMove");
    }

    void OnJoystickMoveEnd(MovingJoystick value)
    {
        Debug.Log("OnJoystickMoveEnd");
    }
}
