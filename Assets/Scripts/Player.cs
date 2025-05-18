using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    
    private float inputAxis;
    private bool isGrounded;
    private int jumpCount;

    [Header("Movement")]
    public float moveSpeed = 8f;

    [Header("Jumping")]
    public float jumpForce = 15f;
    public int maxJumpCount = 1;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        jumpCount = maxJumpCount;
    }

    void Update()
    {
        inputAxis = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(inputAxis));
        animator.SetBool("Jump", !isGrounded && jumpCount == maxJumpCount);
        animator.SetBool("DoubleJump", !isGrounded && jumpCount < maxJumpCount);

        //플레이어가 이동하는 방향을 바라보도록 함
        if (inputAxis < 0 )
        {
            spriteRenderer.flipX = true;
        }
        else if ( inputAxis > 0  )
        {
            spriteRenderer.flipX = false;
        }


        if (Input.GetButtonDown("Jump"))
        {
            if ( isGrounded )
            {
                animator.SetTrigger("Jump");
                jumpCount = maxJumpCount;
                rigid.linearVelocity = new Vector2(rigid.linearVelocity.x, jumpForce);
            }
            else if ( jumpCount > 0 )
            {
                animator.SetTrigger("DoubleJump");
                jumpCount--;
                rigid.linearVelocity = new Vector2(rigid.linearVelocity.x, jumpForce);
            }
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle( groundCheck.position, groundCheckRadius, groundLayer );
        animator.SetBool("isGrounded", isGrounded);
        
        if (isGrounded)
            jumpCount = maxJumpCount;
        
        rigid.linearVelocity = new Vector2(inputAxis * moveSpeed, rigid.linearVelocity.y);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
