using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystickPlayer : MonoBehaviour
{
    private const string _isRun = "IsRun";

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystickPortrait;
    [SerializeField] private FixedJoystick _joystickLandscape;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _speed;

    private bool _isRunning = false;

    private void Update()
    {
        //if (MovementPlayer.Instance.MovmentSpeed == 0 && _isRunning == true)
        //{
        //    _animator.SetBool(_isRun, false);
        //    _isRunning = false;
        //}

        //if (MovementPlayer.Instance.MovmentSpeed > 0 && _isRunning == false)
        //{
        //    _animator.SetBool(_isRun, true);
        //    _isRunning = true;
        //}
    }

    private void FixedUpdate()
    {
        if (Screen.width < Screen.height)
        {
            MovePlayer(_joystickPortrait);
        }
        else
        {
            MovePlayer(_joystickLandscape);
        }
    }

    private void MovePlayer(FixedJoystick joystick)
    {
        _rigidbody.velocity = new Vector3(joystick.Horizontal * _speed, _rigidbody.velocity.y, joystick.Vertical * _speed);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0 && _isRunning == false)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            _animator.SetBool(_isRun, true);
            _isRunning = true;
        }
        else
        {
            _animator.SetBool(_isRun, false);
            _isRunning = false;
        }
    }
}
