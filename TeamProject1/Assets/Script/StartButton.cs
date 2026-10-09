using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void StartClick()// press button to load the game scene
    {
        SceneManager.LoadScene("GameScenes");

    }

    public void BackToTitle()// press button to get back to title when end
    {
        SceneManager.LoadScene("StartMenu");

    }

    public void Restart()//load ganmescene
    {
        SceneManager.LoadScene("GameScenes");
    }



}
