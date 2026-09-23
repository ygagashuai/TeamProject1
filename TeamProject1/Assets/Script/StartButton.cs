using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void OnMyButtonClick()
    {
        SceneManager.LoadScene("GameScenes");

    }


}
