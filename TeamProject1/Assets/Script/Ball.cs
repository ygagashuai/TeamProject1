using UnityEngine;

public class Ball : MonoBehaviour
{
    public float LifeTime = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float knockbackForce = 8f;
    void Start()
    {
        Destroy(gameObject, LifeTime);//after 2 second destory the bullet

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            float direction = collision.transform.position.x - transform.position.x;
            direction = Mathf.Sign(direction);

            player.Knockback(direction);
        }
        }
            
    }
}
