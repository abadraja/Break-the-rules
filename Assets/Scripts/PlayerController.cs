using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float moveVelocity;
    public float JumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private bool _rightButtonIsPressed;
    private bool _leftButtonIsPressed;
    private bool _jumpButtonIsPressed;
    private bool _shootButtonIsPressed;

    public float fireRate = 0.2F;
    private float nextFire = 0.0F;

    private bool canDoubleJump;

    private Animator animator;

    public Transform firePoint;
    public GameObject bullet;

	void Start ()
    {
        _rightButtonIsPressed = false;
        _leftButtonIsPressed = false;

        animator = GetComponent<Animator>();
        canDoubleJump = false;
        groundCheckRadius = 0.1f;
        moveSpeed = 5f;
        JumpHeight = 22f;
        GetComponent<Rigidbody2D>().gravityScale = 3.5f; // Gravity power
	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    public void Jump()
    {
        
        if (grounded)
            canDoubleJump = false;
        if (grounded)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
        }
        if (!canDoubleJump && !grounded)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
            canDoubleJump = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        animator.SetBool("isGrounded", grounded);
        moveVelocity = 0f; // to stop the continious movement of the player
        if (_rightButtonIsPressed || Input.GetKey(KeyCode.D))
        { moveVelocity = moveSpeed; }
        if (_leftButtonIsPressed || Input.GetKey(KeyCode.A))
        { moveVelocity = -moveSpeed; }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        if (Time.time > nextFire && (_shootButtonIsPressed || Input.GetKeyDown(KeyCode.Return)))
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        } 
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "LastPlatform")
            transform.parent = other.transform;
    }

    public void ShootDown()
    { _shootButtonIsPressed= true; }

    public void ShootUp()
    { _shootButtonIsPressed = false; }

    public void GoLeftDown()
    { _leftButtonIsPressed = true; }

    public void GoRightDown()
    { _rightButtonIsPressed = true; }

    public void GoLeftUp()
    { _leftButtonIsPressed = false; }

    public void GoRightUp()
    { _rightButtonIsPressed = false; }
}
