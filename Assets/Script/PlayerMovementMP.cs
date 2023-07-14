using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerMovementMP : MonoBehaviour
{
    private Animator animator;

    private CharacterController _controller;
    PhotonView view;

    [SerializeField]
    public float _playerSpeed = 5f;

    [SerializeField]
    private float _rotationSpeed = 10f;

    private Vector3 _playerVelocity;
    private bool _groundedPlayer;

    [SerializeField]
    private float _gravityValue = -9.81f;

    [SerializeField]
    private float _jumpSpeed = 3.5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        view = GetComponent<PhotonView>();
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(view.IsMine)
        {
            _groundedPlayer = _controller.isGrounded;
            if (_groundedPlayer && _playerVelocity.y < 0)
            {
                _playerVelocity.y = 0f;
            }

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movementInput = new Vector3(-verticalInput, 0, horizontalInput);
            Vector3 movementDirection = movementInput.normalized;

            _controller.Move(movementDirection * _playerSpeed * Time.deltaTime);

            if (movementDirection != Vector3.zero)
            {
                animator.SetBool("IsMoving", true);
                Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, _rotationSpeed * Time.deltaTime);
            }
            else
            {
                animator.SetBool("IsMoving", false);
            }

            if (Input.GetMouseButtonDown(1))
            {
                animator.SetBool("IsJumping", true);
                _playerVelocity.y = _jumpSpeed;
            }
            else
            {
                animator.SetBool("IsJumping", false);
            }
            _playerVelocity.y += _gravityValue * Time.deltaTime;
            _controller.Move(_playerVelocity * Time.deltaTime);
        }
        
    }

}