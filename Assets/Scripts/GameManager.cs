using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform player1;
    public Transform player2;

    private Vector2 respawnPoint;

    private void Awake()
    {
        Instance = this;
        respawnPoint = player1.position; 
    }

    public void SetCheckpoint(Vector2 newPoint)
    {
        respawnPoint = newPoint;
        Debug.Log("Checkpoint reached");
    }

    public void RespawnPlayers()
    {
        player1.position = respawnPoint + Vector2.left;
        player2.position = respawnPoint + Vector2.left;

    }
}
