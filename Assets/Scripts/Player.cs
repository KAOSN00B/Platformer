using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 600;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private JumpTrigger jumpTrigger;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TMP_Text scoreText;

    private float horizontalMovement;
    private int keyCount = 0;

    private bool jumpKeyPressed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //Based on frames per second
    {

        if (CompareTag("Player"))
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal1") * moveSpeed * Time.deltaTime;
            animator.SetFloat("PlayerSpeed", Mathf.Abs(horizontalMovement));
        }

        else if (CompareTag("Player2"))
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal2") * moveSpeed * Time.deltaTime;
            animator.SetFloat("PlayerSpeed", Mathf.Abs(horizontalMovement));
        }


        if (horizontalMovement < 0)
        {
            spriteRenderer.flipX = true;
        }

        else if (horizontalMovement > 0)
        {
            spriteRenderer.flipX = false;
        }

        if (CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && jumpTrigger.CanJump())
        {
            jumpKeyPressed = true;
        }

        if (CompareTag("Player2") && Input.GetKeyDown(KeyCode.J) && jumpTrigger.CanJump())
        {
            jumpKeyPressed = true;
        }

        Collider2D p1 = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        Collider2D p2 = GameObject.FindWithTag("Player2").GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(p1, p2);



    }

    private void FixedUpdate() //Based for time internals
    {
        rb.linearVelocityX = horizontalMovement;

        // rb.AddForce(new Vector2(Mathf.Clamp(horizontalMovement, -moveSpeed, moveSpeed), 0));

        if (jumpKeyPressed == true && CompareTag("Player2"))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpKeyPressed = false;
            animator.SetTrigger("PlayerJumped");
        }

        if (jumpKeyPressed == true && CompareTag("Player"))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpKeyPressed = false;
            animator.SetTrigger("BearJumped");
        }
    }

    public void ProcessLandAnimation()
    {
        if (CompareTag("Player2"))
        {
            animator.Play("PlayerIdle");
        }

        if (CompareTag("Player"))
        {
            animator.Play("BearIdle");
        }
        
    }

    public void IncrementKeyCount()
    {
        keyCount++;  
        scoreText.text = "Keys: " + keyCount.ToString();
    }

    public void DecreaseKeyCount()
    {
        if (keyCount < 0)
            keyCount = 0;

        scoreText.text = "Keys: " + keyCount.ToString();
    }


    public bool UseKey()
    {
        if (keyCount < 1)
            return false;

        keyCount--;
        return true;
    }


    public void Death()
    {
        Destroy(this.gameObject);
    }
}
