using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] AnimationController animationController;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform playerChildTransform;

    private Rigidbody playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        SetMovement();
        SetRotation();
    }

    private void SetMovement()
    {
        playerRigidbody.velocity = GetNewVelocity();
        //AnimationController.SetBoolean("Run", playerInput.GetHorizontalInput() != 0 || playerInput.GetVerticalInput() != 0);
    }

    private void SetRotation()
    {
        if(playerInput.GetHorizontalInput() !=0 || playerInput.GetVerticalInput() != 0)
        {
            playerChildTransform.rotation = Quaternion.LookRotation(GetNewVelocity());
            
        }
    }

    private Vector3 GetNewVelocity()
    {
        return new Vector3(playerInput.GetHorizontalInput(),playerRigidbody.velocity.y, playerInput.GetVerticalInput()) * _moveSpeed * Time.fixedDeltaTime;
    }
}
