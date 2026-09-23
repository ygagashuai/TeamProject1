using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectGold : MonoBehaviour

{
    public float Gold = 0f;

    [SerializeField] private Text GoldText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GoldText.text = "Gold : " + Gold;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Gold++;
            GoldText.text = "Gold : " + Gold;

        }
    }
}
