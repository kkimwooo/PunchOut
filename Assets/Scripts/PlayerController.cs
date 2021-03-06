﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb2D { get; set; }
    public Vector3 moveVector { get; set; }
    public float moveSpeed;

    public Joystick joystick;

    public static float startFadeTime = 2.0f;

    void Awake()
    {
        System.GC.Collect();

        rb2D = GetComponent<Rigidbody2D>();
        moveVector = new Vector3(0, 0, 0);
    }

    void Start()
    {
        zFoxFadeFilter.instance.FadeIn(Color.black, startFadeTime);
        startFadeTime = 2.0f;
    }

    void Update()
    {
        HandleInput();
    }

    //모든기기에 동일한 타이밍으로 주기적으로 발생하는 함수 
    void FixedUpdate()
    {
        Move();
        EaseVelocity();
    }

    void HandleInput()
    {
        moveVector = PoolInput();

        if (Application.platform == RuntimePlatform.Android)    //Android Platform
        {
            if (Input.GetKey(KeyCode.Home))
            {
                //Home Button
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                //Back Button
            }
            else if (Input.GetKey(KeyCode.Menu))
            {
                //Menu Button
            }
        }
        else                                                    //Other Platform
        {

        }
    }

    void Move()
    {
        rb2D.AddForce(moveVector * moveSpeed);
        //Debug.Log("velocity x: " + rb2D.velocity.x + " y: " + rb2D.velocity.y);
    }

    void EaseVelocity()
    {
        Vector3 easeVelocity = rb2D.velocity;
        easeVelocity.x *= 0.75f;
        easeVelocity.y *= 0.75f;
        easeVelocity.z = 0.0f;
        rb2D.velocity = easeVelocity;
    }

    Vector3 PoolInput()
    {
        Vector3 direction = Vector3.zero;

        direction.x = joystick.GetHorizontalValue();
        direction.y = joystick.GetVerticalValue();

        if (direction.magnitude > 1)
            direction.Normalize();

        return direction;
    }

    public void Kill()
    {

    }
}
