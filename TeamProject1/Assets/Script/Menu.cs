using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject PauseMenu;
    public GameObject ExitConfirmation;

    private bool isPaused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ExitConfirmation.activeSelf)
            {
                ExitConfirmation.SetActive(false);
            }
            else if (isPaused)
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
        isPaused = true;
        PauseMenu.SetActive(true);//show pause menu
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        isPaused = false;
        PauseMenu.SetActive(false);//close the panle
        ExitConfirmation.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ShowExitConfirmation()
    {
        ExitConfirmation.SetActive(true);
    }

    public void CancelExit()
    {
        ExitConfirmation.SetActive(false);
    }

    public void ExitGame()
    {

        SceneManager.LoadScene("StartMenu");//back to start menu
        Time.timeScale = 1f;
    }
}
