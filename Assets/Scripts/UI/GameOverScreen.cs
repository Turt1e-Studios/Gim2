using UnityEngine;
using UnityEngine.SceneManagement;

// Controls UI and button function of the Game Over screen

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private AudioSource gameOverAudio;

    private bool isGameOver;

    private void Setup()
    {
        gameObject.SetActive(true);
        healthBar.SetActive(false);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void GameOver()
    {
        if (isGameOver)
        {
            return;
        }
        isGameOver = true;
        
        gameOverAudio.Play();
        GeneralUI.EnableCursor();
        Setup();
    }
}
