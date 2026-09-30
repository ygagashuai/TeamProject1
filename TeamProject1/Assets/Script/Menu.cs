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
        if (Input.GetKeyDown(KeyCode.Escape))// press esc to show the pause menu
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

    public void PauseGame()// press to show the pause menu
    {
        isPaused = true;
        PauseMenu.SetActive(true);//show pause menu
        Time.timeScale = 0f;// freeze the game
    }
    public void ResumeGame()//get back to game
    {
        isPaused = false;
        PauseMenu.SetActive(false);//close the menu or menu
        ExitConfirmation.SetActive(false);// does't show exit confirmation page
        Time.timeScale = 1f;// stop pause
    }
    public void ShowExitConfirmation()
    {
        ExitConfirmation.SetActive(true);// show the exit confirmation page
    }

    public void CancelExit()
    {
        ExitConfirmation.SetActive(false);// close exit confirmation page
    }

    public void ExitGame()
    {

        SceneManager.LoadScene("StartMenu");//back to start menu
        Time.timeScale = 1f;
    }
}
