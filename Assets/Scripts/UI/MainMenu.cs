using UnityEngine;
using UnityEngine.SceneManagement;

// Button functionality in main menu ( + background music?) maybe should make that into another script

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;

    public void PlayGame()
    {
        // sets the setting of music volume when leaving the main menu
        PlayerPrefs.SetFloat("Volume", backgroundMusic.volume);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!!");
        Application.Quit();
    }
}
