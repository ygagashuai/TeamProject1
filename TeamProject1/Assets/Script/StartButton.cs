using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject dog;

    private void Start()
    {
        
    }

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


    public void NextLevel()//move to second level
    {
        SceneManager.LoadScene("Level 2");
    }



}
