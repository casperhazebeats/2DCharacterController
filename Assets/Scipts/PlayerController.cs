using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    public float maxSpeed = 10f;
    [SerializeField]
    private Rigidbody2D rigidbody2DInstance;
    [SerializeField]
    private float accelerationForce = 5;
    [SerializeField]
    private float jumpforce = 5;

    private float horizontalInput;
    private bool isFacingRight;
    private void UpdateIsOnGround()
    {

    }

    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        UpdateHorizontalInput();
        UpdateIsOnGround();
    }
    void FixedUpdate()
    {
        Move();
        
    }
    private void UpdateHorizontalInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(horizontalInput));
    }
	
    private void HandleJumpInput()
    {
     if(Input.GetButtonDown)("jump") && isOnGround)
        {
            rigidbody2DInstance.AddForce(Vector2.up * jumpforce, ForceMode2D.Force Impulse);
        }
    }
	// Update is called once per frame
	private void Move()
    {
        rigidbody2DInstance.AddForce(Vector2.right * horizontalInput * accelerationForce);
        Vector2 clampedVelocity = rigidbody2DInstance.velocity;
        clampedVelocity.x = Mathf.Clamp(rigidbody2DInstance.velocity.x, -maxSpeed, maxSpeed);
        rigidbody2DInstance.velocity = clampedVelocity;
        if (horizontalInput < 0 && !isFacingRight)
            Flip();
        else if (horizontalInput > 0 && isFacingRight)
            Flip();

	}

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
