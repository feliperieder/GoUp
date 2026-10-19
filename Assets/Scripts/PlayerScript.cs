using TMPro;
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
    [SerializeField] private TextMeshProUGUI doubleJumpText;

    //Colisão do chão
    private Vector2 groundCheckSize = new Vector2(0.75f, 0.1f);
    private float castDistance = 0.1f;

    //Coyote Jump -- Periodo de tempo que o jogador pode pular mesmo não estando no chão
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    //Jump Buffer -- Periodo de tempo que o jogador pode apertar o botão de pulo antes de tocar o chão
    private float jumpBufferTime = 0.1f;
    private float jumpBufferCounter;

    PlayerDoubleJump playerDoubleJump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerDoubleJump = new PlayerDoubleJump(0); // Initialize with 0 extra jumps
        doubleJumpText.text = "Pulo Duplo: " + playerDoubleJump.ExtraJumps + "/" + playerDoubleJump.maxExtraJumps; // Update the UI

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

        if (Input.GetButtonDown("Jump") && coyoteTimeCounter <= 0f && jumpBufferCounter > 0f && playerDoubleJump.ExtraJumps > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            coyoteTimeCounter = 0f; // Reset coyote time counter when jump is released
            playerDoubleJump.RemoveExtraJump(1); // Use one extra jump
            doubleJumpText.text = "Pulo Duplo: " + playerDoubleJump.ExtraJumps + "/" + playerDoubleJump.maxExtraJumps; // Update the UI
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

    public void AddDoubleJump()
    {
        playerDoubleJump.AddExtraJump(1); // Add one extra jump
        doubleJumpText.text = "Pulo Duplo: " + playerDoubleJump.ExtraJumps + "/" + playerDoubleJump.maxExtraJumps; // Update the UI
    }
}
