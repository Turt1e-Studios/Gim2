using UnityEngine;
using UnityEngine.SceneManagement;

// Controls UI and button function of the Game Over screen

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;

    public void Setup()
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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Setup();
    }
}
