using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 600;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private JumpTrigger jumpTrigger;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private float horizontalMovement;

    private bool jumpKeyPressed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //Based on frames per second
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        animator.SetFloat("PlayerSpeed", Mathf.Abs(horizontalMovement));

        if (horizontalMovement < 0)
        {
            spriteRenderer.flipX = true;
        }

        else if (horizontalMovement > 0)
        {
            spriteRenderer.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpTrigger.CanJump())
        {
            jumpKeyPressed = true;
        }

    }

    private void FixedUpdate() //Based for time internals
    {
        rb.linearVelocityX = horizontalMovement;

        // rb.AddForce(new Vector2(Mathf.Clamp(horizontalMovement, -moveSpeed, moveSpeed), 0));

        if (jumpKeyPressed == true)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpKeyPressed = false;
            animator.SetTrigger("PlayerJumped");
        }
    }

    public void ProcessLandAnimation()
    {
        
        animator.Play("PlayerIdle");
    }
}
