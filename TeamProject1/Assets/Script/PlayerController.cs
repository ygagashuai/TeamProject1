using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody2D rb;

    public float dirx = 0f;

    public float speed = 5f;

    public float jumpH = 5f;
    bool jump;

    public float DoubleJump = 2f;

    public float DashDis = 15f;

    public float CoolDownDash = 3f;

    bool dashing = false;

    [SerializeField] private Text HealthText;

    public float Health = 5f;

    [SerializeField] private Text DashText;

    public float Dash = 0f;

    public float ShootAbility = 0f;

    [SerializeField] private Text AbilityText;

    public float ShootTime = 0f;

    public float StartCount = 0f;

    public GameObject BulletPrefab;

    public Transform FirePoint;

    public float BulletSpeed = 10f;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = true;
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = "Health : " + Health;
        DashText.text = "Dash : " + Dash;
        // player movement in horizontral
        dirx = Input.GetAxisRaw("Horizontal");
        if (!dashing)
        {
            rb.linearVelocity = new Vector2(dirx * speed, rb.linearVelocity.y);
        }

        //jump 
        if (Input.GetButtonDown("Jump") && jump == true && DoubleJump >= 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpH);
            DoubleJump -= 1;
            if (DoubleJump == 0)
            {
                jump = false;

            }
            
        }

        CoolDownDash += Time.deltaTime;
        if(CoolDownDash >= 3)
        {
            Dash = 1;
        }
        if (Input.GetKeyDown(KeyCode.K) && CoolDownDash >= 3)
        {
            dashing = true;

            if (dirx >= 0)
            {
                rb.linearVelocity = new Vector2(DashDis, 0);//dash right
            }
            else if (dirx < 0)
            {
                rb.linearVelocity = new Vector2(-DashDis, 0);//dash left
            }


            CoolDownDash = 0;
            Dash = 0;
            Invoke("StopDash", 0.2f);
        }

        if (Input.GetKeyDown(KeyCode.J) && ShootAbility >= 1)
        {

            Shoot();
            StartCount = 1f;

            

        }
        if (StartCount == 1)
        {
            ShootTime += Time.deltaTime;
            if (ShootTime >= 5)
            {
                StartCount = 0;
                ShootAbility -= 1f;
                ShootTime = 0;

            }
        }


    }
    void StopDash()
    {
        dashing = false;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.linearVelocity = FirePoint.right * BulletSpeed;
        
    }
    //player only can jump after touch ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && DoubleJump >= 0)
        {

            jump = true;
            DoubleJump = 2;
        }
        //Decrease health when hit by the enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {

            
            if (rb.linearVelocity.y <= 0)
            {
                // Destroy the enemy
                Destroy(collision.gameObject);
            }
            else
            {
                Health -= 1;
            }

        }
        //load end scenes when touch end point
        if (collision.gameObject.CompareTag("End Point"))
        {

            SceneManager.LoadScene("EndScenes");

        }

        if (collision.gameObject.CompareTag("ShootAbility"))
        {

            ShootAbility += 1;
            
        }
    }


}
