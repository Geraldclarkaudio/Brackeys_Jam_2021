using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript: MonoBehaviour
{
    [Header("Controller Settings")]
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _jumpHeight = 8.0f;
    [SerializeField]
    private float _gravity = 15.0f;
    private CharacterController _controller;
    private float yVel;
    private Vector3 velocity;
    private Vector3 direction;

    [Header("UI Settings")]
    private UIManager _uiManager;


    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {

        _controller = GetComponent<CharacterController>();

        if (_controller == null)
        {
            Debug.LogError("Character Controller is Null");
        }

        _anim = GetComponentInChildren<Animator>();

        if (_anim == null)
        {
            Debug.LogError("Animator is Null");
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //_uiManager.UpateLivesDisplay(health);
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void CalculateMovement()
    {
        if (_controller.isGrounded == true)
        {
            _anim.SetBool("Jumping", false);
            float vertical = Input.GetAxisRaw("Vertical");

            direction = new Vector3(0, 0, vertical);
            velocity = direction * _speed;
            _anim.SetFloat("Move", Mathf.Abs(vertical));

            //CONVERT TO WORLD SPACE
            velocity = transform.TransformDirection(velocity);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y += _jumpHeight;
                _anim.SetBool("Jumping", true);
            }
        }

        velocity.y -= _gravity * Time.deltaTime;

    }

}
