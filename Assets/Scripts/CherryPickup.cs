using UnityEngine;

public class CherryPickup : MonoBehaviour
{
    [SerializeField] private Player player2;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2"))
        {
            Player p1 = GameObject.FindGameObjectWithTag("Player")
                                   .GetComponent<Player>();

            player2.IncrementKeyCount();
            p1.IncrementKeyCount();
            Destroy(this.gameObject);
        }
    }
    
}
