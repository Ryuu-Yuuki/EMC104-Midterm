using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuCanvas; 
    private bool isGamePaused = false;
    private AudioManager audioManager;

    void Start()
    {
        pauseMenuCanvas.SetActive(false);

        audioManager = AudioManager.Instance;


        Time.timeScale = 1f;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isGamePaused = true;
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        isGamePaused = false;

        pauseMenuCanvas.SetActive(false);

        Time.timeScale = 1f;
    }

    public void LoadMainMenu(string sceneName)
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(sceneName);
    }
}