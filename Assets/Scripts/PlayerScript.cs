using UnityEngine;
using UnityEngine.Rendering;

public class PlayerScript : MonoBehaviour
{
    private float horizontal;
    private float speed = 4f;
    private float jumpForce = 12f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    //Colisão do chão
    private Vector2 groundCheckSize = new Vector2(0.75f, 0.1f);
    private float castDistance = 0.1f;

    //Coyote Jump -- Periodo de tempo que o jogador pode pular mesmo não estando no chão
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    //Jump Buffer -- Periodo de tempo que o jogador pode apertar o botão de pulo antes de tocar o chão
    private float jumpBufferTime = 0.1f;
    private float jumpBufferCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");


        //Jumping
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            jumpBufferCounter = 0f; // Reset jump buffer counter after jumping
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            coyoteTimeCounter = 0f; // Reset coyote time counter when jump is released
        }
    }
    
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(groundCheck.position, groundCheckSize, 0f, Vector2.down, castDistance, groundLayer);
    }

    public void ApplyUpgrades(float newSpeed, float newJumpForce, float newCoyoteTime)
    {
        speed = newSpeed;
        jumpForce = newJumpForce;
        coyoteTime = newCoyoteTime;
    }
}
