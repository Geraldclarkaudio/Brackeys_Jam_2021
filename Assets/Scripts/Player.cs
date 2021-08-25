using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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

    [Header("Camera Settings")]
    [SerializeField]
    private float _cameraSensitivity = 2.0f;
    private Camera mainCam;

    [Header("UI Settings")]
    [SerializeField]
    private int gold;
    private UIManager _uiManager;

    [Header("Stats")]
    [SerializeField]
    private int health;

    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;

        if (mainCam == null)
        {
            Debug.LogError("main cam is null");
        }

        _controller = GetComponent<CharacterController>();

        if (_controller == null)
        {
            Debug.LogError("Character Controller is Null");
        }

        _uiManager = GameObject.Find("UI_Manager").GetComponent<UIManager>();

        if (_uiManager == null)
        {
            Debug.LogError("UI Manager is Null");
        }

        _anim = GetComponentInChildren<Animator>();
       
        health = 5;
       
        //lock cursor and hide it
        //escape key to unlock and reshow
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _uiManager.UpateLivesDisplay(health);
        CalculateMovement();
        CameraRotation();
        Attack();

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
            float vertical = Input.GetAxis("Vertical");

             direction = new Vector3(0, 0, vertical);
             velocity = direction * _speed;
            _anim.SetFloat("Move", vertical);

            //CONVERT TO WORLD SPACE
            velocity = transform.TransformDirection(velocity);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y += _jumpHeight;
                _anim.SetBool("Jumping", true);
            }
        }

        velocity.y -= _gravity * Time.deltaTime;

        _controller.Move(velocity * Time.deltaTime);
        
    }

    void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");


        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.y += mouseX * _cameraSensitivity;
        transform.localRotation = Quaternion.AngleAxis(currentRotation.y, Vector3.up);



        //apply mousey to camera roation x (look Up and Down)
        //clamp between 0 and 15
        Vector3 currentCamRot = mainCam.gameObject.transform.localEulerAngles;
        currentCamRot.x -= mouseY * _cameraSensitivity;
        currentCamRot.x = Mathf.Clamp(currentCamRot.x, 0, 26);
        mainCam.gameObject.transform.localRotation = Quaternion.AngleAxis(currentCamRot.x, Vector3.right);
    }

    public void AddCoins()
    {
        gold++;
        _uiManager.UpdateGoldDisplay(gold);

    }

    public void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _anim.SetTrigger("Attack");
        }
        
    }

    public void Damage()
    {
        health--;
        _uiManager.UpateLivesDisplay(health);
    }
}
