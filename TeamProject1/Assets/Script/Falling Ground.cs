using UnityEngine;

public class FallingGround : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public SpriteRenderer sr;
    public GameObject currentPlatform;
    void Start()
    {
        currentPlatform = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroyPlatform()
    {
        Destroy(currentPlatform);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sr.color = Color.darkGreen;
            Invoke("DestroyPlatform", 2f);
        }
    }

}
