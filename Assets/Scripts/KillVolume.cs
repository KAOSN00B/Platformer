using UnityEngine;
using System.Collections;

public class KillVolume : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (other.CompareTag("Player") || other.CompareTag("Player2"))
        {
            triggered = true;
            StartCoroutine(RespawnAfterDelay(1.0f)); 
        }
    }
    private IEnumerator RespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameManager.Instance.RespawnPlayers();
        triggered = false;
    }

}
