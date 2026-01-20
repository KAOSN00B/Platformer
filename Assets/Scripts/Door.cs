using UnityEngine;

public class Door : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Door touched by: " + collision.name);

        if (collision.CompareTag("Player"))
        {
            Debug.Log("It *is* the Player");

            Player player = collision.GetComponent<Player>();

            if (player == null)
            {
                Debug.Log("No Player component found!");
                return;
            }

            if (player.UseKey())
            {
                Debug.Log("Key used, opening door");
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Player has NO keys");
            }
        }
    }

}
