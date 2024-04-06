using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTouch : MonoBehaviour
{
    public string playerTag = "Player";
    public string targetSceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            ChangeToTargetScene();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(playerTag))
        {
            ChangeToTargetScene();
        }
    }

    private void ChangeToTargetScene()
    {
        SceneManager.LoadScene(targetSceneName); //Change to Death Screen 
    }
}