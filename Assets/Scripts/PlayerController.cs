using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //параметры свободного падения
    public float gravity = 9.8f;
    private float _fallVelocity = 0;
    //параметры игрока
    public float JumpForce;
    public float Speed;

    private CharacterController _characterController;
    private Vector3 _moveVector;
    [SerializeField] float groundCheckDistance = 5f;
    private bool isOnGround
    {
        get
        {
            return Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, groundCheckDistance);
        }
    }
    void Start()
    {
        //получаем компонент CharacterController
        _characterController = GetComponent<CharacterController>();
    }

    //для обработки нажатия клавиш
    private void Update()
    {
        
        if (isOnGround)
            Debug.Log("We are grounded");

        

        //передвижение
        _moveVector =Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }

        //Прыжок
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            _fallVelocity = -JumpForce;
        }

    }

    //для обработки физики
    void FixedUpdate()
    {
        //Падение
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        _characterController.Move(_moveVector * Speed * Time.fixedDeltaTime);

        if (isOnGround)
        {
            _fallVelocity = 0;
        }

    }
}
