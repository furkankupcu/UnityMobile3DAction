using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [Inject]
    AudioManager audioManager;

    //[SerializeField] AnimationController animationController;
    [SerializeField] PlayerInput PlayerInput;
    [SerializeField] GunRaycast GunRaycast;

    //Input
    private Vector2 _inputVector;

    //Player
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    private Rigidbody playerRigidbody;

    [SerializeField] private Transform playerChildTransform;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        audioManager.PlayZenAudio();
    }

    private void FixedUpdate()
    {
        SetMovement();
        SetRotation();
    }

    private void Update()
    {
        _inputVector = InputHandler();
        Attack();
    }

    private void SetMovement()
    {
        playerRigidbody.velocity = GetNewVelocity();
        //AnimationController.SetBoolean("Run", playerInput.GetHorizontalInput() != 0 || playerInput.GetVerticalInput() != 0);
    }

    private void SetRotation()
    {
        float targetAngle = Mathf.Atan2(_inputVector.x, _inputVector.y) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);

        playerChildTransform.rotation = Quaternion.Slerp(playerChildTransform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
    
    private Vector3 GetNewVelocity()
    {
        return new Vector3(_inputVector.x, playerRigidbody.velocity.y, _inputVector.y) * _moveSpeed * Time.fixedDeltaTime;
    }

    private Vector2 InputHandler()
    {
        return new Vector2(PlayerInput.GetHorizontalInput(), PlayerInput.GetVerticalInput());
    }

    private void Attack()
    {
        RaycastHit hit = GunRaycast.SendRaycast();

        if (hit.collider != null )
        {
            GunRaycast.SetLineRenderer(hit.point);
            StartCoroutine(GunRaycast.Laser());
        }
    }


}
