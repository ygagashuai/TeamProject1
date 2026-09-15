using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody2D rb;

    public float dirx = 0f;

    public float speed = 5f;

    public float jumpH = 5f;
    bool jump;


    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = true;
    }

    // Update is called once per frame
    void Update()
    {
        // player movement in horizontral
        dirx = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(dirx * speed, rb.linearVelocity.y);

        //jump 
        if (Input.GetButtonDown("Jump") && jump == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpH);
            jump = false;
        }


    }
    //player only can jump after touch ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jump = true;
        }
    }

}
