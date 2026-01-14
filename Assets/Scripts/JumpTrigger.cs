using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    [SerializeField] private Player player;

    private bool canJump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            player.ProcessLandAnimation();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       if(collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;
            
        }
    }

    public bool CanJump()
    {
        return canJump;
    }

    
}
