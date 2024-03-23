using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //��������� ���������� �������
    public float gravity = 9.8f;
    private float _fallVelocity = 0;
    //��������� ������
    public float JumpForce;
    public float Speed;

    public Animator animator;

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
        //�������� ��������� CharacterController
        _characterController = GetComponent<CharacterController>();
    }

    //��� ��������� ������� ������
    private void Update()
    {
        

        if (isOnGround)
            Debug.Log("We are grounded");

        //������������
        _moveVector =Vector3.zero;
        var runDirection = 0;


        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward; //1
            runDirection = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right; //4
            runDirection = 4;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward; //2
            runDirection = 2;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right; //3
            runDirection = 3;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

        //������
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            _fallVelocity = -JumpForce;
        }

        animator.SetInteger("RunDirection", runDirection);
    }

    //��� ��������� ������
    void FixedUpdate()
    {
        //�������
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        _characterController.Move(_moveVector * Speed * Time.fixedDeltaTime);

        if (isOnGround)
        {
            _fallVelocity = 0;
        }

    }
}
