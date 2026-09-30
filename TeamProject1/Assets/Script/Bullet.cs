using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float LifeTime = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, LifeTime);//after 2 second destory the bullet
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)// kill  enemy when bullet hit enemy and destory bullet when hit
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
