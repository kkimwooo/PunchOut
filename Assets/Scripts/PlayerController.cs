using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb2D { get; set; }
    public Vector3 moveVector { get; set; }
    public float moveSpeed;
    public Joystick joystick;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        moveVector = new Vector3(0, 0, 0);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        moveVector = PoolInput();
        Debug.Log("velocity x: " + rb2D.velocity.x + " y: " + rb2D.velocity.y);
	}

    //모든기기에 동일한 타이밍으로 주기적으로 발생하는 함수 
    void FixedUpdate()
    {
        Move();
        EaseVelocity();
    }

    void Move()
    {
        rb2D.AddForce(moveVector * moveSpeed);
    }

    void EaseVelocity()
    {
        Vector3 easeVelocity = rb2D.velocity;
        easeVelocity.x *= 0.75f;
        easeVelocity.y *= 0.75f;
        //easeVelocity.z = 0.0f;
        rb2D.velocity = easeVelocity;
    }

    Vector3 PoolInput()
    {
        Vector3 dir = Vector3.zero;

        dir.x = joystick.Horizontal();
        dir.y = joystick.Vertical();

        if (dir.magnitude > 1)
            dir.Normalize();

        return dir;
    }
}
