using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
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

    //Gun
    [SerializeField] SO_Weapon _currentWeapon;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float gunRange;
    int enemyLayerMask;

    
    

    private void Awake()
    {
        enemyLayerMask = 1 << LayerMask.NameToLayer("Enemy");
        playerRigidbody = GetComponent<Rigidbody>();
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
        Debug.Log("Attack");
        RaycastHit hit = GunRaycast.SendRaycast(bulletSpawnPoint, _currentWeapon.range, enemyLayerMask);

        if (hit.collider != null )
        {
            GunRaycast.SetLineRenderer(bulletSpawnPoint.position, hit.point);
            StartCoroutine(GunRaycast.Laser());
            //Debug.DrawLine(bulletSpawnPoint.position, hit.point, Color.green);
        }
    }
}
