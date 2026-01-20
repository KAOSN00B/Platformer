using UnityEngine;
using UnityEngine.SceneManagement;

public class Winscreen : MonoBehaviour
{

    [SerializeField] private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Player2"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
