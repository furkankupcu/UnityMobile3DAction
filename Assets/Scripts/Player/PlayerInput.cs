using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private FloatingJoystick floatingJoystick;

    private float _horizontal;
    private float _vertical;


    public float GetHorizontalInput()
    {
        return floatingJoystick.Horizontal;
    }

    public float GetVerticalInput()
    {
        return floatingJoystick.Vertical;
    }
} 
